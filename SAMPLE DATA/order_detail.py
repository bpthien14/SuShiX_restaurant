import csv
import random

def generate_order_detail_data(num_records, num_orders, num_items):
    data = set()  # Sử dụng tập hợp để đảm bảo tính duy nhất
    while len(data) < num_records:
        order_id = f"ORD{random.randint(1, num_orders):05d}"  # Giả sử có num_orders OrderID hợp lệ
        item_id = f"ITEM{random.randint(1, num_items):05d}"  # Giả sử có num_items ItemID hợp lệ
        quantity = random.randint(1, 10)  # Số lượng ngẫu nhiên từ 1 đến 10

        # Thêm vào tập hợp nếu cặp (OrderID, ItemID) là duy nhất
        data.add((order_id, item_id, quantity))

    # Chuyển đổi tập hợp thành danh sách từ điển
    return [{"OrderID": o_id, "ItemID": i_id, "Quantity": qty} for o_id, i_id, qty in data]

# Giả sử có 10,000 OrderID và 10,000 ItemID hợp lệ
num_orders = 10000
num_items = 10000

# Tạo 10,000 dòng dữ liệu
order_detail_data = generate_order_detail_data(10000, num_orders, num_items)

# Ghi dữ liệu vào file CSV
with open('ORDER_DETAIL.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=["OrderID", "ItemID", "Quantity"])
    writer.writeheader()
    writer.writerows(order_detail_data)

print("File CSV đã được tạo thành công.")