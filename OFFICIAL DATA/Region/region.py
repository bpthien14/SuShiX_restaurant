import pandas as pd
import random

# Tạo danh sách các prefix cho tên khu vực
region_prefixes = [
    "Miền Bắc", "Miền Nam", "Miền Trung", "Đông", "Tây", "Nam", "Bắc",
    "Đông Bắc", "Tây Bắc", "Đông Nam", "Tây Nam", "Trung Tâm"
]

# Tạo danh sách các suffix cho tên khu vực
region_suffixes = [
    "Thành phố", "Quận", "Huyện", "Khu vực", "Địa phận",
    "Phía", "Vùng", "Khu", "Phường", "Xã"
]

def generate_region_data(num_records):
    regions = []
    used_names = set()
    
    for i in range(1, num_records + 1):
        while True:
            # Tạo tên khu vực ngẫu nhiên
            prefix = random.choice(region_prefixes)
            suffix = random.choice(region_suffixes)
            number = random.randint(1, 999)
            region_name = f"{prefix} {suffix} {number}"
            
            # Đảm bảo tên không trùng lặp
            if region_name not in used_names:
                used_names.add(region_name)
                regions.append({
                    'RegionID': i,
                    'RegionName': region_name
                })
                break
    
    return regions

# Tạo 10000 bản ghi
regions_data = generate_region_data(10000)

# Chuyển đổi thành DataFrame
df = pd.DataFrame(regions_data)

# Lưu thành file CSV
csv_file = 'region_data.csv'
df.to_csv(csv_file, index=False)

# Tạo file SQL INSERT statements
sql_file = 'region_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for region in regions_data:
        sql = f"INSERT INTO REGION (RegionID, RegionName) VALUES ({region['RegionID']}, N'{region['RegionName']}');\n"
        f.write(sql)

print(f"Đã tạo {len(regions_data)} bản ghi")
print(f"Đã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")