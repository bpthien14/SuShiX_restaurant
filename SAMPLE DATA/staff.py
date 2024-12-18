import csv
from faker import Faker
import random
from datetime import datetime

fake = Faker()

def clean_text(text):
    return text.replace(',', '')  # Loại bỏ dấu phẩy

def generate_staff_data(num_records):
    data = []
    for i in range(1, num_records + 1):
        staff_id = f"ST{i:05d}"  # Tạo ID theo định dạng ST00001, ST00002, ...
        department_id = f"DP{random.randint(1, 10000):05d}"  # Giả sử có 10,000 DepartmentID
        branch_id = f"BR{random.randint(1, 1000):05d}"  # Giả sử có 1,000 BranchID
        full_name = clean_text(fake.name())
        gender = random.choice(['Male', 'Female'])
        birth_date = fake.date_of_birth(minimum_age=18, maximum_age=65).strftime('%Y-%m-%d')
        start_date = fake.date_this_decade()
        end_date = fake.date_between(start_date=start_date) if random.choice([True, False]) else ''
        salary = round(random.uniform(3000, 10000), 2)
        address = clean_text(fake.address())
        phone_number = clean_text(fake.phone_number())
        user_id = f"USR{random.randint(1, 10000):05d}"  # Giả sử có 10,000 UserID

        data.append({
            "StaffID": staff_id,
            "DepartmentID": department_id,
            "BranchID": branch_id,
            "FullName": full_name,
            "Gender": gender,
            "BirthDate": birth_date,
            "StartDate": start_date.strftime('%Y-%m-%d'),
            "EndDate": end_date.strftime('%Y-%m-%d') if end_date else '',
            "Salary": salary,
            "Address": address,
            "PhoneNumber": phone_number,
            "UserID": user_id
        })
    return data

# Tạo 10,000 dòng dữ liệu
staff_data = generate_staff_data(10000)

# Ghi dữ liệu vào file CSV
with open('STAFF.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=[
        "StaffID", "DepartmentID", "BranchID", "FullName", "Gender",
        "BirthDate", "StartDate", "EndDate", "Salary", "Address",
        "PhoneNumber", "UserID"
    ])
    writer.writeheader()
    writer.writerows(staff_data)

print("File CSV đã được tạo thành công.")