import random
import uuid
import csv
from datetime import time

# Đọc RegionID từ file region_data.csv
def get_region_ids():
    region_ids = []
    try:
        with open('region_data.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                region_ids.append(int(row['RegionID']))
    except FileNotFoundError:
        # Nếu không có file, tạm sử dụng 3 region mặc định
        region_ids = [1, 2, 3]
    return region_ids

# Danh sách các thành phố và mã vùng tương ứng
city_codes = {
    'Hà Nội': '024',
    'TP.HCM': '028',
    'Đà Nẵng': '0236',
    'Hải Phòng': '0225',
    'Cần Thơ': '0292',
    'Biên Hòa': '0251',
    'Nha Trang': '0258',
    'Huế': '0234'
}

districts = [
    'Quận 1', 'Quận 2', 'Quận 3', 'Hoàn Kiếm', 'Hai Bà Trưng', 'Cầu Giấy',
    'Ngũ Hành Sơn', 'Hải Châu', 'Sơn Trà', 'Thanh Khê', 'Liên Chiểu'
]

streets = [
    'Lê Lợi', 'Nguyễn Huệ', 'Trần Hưng Đạo', 'Lý Thái Tổ', 'Phan Chu Trinh',
    'Điện Biên Phủ', 'Nguyễn Du', 'Lê Duẩn', 'Hai Bà Trưng', 'Lê Thánh Tôn'
]

def generate_branch_name(city):
    types = ['Sushi X', 'Sushi X Premium', 'Sushi X Express']
    return f"{random.choice(types)} - {city} {random.randint(1,99)}"

def generate_address(city):
    street_number = random.randint(1, 999)
    street = random.choice(streets)
    district = random.choice(districts)
    return f"{street_number} {street}, {district}, {city}"

def generate_phone(city):
    prefix = city_codes[city]
    suffix = ''.join(random.choices('0123456789', k=7))
    return f"{prefix}{suffix}"

def generate_time():
    opening = time(random.choice([10, 11]), random.choice([0, 30]))
    closing = time(random.choice([21, 22]), random.choice([0, 30]))
    return opening, closing

def generate_branches_data(num_records, region_ids):
    branches = []
    used_names = set()
    used_addresses = set()
    used_phones = set()
    
    cities = list(city_codes.keys())
    
    for _ in range(num_records):
        city = random.choice(cities)
        attempts = 0
        
        while attempts < 100:  # Giới hạn số lần thử để tránh vòng lặp vô hạn
            branch_name = generate_branch_name(city)
            address = generate_address(city)
            phone = generate_phone(city)
            
            if (branch_name not in used_names and 
                address not in used_addresses and 
                phone not in used_phones):
                
                opening_time, closing_time = generate_time()
                
                branches.append({
                    'BranchID': str(uuid.uuid4()),
                    'RegionID': random.choice(region_ids),
                    'BranchName': branch_name,
                    'Address': address,
                    'BranchPhoneNumber': phone,
                    'OpeningTime': opening_time.strftime('%H:%M'),
                    'ClosingTime': closing_time.strftime('%H:%M'),
                    'HasCarParking': random.choice([0, 1]),
                    'HasBikeParking': 1,
                    'DeliveryService': random.choice([0, 1]),
                    'ManagerID': None
                })
                
                used_names.add(branch_name)
                used_addresses.add(address)
                used_phones.add(phone)
                break
            
            attempts += 1
        
        if attempts >= 100:
            print(f"Warning: Không thể tạo thêm chi nhánh độc nhất sau {len(branches)} bản ghi")
            break
    
    return branches

# Lấy RegionID
region_ids = get_region_ids()

# Tạo dữ liệu chi nhánh
branches_data = generate_branches_data(10000, region_ids)

# Lưu thành file CSV
csv_file = 'branches_data.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=[
        'BranchID', 'RegionID', 'BranchName', 'Address', 'BranchPhoneNumber',
        'OpeningTime', 'ClosingTime', 'HasCarParking', 'HasBikeParking',
        'DeliveryService', 'ManagerID'
    ])
    writer.writeheader()
    writer.writerows(branches_data)

# Tạo file SQL INSERT statements
sql_file = 'branches_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for branch in branches_data:
        sql = f"INSERT INTO BRANCH (BranchID, RegionID, BranchName, Address, BranchPhoneNumber, "
        sql += f"OpeningTime, ClosingTime, HasCarParking, HasBikeParking, DeliveryService)\n"
        sql += f"VALUES ('{branch['BranchID']}', {branch['RegionID']}, N'{branch['BranchName']}', "
        sql += f"N'{branch['Address']}', '{branch['BranchPhoneNumber']}', '{branch['OpeningTime']}', "
        sql += f"'{branch['ClosingTime']}', {branch['HasCarParking']}, {branch['HasBikeParking']}, "
        sql += f"{branch['DeliveryService']});\n"
        f.write(sql)

print(f"Đã tạo {len(branches_data)} bản ghi")
print(f"Đã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")