-- Insert data into REGION
INSERT INTO REGION (RegionID, RegionName) VALUES
(0, 'Ho Chi Minh'),
(1, 'Hanoi'),
(2, 'Gia Lai');

-- Insert data into BRANCH
INSERT INTO BRANCH (BranchID, RegionID, BranchName, Address, BranchPhoneNumber, OpeningTime, ClosingTime, HasCarParking, HasBikeParking, DeliveryService, ManagerID) VALUES
('BR001', 0, 'HCM CN 1', '123 HCM Street', '0123456789', '08:00:00', '18:00:00', 1, 1, 1, 'S001'),
('BR002', 0, 'HCM CN 2', '456 HCM Street', '0987654321', '09:00:00', '19:00:00', 1, 1, 0, 'S002'),
('BR003', 1, 'HN CN 1', '789 HN Street', '0123456789', '08:00:00', '18:00:00', 1, 0, 1, 'S003');

-- Insert data into USERS
INSERT INTO USERS (UserID, Username, Password, Role) VALUES
('U001', 'john_doe', 'password', 'Customer'),
('U002', 'jane_smith', 'password', 'Customer');

-- Insert data into CUSTOMER
INSERT INTO CUSTOMER (CustomerID, FullName, PhoneNumber, Email, IDNumber, Gender, UserID) VALUES
('C001', 'John Doe', '0123456789', 'john@example.com', '123456789', 'Male', 'U001'),
('C002', 'Jane Smith', '0987654321', 'jane@example.com', '987654321', 'Female', 'U002');

INSERT INTO DEPARTMENT (DepartmentID, DepartmentName)
VALUES
('D001', 'Finance'),
('D002', 'Human Resources'),
('D003', 'IT'),
('D004', 'Marketing'),
('D005', 'Sales'),
('D006', 'Operations');

INSERT INTO STAFF (StaffID, DepartmentID, BranchID, FullName, Gender, BirthDate, StartDate, EndDate, Salary, Address, PhoneNumber, UserID)
VALUES
('S001', 'D001', 'BR001', 'John Doe', 'Male', '1985-05-15', '2023-01-01', NULL, 5000.00, '123 HCM Street', '0123456789', 'U001'),
('S002', 'D002', 'BR002', 'Jane Smith', 'Female', '1990-07-20', '2023-02-01', NULL, 4500.00, '456 HCM Street', '0987654321', 'U002'),
('S003', 'D003', 'BR003', 'Alice Brown', 'Female', '1988-03-30', '2023-03-01', NULL, 4700.00, '789 HN Street', '0123456789', 'U003'),
('S004', 'D004', 'BR004', 'Bob White', 'Male', '1992-10-10', '2023-04-01', NULL, 4800.00, '101 HN Street', '0987654321', 'U004'),
('S005', 'D005', 'BR005', 'Eve Black', 'Female', '1985-08-25', '2023-05-01', NULL, 5100.00, '202 GL Street', '0123456789', 'U005'),
('S006', 'D006', 'BR006', 'Tom Green', 'Male', '1995-12-12', '2023-06-01', NULL, 4600.00, '303 GL Street', '0987654321', 'U006');

-- Insert data into MEMBERSHIP_CARD
INSERT INTO MEMBERSHIP_CARD (CardID, CustomerID, StaffID, CardType, RegistrationDate, AccumulatedPoints) VALUES
('CARD001', 'C001', 'S001', 'Gold', '2023-01-01', 120),
('CARD002', 'C002', 'S002', 'Silver', '2023-01-02', 50);

-- Insert data into MENU_CATEGORY
INSERT INTO MENU_CATEGORY (CategoryID, CategoryName) VALUES
('MC001', 'Sushi'),
('MC002', 'Drinks');

-- Insert data into MENU_ITEM
INSERT INTO MENU_ITEM (ItemID, CategoryID, ItemName, CurrentPrice, DeliveryAvailable) VALUES
('MI001', 'MC001', 'Salmon Sushi', 5.00, 1),
('MI002', 'MC002', 'Green Tea', 1.50, 1);

-- Insert additional data into ORDER_TABLE
INSERT INTO ORDER_TABLE (OrderID, OrderDate, StaffID, TableNumber, BranchID, CustomerID) VALUES
('ORD003', '2024-01-03', 'S001', 3, 'BR001', 'C001'),
('ORD004', '2024-01-03', 'S002', 4, 'BR002', 'C002'),
('ORD005', '2024-01-04', 'S003', 1, 'BR003', 'C001'),
('ORD006', '2024-01-04', 'S003', 2, 'BR003', 'C002'),
('ORD007', '2024-01-05', 'S004', 1, 'BR001', 'C002'),
('ORD008', '2024-01-05', 'S001', 2, 'BR001', 'C001');

-- Insert additional data into ORDER_DETAIL
INSERT INTO ORDER_DETAIL (OrderID, ItemID, Quantity) VALUES
('ORD003', 'MI001', 2),
('ORD003', 'MI002', 4),
('ORD004', 'MI001', 1),
('ORD004', 'MI002', 3),
('ORD005', 'MI001', 6),
('ORD005', 'MI002', 2),
('ORD006', 'MI002', 5),
('ORD007', 'MI001', 3),
('ORD008', 'MI001', 4),
('ORD008', 'MI002', 1);

-- Insert additional data into ORDER_INVOICE
INSERT INTO ORDER_INVOICE (InvoiceID, OrderID, CardID, TotalAmount, Discount, FinalAmount, CreatedAt) VALUES
('INV003', 'ORD003', 'CARD001', 14.00, 1.00, 13.00, '2024-01-03'),
('INV004', 'ORD004', 'CARD002', 9.00, 0.50, 8.50, '2024-01-03'),
('INV005', 'ORD005', 'CARD001', 35.00, 3.00, 32.00, '2024-01-04'),
('INV006', 'ORD006', 'CARD002', 7.50, 0.50, 7.00, '2024-01-04'),
('INV007', 'ORD007', 'CARD002', 15.00, 1.50, 13.50, '2024-01-05'),
('INV008', 'ORD008', 'CARD001', 20.00, 2.00, 18.00, '2024-01-05');


-- Insert data into ONLINE_BOOKING
INSERT INTO ONLINE_BOOKING (BookingID, CustomerID, BranchID, GuestCount, BookingDate, ArrivalTime, Notes) VALUES
(1001, 'C001', 'BR001', 4, '2024-01-03', '12:00:00', 'Lunch reservation'),
(1002, 'C002', 'BR002', 2, '2024-01-03', '19:00:00', 'Dinner with client'),
(1003, 'C001', 'BR003', 5, '2024-01-04', '11:30:00', 'Family lunch'),
(1004, 'C002', 'BR003', 3, '2024-01-04', '13:00:00', 'Business meeting'),
(1005, 'C001', 'BR001', 6, '2024-01-05', '20:00:00', 'Birthday party'),
(1006, 'C002', 'BR002', 8, '2024-01-05', '18:00:00', 'Group dinner');


-- Insert data into ONLINE_BOOKING_ORDER
INSERT INTO ONLINE_BOOKING_ORDER (BookingID, ItemID, Quantity) VALUES
(1001, 'MI001', 3),
(1001, 'MI002', 2),
(1002, 'MI001', 1),
(1002, 'MI002', 4),
(1003, 'MI001', 5),
(1003, 'MI002', 3),
(1004, 'MI002', 6),
(1005, 'MI001', 7),
(1005, 'MI002', 4),
(1006, 'MI001', 2),
(1006, 'MI002', 6);


-- Insert data into BOOKING_INVOICE
INSERT INTO BOOKING_INVOICE (InvoiceID, BookingID, CardID, TotalAmount, Discount, FinalAmount, CreatedAt) VALUES
('BINV001', 1001, 'CARD001', 25.00, 2.00, 23.00, '2024-01-03'),
('BINV002', 1002, 'CARD002', 20.00, 1.50, 18.50, '2024-01-03'),
('BINV003', 1003, 'CARD001', 40.00, 3.00, 37.00, '2024-01-04'),
('BINV004', 1004, 'CARD002', 30.00, 2.50, 27.50, '2024-01-04'),
('BINV005', 1005, 'CARD001', 60.00, 5.00, 55.00, '2024-01-05'),
('BINV006', 1006, 'CARD002', 50.00, 4.00, 46.00, '2024-01-05');
