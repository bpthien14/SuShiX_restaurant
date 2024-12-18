import csv
from faker import Faker
import random

fake = Faker()

def generate_menu_item_data(num_records, num_categories):
    data = []
    for i in range(1, num_records + 1):
        item_id = f"ITEM{i:05d}"  # Tạo ID theo định dạng ITEM00001, ITEM00002, ...
        category_id = f"CAT{random.randint(1, num_categories):05d}"  # Giả sử có num_categories CategoryID hợp lệ
        item_name = fake.word().capitalize()  # Tên món ăn ngẫu nhiên
        current_price = round(random.uniform(5, 100), 2)  # Giá ngẫu nhiên từ 5 đến 100
        delivery_available = random.choice([0, 1])  # Khả năng giao hàng ngẫu nhiên

        data.append({
            "ItemID": item_id,
            "CategoryID": category_id,
            "ItemName": item_name,
            "CurrentPrice": current_price,
            "DeliveryAvailable": delivery_available
        })
    return data

# Giả sử có 1,000 CategoryID hợp lệ
num_categories = 1000

# Tạo 10,000 dòng dữ liệu
menu_item_data = generate_menu_item_data(10000, num_categories)

# Ghi dữ liệu vào file CSV
with open('MENU_ITEM.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=[
        "ItemID", "CategoryID", "ItemName", "CurrentPrice", "DeliveryAvailable"
    ])
    writer.writeheader()
    writer.writerows(menu_item_data)

print("File CSV đã được tạo thành công.")