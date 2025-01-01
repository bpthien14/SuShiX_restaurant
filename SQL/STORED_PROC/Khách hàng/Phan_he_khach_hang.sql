EXEC sp_CheckLogin 'thien', 'thien';
GO
ALTER PROCEDURE sp_CheckLogin
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
    WHERE (c.PhoneNumber = @LoginInput OR c.Email = @LoginInput)
    AND u.Password = @Password
    AND u.Role = 'CUSTOMER'
END
GO

ALTER PROCEDURE sp_GetCustomerDashboard
    @UserID VARCHAR(255)  -- Đầu vào mới là UserID
AS
BEGIN
    -- Thông tin khách hàng và thẻ thành viên
    SELECT 
        c.CustomerID,
        c.FullName,
        mc.CardType,
        mc.AccumulatedPoints
    FROM CUSTOMER c
    LEFT JOIN MEMBERSHIP_CARD mc ON c.CustomerID = mc.CustomerID
    WHERE c.UserID = @UserID;  -- Sử dụng UserID để truy vấn

    -- Đơn đặt bàn đang chờ
    SELECT COUNT(*) AS PendingBookings
    FROM ONLINE_BOOKING ob
    JOIN CUSTOMER c ON ob.CustomerID = c.CustomerID  -- Ánh xạ qua CUSTOMER
    WHERE c.UserID = @UserID 
    AND ob.BookingDate >= CAST(GETDATE() AS DATE);

    -- Đơn hàng đang xử lý
    SELECT 
        COUNT(ob.BookingID) as PendingOrderCount

    FROM CUSTOMER c
    JOIN ONLINE_BOOKING ob ON c.CustomerID = ob.CustomerID
    WHERE c.UserID = @UserID
    AND ob.Status = 'PENDING'  -- hoặc status tương ứng với "đang giao"
    GROUP BY c.CustomerID, c.FullName;

    -- Lịch sử đơn hàng gần nhất
    -- SELECT TOP 5
    --     ot.OrderID,
    --     ot.OrderDate,
    --     b.BranchName,
    --     i.FinalAmount
    -- FROM ORDER_TABLE ot
    -- JOIN BRANCH b ON ot.BranchID = b.BranchID
    -- JOIN INVOICE i ON ot.OrderID = i.OrderID
    -- JOIN CUSTOMER c ON ot.CustomerID = c.CustomerID  -- Ánh xạ qua CUSTOMER
    -- WHERE c.UserID = @UserID
    -- ORDER BY ot.OrderDate DESC;
END;

GO
--exec sp_GetCustomerDashboard 'USR00001';

CREATE TYPE OrderItemTableType AS TABLE
(
    ItemID VARCHAR(255),
    Quantity INT
);


CREATE PROCEDURE sp_SaveOrderAndBooking  
    -- Booking parameters  
    @CustomerID VARCHAR(255),  
    @BranchID VARCHAR(255),  
    @GuestCount INT,  
    @BookingDate DATE,  
    @ArrivalTime TIME,  
    @Notes VARCHAR(255),  
    @GuestName VARCHAR(255),  
    @GuestPhone VARCHAR(255),  
    @DeliveryType VARCHAR(50),  
    @DeliveryAddress VARCHAR(255),  
    @DeliveryFee FLOAT,  
    @Status VARCHAR(50),  
      
    -- Order parameters  
    @OrderID VARCHAR(255),  
    @OrderDate DATE,  
    @StaffID VARCHAR(255),  
    @TableNumber INT,  
      
    -- Invoice parameters  
    @Discount FLOAT,  
    @FinalAmount FLOAT,  
      
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
          
        -- 2. Insert Online Booking Orders  
        INSERT INTO ONLINE_BOOKING_ORDER (BookingID, ItemID, Quantity)  
        SELECT @BookingID, ItemID, Quantity FROM @OrderItems;  
          
        -- 3. Insert Order  
        INSERT INTO ORDER_TABLE   
        (OrderID, OrderDate, StaffID, TableNumber, BranchID, CustomerID)  
        VALUES   
        (@OrderID, @OrderDate, @StaffID, @TableNumber, @BranchID, @CustomerID);  
          
        -- 4. Insert Order Details  
        INSERT INTO ORDER_DETAIL (OrderID, ItemID, Quantity)  
        SELECT @OrderID, ItemID, Quantity FROM @OrderItems;  
          
        -- 5. Insert Invoice với InvoiceID tự động  
        DECLARE @InvoiceID VARCHAR(255) = 'INV' + RIGHT('00000' + CAST(NEXT VALUE FOR InvoiceSeq AS VARCHAR(5)), 5)  
          
        INSERT INTO BOOKING_INVOICE   
        (InvoiceID, BookingID, TotalAmount, Discount, FinalAmount, CreatedAt)  
        VALUES   
        (@InvoiceID,  
         @BookingID,   
         (SELECT SUM(oi.Quantity * mi.CurrentPrice)   
          FROM @OrderItems oi  
          JOIN MENU_ITEM mi ON oi.ItemID = mi.ItemID),  
         @Discount,   
         @FinalAmount,  
         GETDATE());  
          
        COMMIT TRANSACTION;  
        SELECT @BookingID AS BookingID, @InvoiceID AS InvoiceID;  
    END TRY  
    BEGIN CATCH  
        IF @@TRANCOUNT > 0  
            ROLLBACK TRANSACTION;  
          
        THROW;  
    END CATCH  
END

go
CREATE   PROCEDURE sp_BookTable  
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
        GuestName, GuestPhone, Status  
    )  
    VALUES (  
        @CustomerID, @BranchID, @GuestCount, @BookingDate, @ArrivalTime, @Notes,   
        @GuestName, @GuestPhone, @Status  
    );  
  
    SELECT SCOPE_IDENTITY() AS BookingID;  
END  
