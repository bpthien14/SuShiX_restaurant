import csv
import random

def get_branches():
    branches = []
    try:
        with open('branches_data.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                branches.append(row['BranchID'])
    except FileNotFoundError:
        print("Không tìm thấy file branches_data.csv")
        return []
    return branches

def get_menu_items():
    items = []
    try:
        with open('menu_items.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                items.append({
                    'ItemID': row['ItemID'],
                    'CategoryID': row['CategoryID']
                })
    except FileNotFoundError:
        print("Không tìm thấy file menu_items.csv")
        return []
    return items

def generate_availability(branches, menu_items):
    availability = []
    
    for branch in branches:
        # Xác định các món không có sẵn dựa trên category
        unavailable_items = set()
        
        # 20% chi nhánh không có các món trong danh mục Sashimi (cần nguyên liệu đặc biệt)
        if random.random() < 0.2:
            unavailable_items.update([item['ItemID'] for item in menu_items if item['CategoryID'] == 'CAT_SASHIMI'])
        
        # 10% chi nhánh không có các món trong Bento Sets
        if random.random() < 0.1:
            unavailable_items.update([item['ItemID'] for item in menu_items if item['CategoryID'] == 'CAT_BENTO'])
        
        # Với mỗi món ăn
        for item in menu_items:
            # Nếu món thuộc danh sách không có sẵn của chi nhánh
            if item['ItemID'] in unavailable_items:
                is_available = 0
            else:
                # Các món còn lại có 95% khả năng có sẵn
                is_available = 1 if random.random() < 0.95 else 0
            
            availability.append({
                'BranchID': branch,
                'ItemID': item['ItemID'],
                'IsAvailable': is_available
            })
    
    return availability

# Lấy dữ liệu từ các bảng liên quan
branches = get_branches()
menu_items = get_menu_items()

if not branches or not menu_items:
    print("Không thể tạo dữ liệu do thiếu thông tin từ các bảng liên quan")
    exit()

# Tạo dữ liệu availability
availability_data = generate_availability(branches, menu_items)

# Lưu thành file CSV
csv_file = 'menu_item_availability.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=['BranchID', 'ItemID', 'IsAvailable'])
    writer.writeheader()
    writer.writerows(availability_data)

# Tạo file SQL INSERT statements
sql_file = 'menu_item_availability_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    batch_size = 1000
    for i in range(0, len(availability_data), batch_size):
        f.write('INSERT INTO MENU_ITEM_AVAILABILITY (BranchID, ItemID, IsAvailable) VALUES\n')
        batch = availability_data[i:i + batch_size]
        values = []
        for item in batch:
            values.append(f"('{item['BranchID']}', '{item['ItemID']}', {item['IsAvailable']})")
        f.write(',\n'.join(values) + ';\n\n')

# Thống kê
total_records = len(availability_data)
available_count = sum(1 for item in availability_data if item['IsAvailable'] == 1)
unavailable_count = total_records - available_count

print(f"Đã tạo {total_records} bản ghi cho {len(branches)} chi nhánh")
print(f"Tổng số món có sẵn: {available_count} ({(available_count/total_records)*100:.1f}%)")
print(f"Tổng số món không có sẵn: {unavailable_count} ({(unavailable_count/total_records)*100:.1f}%)")

# Thống kê theo chi nhánh
print("\nMột số chi nhánh mẫu:")
branch_stats = {}
for item in availability_data:
    branch = item['BranchID']
    if branch not in branch_stats:
        branch_stats[branch] = {'total': 0, 'available': 0}
    branch_stats[branch]['total'] += 1
    if item['IsAvailable'] == 1:
        branch_stats[branch]['available'] += 1

# In thống kê cho 5 chi nhánh đầu tiên
for i, (branch, stats) in enumerate(list(branch_stats.items())[:5]):
    available_percent = (stats['available'] / stats['total']) * 100
    print(f"Chi nhánh {branch}: {stats['available']}/{stats['total']} món có sẵn ({available_percent:.1f}%)")

print(f"\nĐã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")