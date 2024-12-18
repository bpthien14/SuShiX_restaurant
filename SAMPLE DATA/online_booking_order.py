import csv
import random

def generate_online_booking_order_data1(num_records):
    data = set()  # Sử dụng tập hợp để đảm bảo tính duy nhất
    while len(data) < num_records:
        booking_id = random.randint(1, 5000)
        item_id = f"ITEM{random.randint(5001, 10000):05d}"
        quantity = random.randint(1, 10)

        # Thêm vào tập hợp nếu cặp (BookingID, ItemID) là duy nhất
        data.add((booking_id, item_id, quantity))

    # Chuyển đổi tập hợp thành danh sách từ điển
    return [{"BookingID": b_id, "ItemID": i_id, "Quantity": qty} for b_id, i_id, qty in data]

def generate_online_booking_order_data2(num_records):
    data = set()  # Sử dụng tập hợp để đảm bảo tính duy nhất
    while len(data) < num_records:
        booking_id = random.randint(5001, 10000)
        item_id = f"ITEM{random.randint(1, 5000):05d}"
        quantity = random.randint(1, 10)

        # Thêm vào tập hợp nếu cặp (BookingID, ItemID) là duy nhất
        data.add((booking_id, item_id, quantity))

    # Chuyển đổi tập hợp thành danh sách từ điển
    return [{"BookingID": b_id, "ItemID": i_id, "Quantity": qty} for b_id, i_id, qty in data]



# Tạo 10,000 dòng dữ liệu
online_booking_order_data1 = generate_online_booking_order_data1(5000)
online_booking_order_data2 = generate_online_booking_order_data2(5000)

# Ghi dữ liệu vào file CSV
with open('online_booking_order.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=["BookingID", "ItemID", "Quantity"])
    writer.writeheader()
    writer.writerows(online_booking_order_data1)
    writer.writerows(online_booking_order_data2)

print("File CSV đã được tạo thành công.")