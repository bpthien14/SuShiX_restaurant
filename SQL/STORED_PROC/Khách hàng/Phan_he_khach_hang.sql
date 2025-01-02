use SUSHI_X
go

Create or alter PROCEDURE sp_CheckLogin
    @LoginInput VARCHAR(50),  -- Có thể là SĐT hoặc Email
    @Password VARCHAR(100)
AS
BEGIN
    SELECT 
        c.CustomerID, 
        c.FullName,
        c.PhoneNumber,
        c.Email,
        mc.CardType,
        mc.AccumulatedPoints,
        u.UserID,
		u.Role
    FROM CUSTOMER c
    JOIN USERS u ON c.UserID = u.UserID
    LEFT JOIN MEMBERSHIP_CARD mc ON c.CustomerID = mc.CustomerID
    WHERE (c.PhoneNumber = @LoginInput OR c.Email = @LoginInput OR u.Username = @LoginInput)
    AND u.Password = @Password
    AND u.Role = 'CUSTOMER'
END
GO
exec sp_CheckLogin 'thien', 'thien'

CREATE OR ALTER PROCEDURE sp_GetCustomerDashboard
    @UserID VARCHAR(255)
AS
BEGIN
    -- 1. Thông tin khách hàng và thẻ thành viên
    SELECT 
        c.CustomerID,
        c.FullName,
        mc.CardType,
        mc.AccumulatedPoints,
        mc.CardID
    FROM CUSTOMER c
    LEFT JOIN MEMBERSHIP_CARD mc ON c.CustomerID = mc.CustomerID
    WHERE c.UserID = @UserID;

    -- 2. Đơn đặt bàn đang chờ (chỉ lấy DINE_IN)
    SELECT COUNT(*) AS PendingDineInBookings
    FROM ONLINE_BOOKING ob
    JOIN CUSTOMER c ON ob.CustomerID = c.CustomerID
    WHERE c.UserID = @UserID 
    AND ob.BookingDate >= CAST(GETDATE() AS DATE)
    AND ob.DeliveryType = 'DINE_IN'
    AND ob.Status = 'PENDING';

    -- 3. Đơn hàng đang xử lý (DELIVERY và TAKEAWAY)
    SELECT 
        COUNT(CASE WHEN ob.DeliveryType = 'DELIVERY' THEN 1 END) as PendingDeliveryCount,
        COUNT(CASE WHEN ob.DeliveryType = 'TAKEAWAY' THEN 1 END) as PendingTakeawayCount
    FROM CUSTOMER c
    JOIN ONLINE_BOOKING ob ON c.CustomerID = ob.CustomerID
    WHERE c.UserID = @UserID
    AND ob.Status = 'PENDING';

    -- 4. Lịch sử đơn hàng gần nhất (5 đơn gần nhất)
    SELECT TOP 5
        ob.BookingID,
        ob.BookingDate,
        ob.ArrivalTime,
        ob.DeliveryType,
        ob.Status,
        b.BranchName,
        bi.TotalAmount,
        bi.Discount,
        bi.ServiceCharge,
        bi.DeliveryFee,
        bi.FinalAmount,
        bi.PaymentMethod,
        bi.PaymentStatus
    FROM ONLINE_BOOKING ob
    JOIN BRANCH b ON ob.BranchID = b.BranchID
    JOIN BOOKING_INVOICE bi ON ob.BookingID = bi.BookingID
    JOIN CUSTOMER c ON ob.CustomerID = c.CustomerID
    WHERE c.UserID = @UserID
    ORDER BY ob.BookingDate DESC, ob.ArrivalTime DESC;

    -- 5. Tổng chi tiêu và điểm tích lũy
    SELECT 
        COUNT(DISTINCT ob.BookingID) as TotalOrders,
        SUM(bi.FinalAmount) as TotalSpent
    FROM CUSTOMER c
    JOIN ONLINE_BOOKING ob ON c.CustomerID = ob.CustomerID
    JOIN BOOKING_INVOICE bi ON ob.BookingID = bi.BookingID
    WHERE c.UserID = @UserID
    AND bi.PaymentStatus = 'PAID';
END;
exec sp_GetCustomerDashboard '926cb287-1e86-48cf-9a31-0f5a6bc32236';

CREATE TYPE OrderItemTableType AS TABLE
(
    ItemID VARCHAR(255),
    Quantity INT
);

CREATE TYPE OrderItemTableType AS TABLE
(
    ItemID VARCHAR(255),
    Quantity INT
);
GO

CREATE OR ALTER PROCEDURE sp_SaveOrderAndBooking
    -- Booking parameters
    @CustomerID VARCHAR(255),
    @BranchID VARCHAR(255),
    @GuestCount INT,
    @BookingDate DATE,
    @ArrivalTime TIME,
    @Notes VARCHAR(255),
    @GuestName VARCHAR(255),
    @GuestPhone VARCHAR(255),
    @DeliveryType VARCHAR(50),    -- 'DELIVERY' hoặc 'TAKEAWAY'
    @DeliveryAddress VARCHAR(255),
    @DeliveryFee FLOAT,
    @Status VARCHAR(50),
    
    -- Payment parameters
    @CardID VARCHAR(255) = NULL,  -- Thẻ thành viên nếu có
    @PaymentMethod VARCHAR(50),   -- Phương thức thanh toán
    
    -- OrderItems as structured table parameter
    @OrderItems OrderItemTableType READONLY
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- 1. Insert Booking
        DECLARE @BookingID INT;
        INSERT INTO ONLINE_BOOKING 
        (CustomerID, BranchID, GuestCount, BookingDate, ArrivalTime, Notes, 
         GuestName, GuestPhone, DeliveryType, DeliveryAddress, DeliveryFee, Status)
        VALUES 
        (@CustomerID, @BranchID, @GuestCount, @BookingDate, @ArrivalTime, @Notes,
         @GuestName, @GuestPhone, @DeliveryType, @DeliveryAddress, @DeliveryFee, @Status);
        
        SET @BookingID = SCOPE_IDENTITY();
        
        -- 2. Insert Online Booking Orders with UnitPrice
        INSERT INTO ONLINE_BOOKING_ORDER (BookingID, ItemID, Quantity, UnitPrice, Notes)
        SELECT 
            @BookingID,
            oi.ItemID,
            oi.Quantity,
            mi.CurrentPrice,
            NULL
        FROM @OrderItems oi
        JOIN MENU_ITEM mi ON oi.ItemID = mi.ItemID;
        
        -- 3. Calculate amounts
        DECLARE @TotalAmount FLOAT;
        DECLARE @ServiceCharge FLOAT;
        DECLARE @Discount FLOAT = 0;
        DECLARE @FinalAmount FLOAT;
        
        -- Calculate total amount
        SELECT @TotalAmount = SUM(Quantity * UnitPrice)
        FROM ONLINE_BOOKING_ORDER
        WHERE BookingID = @BookingID;
        
        -- Calculate service charge (5%)
        SET @ServiceCharge = @TotalAmount * 0.05;
        
        -- Calculate discount based on card type if card is provided
        IF @CardID IS NOT NULL
        BEGIN
            DECLARE @CardType VARCHAR(50);
            SELECT @CardType = CardType 
            FROM MEMBERSHIP_CARD 
            WHERE CardID = @CardID;
            
            SET @Discount = @TotalAmount * 
                CASE @CardType
                    WHEN 'MEMBERSHIP' THEN 0.03
                    WHEN 'SILVER' THEN 0.07
                    WHEN 'GOLD' THEN 0.12
                    ELSE 0
                END;
        END
        
        -- Calculate final amount
        SET @FinalAmount = @TotalAmount + @ServiceCharge + @DeliveryFee - @Discount;
        
        -- 4. Insert Invoice
        INSERT INTO BOOKING_INVOICE 
        (BookingID, CardID, TotalAmount, Discount, ServiceCharge, 
         DeliveryFee, FinalAmount, PaymentMethod, PaymentStatus, CreatedAt)
        VALUES 
        (@BookingID, @CardID, @TotalAmount, @Discount, @ServiceCharge,
         @DeliveryFee, @FinalAmount, @PaymentMethod, 'PAID', GETDATE());
        
        COMMIT TRANSACTION;
        
        -- Return BookingID and InvoiceID
        SELECT 
            @BookingID AS BookingID,
            SCOPE_IDENTITY() AS InvoiceID,
            @TotalAmount AS TotalAmount,
            @ServiceCharge AS ServiceCharge,
            @Discount AS Discount,
            @DeliveryFee AS DeliveryFee,
            @FinalAmount AS FinalAmount;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        THROW;
    END CATCH
END
go


CREATE OR ALTER PROCEDURE sp_BookTable
    @CustomerID VARCHAR(255),
    @BranchID VARCHAR(255),
    @GuestCount INT,
    @BookingDate DATE,
    @ArrivalTime TIME,
    @Notes VARCHAR(255),
    @GuestName VARCHAR(255),
    @GuestPhone VARCHAR(255),
    @Status VARCHAR(50) = 'PENDING'
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ONLINE_BOOKING (
        CustomerID, BranchID, GuestCount, BookingDate, ArrivalTime, Notes, 
        GuestName, GuestPhone, DeliveryType, DeliveryAddress, DeliveryFee, Status
    )
    VALUES (
        @CustomerID, @BranchID, @GuestCount, @BookingDate, @ArrivalTime, @Notes, 
        @GuestName, @GuestPhone, 'DINE_IN', NULL, 0, @Status
    );

    SELECT SCOPE_IDENTITY() AS BookingID;
END


-- 1. Tạo user-defined table type trước
CREATE TYPE OrderItemTableType AS TABLE
(
    ItemID VARCHAR(255),
    Quantity INT
);
GO

-- 2. Sau đó mới chạy lệnh EXEC
DECLARE @OrderItems AS OrderItemTableType;

-- Thêm dữ liệu test vào bảng tạm
INSERT INTO @OrderItems (ItemID, Quantity) VALUES
('ITEM_d048bceb', 2),  -- 2 phần Salmon Nigiri
('ITEM_1d7d641f', 1),  -- 1 phần món khác
('ITEM_c5f7580e', 3);  -- 3 phần món khác

-- Thực thi stored procedure
EXEC sp_SaveOrderAndBooking
    @CustomerID = 'f933079b-d869-4423-a5d5-fdc79ade750d',
    @BranchID = '4652178d-b33b-452b-9f06-bbf397b0015d',
    @GuestCount = 2,
    @BookingDate = '2024-03-19',
    @ArrivalTime = '18:30',
    @Notes = N'Giao giờ hành chính',
    @GuestName = N'Nguyễn Văn A',
    @GuestPhone = '0123456789',
    @DeliveryType = 'DELIVERY',
    @DeliveryAddress = N'123 Đường ABC, Quận 1, TP.HCM',
    @DeliveryFee = 15000,
    @Status = 'COMPLETED',
    @CardID = NULL,
    @PaymentMethod = 'MOMO',
    @OrderItems = @OrderItems;