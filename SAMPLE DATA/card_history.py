import csv
from faker import Faker
import random

fake = Faker()

def generate_card_history_data(num_records, num_valid_cards):
    data = []
    card_types = ['Membership', 'Silver', 'Gold']  # Các loại thẻ có thể có
    for i in range(1, num_records + 1):
        history_id = i  # ID tăng dần từ 1
        card_id = f"CARD{random.randint(1, num_valid_cards):05d}"  # Chọn ngẫu nhiên từ danh sách CardID hợp lệ
        status_change_date = fake.date_between(start_date='-2y', end_date='today')
        previous_card_type = random.choice(card_types)
        new_card_type = random.choice([ct for ct in card_types if ct != previous_card_type])
        spending_during_period = round(random.uniform(0, 10000), 2)  # Chi tiêu ngẫu nhiên

        data.append({
            "HistoryID": history_id,
            "CardID": card_id,
            "StatusChangeDate": status_change_date,
            "PreviousCardType": previous_card_type,
            "NewCardType": new_card_type,
            "SpendingDuringPeriod": spending_during_period
        })
    return data

# Giả sử có 10,000 CardID hợp lệ
num_valid_cards = 10000

# Tạo 10,000 dòng dữ liệu
card_history_data = generate_card_history_data(10000, num_valid_cards)

# Ghi dữ liệu vào file CSV
with open('CARD_HISTORY.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=[
        "HistoryID", "CardID", "StatusChangeDate", "PreviousCardType", "NewCardType", "SpendingDuringPeriod"
    ])
    writer.writeheader()
    writer.writerows(card_history_data)

print("File CSV đã được tạo thành công.")