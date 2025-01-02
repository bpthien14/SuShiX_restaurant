import random
import uuid
import csv
from datetime import datetime, timedelta

def get_new_user_ids():
    new_users = []
    with open('additional_managers_insert.sql', 'r', encoding='utf-8') as f:
        for line in f:
            if 'VALUES' in line:
                user_id = line.split("'")[1]  # Lấy UserID từ câu lệnh INSERT
                new_users.append(user_id)
    return new_users

def get_branch_ids():
    branches = []
    with open('branches_data.csv', 'r', encoding='utf-8') as f:
        reader = csv.DictReader(f)
        for row in reader:
            if row['ManagerID'] is None or row['ManagerID'] == '':
                branches.append(row['BranchID'])
    return branches

def generate_staff_data(user_ids):
    staff = []
    ho = ['Nguyễn', 'Trần', 'Lê', 'Phạm', 'Hoàng', 'Huỳnh', 'Phan', 'Vũ', 'Võ', 'Đặng']
    ten_dem = ['Văn', 'Thị', 'Hữu', 'Đức', 'Minh', 'Hoàng', 'Tuấn', 'Anh', 'Hồng']
    ten = ['Nam', 'Hương', 'Anh', 'Hoàng', 'Minh', 'Hoa', 'Thảo', 'Đức', 'Phương']
    
    for user_id in user_ids:
        birthdate = datetime.now() - timedelta(days=random.randint(35*365, 50*365))
        start_date = birthdate + timedelta(days=random.randint(20*365, 30*365))
        
        staff.append({
            'StaffID': str(uuid.uuid4()),
            'DepartmentID': 'DEPT_MGR',  # Phòng ban quản lý
            'BranchID': None,  # Sẽ được update sau
            'FullName': f"{random.choice(ho)} {random.choice(ten_dem)} {random.choice(ten)}",
            'Gender': random.choice(['Nam', 'Nữ']),
            'BirthDate': birthdate.strftime('%Y-%m-%d'),
            'StartDate': start_date.strftime('%Y-%m-%d'),
            'EndDate': None,
            'Salary': random.randint(15000000, 25000000),  # Lương manager cao hơn
            'Address': f"{random.randint(1, 999)} {random.choice(['Lê Lợi', 'Nguyễn Huệ', 'Trần Hưng Đạo'])}, {random.choice(['Q1', 'Q2', 'Q3'])}, {random.choice(['Hà Nội', 'TP.HCM', 'Đà Nẵng'])}",
            'PhoneNumber': f"0{random.choice(['9', '8', '7'])}{random.randint(10000000, 99999999)}",
            'UserID': user_id
        })
    
    return staff

# Lấy UserID của các manager mới
new_user_ids = get_new_user_ids()

# Tạo dữ liệu STAFF cho các manager mới
new_staff = generate_staff_data(new_user_ids)

# Lưu thành file CSV
csv_file = 'additional_managers_staff.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=[
        'StaffID', 'DepartmentID', 'BranchID', 'FullName', 'Gender',
        'BirthDate', 'StartDate', 'EndDate', 'Salary', 'Address',
        'PhoneNumber', 'UserID'
    ])
    writer.writeheader()
    writer.writerows(new_staff)

# Tạo file SQL INSERT
sql_file = 'additional_managers_staff_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for staff in new_staff:
        sql = f"INSERT INTO STAFF (StaffID, DepartmentID, BranchID, FullName, Gender, "
        sql += f"BirthDate, StartDate, EndDate, Salary, Address, PhoneNumber, UserID)\n"
        sql += f"VALUES ('{staff['StaffID']}', '{staff['DepartmentID']}', NULL, "
        sql += f"N'{staff['FullName']}', N'{staff['Gender']}', '{staff['BirthDate']}', "
        sql += f"'{staff['StartDate']}', NULL, {staff['Salary']}, N'{staff['Address']}', "
        sql += f"'{staff['PhoneNumber']}', '{staff['UserID']}');\n"
        f.write(sql)

print(f"Đã tạo {len(new_staff)} bản ghi STAFF cho managers mới")
print(f"Đã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")