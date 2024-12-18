import csv
import random
from faker import Faker

fake = Faker()

def generate_review_data(num_records, num_invoices):
    data = []
    for i in range(1, num_records + 1):
        review_id = f"REV{i:05d}"  # Tạo ID theo định dạng REV00001, REV00002, ...
        invoice_id = f"INV{random.randint(1, num_invoices):05d}"  # Giả sử có num_invoices InvoiceID hợp lệ
        service_score = random.randint(1, 5)
        location_score = random.randint(1, 5)
        food_quality_score = random.randint(1, 5)
        price_score = random.randint(1, 5)
        ambiance_score = random.randint(1, 5)
        comment = fake.sentence(nb_words=10)  # Bình luận ngẫu nhiên

        data.append({
            "ReviewID": review_id,
            "InvoiceID": invoice_id,
            "ServiceScore": service_score,
            "LocationScore": location_score,
            "FoodQualityScore": food_quality_score,
            "PriceScore": price_score,
            "AmbianceScore": ambiance_score,
            "Comment": comment
        })
    return data

# Giả sử có 10,000 InvoiceID hợp lệ
num_invoices = 10000

# Tạo 10,000 dòng dữ liệu
review_data = generate_review_data(10000, num_invoices)

# Ghi dữ liệu vào file CSV
with open('review.csv', mode='w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=[
        "ReviewID", "InvoiceID", "ServiceScore", "LocationScore", "FoodQualityScore",
        "PriceScore", "AmbianceScore", "Comment"
    ])
    writer.writeheader()
    writer.writerows(review_data)

print("File CSV đã được tạo thành công.")