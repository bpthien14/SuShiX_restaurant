import random
import csv
from datetime import datetime, timedelta

def get_staff_data():
    staff_data = []
    try:
        with open('staff_data.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                start_date = datetime.strptime(row['StartDate'], '%Y-%m-%d')
                end_date = datetime.strptime(row['EndDate'], '%Y-%m-%d') if row['EndDate'] else None
                
                # Chỉ lấy nhân viên có ngày bắt đầu trong quá khứ
                if start_date <= datetime.now():
                    staff_data.append({
                        'StaffID': row['StaffID'],
                        'StartDate': start_date,
                        'EndDate': end_date
                    })
    except FileNotFoundError:
        print("Không tìm thấy file staff_data.csv")
        return []
    return staff_data

def get_branch_ids():
    branch_ids = []
    try:
        with open('branches_data.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                branch_ids.append(row['BranchID'])
    except FileNotFoundError:
        print("Không tìm thấy file branches_data.csv")
        return []
    return branch_ids

def generate_work_history(num_records, staff_data, branch_ids):
    work_history = []
    used_combinations = set()  # Để tránh trùng lặp StaffID-BranchID-StartDate
    current_date = datetime.now()
    
    for i in range(num_records):
        attempts = 0
        while attempts < 100:  # Giới hạn số lần thử
            staff = random.choice(staff_data)
            branch_id = random.choice(branch_ids)
            
            # Tính khoảng thời gian hợp lệ cho start_date
            max_start_date = min(current_date, staff['EndDate'] if staff['EndDate'] else current_date)
            days_range = (max_start_date - staff['StartDate']).days
            
            if days_range <= 0:
                attempts += 1
                continue
                
            # Tạo ngày bắt đầu
            start_date = staff['StartDate'] + timedelta(days=random.randint(0, days_range))
            
            # Tính khoảng thời gian hợp lệ cho end_date
            max_end_date = staff['EndDate'] if staff['EndDate'] else current_date
            days_until_end = (max_end_date - start_date).days
            
            # 70% có ngày kết thúc, 30% là công việc hiện tại
            if random.random() < 0.7 and days_until_end > 30:
                end_date = start_date + timedelta(days=random.randint(30, days_until_end))
            else:
                end_date = None
            
            # Tạo key để kiểm tra trùng lặp
            key = (staff['StaffID'], branch_id, start_date.strftime('%Y-%m-%d'))
            
            if key not in used_combinations:
                work_history.append({
                    'HistoryID': i + 1,
                    'StaffID': staff['StaffID'],
                    'BranchID': branch_id,
                    'StartDate': start_date.strftime('%Y-%m-%d'),
                    'EndDate': end_date.strftime('%Y-%m-%d') if end_date else None
                })
                used_combinations.add(key)
                break
                
            attempts += 1
            
        if attempts >= 100:
            print(f"Warning: Không thể tạo thêm bản ghi độc nhất sau {len(work_history)} bản ghi")
            break
    
    return work_history

# Lấy dữ liệu từ các bảng liên quan
staff_data = get_staff_data()
branch_ids = get_branch_ids()

if not staff_data or not branch_ids:
    print("Không thể tạo dữ liệu do thiếu thông tin từ các bảng liên quan")
    exit()

print(f"Đã tìm thấy {len(staff_data)} nhân viên và {len(branch_ids)} chi nhánh")

# Tạo dữ liệu lịch sử làm việc
work_history_data = generate_work_history(10000, staff_data, branch_ids)

# Lưu thành file CSV
csv_file = 'staff_work_history.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=[
        'HistoryID', 'StaffID', 'BranchID', 'StartDate', 'EndDate'
    ])
    writer.writeheader()
    writer.writerows(work_history_data)

# Tạo file SQL INSERT statements
sql_file = 'staff_work_history_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for history in work_history_data:
        end_date = f"'{history['EndDate']}'" if history['EndDate'] else 'NULL'
        sql = f"INSERT INTO STAFF_WORK_HISTORY (HistoryID, StaffID, BranchID, StartDate, EndDate) "
        sql += f"VALUES ({history['HistoryID']}, '{history['StaffID']}', "
        sql += f"'{history['BranchID']}', '{history['StartDate']}', {end_date});\n"
        f.write(sql)

print(f"Đã tạo {len(work_history_data)} bản ghi")
print(f"Đã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")