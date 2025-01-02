import random
import csv
import pyodbc

def get_bookings_from_db():
    try:
        conn = pyodbc.connect('Driver={SQL Server};'
                      'Server=DESKTOP-6OT2STG;'
                      'Database=SUSHI_X;'
                      'Trusted_Connection=yes;')
        
        cursor = conn.cursor()
        cursor.execute("""
            SELECT BookingID, DeliveryType, GuestCount, Status 
            FROM ONLINE_BOOKING
            WHERE Status != 'CANCELLED'
        """)
        
        bookings = []
        for row in cursor:
            bookings.append({
                'BookingID': row[0],
                'DeliveryType': row[1],
                'GuestCount': row[2],
                'Status': row[3]
            })
        
        conn.close()
        return bookings
    except Exception as e:
        print(f"Lỗi kết nối database: {str(e)}")
        return []

def get_menu_items():
    try:
        conn = pyodbc.connect('Driver={SQL Server};'
                      'Server=DESKTOP-6OT2STG;'
                      'Database=SUSHI_X;'
                      'Trusted_Connection=yes;')
        
        cursor = conn.cursor()
        cursor.execute("""
            SELECT ItemID, CategoryID, CurrentPrice 
            FROM MENU_ITEM
        """)
        
        items = []
        for row in cursor:
            items.append({
                'ItemID': row[0],
                'CategoryID': row[1],
                'CurrentPrice': float(row[2])
            })
        
        conn.close()
        return items
    except Exception as e:
        print(f"Lỗi kết nối database: {str(e)}")
        return []

def generate_booking_orders(bookings, menu_items):
    booking_orders = []
    
    # Phân loại món ăn theo category
    categorized_items = {}
    for item in menu_items:
        cat = item['CategoryID']
        if cat not in categorized_items:
            categorized_items[cat] = []
        categorized_items[cat].append(item)
    
    for booking in bookings:
        # Số món đặt dựa vào số khách và loại đặt chỗ
        if booking['DeliveryType'] == 'DINE_IN':
            min_items = booking['GuestCount']
            max_items = min_items + 2
        else:
            min_items = max(1, booking['GuestCount'] - 1)
            max_items = booking['GuestCount'] + 1
            
        num_items = random.randint(min_items, max_items)
        
        # Chọn các món cho đơn hàng
        selected_items = []
        
        # Luôn có ít nhất 1 món chính
        main_categories = ['CAT_SUSHI', 'CAT_SASHIMI', 'CAT_MAKI', 'CAT_TEMAKI']
        available_main_cats = [cat for cat in main_categories if cat in categorized_items]
        if available_main_cats:
            main_cat = random.choice(available_main_cats)
            main_dish = random.choice(categorized_items[main_cat])
            selected_items.append(main_dish)
        
        # Thêm món phụ
        remaining_items = num_items - len(selected_items)
        for _ in range(remaining_items):
            cat = random.choice(list(categorized_items.keys()))
            item = random.choice(categorized_items[cat])
            
            attempts = 0
            while item in selected_items and attempts < 5:
                cat = random.choice(list(categorized_items.keys()))
                item = random.choice(categorized_items[cat])
                attempts += 1
            
            if attempts < 5:
                selected_items.append(item)
        
        # Tạo chi tiết đơn hàng
        for item in selected_items:
            if item['CategoryID'] in ['CAT_DRINKS', 'CAT_SOUP']:
                quantity = random.randint(1, booking['GuestCount'])
            elif item['CategoryID'] in ['CAT_SUSHI', 'CAT_SASHIMI']:
                quantity = random.randint(1, 2)
            else:
                quantity = random.randint(1, 3)
                
            notes = ''
            if random.random() < 0.2:  # 20% có ghi chú
                if item['CategoryID'] == 'CAT_SUSHI':
                    notes = random.choice(['No wasabi', 'Extra wasabi', 'Extra ginger'])
                elif item['CategoryID'] == 'CAT_MAKI':
                    notes = random.choice(['No mayo', 'Extra spicy', 'No cucumber'])
                elif item['CategoryID'] == 'CAT_DRINKS':
                    notes = random.choice(['No ice', 'Less ice', 'Extra ice'])
                
            booking_orders.append({
                'BookingID': booking['BookingID'],
                'ItemID': item['ItemID'],
                'Quantity': quantity,
                'UnitPrice': item['CurrentPrice'],
                'Notes': notes
            })
    
    return booking_orders

# Lấy dữ liệu từ database
bookings = get_bookings_from_db()
menu_items = get_menu_items()

if not bookings or not menu_items:
    print("Không thể tạo dữ liệu do thiếu thông tin")
    exit()

print(f"Đã tìm thấy {len(bookings)} đơn đặt chỗ và {len(menu_items)} món ăn")

# Tạo chi tiết đơn hàng
booking_orders = generate_booking_orders(bookings, menu_items)

# Tạo file SQL INSERT statements
sql_file = 'online_booking_orders_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    batch_size = 1000
    for i in range(0, len(booking_orders), batch_size):
        f.write('INSERT INTO ONLINE_BOOKING_ORDER (BookingID, ItemID, Quantity, UnitPrice, Notes) VALUES\n')
        batch = booking_orders[i:i + batch_size]
        values = []
        for order in batch:
            notes = f"N'{order['Notes']}'" if order['Notes'] else 'NULL'
            values.append(
                f"({order['BookingID']}, '{order['ItemID']}', {order['Quantity']}, {order['UnitPrice']}, {notes})"
            )
        f.write(',\n'.join(values) + ';\n\n')

# Thống kê
print(f"Đã tạo {len(booking_orders)} chi tiết đơn hàng")

# Thống kê số món trung bình mỗi đơn
orders_per_booking = {}
for order in booking_orders:
    booking_id = order['BookingID']
    if booking_id not in orders_per_booking:
        orders_per_booking[booking_id] = []
    orders_per_booking[booking_id].append(order['Quantity'])

avg_items = sum(len(items) for items in orders_per_booking.values()) / len(orders_per_booking)
avg_quantity = sum(sum(items) for items in orders_per_booking.values()) / len(orders_per_booking)

print(f"\nTrung bình mỗi đơn:")
print(f"- Số loại món: {avg_items:.1f}")
print(f"- Tổng số món: {avg_quantity:.1f}")

print(f"\nĐã lưu câu lệnh SQL vào file: {sql_file}")