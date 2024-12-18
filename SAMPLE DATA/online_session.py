import csv
from faker import Faker
import random

fake = Faker()

def generate_online_session_data(num_records, num_users):
    data = []
    device_types = ['Desktop', 'Mobile', 'Tablet']  # Các loại thiết bị có thể có
    internal_sources = ['Website', 'App', 'API']  # Các nguồn nội bộ có thể có

    for i in range(1, num_records + 1):
        session_id = f"SESSION{i:05d}"  # Tạo ID theo định dạng SESSION00001, SESSION00002, ...
        user_id = f"USR{random.randint(1, num_users):05d}"  # Giả sử có num_users UserID hợp lệ
        session_start = fake.date_time_between(start_date='-1y', end_date='now')
        session_duration = random.randint(1, 7200)  # Thời gian phiên ngẫu nhiên từ 1 giây đến 2 giờ
        device_type = random.choice(device_types)
        ip_address = fake.ipv4()
        internal_source = random.choice(internal_sources)

        data.append({
            "SessionID": session_id,
            "UserID": user_id,
            "SessionStart": session_start,
            "SessionDuration": session_duration,
            "DeviceType": device_type,
            "IPAddress": ip_address,
            "InternalSource": internal_source
        })
    return data

# Giả sử có 10,000 UserID hợp lệ
num_users = 10000

# Tạo 10,000 dòng dữ liệu
online_session_data = generate_online_session_data(10000, num_users)

# Ghi dữ liệu vào file CSV
with open('ONLINE_SESSION.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=[
        "SessionID", "UserID", "SessionStart", "SessionDuration", "DeviceType", "IPAddress", "InternalSource"
    ])
    writer.writeheader()
    writer.writerows(online_session_data)

print("File CSV đã được tạo thành công.")