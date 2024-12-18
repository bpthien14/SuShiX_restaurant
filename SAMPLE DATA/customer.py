import csv
from faker import Faker
import random

fake = Faker()

def generate_customer_data(num_records):
    data = []
    genders = ['Male', 'Female', 'Other']  # Các giới tính có thể có
    for i in range(1, num_records + 1):
        customer_id = f"CUST{i:05d}"  # Tạo ID theo định dạng CUST00001, CUST00002, ...
        full_name = fake.name()
        phone_number = fake.phone_number()
        email = fake.email()
        id_number = fake.ssn()  # Sử dụng số an sinh xã hội giả lập
        gender = random.choice(genders)
        user_id = f"USR{i:05d}"  # Giả sử UserID tương ứng với CustomerID

        data.append({
            "CustomerID": customer_id,
            "FullName": full_name,
            "PhoneNumber": phone_number,
            "Email": email,
            "IDNumber": id_number,
            "Gender": gender,
            "UserID": user_id
        })
    return data

# Tạo 10,000 dòng dữ liệu
customer_data = generate_customer_data(10000)

# Ghi dữ liệu vào file CSV
with open('CUSTOMER.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=[
        "CustomerID", "FullName", "PhoneNumber", "Email", "IDNumber", "Gender", "UserID"
    ])
    writer.writeheader()
    writer.writerows(customer_data)

print("File CSV đã được tạo thành công.")