import random
import csv
from datetime import datetime, timedelta, time

def get_customers():
    customers = []
    try:
        with open('customers_data.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                customers.append({
                    'CustomerID': row['CustomerID'],
                    'FullName': row.get('FullName', ''),
                    'PhoneNumber': row.get('PhoneNumber', ''),
                    'Address': row.get('Address', '')
                })
    except FileNotFoundError:
        print("Không tìm thấy file customers_data.csv")
        return []
    return customers

def get_branches():
    branches = []
    try:
        with open('branches_data.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                branches.append(row['BranchID'])
    except FileNotFoundError:
        print("Không tìm thấy file branches_data.csv")
        return []
    return branches

def generate_arrival_time():
    # Tạo thời gian đến từ 10:00 đến 21:00
    hour = random.randint(10, 21)
    minute = random.choice([0, 15, 30, 45])
    return time(hour, minute)

def calculate_delivery_fee(distance):
    # Phí giao hàng: 15k cho 2km đầu, 5k mỗi km tiếp theo
    if distance <= 2:
        return 15000
    else:
        return 15000 + (distance - 2) * 5000

def generate_bookings(customers, branches, num_bookings):
    bookings = []
    current_date = datetime.now()
    start_date = current_date - timedelta(days=30)  # Dữ liệu 30 ngày trước
    end_date = current_date + timedelta(days=7)     # Dữ liệu 7 ngày sau
    
    delivery_types = ['DINE_IN', 'DELIVERY', 'TAKEAWAY']
    status_weights = {
        'past': {'CONFIRMED': 0.8, 'CANCELLED': 0.2},
        'future': {'PENDING': 0.3, 'CONFIRMED': 0.7}
    }

    for _ in range(num_bookings):
        customer = random.choice(customers)
        branch = random.choice(branches)
        booking_date = start_date + timedelta(
            days=random.randint(0, (end_date - start_date).days)
        )
        
        delivery_type = random.choices(
            delivery_types, 
            weights=[0.5, 0.3, 0.2]  # 50% dine-in, 30% delivery, 20% takeaway
        )[0]
        
        # Xác định trạng thái dựa vào ngày đặt
        is_past = booking_date.date() < current_date.date()
        if is_past:
            status = random.choices(
                list(status_weights['past'].keys()),
                weights=list(status_weights['past'].values())
            )[0]
        else:
            status = random.choices(
                list(status_weights['future'].keys()),
                weights=list(status_weights['future'].values())
            )[0]

        booking = {
            'CustomerID': customer['CustomerID'],
            'BranchID': branch,
            'BookingDate': booking_date.strftime('%Y-%m-%d'),
            'GuestName': customer['FullName'],
            'GuestPhone': customer['PhoneNumber'],
            'DeliveryType': delivery_type,
            'Status': status,
            'Notes': ''
        }

        # Thông tin theo loại đặt chỗ
        if delivery_type == 'DINE_IN':
            booking['GuestCount'] = random.randint(1, 8)
            booking['ArrivalTime'] = generate_arrival_time().strftime('%H:%M')
            booking['DeliveryAddress'] = None
            booking['DeliveryFee'] = 0
            booking['Notes'] = random.choice([
                'Window seat preferred',
                'Birthday celebration',
                'Need high chair for baby',
                ''
            ])
        
        elif delivery_type == 'DELIVERY':
            booking['GuestCount'] = random.randint(1, 4)
            booking['ArrivalTime'] = None
            booking['DeliveryAddress'] = customer['Address']
            distance = random.uniform(1, 10)  # 1-10km
            booking['DeliveryFee'] = calculate_delivery_fee(distance)
            booking['Notes'] = random.choice([
                'Please call before delivery',
                'Leave at door',
                'No wasabi',
                ''
            ])
        
        else:  # TAKEAWAY
            booking['GuestCount'] = random.randint(1, 4)
            booking['ArrivalTime'] = generate_arrival_time().strftime('%H:%M')
            booking['DeliveryAddress'] = None
            booking['DeliveryFee'] = 0
            booking['Notes'] = random.choice([
                'Extra chopsticks please',
                'Extra soy sauce',
                ''
            ])
        
        bookings.append(booking)
    
    return bookings

# Lấy dữ liệu từ các bảng liên quan
customers = get_customers()
branches = get_branches()

if not customers or not branches:
    print("Không thể tạo dữ liệu do thiếu thông tin từ các bảng liên quan")
    exit()

# Tạo 5000 đơn đặt chỗ
bookings = generate_bookings(customers, branches, 5000)

# Lưu thành file CSV
csv_file = 'online_bookings.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=[
        'CustomerID', 'BranchID', 'GuestCount', 'BookingDate', 'ArrivalTime',
        'Notes', 'GuestName', 'GuestPhone', 'DeliveryType', 'DeliveryAddress',
        'DeliveryFee', 'Status'
    ])
    writer.writeheader()
    writer.writerows(bookings)

# Tạo file SQL INSERT statements
sql_file = 'online_bookings_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for booking in bookings:
        arrival_time = f"'{booking['ArrivalTime']}'" if booking['ArrivalTime'] else 'NULL'
        delivery_address = f"N'{booking['DeliveryAddress']}'" if booking['DeliveryAddress'] else 'NULL'
        notes = f"N'{booking['Notes']}'" if booking['Notes'] else 'NULL'
        
        sql = f"INSERT INTO ONLINE_BOOKING (CustomerID, BranchID, GuestCount, "
        sql += f"BookingDate, ArrivalTime, Notes, GuestName, GuestPhone, "
        sql += f"DeliveryType, DeliveryAddress, DeliveryFee, Status) VALUES ("
        sql += f"'{booking['CustomerID']}', '{booking['BranchID']}', {booking['GuestCount']}, "
        sql += f"'{booking['BookingDate']}', {arrival_time}, {notes}, "
        sql += f"N'{booking['GuestName']}', '{booking['GuestPhone']}', "
        sql += f"'{booking['DeliveryType']}', {delivery_address}, "
        sql += f"{booking['DeliveryFee']}, '{booking['Status']}');\n"
        f.write(sql)

# Thống kê
print(f"Đã tạo {len(bookings)} đơn đặt chỗ")

print("\nPhân bổ theo loại đặt chỗ:")
delivery_types = {}
for booking in bookings:
    dtype = booking['DeliveryType']
    delivery_types[dtype] = delivery_types.get(dtype, 0) + 1

for dtype, count in delivery_types.items():
    print(f"{dtype}: {count} đơn ({(count/len(bookings))*100:.1f}%)")

print("\nPhân bổ theo trạng thái:")
statuses = {}
for booking in bookings:
    status = booking['Status']
    statuses[status] = statuses.get(status, 0) + 1

for status, count in statuses.items():
    print(f"{status}: {count} đơn ({(count/len(bookings))*100:.1f}%)")

print(f"\nĐã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")