import csv
from faker import Faker
import random

fake = Faker()

def generate_user_data(num_records):
    data = []
    roles = ['admin', 'customer', 'staff']  # Các vai trò có thể có
    for i in range(1, num_records + 1):
        user_id = f"USR{i:05d}"  # Tạo ID theo định dạng USR00001, USR00002, ...
        username = fake.user_name()
        password = fake.password(length=10)  # Tạo mật khẩu ngẫu nhiên
        role = random.choice(roles)  # Chọn ngẫu nhiên một vai trò

        data.append({
            "UserID": user_id,
            "Username": username,
            "Password": password,
            "Role": role
        })
    return data

# Tạo 10,000 dòng dữ liệu
user_data = generate_user_data(10000)

# Ghi dữ liệu vào file CSV
with open('USERS.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=["UserID", "Username", "Password", "Role"])
    writer.writeheader()
    writer.writerows(user_data)

print("File CSV đã được tạo thành công.")