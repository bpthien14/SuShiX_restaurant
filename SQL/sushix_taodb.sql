USE SUSHI_X 
GO;

CREATE TABLE REGION (
    RegionID INT PRIMARY KEY,
    RegionName VARCHAR(255)
);

CREATE TABLE USERS (
    UserID VARCHAR(255) PRIMARY KEY,
    Username VARCHAR(255),
    Password VARCHAR(255),
    Role VARCHAR(50)
);

CREATE TABLE CUSTOMER (
    CustomerID VARCHAR(255) PRIMARY KEY,
    FullName VARCHAR(255),
    PhoneNumber VARCHAR(255),
    Email VARCHAR(255),
    IDNumber VARCHAR(20),
    Gender VARCHAR(10),
    UserID VARCHAR(255),
    FOREIGN KEY (UserID) REFERENCES USERS(UserID)
);

-- Cách 1: Tạm thời bỏ khóa ngoại ManagerID khi tạo bảng, thêm sau bằng ALTER TABLE
CREATE TABLE BRANCH (
    BranchID VARCHAR(255) PRIMARY KEY,
    RegionID INT,
    BranchName VARCHAR(255),
    Address VARCHAR(255),
    BranchPhoneNumber VARCHAR(20),
    OpeningTime TIME,
    ClosingTime TIME,
    HasCarParking BIT,
    HasBikeParking BIT,
    DeliveryService BIT,
    ManagerID VARCHAR(255),
    FOREIGN KEY (RegionID) REFERENCES REGION(RegionID)
);

CREATE TABLE DEPARTMENT (
    DepartmentID VARCHAR(255) PRIMARY KEY,
    DepartmentName VARCHAR(255)
);

CREATE TABLE STAFF (
    StaffID VARCHAR(255) PRIMARY KEY,
    DepartmentID VARCHAR(255),
    BranchID VARCHAR(255),
    FullName VARCHAR(255),
    Gender VARCHAR(10),
    BirthDate DATE,
    StartDate DATE,
    EndDate DATE,
    Salary DECIMAL(10, 2),
    Address VARCHAR(255),
    PhoneNumber VARCHAR(20),
    UserID VARCHAR(255),
    FOREIGN KEY (DepartmentID) REFERENCES DEPARTMENT(DepartmentID),
    FOREIGN KEY (BranchID) REFERENCES BRANCH(BranchID),
    FOREIGN KEY (UserID) REFERENCES USERS(UserID)
);

-- Thêm khóa ngoại sau khi đã có dữ liệu
ALTER TABLE BRANCH
ADD CONSTRAINT FK_Branch_Manager 
FOREIGN KEY (ManagerID) REFERENCES STAFF(StaffID);

CREATE TABLE STAFF_WORK_HISTORY (
    HistoryID INT PRIMARY KEY,
    StaffID VARCHAR(255),
    BranchID VARCHAR(255),
    StartDate DATE,
    EndDate DATE,
    FOREIGN KEY (StaffID) REFERENCES STAFF(StaffID),
    FOREIGN KEY (BranchID) REFERENCES BRANCH(BranchID)
);


CREATE TABLE MEMBERSHIP_CARD (
    CardID VARCHAR(255) PRIMARY KEY,
    CustomerID VARCHAR(255),
    StaffID VARCHAR(255),
    CardType VARCHAR(50),
    RegistrationDate DATE,
    AccumulatedPoints FLOAT,
    FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(CustomerID),
    FOREIGN KEY (StaffID) REFERENCES STAFF(StaffID)
);

CREATE TABLE CARD_HISTORY (
    HistoryID INT PRIMARY KEY,
    CardID VARCHAR(255),
    StatusChangeDate DATE,
    PreviousCardType VARCHAR(50),
    NewCardType VARCHAR(50),
    SpendingDuringPeriod FLOAT,
    FOREIGN KEY (CardID) REFERENCES MEMBERSHIP_CARD(CardID)
);

CREATE TABLE ONLINE_SESSION (
    SessionID VARCHAR(255) PRIMARY KEY,
    UserID VARCHAR(255),
    SessionStart DATETIME,
    SessionDuration INT,
    DeviceType VARCHAR(50),
    IPAddress VARCHAR(50),
    InternalSource VARCHAR(50),
    FOREIGN KEY (UserID) REFERENCES USERS(UserID)
);

CREATE TABLE MENU_CATEGORY (
    CategoryID VARCHAR(255) PRIMARY KEY,
    CategoryName VARCHAR(255)
);

CREATE TABLE MENU_ITEM (
    ItemID VARCHAR(255) PRIMARY KEY,
    CategoryID VARCHAR(255),
    ItemName VARCHAR(255),
    CurrentPrice FLOAT,
    DeliveryAvailable BIT,
    FOREIGN KEY (CategoryID) REFERENCES MENU_CATEGORY(CategoryID)
);

CREATE TABLE MENU_ITEM_AVAILABILITY (
    BranchID VARCHAR(255),
    ItemID VARCHAR(255),
    IsAvailable BIT,
    PRIMARY KEY (BranchID, ItemID),
    FOREIGN KEY (BranchID) REFERENCES BRANCH(BranchID),
    FOREIGN KEY (ItemID) REFERENCES MENU_ITEM(ItemID)
);

CREATE TABLE ONLINE_BOOKING (
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID VARCHAR(255),
    BranchID VARCHAR(255),
    GuestCount INT,
    BookingDate DATE,
    ArrivalTime TIME,
    Notes VARCHAR(255),
    GuestName VARCHAR(255),
    GuestPhone VARCHAR(255),
    DeliveryType VARCHAR(50),   --  'DINE_IN', 'DELIVERY', 'TAKEAWAY'
    DeliveryAddress VARCHAR(255),
    DeliveryFee FLOAT DEFAULT 0,
    Status VARCHAR(50) DEFAULT 'PENDING',  -- PENDING, CONFIRMED, CANCELLED
    FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(CustomerID),
    FOREIGN KEY (BranchID) REFERENCES BRANCH(BranchID)
);

CREATE TABLE ONLINE_BOOKING_ORDER (
    BookingID INT,
    ItemID VARCHAR(255),
    Quantity INT,
    UnitPrice FLOAT,              -- Thêm giá tại thời điểm đặt
    Notes VARCHAR(255),
    PRIMARY KEY (BookingID, ItemID),
    FOREIGN KEY (BookingID) REFERENCES ONLINE_BOOKING(BookingID),
    FOREIGN KEY (ItemID) REFERENCES MENU_ITEM(ItemID)
);


CREATE TABLE BOOKING_INVOICE (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,  -- Đổi thành IDENTITY
    BookingID INT,
    CardID VARCHAR(255),
    TotalAmount FLOAT,
    Discount FLOAT DEFAULT 0,
    ServiceCharge FLOAT DEFAULT 0,
    DeliveryFee FLOAT DEFAULT 0,
    FinalAmount FLOAT,
    PaymentMethod VARCHAR(50),
    PaymentStatus VARCHAR(50) DEFAULT 'PENDING',
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (BookingID) REFERENCES ONLINE_BOOKING(BookingID),
    FOREIGN KEY (CardID) REFERENCES MEMBERSHIP_CARD(CardID)
);



