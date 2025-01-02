import random
import pyodbc
from datetime import datetime, timedelta

def get_booking_details():
    try:
        conn = pyodbc.connect('Driver={SQL Server};'
                      'Server=DESKTOP-6OT2STG;'
                      'Database=SUSHI_X;'
                      'Trusted_Connection=yes;')
        
        cursor = conn.cursor()
        # Lấy thông tin đơn và tổng tiền món
        cursor.execute("""
            SELECT 
                b.BookingID,
                b.CustomerID,
                b.DeliveryFee,
                b.Status,
                SUM(bo.Quantity * bo.UnitPrice) as SubTotal
            FROM ONLINE_BOOKING b
            JOIN ONLINE_BOOKING_ORDER bo ON b.BookingID = bo.BookingID
            WHERE b.Status != 'CANCELLED'
            GROUP BY b.BookingID, b.CustomerID, b.DeliveryFee, b.Status
        """)
        
        bookings = []
        for row in cursor:
            bookings.append({
                'BookingID': row[0],
                'CustomerID': row[1],
                'DeliveryFee': row[2],
                'Status': row[3],
                'SubTotal': row[4]
            })
        
        # Lấy thông tin thẻ thành viên
        cursor.execute("""
            SELECT CardID, CustomerID, CardType 
            FROM MEMBERSHIP_CARD
        """)
        
        member_cards = {}
        for row in cursor:
            if row[1] not in member_cards:
                member_cards[row[1]] = []
            member_cards[row[1]].append({
                'CardID': row[0],
                'CardType': row[2]
            })
        
        conn.close()
        return bookings, member_cards
    except Exception as e:
        print(f"Lỗi kết nối database: {str(e)}")
        return [], {}

def calculate_discount(card_type, subtotal):
    if not card_type:
        return 0
    
    # Mức giảm giá theo loại thẻ thành viên
    discount_rates = {
        'MEMBERSHIP': 0.03,  # 3%
        'SILVER': 0.07,     # 7%
        'GOLD': 0.12       # 12%
    }
    
    return subtotal * discount_rates.get(card_type, 0)

def generate_invoices(bookings, member_cards):
    invoices = []
    payment_methods = ['CASH', 'CREDIT_CARD', 'MOMO', 'BANK_TRANSFER']
    
    for booking in bookings:
        # Xác định thẻ thành viên (nếu có)
        card_info = None
        if booking['CustomerID'] in member_cards:
            if random.random() < 0.8:  # 80% khách hàng có thẻ sẽ dùng thẻ
                card_info = random.choice(member_cards[booking['CustomerID']])
        
        subtotal = booking['SubTotal']
        delivery_fee = booking['DeliveryFee'] or 0
        
        # Tính các khoản phí và giảm giá
        service_charge = subtotal * 0.05  # 5% phí dịch vụ
        discount = calculate_discount(card_info['CardType'] if card_info else None, subtotal)
        final_amount = subtotal + service_charge + delivery_fee - discount
        
        # Xác định trạng thái thanh toán
        if booking['Status'] == 'COMPLETED':
            payment_status = 'PAID'
        elif booking['Status'] == 'CONFIRMED':
            payment_status = random.choices(
                ['PAID', 'PENDING'],
                weights=[0.7, 0.3]  # 70% đã thanh toán, 30% chưa
            )[0]
        else:
            payment_status = 'PENDING'
        
        # Tạo hóa đơn
        invoice = {
            'BookingID': booking['BookingID'],
            'CardID': card_info['CardID'] if card_info else None,
            'TotalAmount': subtotal,
            'Discount': discount,
            'ServiceCharge': service_charge,
            'DeliveryFee': delivery_fee,
            'FinalAmount': final_amount,
            'PaymentMethod': random.choice(payment_methods) if payment_status == 'PAID' else None,
            'PaymentStatus': payment_status,
            'CreatedAt': datetime.now() - timedelta(minutes=random.randint(0, 60))
        }
        
        invoices.append(invoice)
    
    return invoices

# Lấy dữ liệu từ database
bookings, member_cards = get_booking_details()

if not bookings:
    print("Không thể tạo dữ liệu do thiếu thông tin đơn hàng")
    exit()

# Tạo hóa đơn
invoices = generate_invoices(bookings, member_cards)

# Tạo file SQL INSERT statements
sql_file = 'booking_invoices_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    batch_size = 1000
    for i in range(0, len(invoices), batch_size):
        f.write('INSERT INTO BOOKING_INVOICE (BookingID, CardID, TotalAmount, Discount, ServiceCharge, ' +
                'DeliveryFee, FinalAmount, PaymentMethod, PaymentStatus, CreatedAt) VALUES\n')
        batch = invoices[i:i + batch_size]
        values = []
        for inv in batch:
            card_id = f"'{inv['CardID']}'" if inv['CardID'] else 'NULL'
            payment_method = f"'{inv['PaymentMethod']}'" if inv['PaymentMethod'] else 'NULL'
            values.append(
                f"({inv['BookingID']}, {card_id}, {inv['TotalAmount']:.2f}, " +
                f"{inv['Discount']:.2f}, {inv['ServiceCharge']:.2f}, {inv['DeliveryFee']:.2f}, " +
                f"{inv['FinalAmount']:.2f}, {payment_method}, '{inv['PaymentStatus']}', " +
                f"'{inv['CreatedAt'].strftime('%Y-%m-%d %H:%M:%S')}')"
            )
        f.write(',\n'.join(values) + ';\n\n')

# Thống kê
print(f"Đã tạo {len(invoices)} hóa đơn")

# Thống kê theo trạng thái thanh toán
payment_stats = {}
for inv in invoices:
    status = inv['PaymentStatus']
    payment_stats[status] = payment_stats.get(status, 0) + 1

print("\nPhân bổ theo trạng thái thanh toán:")
for status, count in payment_stats.items():
    print(f"{status}: {count} hóa đơn ({(count/len(invoices))*100:.1f}%)")

# Thống kê sử dụng thẻ thành viên
member_count = sum(1 for inv in invoices if inv['CardID'])
print(f"\nSử dụng thẻ thành viên: {member_count} hóa đơn ({(member_count/len(invoices))*100:.1f}%)")

print(f"\nĐã lưu câu lệnh SQL vào file: {sql_file}")