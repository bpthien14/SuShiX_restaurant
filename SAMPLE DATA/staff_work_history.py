import csv
from faker import Faker
import random
from datetime import datetime, timedelta

fake = Faker()

def generate_work_history_data(num_records):
    data = []
    for i in range(1, num_records + 1):
        history_id = i
        staff_id = f"ST{random.randint(1, 10000):05d}"  # Giả sử có 10,000 StaffID
        branch_id = f"BR{random.randint(1, 10000):05d}"  # Giả sử có 1,000 BranchID
        start_date = fake.date_this_decade()
        end_date = fake.date_between(start_date=start_date, end_date=start_date + timedelta(days=365)) if random.choice([True, False]) else ''

        data.append({
            "HistoryID": history_id,
            "StaffID": staff_id,
            "BranchID": branch_id,
            "StartDate": start_date.strftime('%Y-%m-%d'),
            "EndDate": end_date.strftime('%Y-%m-%d') if end_date else ''
        })
    return data

# Tạo 10,000 dòng dữ liệu
work_history_data = generate_work_history_data(10000)

# Ghi dữ liệu vào file CSV
with open('STAFF_WORK_HISTORY.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=[
        "HistoryID", "StaffID", "BranchID", "StartDate", "EndDate"
    ])
    writer.writeheader()
    writer.writerows(work_history_data)

print("File CSV đã được tạo thành công.")