import random
import uuid
import csv

# Đọc UserID từ file users_data.csv đã tạo trước đó
def get_customer_userids():
    customer_userids = []
    with open('users_data.csv', 'r', encoding='utf-8') as f:
        reader = csv.DictReader(f)
        for row in reader:
            if row['Role'] == 'CUSTOMER':
                customer_userids.append(row['UserID'])
    return customer_userids

# Danh sách họ, tên đệm và tên
ho = ['Nguyễn', 'Trần', 'Lê', 'Phạm', 'Hoàng', 'Huỳnh', 'Phan', 'Vũ', 'Võ', 'Đặng', 'Bùi', 'Đỗ']
ten_dem = ['Văn', 'Thị', 'Hữu', 'Đức', 'Minh', 'Hoàng', 'Tuấn', 'Anh', 'Hồng', 'Thanh', 'Quang']
ten = ['Nam', 'Hương', 'Anh', 'Hoàng', 'Minh', 'Hoa', 'Thảo', 'Đức', 'Phương', 'Linh', 'Tú', 'Hùng']

def generate_phone_number():
    # Số điện thoại Việt Nam format: 03x, 05x, 07x, 08x, 09x
    prefixes = ['03', '05', '07', '08', '09']
    prefix = random.choice(prefixes)
    suffix = ''.join(random.choices('0123456789', k=8))
    return prefix + suffix

def generate_email(full_name):
    # Tạo email từ tên
    email_name = full_name.lower().replace(' ', '.')
    email_name = ''.join(c for c in email_name if c.isalnum() or c == '.')
    domains = ['gmail.com', 'yahoo.com', 'hotmail.com', 'outlook.com']
    return f"{email_name}{random.randint(1,999)}@{random.choice(domains)}"

def generate_id_number():
    # CCCD 12 số
    return ''.join(random.choices('0123456789', k=12))

def generate_customers_data(customer_userids):
    customers = []
    used_phones = set()
    used_emails = set()
    used_ids = set()
    
    for userid in customer_userids:
        while True:
            # Tạo họ tên đầy đủ
            full_name = f"{random.choice(ho)} {random.choice(ten_dem)} {random.choice(ten)}"
            
            # Tạo số điện thoại không trùng
            phone = generate_phone_number()
            
            # Tạo email không trùng
            email = generate_email(full_name)
            
            # Tạo CCCD không trùng
            id_number = generate_id_number()
            
            # Kiểm tra trùng lặp
            if phone not in used_phones and email not in used_emails and id_number not in used_ids:
                used_phones.add(phone)
                used_emails.add(email)
                used_ids.add(id_number)
                
                customers.append({
                    'CustomerID': str(uuid.uuid4()),
                    'FullName': full_name,
                    'PhoneNumber': phone,
                    'Email': email,
                    'IDNumber': id_number,
                    'Gender': random.choice(['Nam', 'Nữ']),
                    'UserID': userid
                })
                break
    
    return customers

# Lấy danh sách UserID của các customer
customer_userids = get_customer_userids()

# Tạo dữ liệu customer
customers_data = generate_customers_data(customer_userids)

# Lưu thành file CSV
csv_file = 'customers_data.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=['CustomerID', 'FullName', 'PhoneNumber', 'Email', 'IDNumber', 'Gender', 'UserID'])
    writer.writeheader()
    writer.writerows(customers_data)

# Tạo file SQL INSERT statements
sql_file = 'customers_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for customer in customers_data:
        sql = f"INSERT INTO CUSTOMER (CustomerID, FullName, PhoneNumber, Email, IDNumber, Gender, UserID) \n"
        sql += f"VALUES ('{customer['CustomerID']}', N'{customer['FullName']}', '{customer['PhoneNumber']}', "
        sql += f"'{customer['Email']}', '{customer['IDNumber']}', N'{customer['Gender']}', '{customer['UserID']}');\n"
        f.write(sql)

print(f"Đã tạo {len(customers_data)} bản ghi")
print(f"Đã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")