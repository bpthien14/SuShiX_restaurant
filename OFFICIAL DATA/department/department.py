import uuid
import csv

# Danh sách các phòng ban chuẩn cho chuỗi nhà hàng
departments = [
    # Các phòng ban quản lý
    {
        'DepartmentID': 'DEPT_BOD',
        'DepartmentName': 'Ban Giám đốc'
    },
    {
        'DepartmentID': 'DEPT_MGR',
        'DepartmentName': 'Quản lý Chi nhánh'
    },
    {
        'DepartmentID': 'DEPT_ADM',
        'DepartmentName': 'Hành chính'
    },
    {
        'DepartmentID': 'DEPT_HR',
        'DepartmentName': 'Nhân sự'
    },
    {
        'DepartmentID': 'DEPT_FIN',
        'DepartmentName': 'Tài chính - Kế toán'
    },
    
    # Các phòng ban vận hành
    {
        'DepartmentID': 'DEPT_KIT',
        'DepartmentName': 'Bếp'
    },
    {
        'DepartmentID': 'DEPT_SVC',
        'DepartmentName': 'Phục vụ'
    },
    {
        'DepartmentID': 'DEPT_BAR',
        'DepartmentName': 'Quầy bar'
    },
    {
        'DepartmentID': 'DEPT_CSR',
        'DepartmentName': 'Chăm sóc khách hàng'
    },
    
    # Các phòng ban hỗ trợ
    {
        'DepartmentID': 'DEPT_MKT',
        'DepartmentName': 'Marketing'
    },
    {
        'DepartmentID': 'DEPT_IT',
        'DepartmentName': 'Công nghệ thông tin'
    },
    {
        'DepartmentID': 'DEPT_SEC',
        'DepartmentName': 'Bảo vệ'
    },
    {
        'DepartmentID': 'DEPT_LOG',
        'DepartmentName': 'Kho vận'
    },
    {
        'DepartmentID': 'DEPT_PUR',
        'DepartmentName': 'Thu mua'
    },
    {
        'DepartmentID': 'DEPT_QC',
        'DepartmentName': 'Kiểm soát chất lượng'
    }
]

# Lưu thành file CSV
csv_file = 'departments_data.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=['DepartmentID', 'DepartmentName'])
    writer.writeheader()
    writer.writerows(departments)

# Tạo file SQL INSERT statements
sql_file = 'departments_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for dept in departments:
        sql = f"INSERT INTO DEPARTMENT (DepartmentID, DepartmentName) "
        sql += f"VALUES ('{dept['DepartmentID']}', N'{dept['DepartmentName']}');\n"
        f.write(sql)

print(f"Đã tạo {len(departments)} phòng ban")
print(f"Đã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")