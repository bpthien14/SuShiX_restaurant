import csv
from faker import Faker

fake = Faker()

def generate_menu_category_data(num_records):
    data = []
    for i in range(1, num_records + 1):
        category_id = f"CAT{i:05d}"  # Tạo ID theo định dạng CAT00001, CAT00002, ...
        category_name = fake.word().capitalize()  # Tên danh mục ngẫu nhiên

        data.append({
            "CategoryID": category_id,
            "CategoryName": category_name
        })
    return data

# Tạo 10,000 dòng dữ liệu
menu_category_data = generate_menu_category_data(10000)

# Ghi dữ liệu vào file CSV
with open('MENU_CATEGORY.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=["CategoryID", "CategoryName"])
    writer.writeheader()
    writer.writerows(menu_category_data)

print("File CSV đã được tạo thành công.")