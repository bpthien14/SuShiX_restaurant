import csv
from faker import Faker
import random
from datetime import datetime

fake = Faker()

def generate_membership_card_data(num_records):
    data = []
    card_types = ['Membership', 'Silver', 'Gold']  # Các loại thẻ có thể có
    for i in range(1, num_records + 1):
        card_id = f"CARD{i:05d}"  # Tạo ID theo định dạng CARD00001, CARD00002, ...
        customer_id = f"CUST{random.randint(1, 10000):05d}"  # Giả sử có 10,000 CustomerID
        staff_id = f"ST{random.randint(1, 10000):05d}"  # Giả sử có 1,000 StaffID
        card_type = random.choice(card_types)
        registration_date = fake.date_between(start_date='-2y', end_date='today')
        accumulated_points = round(random.uniform(0, 500), 2)  # Điểm tích lũy ngẫu nhiên

        data.append({
            "CardID": card_id,
            "CustomerID": customer_id,
            "StaffID": staff_id,
            "CardType": card_type,
            "RegistrationDate": registration_date,
            "AccumulatedPoints": accumulated_points
        })
    return data

# Tạo 10,000 dòng dữ liệu
membership_card_data = generate_membership_card_data(10000)

# Ghi dữ liệu vào file CSV
with open('MEMBERSHIP_CARD.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=[
        "CardID", "CustomerID", "StaffID", "CardType", "RegistrationDate", "AccumulatedPoints"
    ])
    writer.writeheader()
    writer.writerows(membership_card_data)

print("File CSV đã được tạo thành công.")