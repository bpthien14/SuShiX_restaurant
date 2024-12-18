import csv
import random

def generate_menu_item_availability_data(num_records, num_branches, num_items):
    data = []
    for i in range(1, num_records + 1):
        branch_id = f"BR{random.randint(1, num_branches):05d}"  # Giả sử có num_branches BranchID hợp lệ
        item_id = f"ITEM{random.randint(1, num_items):05d}"  # Giả sử có num_items ItemID hợp lệ
        is_available = random.choice([0, 1])  # Tình trạng sẵn có ngẫu nhiên

        data.append({
            "BranchID": branch_id,
            "ItemID": item_id,
            "IsAvailable": is_available
        })
    return data

# Giả sử có 1,000 BranchID và 10,000 ItemID hợp lệ
num_branches = 10000
num_items = 10000

# Tạo 10,000 dòng dữ liệu
menu_item_availability_data = generate_menu_item_availability_data(10000, num_branches, num_items)

# Ghi dữ liệu vào file CSV
with open('MENU_ITEM_AVAILABILITY.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=["BranchID", "ItemID", "IsAvailable"])
    writer.writeheader()
    writer.writerows(menu_item_availability_data)

print("File CSV đã được tạo thành công.")