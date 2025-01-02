import random
import string
import uuid
import csv
from datetime import datetime

# Đọc danh sách users hiện có để tránh trùng username
def get_existing_usernames():
    existing_usernames = set()
    try:
        with open('users_data.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                existing_usernames.add(row['Username'])
    except FileNotFoundError:
        pass
    return existing_usernames

# Danh sách họ tên Việt Nam
first_names = ['Nguyen', 'Tran', 'Le', 'Pham', 'Hoang', 'Huynh', 'Phan', 'Vu', 'Vo', 'Dang', 'Bui', 'Do']
last_names = ['Van', 'Thi', 'Huu', 'Duc', 'Minh', 'Hoang', 'Tuan', 'Anh', 'Hong', 'Thanh']

def generate_username(first, last, existing_usernames):
    while True:
        username = f"{first.lower()}.{last.lower()}{random.randint(1, 9999)}"
        if username not in existing_usernames:
            return username

def generate_password():
    characters = string.ascii_letters + string.digits + "!@#$%^&*"
    return ''.join(random.choice(characters) for _ in range(12))

def generate_additional_managers(num_records):
    existing_usernames = get_existing_usernames()
    new_users = []
    
    for _ in range(num_records):
        first = random.choice(first_names)
        last = random.choice(last_names)
        username = generate_username(first, last, existing_usernames)
        
        user = {
            'UserID': str(uuid.uuid4()),
            'Username': username,
            'Password': generate_password(),
            'Role': 'MANAGER'
        }
        
        new_users.append(user)
        existing_usernames.add(username)
    
    return new_users

# Tạo thêm 400 managers mới
additional_managers = generate_additional_managers(400)

# Append vào file CSV hiện có
csv_file = 'users_data.csv'
with open(csv_file, 'a', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=['UserID', 'Username', 'Password', 'Role'])
    writer.writerows(additional_managers)

# Tạo file SQL INSERT riêng cho managers mới
sql_file = 'additional_managers_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for user in additional_managers:
        sql = f"INSERT INTO USERS (UserID, Username, Password, Role) "
        sql += f"VALUES ('{user['UserID']}', '{user['Username']}', "
        sql += f"'{user['Password']}', '{user['Role']}');\n"
        f.write(sql)

print(f"Đã tạo thêm {len(additional_managers)} managers mới")
print(f"Đã append vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")