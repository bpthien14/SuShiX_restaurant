import csv

# Danh sách các danh mục
categories = [
    {
        'CategoryID': 'CAT_SUSHI',
        'CategoryName': 'Sushi'
    },
    {
        'CategoryID': 'CAT_SASHIMI',
        'CategoryName': 'Sashimi'
    },
    {
        'CategoryID': 'CAT_MAKI',
        'CategoryName': 'Maki Rolls'
    },
    {
        'CategoryID': 'CAT_TEMAKI',
        'CategoryName': 'Temaki (Hand Rolls)'
    },
    {
        'CategoryID': 'CAT_APPETIZER',
        'CategoryName': 'Appetizers'
    },
    {
        'CategoryID': 'CAT_SOUP',
        'CategoryName': 'Soups & Noodles'
    },
    {
        'CategoryID': 'CAT_BENTO',
        'CategoryName': 'Bento Sets'
    },
    {
        'CategoryID': 'CAT_DRINKS',
        'CategoryName': 'Drinks'
    },
    {
        'CategoryID': 'CAT_DESSERT',
        'CategoryName': 'Desserts'
    }
]

# Lưu thành file CSV
csv_file = 'menu_categories.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as f:
    writer = csv.DictWriter(f, fieldnames=['CategoryID', 'CategoryName'])
    writer.writeheader()
    writer.writerows(categories)

# Tạo file SQL INSERT statements
sql_file = 'menu_categories_insert.sql'
with open(sql_file, 'w', encoding='utf-8') as f:
    f.write('USE SUSHI_X;\nGO\n\n')
    for category in categories:
        sql = f"INSERT INTO MENU_CATEGORY (CategoryID, CategoryName) "
        sql += f"VALUES ('{category['CategoryID']}', N'{category['CategoryName']}');\n"
        f.write(sql)

print(f"Đã tạo {len(categories)} danh mục menu:")
for cat in categories:
    print(f"- {cat['CategoryName']} ({cat['CategoryID']})")
print(f"\nĐã lưu dữ liệu vào file CSV: {csv_file}")
print(f"Đã lưu câu lệnh SQL vào file: {sql_file}")