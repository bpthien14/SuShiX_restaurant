import random
import uuid
import csv
from datetime import datetime, timedelta

def get_customer_ids():
    customer_ids = []
    try:
        with open('customers_data.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                customer_ids.append(row['CustomerID'])
    except FileNotFoundError:
        print("Không tìm thấy file customers_data.csv")
        return []
    return customer_ids

def get_staff_ids():
    staff_ids = []
    try:
        with open('staff_data.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                if row['DepartmentID'] in ['DEPT_CS', 'DEPT_MGR']:  # Chỉ lấy nhân viên CSKH và quản lý
                    staff_ids.append(row['StaffID'])
    except FileNotFoundError:
        print("Không tìm thấy file staff_data.csv")
        return []
    return staff_ids

def generate_membership_cards(customer_ids, staff_ids):
    cards = []
    used_customers = set()
    current_date = datetime.now()
    start_date = current_date - timedelta(days=365*2)  # Dữ liệu trong 2 năm

    for customer_id in customer_ids:
        # Tạo ngày đăng ký ngẫu nhiên trong khoảng thời gian
        registration_date = start_date + timedelta(
            days=random.randint(0, (current_date - start_date).days)
        )
        
        # Tính điểm tích lũy ngẫu nhiên
        points = random.uniform(0, 300)  # 0-300 điểm (0-30tr VND)
        
        # Xác định loại thẻ dựa trên điểm
        if points >= 100:  # Trên 10tr -> có thể là GOLD
            if random.random() < 0.7:  # 70% cơ hội được GOLD nếu đủ điểm
                card_type = 'GOLD'
            else:
                card_type = 'SILVER'
        elif points >= 50:  # 5-10tr -> SILVER
            card_type = 'SILVER'
        else:
            card_type = 'MEMBERSHIP'

        cards.append({
            'CardID': f"CARD_{str(uuid.uuid4())[:8]}",
            'CustomerID': customer_id,
            'StaffID': random.choice(staff_ids),
            'CardType': card_type,
            'RegistrationDate': registration_date.strftime('%Y-%m-%d'),
            'AccumulatedPoints': round(points, 2)
        })
        
        # 10% khách hàng có 2 thẻ (thẻ cũ đã hủy, cấp thẻ mới)
        if random.random() < 0.1:
            old_reg_date = registration_date - timedelta(days=random.randint(30, 180))
            cards.append({
                'CardID': f"CARD_{str(uuid.uuid4())[:8]}",
                'CustomerID': customer_id,
                'StaffID': random.choice(staff_ids),
                'CardType': 'MEMBERSHIP',  # Thẻ cũ luôn là thẻ cơ bản
                'RegistrationDate': old_reg_date.strftime('%Y-%m-%d'),
                'AccumulatedPoints': 0  # Thẻ cũ không còn điểm
            })

    return cards

# Lấy dữ liệu từ các bảng liên quan
customer_ids = get_customer_ids()
staff_ids = get_staff_ids()

if not customer_ids or not staff_ids:
    print("Không thể tạo dữ liệu do thiếu thông tin từ các bảng liên quan")
    exit()

print(f"Đã tìm thấy {len(customer_ids)} khách hàng và {len(staff_ids)} nhân viên")

# Tạo dữ liệu thẻ thành viên
membership_cards = generate_membership_cards(customer_ids, staff_ids)

# Lưu thành file CSV
csv_file = 'membership_cards.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=[
        'CardID', 'CustomerID', 'StaffID', 'CardType',
        'RegistrationDate', 'AccumulatedPoints'
    ])
    writer.writeheader()
    writer.writerows(membership_cards)

# Tạo file SQL INSERT statements
sql_file = 'membership_cards_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for card in membership_cards:
        sql = f"INSERT INTO MEMBERSHIP_CARD (CardID, CustomerID, StaffID, "
        sql += f"CardType, RegistrationDate, AccumulatedPoints) "
        sql += f"VALUES ('{card['CardID']}', '{card['CustomerID']}', "
        sql += f"'{card['StaffID']}', '{card['CardType']}', "
        sql += f"'{card['RegistrationDate']}', {card['AccumulatedPoints']});\n"
        f.write(sql)

print(f"Đã tạo {len(membership_cards)} bản ghi")
print("Phân bổ theo loại thẻ:")
card_types = {}
for card in membership_cards:
    card_type = card['CardType']
    card_types[card_type] = card_types.get(card_type, 0) + 1
for card_type, count in card_types.items():
    print(f"{card_type}: {count} thẻ ({(count/len(membership_cards))*100:.1f}%)")
print(f"Đã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")