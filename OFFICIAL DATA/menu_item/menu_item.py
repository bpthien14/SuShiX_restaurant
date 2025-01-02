import csv
import uuid

def generate_menu_items():
    menu_items = []
    
    # Sushi (CAT_SUSHI)
    sushi_items = [
        ("Salmon Nigiri", 35000, 1),
        ("Tuna Nigiri", 40000, 1),
        ("Ebi Nigiri", 35000, 1),
        ("Unagi Nigiri", 45000, 1),
        ("Tamago Nigiri", 30000, 1),
        ("Ikura Gunkan", 50000, 1),
        ("Tobiko Gunkan", 45000, 1)
    ]
    
    # Sashimi (CAT_SASHIMI)
    sashimi_items = [
        ("Salmon Sashimi (5 pcs)", 120000, 1),
        ("Tuna Sashimi (5 pcs)", 130000, 1),
        ("Mixed Sashimi Platter", 250000, 1),
        ("Premium Sashimi Set", 350000, 1),
        ("Yellowtail Sashimi", 150000, 1)
    ]
    
    # Maki Rolls (CAT_MAKI)
    maki_items = [
        ("California Roll", 85000, 1),
        ("Spicy Tuna Roll", 95000, 1),
        ("Dragon Roll", 120000, 1),
        ("Rainbow Roll", 130000, 1),
        ("Philadelphia Roll", 110000, 1),
        ("Avocado Roll", 75000, 1),
        ("Cucumber Roll", 65000, 1)
    ]
    
    # Temaki (CAT_TEMAKI)
    temaki_items = [
        ("Salmon Temaki", 55000, 1),
        ("Spicy Tuna Temaki", 60000, 1),
        ("California Temaki", 55000, 1),
        ("Unagi Temaki", 65000, 1)
    ]
    
    # Appetizers (CAT_APPETIZER)
    appetizer_items = [
        ("Edamame", 45000, 1),
        ("Gyoza (6 pcs)", 65000, 1),
        ("Tempura Moriawase", 95000, 1),
        ("Agedashi Tofu", 55000, 1),
        ("Takoyaki (6 pcs)", 75000, 1),
        ("Miso Soup", 30000, 1)
    ]
    
    # Soups & Noodles (CAT_SOUP)
    soup_items = [
        ("Shoyu Ramen", 95000, 1),
        ("Miso Ramen", 95000, 1),
        ("Udon Noodle Soup", 85000, 1),
        ("Tempura Udon", 105000, 1),
        ("Nabeyaki Udon", 115000, 1)
    ]
    
    # Bento Sets (CAT_BENTO)
    bento_items = [
        ("Salmon Teriyaki Bento", 150000, 0),
        ("Chicken Katsu Bento", 135000, 0),
        ("Tempura Bento", 140000, 0),
        ("Unagi Bento", 180000, 0),
        ("Vegetarian Bento", 120000, 0)
    ]
    
    # Drinks (CAT_DRINKS)
    drink_items = [
        ("Green Tea", 25000, 1),
        ("Sake (Small)", 85000, 1),
        ("Sake (Large)", 150000, 1),
        ("Asahi Beer", 45000, 1),
        ("Sapporo Beer", 45000, 1),
        ("Soft Drinks", 25000, 1),
        ("Japanese Soda", 35000, 1),
        ("Mineral Water", 20000, 1)
    ]
    
    # Desserts (CAT_DESSERT)
    dessert_items = [
        ("Mochi Ice Cream (3 pcs)", 45000, 1),
        ("Green Tea Ice Cream", 35000, 1),
        ("Tempura Ice Cream", 55000, 1),
        ("Dorayaki", 40000, 1),
        ("Matcha Pudding", 45000, 1)
    ]
    
    # Tạo ItemID và thêm vào danh sách
    categories = {
        'CAT_SUSHI': sushi_items,
        'CAT_SASHIMI': sashimi_items,
        'CAT_MAKI': maki_items,
        'CAT_TEMAKI': temaki_items,
        'CAT_APPETIZER': appetizer_items,
        'CAT_SOUP': soup_items,
        'CAT_BENTO': bento_items,
        'CAT_DRINKS': drink_items,
        'CAT_DESSERT': dessert_items
    }
    
    for category_id, items in categories.items():
        for item_name, price, delivery in items:
            item_id = f"ITEM_{str(uuid.uuid4())[:8]}"
            menu_items.append({
                'ItemID': item_id,
                'CategoryID': category_id,
                'ItemName': item_name,
                'CurrentPrice': price,
                'DeliveryAvailable': delivery
            })
    
    return menu_items

# Tạo dữ liệu
menu_items = generate_menu_items()

# Lưu thành file CSV
csv_file = 'menu_items.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=[
        'ItemID', 'CategoryID', 'ItemName', 'CurrentPrice', 'DeliveryAvailable'
    ])
    writer.writeheader()
    writer.writerows(menu_items)

# Tạo file SQL INSERT statements
sql_file = 'menu_items_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for item in menu_items:
        sql = f"INSERT INTO MENU_ITEM (ItemID, CategoryID, ItemName, CurrentPrice, DeliveryAvailable) "
        sql += f"VALUES ('{item['ItemID']}', '{item['CategoryID']}', "
        sql += f"N'{item['ItemName']}', {item['CurrentPrice']}, {item['DeliveryAvailable']});\n"
        f.write(sql)

# Thống kê
print(f"Đã tạo {len(menu_items)} món ăn và đồ uống")
print("\nPhân bổ theo danh mục:")
categories = {}
for item in menu_items:
    cat = item['CategoryID']
    categories[cat] = categories.get(cat, 0) + 1

for cat, count in categories.items():
    print(f"{cat}: {count} món ({(count/len(menu_items))*100:.1f}%)")

print(f"\nĐã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")