import csv
from faker import Faker
import random

fake = Faker()

def generate_online_booking_data(num_records, num_customers, num_branches):
    data = []
    for i in range(1, num_records + 1):
        booking_id = i  # ID tăng dần từ 1
        customer_id = f"CUST{random.randint(1, num_customers):05d}"  # Giả sử có num_customers CustomerID hợp lệ
        branch_id = f"BR{random.randint(1, num_branches):05d}"  # Giả sử có num_branches BranchID hợp lệ
        guest_count = random.randint(1, 20)  # Số lượng khách ngẫu nhiên
        booking_date = fake.date_between(start_date='-1y', end_date='today')
        arrival_time = fake.time(pattern="%H:%M:%S")
        notes = fake.sentence(nb_words=10)  # Ghi chú ngẫu nhiên

        data.append({
            "BookingID": booking_id,
            "CustomerID": customer_id,
            "BranchID": branch_id,
            "GuestCount": guest_count,
            "BookingDate": booking_date,
            "ArrivalTime": arrival_time,
            "Notes": notes
        })
    return data

# Giả sử có 10,000 CustomerID và 1,000 BranchID hợp lệ
num_customers = 10000
num_branches = 10000

# Tạo 10,000 dòng dữ liệu
online_booking_data = generate_online_booking_data(10000, num_customers, num_branches)

# Ghi dữ liệu vào file CSV
with open('ONLINE_BOOKING.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=[
        "BookingID", "CustomerID", "BranchID", "GuestCount", "BookingDate", "ArrivalTime", "Notes"
    ])
    writer.writeheader()
    writer.writerows(online_booking_data)

print("File CSV đã được tạo thành công.")