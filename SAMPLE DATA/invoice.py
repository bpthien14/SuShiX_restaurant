import csv
import random
from faker import Faker

fake = Faker()

def generate_invoice_data(num_records, num_orders, num_cards):
    data = []
    for i in range(1, num_records + 1):
        invoice_id = f"INV{i:05d}"  # Tạo ID theo định dạng INV00001, INV00002, ...
        order_id = f"ORD{random.randint(1, num_orders):05d}"  # Giả sử có num_orders OrderID hợp lệ
        card_id = f"CARD{random.randint(1, num_cards):05d}"  # Giả sử có num_cards CardID hợp lệ
        total_amount = round(random.uniform(50, 500), 2)  # Tổng số tiền ngẫu nhiên
        discount = round(random.uniform(0, 50), 2)  # Giảm giá ngẫu nhiên
        final_amount = round(total_amount - discount, 2)  # Số tiền cuối cùng
        created_at = fake.date_between(start_date='-1y', end_date='today')

        data.append({
            "InvoiceID": invoice_id,
            "OrderID": order_id,
            "CardID": card_id,
            "TotalAmount": total_amount,
            "Discount": discount,
            "FinalAmount": final_amount,
            "CreatedAt": created_at
        })
    return data

# Giả sử có 10,000 OrderID và 10,000 CardID hợp lệ
num_orders = 10000
num_cards = 10000

# Tạo 10,000 dòng dữ liệu
invoice_data = generate_invoice_data(10000, num_orders, num_cards)

# Ghi dữ liệu vào file CSV
with open('INVOICE.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=[
        "InvoiceID", "OrderID", "CardID", "TotalAmount", "Discount", "FinalAmount", "CreatedAt"
    ])
    writer.writeheader()
    writer.writerows(invoice_data)

print("File CSV đã được tạo thành công.")