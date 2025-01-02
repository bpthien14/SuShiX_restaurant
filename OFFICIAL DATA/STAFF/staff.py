import random
import uuid
import csv
from datetime import datetime, timedelta

# Đọc dữ liệu từ các file CSV đã tạo trước đó
def get_department_ids():
    departments = []
    try:
        with open('departments_data.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                departments.append(row['DepartmentID'])
    except FileNotFoundError:
        departments = ['DEPT_KITCHEN', 'DEPT_SERVICE', 'DEPT_MGR', 'DEPT_ADMIN']
    return departments

def get_branch_ids():
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

def get_user_ids():
    users = []
    try:
        with open('users_data.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                if row['Role'] in ['STAFF', 'MANAGER']:
                    users.append(row['UserID'])
    except FileNotFoundError:
        print("Không tìm thấy file users_data.csv")
        return []
    return users

# Danh sách họ, tên đệm và tên Việt Nam
ho = ['Nguyễn', 'Trần', 'Lê', 'Phạm', 'Hoàng', 'Huỳnh', 'Phan', 'Vũ', 'Võ', 'Đặng', 'Bùi', 'Đỗ']
ten_dem = ['Văn', 'Thị', 'Hữu', 'Đức', 'Minh', 'Hoàng', 'Tuấn', 'Anh', 'Hồng', 'Thanh']
ten = ['Nam', 'Hương', 'Anh', 'Hoàng', 'Minh', 'Hoa', 'Thảo', 'Đức', 'Phương', 'Linh']

def generate_phone_numbers(count):
    """Tạo trước một tập hợp số điện thoại không trùng lặp"""
    phone_numbers = set()
    prefixes = ['03', '05', '07', '08', '09']
    
    while len(phone_numbers) < count:
        prefix = random.choice(prefixes)
        number = ''.join(str(random.randint(0, 9)) for _ in range(8))
        phone_numbers.add(f"{prefix}{number}")
    
    return list(phone_numbers)

def generate_staff_data(num_records, department_ids, branch_ids, user_ids):
    if not department_ids or not branch_ids or not user_ids:
        print("Thiếu dữ liệu từ các bảng liên quan!")
        return []

    # Tạo trước tập hợp số điện thoại
    phone_numbers = generate_phone_numbers(num_records)
    staff = []
    used_users = set()
    
    for i in range(num_records):
        attempts = 0
        while attempts < 100:  # Giới hạn số lần thử
            user_id = random.choice(user_ids)
            
            if user_id not in used_users:
                birthdate = datetime.now() - timedelta(days=random.randint(20*365, 50*365))
                start_date = birthdate + timedelta(days=random.randint(18*365, 30*365))
                
                # 90% nhân viên còn làm việc
                end_date = None
                if random.random() < 0.1:
                    end_date = start_date + timedelta(days=random.randint(30, 365*5))
                
                staff.append({
                    'StaffID': str(uuid.uuid4()),
                    'DepartmentID': random.choice(department_ids),
                    'BranchID': random.choice(branch_ids),
                    'FullName': f"{random.choice(ho)} {random.choice(ten_dem)} {random.choice(ten)}",
                    'Gender': random.choice(['Nam', 'Nữ']),
                    'BirthDate': birthdate.strftime('%Y-%m-%d'),
                    'StartDate': start_date.strftime('%Y-%m-%d'),
                    'EndDate': end_date.strftime('%Y-%m-%d') if end_date else None,
                    'Salary': random.randint(5000000, 20000000),
                    'Address': f"{random.randint(1, 999)} {random.choice(['Lê Lợi', 'Nguyễn Huệ', 'Trần Hưng Đạo'])}, {random.choice(['Q1', 'Q2', 'Q3'])}, {random.choice(['Hà Nội', 'TP.HCM', 'Đà Nẵng'])}",
                    'PhoneNumber': phone_numbers[i],
                    'UserID': user_id
                })
                
                used_users.add(user_id)
                break
            
            attempts += 1
        
        if attempts >= 100:
            print(f"Warning: Không thể tạo thêm nhân viên độc nhất sau {len(staff)} bản ghi")
            break
    
    return staff

# Lấy dữ liệu từ các bảng liên quan
department_ids = get_department_ids()
branch_ids = get_branch_ids()
user_ids = get_user_ids()

# Tạo dữ liệu nhân viên
staff_data = generate_staff_data(10000, department_ids, branch_ids, user_ids)

if staff_data:
    # Lưu thành file CSV
    csv_file = 'staff_data.csv'
    with open(csv_file, 'w', newline='', encoding='utf-8') as f:
        writer = csv.DictWriter(f, fieldnames=[
            'StaffID', 'DepartmentID', 'BranchID', 'FullName', 'Gender',
            'BirthDate', 'StartDate', 'EndDate', 'Salary', 'Address',
            'PhoneNumber', 'UserID'
        ])
        writer.writeheader()
        writer.writerows(staff_data)

    # Tạo file SQL INSERT statements
    sql_file = 'staff_insert.sql'
    with open(sql_file, 'w', encoding='utf-8') as f:
        f.write('USE SUSHI_X;\nGO\n\n')
        for staff in staff_data:
            end_date = f"'{staff['EndDate']}'" if staff['EndDate'] else 'NULL'
            sql = f"INSERT INTO STAFF (StaffID, DepartmentID, BranchID, FullName, Gender, "
            sql += f"BirthDate, StartDate, EndDate, Salary, Address, PhoneNumber, UserID)\n"
            sql += f"VALUES ('{staff['StaffID']}', '{staff['DepartmentID']}', '{staff['BranchID']}', "
            sql += f"N'{staff['FullName']}', N'{staff['Gender']}', '{staff['BirthDate']}', "
            sql += f"'{staff['StartDate']}', {end_date}, {staff['Salary']}, N'{staff['Address']}', "
            sql += f"'{staff['PhoneNumber']}', '{staff['UserID']}');\n"
            f.write(sql)

    print(f"Đã tạo {len(staff_data)} bản ghi")
    print(f"Đã lưu dữ liệu vào file CSV: {csv_file}")
    print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")
else:
    print("Không thể tạo dữ liệu do thiếu thông tin từ các bảng liên quan")