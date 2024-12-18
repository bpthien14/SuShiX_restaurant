import csv
from faker import Faker

fake = Faker()

def clean_text(text):
    return text.replace(',', '')  # Loại bỏ dấu phẩy

def generate_department_data(num_records):
    data = []
    for i in range(1, num_records + 1):
        department_id = f"DP{i:05d}"  # Tạo ID theo định dạng DP00001, DP00002, ...
        department_name = clean_text(fake.bs())  # Tên ngẫu nhiên, loại bỏ dấu phẩy
        data.append({
            "DepartmentID": department_id,
            "DepartmentName": department_name
        })
    return data

# Tạo 10,000 dòng dữ liệu
department_data = generate_department_data(10000)

# Ghi dữ liệu vào file CSV
with open('DEPARTMENT.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=["DepartmentID", "DepartmentName"])
    writer.writeheader()
    writer.writerows(department_data)

print("File CSV đã được tạo thành công.")