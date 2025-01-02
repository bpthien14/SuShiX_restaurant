import random
import uuid
import csv
from datetime import datetime, timedelta
import ipaddress

def get_user_ids():
    users = []
    try:
        with open('users_data.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                users.append({
                    'UserID': row['UserID'],
                    'Role': row['Role']
                })
    except FileNotFoundError:
        print("Không tìm thấy file users_data.csv")
        return []
    return users

def generate_ip_address():
    # 70% là IPv4 nội địa Việt Nam, 30% là các IP khác
    if random.random() < 0.7:
        # Các dải IP phổ biến ở Việt Nam
        vn_ranges = [
            '14.160.0.0/11',  # VNPT
            '14.224.0.0/11',  # Viettel
            '27.64.0.0/12',   # FPT
            '113.160.0.0/11', # VNPT
            '171.224.0.0/11', # Viettel
            '203.113.128.0/18' # CMC
        ]
        ip_range = random.choice(vn_ranges)
        network = ipaddress.ip_network(ip_range)
        ip = network[random.randint(0, min(1000, network.num_addresses - 1))]
    else:
        # IP ngẫu nhiên
        ip = ipaddress.IPv4Address(random.randint(0, 2**32 - 1))
    return str(ip)

def generate_online_sessions(users, num_sessions):
    sessions = []
    device_types = ['Mobile Android', 'Mobile iOS', 'Desktop Windows', 'Desktop MacOS', 
                   'Tablet Android', 'Tablet iOS', 'Smart TV', 'Desktop Linux']
    
    internal_sources = ['Direct Access', 'Mobile App', 'Website', 'QR Code', 
                       'Social Media', 'Email Link', 'Push Notification']
    
    end_date = datetime.now()
    start_date = end_date - timedelta(days=365)  # Dữ liệu trong 1 năm
    
    # Tạo nhiều session hơn cho CUSTOMER và STAFF
    weighted_users = []
    for user in users:
        if user['Role'] == 'CUSTOMER':
            weighted_users.extend([user] * 5)  # Khách hàng có nhiều session nhất
        elif user['Role'] in ['STAFF', 'MANAGER']:
            weighted_users.extend([user] * 3)  # Nhân viên có số session trung bình
        else:
            weighted_users.append(user)  # Admin có ít session nhất

    for _ in range(num_sessions):
        user = random.choice(weighted_users)
        
        # Tạo thời gian session ngẫu nhiên
        session_start = start_date + timedelta(
            seconds=random.randint(0, int((end_date - start_date).total_seconds()))
        )
        
        # Thời lượng session phụ thuộc vào role
        if user['Role'] == 'CUSTOMER':
            duration = random.randint(60, 3600)  # 1 phút đến 1 giờ
        elif user['Role'] in ['STAFF', 'MANAGER']:
            duration = random.randint(1800, 28800)  # 30 phút đến 8 giờ
        else:
            duration = random.randint(300, 7200)  # 5 phút đến 2 giờ
        
        sessions.append({
            'SessionID': str(uuid.uuid4()),
            'UserID': user['UserID'],
            'SessionStart': session_start.strftime('%Y-%m-%d %H:%M:%S'),
            'SessionDuration': duration,
            'DeviceType': random.choice(device_types),
            'IPAddress': generate_ip_address(),
            'InternalSource': random.choice(internal_sources)
        })
    
    return sessions

# Lấy dữ liệu users
users = get_user_ids()

if not users:
    print("Không thể tạo dữ liệu do thiếu thông tin từ bảng USERS")
    exit()

# Tạo 50000 session
online_sessions = generate_online_sessions(users, 50000)

# Lưu thành file CSV
csv_file = 'online_sessions.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=[
        'SessionID', 'UserID', 'SessionStart', 'SessionDuration',
        'DeviceType', 'IPAddress', 'InternalSource'
    ])
    writer.writeheader()
    writer.writerows(online_sessions)

# Tạo file SQL INSERT statements
sql_file = 'online_sessions_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for session in online_sessions:
        sql = f"INSERT INTO ONLINE_SESSION (SessionID, UserID, SessionStart, "
        sql += f"SessionDuration, DeviceType, IPAddress, InternalSource) "
        sql += f"VALUES ('{session['SessionID']}', '{session['UserID']}', "
        sql += f"'{session['SessionStart']}', {session['SessionDuration']}, "
        sql += f"'{session['DeviceType']}', '{session['IPAddress']}', "
        sql += f"'{session['InternalSource']}');\n"
        f.write(sql)

# Thống kê
print(f"Đã tạo {len(online_sessions)} phiên đăng nhập")

print("\nPhân bổ theo loại thiết bị:")
devices = {}
for session in online_sessions:
    device = session['DeviceType']
    devices[device] = devices.get(device, 0) + 1

for device, count in devices.items():
    print(f"{device}: {count} sessions ({(count/len(online_sessions))*100:.1f}%)")

print("\nPhân bổ theo nguồn truy cập:")
sources = {}
for session in online_sessions:
    source = session['InternalSource']
    sources[source] = sources.get(source, 0) + 1

for source, count in sources.items():
    print(f"{source}: {count} sessions ({(count/len(online_sessions))*100:.1f}%)")

print(f"\nĐã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")