import random
import string
import uuid
import csv

# Định nghĩa các role và tỷ lệ phân bổ
roles_distribution = [
    ('STAFF', 0.30),     # 30% là nhân viên
    ('MANAGER', 0.05),   # 5% là quản lý
    ('CUSTOMER', 0.64),  # 64% là khách hàng
    ('ADMIN', 0.01)      # 1% là admin
]

# Danh sách họ phổ biến ở Việt Nam
first_names = ['Nguyen', 'Tran', 'Le', 'Pham', 'Hoang', 'Huynh', 'Phan', 'Vu', 'Vo', 'Dang', 'Bui', 'Do']
last_names = ['Van', 'Thi', 'Huu', 'Duc', 'Minh', 'Hoang', 'Tuan', 'Anh', 'Hong', 'Thanh', 'Quang', 'Nam']

def generate_username(first, last):
    return f"{first.lower()}.{last.lower()}{random.randint(1, 9999)}"

def generate_password():
    # Tạo password có độ dài 12 ký tự
    characters = string.ascii_letters + string.digits + "!@#$%^&*"
    password = ''.join(random.choice(characters) for _ in range(12))
    return password

def generate_users_data(num_records):
    users = []
    used_usernames = set()
    
    # Tính số lượng user cho mỗi role
    role_counts = {}
    remaining = num_records
    for role, percentage in roles_distribution[:-1]:  # Trừ role cuối
        count = int(num_records * percentage)
        role_counts[role] = count
        remaining -= count
    role_counts[roles_distribution[-1][0]] = remaining  # Role cuối lấy số còn lại
    
    # Tạo users cho từng role
    for role, count in role_counts.items():
        for _ in range(count):
            while True:
                first = random.choice(first_names)
                last = random.choice(last_names)
                username = generate_username(first, last)
                
                if username not in used_usernames:
                    used_usernames.add(username)
                    users.append({
                        'UserID': str(uuid.uuid4()),
                        'Username': username,
                        'Password': generate_password(),
                        'Role': role
                    })
                    break
    
    # Xáo trộn danh sách users
    random.shuffle(users)
    return users

# Tạo 30000 users để đảm bảo đủ cho cả nhân viên và khách hàng
# 30000 users sẽ cho:
# - STAFF: ~9000 users (30%)
# - MANAGER: ~1500 users (5%)
# - CUSTOMER: ~19200 users (64%)
# - ADMIN: ~300 users (1%)
users_data = generate_users_data(30000)

# Lưu thành file CSV
csv_file = 'users_data.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=['UserID', 'Username', 'Password', 'Role'])
    writer.writeheader()
    writer.writerows(users_data)

# Tạo file SQL INSERT statements
sql_file = 'users_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for user in users_data:
        sql = f"INSERT INTO USERS (UserID, Username, Password, Role) "
        sql += f"VALUES ('{user['UserID']}', '{user['Username']}', "
        sql += f"'{user['Password']}', '{user['Role']}');\n"
        f.write(sql)

# Đếm số lượng mỗi role
role_counts = {}
for user in users_data:
    role = user['Role']
    role_counts[role] = role_counts.get(role, 0) + 1

print(f"Đã tạo {len(users_data)} bản ghi")
print("Phân bổ theo role:")
for role, count in role_counts.items():
    print(f"{role}: {count} users ({(count/len(users_data))*100:.1f}%)")
print(f"Đã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")