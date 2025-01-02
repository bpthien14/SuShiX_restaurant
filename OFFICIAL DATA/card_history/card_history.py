import random
import csv
from datetime import datetime, timedelta

def get_membership_cards():
    cards = []
    try:
        with open('membership_cards.csv', 'r', encoding='utf-8') as f:
            reader = csv.DictReader(f)
            for row in reader:
                cards.append({
                    'CardID': row['CardID'],
                    'CardType': row['CardType'],
                    'RegistrationDate': datetime.strptime(row['RegistrationDate'], '%Y-%m-%d'),
                    'AccumulatedPoints': float(row['AccumulatedPoints'])
                })
    except FileNotFoundError:
        print("Không tìm thấy file membership_cards.csv")
        return []
    return cards

def generate_card_history(cards):
    history = []
    history_id = 1
    current_date = datetime.now()

    for card in cards:
        card_histories = []
        current_type = 'MEMBERSHIP'  # Mọi thẻ đều bắt đầu từ MEMBERSHIP
        current_date = card['RegistrationDate']
        
        # Tính toán các mốc thay đổi hạng thẻ
        total_points = card['AccumulatedPoints']
        points_per_period = total_points / 4  # Chia điểm thành 4 giai đoạn
        
        # Thời gian giữa các thay đổi
        time_periods = 4
        days_per_period = 90  # Khoảng 3 tháng một lần thay đổi
        
        accumulated_points = 0
        for period in range(time_periods):
            period_points = random.uniform(0, points_per_period * 1.5)
            accumulated_points += period_points
            
            # Xác định hạng thẻ mới dựa trên điểm tích lũy
            new_type = current_type
            if accumulated_points >= 100:  # 10tr VND
                if random.random() < 0.7:  # 70% cơ hội lên GOLD nếu đủ điểm
                    new_type = 'GOLD'
                else:
                    new_type = 'SILVER'
            elif accumulated_points >= 50:  # 5tr VND
                new_type = 'SILVER'
            elif accumulated_points < 50 and current_type != 'MEMBERSHIP':
                new_type = 'SILVER' if current_type == 'GOLD' else 'MEMBERSHIP'
            
            # Nếu có thay đổi hạng thẻ, tạo bản ghi lịch sử
            if new_type != current_type:
                change_date = current_date + timedelta(days=days_per_period * period)
                if change_date <= datetime.now():  # Chỉ lưu các thay đổi trong quá khứ
                    card_histories.append({
                        'HistoryID': history_id,
                        'CardID': card['CardID'],
                        'StatusChangeDate': change_date.strftime('%Y-%m-%d'),
                        'PreviousCardType': current_type,
                        'NewCardType': new_type,
                        'SpendingDuringPeriod': round(period_points * 100000, 2)  # Chuyển điểm thành tiền
                    })
                    history_id += 1
                    current_type = new_type
        
        # Thêm các lịch sử hợp lệ vào danh sách chính
        history.extend(card_histories)
    
    return history

# Lấy dữ liệu thẻ thành viên
membership_cards = get_membership_cards()

if not membership_cards:
    print("Không thể tạo dữ liệu do thiếu thông tin từ bảng MEMBERSHIP_CARD")
    exit()

# Tạo dữ liệu lịch sử thẻ
card_history_data = generate_card_history(membership_cards)

# Lưu thành file CSV
csv_file = 'card_history.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=[
        'HistoryID', 'CardID', 'StatusChangeDate', 
        'PreviousCardType', 'NewCardType', 'SpendingDuringPeriod'
    ])
    writer.writeheader()
    writer.writerows(card_history_data)

# Tạo file SQL INSERT statements
sql_file = 'card_history_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for history in card_history_data:
        sql = f"INSERT INTO CARD_HISTORY (HistoryID, CardID, StatusChangeDate, "
        sql += f"PreviousCardType, NewCardType, SpendingDuringPeriod) "
        sql += f"VALUES ({history['HistoryID']}, '{history['CardID']}', "
        sql += f"'{history['StatusChangeDate']}', '{history['PreviousCardType']}', "
        sql += f"'{history['NewCardType']}', {history['SpendingDuringPeriod']});\n"
        f.write(sql)

# Thống kê
print(f"Đã tạo {len(card_history_data)} bản ghi lịch sử thẻ")
print("\nPhân bổ theo loại thay đổi:")
changes = {}
for history in card_history_data:
    change_type = f"{history['PreviousCardType']} -> {history['NewCardType']}"
    changes[change_type] = changes.get(change_type, 0) + 1

for change_type, count in changes.items():
    print(f"{change_type}: {count} lần ({(count/len(card_history_data))*100:.1f}%)")

print(f"\nĐã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")