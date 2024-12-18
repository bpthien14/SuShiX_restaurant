import csv
from faker import Faker
import random

fake = Faker()

def generate_order_table_data(num_records, num_staff, num_branches, num_customers):
    data = []
    for i in range(1, num_records + 1):
        order_id = f"ORD{i:05d}"  # Tạo ID theo định dạng ORD00001, ORD00002, ...
        order_date = fake.date_between(start_date='-1y', end_date='today')
        staff_id = f"ST{random.randint(1, num_staff):05d}"  # Giả sử có num_staff StaffID hợp lệ
        table_number = random.randint(1, 50)  # Số bàn ngẫu nhiên từ 1 đến 50
        branch_id = f"BR{random.randint(1, num_branches):05d}"  # Giả sử có num_branches BranchID hợp lệ
        customer_id = f"CUST{random.randint(1, num_customers):05d}"  # Giả sử có num_customers CustomerID hợp lệ

        data.append({
            "OrderID": order_id,
            "OrderDate": order_date,
            "StaffID": staff_id,
            "TableNumber": table_number,
            "BranchID": branch_id,
            "CustomerID": customer_id
        })
    return data

# Giả sử có 1,000 StaffID, 1,000 BranchID, và 10,000 CustomerID hợp lệ
num_staff = 1000
num_branches = 1000
num_customers = 10000

# Tạo 10,000 dòng dữ liệu
order_table_data = generate_order_table_data(10000, num_staff, num_branches, num_customers)

# Ghi dữ liệu vào file CSV
with open('order_table.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=[
        "OrderID", "OrderDate", "StaffID", "TableNumber", "BranchID", "CustomerID"
    ])
    writer.writeheader()
    writer.writerows(order_table_data)

print("File CSV đã được tạo thành công.")