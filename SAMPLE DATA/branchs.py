import csv
from faker import Faker
import random

fake = Faker()

def clean_text(text):
    return text.replace(',', '')  # Loại bỏ dấu phẩy

def generate_branch_data(num_records):
    data = []
    for i in range(1, num_records + 1):
        branch_id = f"BR{i:05d}"  # Tạo ID theo định dạng BR00001, BR00002, ...
        region_id = i  # ID tăng dần từ 1
        branch_name = clean_text(fake.company())
        address = clean_text(fake.address())
        branch_phone_number = clean_text(fake.phone_number())
        opening_time = fake.time(pattern="%H:%M:%S")
        closing_time = fake.time(pattern="%H:%M:%S")
        has_car_parking = random.choice([0, 1])
        has_bike_parking = random.choice([0, 1])
        delivery_service = random.choice([0, 1])
        manager_id = f"MG{random.randint(1, 1000):05d}"  # Giả sử có 1,000 ManagerID

        data.append({
            "BranchID": branch_id,
            "RegionID": region_id,
            "BranchName": branch_name,
            "Address": address,
            "BranchPhoneNumber": branch_phone_number,
            "OpeningTime": opening_time,
            "ClosingTime": closing_time,
            "HasCarParking": has_car_parking,
            "HasBikeParking": has_bike_parking,
            "DeliveryService": delivery_service,
            "ManagerID": manager_id
        })
    return data

# Tạo 1,000 dòng dữ liệu
branch_data = generate_branch_data(10000)

# Ghi dữ liệu vào file CSV
with open('BRANCH.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=[
        "BranchID", "RegionID", "BranchName", "Address", "BranchPhoneNumber",
        "OpeningTime", "ClosingTime", "HasCarParking", "HasBikeParking",
        "DeliveryService", "ManagerID"
    ])
    writer.writeheader()
    writer.writerows(branch_data)

print("File CSV đã được tạo thành công.")