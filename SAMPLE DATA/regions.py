import csv
from faker import Faker

fake = Faker()

def clean_text(text):
    """Loại bỏ dấu phẩy khỏi chuỗi văn bản."""
    return text.replace(',', '')

def generate_region_data(num_records):
    data = []
    for i in range(1, num_records + 1):
        region_id = i  # ID tăng dần từ 1
        region_name = clean_text(fake.city())  # Tên ngẫu nhiên, đã loại bỏ dấu phẩy
        data.append({
            "RegionID": region_id,
            "RegionName": region_name
        })
    return data

# Tạo 10,000 dòng dữ liệu
region_data = generate_region_data(10000)

# Ghi dữ liệu vào file CSV
with open('REGION.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=["RegionID", "RegionName"])
    writer.writeheader()
    writer.writerows(region_data)

print("File CSV đã được tạo thành công.")