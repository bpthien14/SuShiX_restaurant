-- 1. Lấy danh sách khu vực
CREATE PROCEDURE sp_GetRegions
AS
BEGIN
    SELECT RegionID, RegionName
    FROM REGION
    ORDER BY RegionName
END
GO

-- 2. Lấy danh sách chi nhánh theo khu vực
CREATE PROCEDURE sp_GetBranchesByRegion
    @RegionID INT
AS
BEGIN
    SELECT 
        BranchID,
        BranchName,
        Address,
        OpeningTime,
        ClosingTime,
        DeliveryService
    FROM BRANCH
    WHERE RegionID = @RegionID
    ORDER BY BranchName
END
GO

-- 3. Lấy danh sách món ăn theo danh mục và chi nhánh
CREATE PROCEDURE sp_GetMenuItemsForTakeaway
    @BranchID VARCHAR(255),
    @CategoryID VARCHAR(255) = NULL,
    @SearchText NVARCHAR(100) = NULL,
    @DeliveryType VARCHAR(50)
AS
BEGIN
    SELECT 
        mi.ItemID,
        mi.ItemName,
        mi.CurrentPrice,
        mc.CategoryName,
        mi.DeliveryAvailable,
        mia.IsAvailable
    FROM MENU_ITEM mi
    JOIN MENU_CATEGORY mc ON mi.CategoryID = mc.CategoryID
    JOIN MENU_ITEM_AVAILABILITY mia ON mi.ItemID = mia.ItemID 
        AND mia.BranchID = @BranchID
    WHERE (@CategoryID IS NULL OR mi.CategoryID = @CategoryID)
    AND (@SearchText IS NULL OR mi.ItemName LIKE N'%' + @SearchText + N'%')
    AND mia.IsAvailable = 1
    AND (@DeliveryType = 'PICKUP' OR (@DeliveryType = 'DELIVERY' AND mi.DeliveryAvailable = 1))
    ORDER BY mc.CategoryName, mi.ItemName
END
GO

-- 4. Tạo đơn hàng mang về mới
CREATE PROCEDURE sp_CreateTakeawayOrder
    @CustomerID VARCHAR(255) = NULL,
    @BranchID VARCHAR(255),
    @GuestName VARCHAR(255),
    @GuestPhone VARCHAR(255),
    @DeliveryType VARCHAR(50),
    @DeliveryAddress VARCHAR(255) = NULL,
    @Notes VARCHAR(255) = NULL
AS
BEGIN
    DECLARE @BookingID INT

    INSERT INTO ONLINE_BOOKING (
        CustomerID,
        BranchID,
        GuestName,
        GuestPhone,
        BookingDate,
        DeliveryType,
        DeliveryAddress,
        DeliveryFee,
        Notes,
        Status
    )
    VALUES (
        @CustomerID,
        @BranchID,
        @GuestName,
        @GuestPhone,
        GETDATE(),
        @DeliveryType,
        @DeliveryAddress,
        CASE WHEN @DeliveryType = 'DELIVERY' THEN 30000 ELSE 0 END,
        @Notes,
        'PENDING'
    )

    SET @BookingID = SCOPE_IDENTITY()
    
    SELECT @BookingID AS BookingID
END
GO

-- 5. Thêm món vào đơn hàng
CREATE PROCEDURE sp_AddItemToTakeawayOrder
    @BookingID INT,
    @ItemID VARCHAR(255),
    @Quantity INT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM ONLINE_BOOKING_ORDER 
        WHERE BookingID = @BookingID AND ItemID = @ItemID
    )
    BEGIN
        UPDATE ONLINE_BOOKING_ORDER
        SET Quantity = Quantity + @Quantity
        WHERE BookingID = @BookingID AND ItemID = @ItemID
    END
    ELSE
    BEGIN
        INSERT INTO ONLINE_BOOKING_ORDER (BookingID, ItemID, Quantity)
        VALUES (@BookingID, @ItemID, @Quantity)
    END
END
GO

-- 6. Lấy thông tin tổng tiền đơn hàng
CREATE PROCEDURE sp_GetTakeawayOrderTotal
    @BookingID INT
AS
BEGIN
    SELECT 
        SUM(mi.CurrentPrice * obo.Quantity) AS SubTotal,
        ob.DeliveryFee,
        CASE 
            WHEN mc.CardType = 'GOLD' THEN SUM(mi.CurrentPrice * obo.Quantity) * 0.15
            WHEN mc.CardType = 'SILVER' THEN SUM(mi.CurrentPrice * obo.Quantity) * 0.10
            WHEN mc.CardType = 'MEMBER' THEN SUM(mi.CurrentPrice * obo.Quantity) * 0.05
            ELSE 0 
        END AS Discount,
        SUM(mi.CurrentPrice * obo.Quantity) + ob.DeliveryFee - 
        CASE 
            WHEN mc.CardType = 'GOLD' THEN SUM(mi.CurrentPrice * obo.Quantity) * 0.15
            WHEN mc.CardType = 'SILVER' THEN SUM(mi.CurrentPrice * obo.Quantity) * 0.10
            WHEN mc.CardType = 'MEMBER' THEN SUM(mi.CurrentPrice * obo.Quantity) * 0.05
            ELSE 0 
        END AS FinalAmount
    FROM ONLINE_BOOKING ob
    JOIN ONLINE_BOOKING_ORDER obo ON ob.BookingID = obo.BookingID
    JOIN MENU_ITEM mi ON obo.ItemID = mi.ItemID
    LEFT JOIN MEMBERSHIP_CARD mc ON ob.CustomerID = mc.CustomerID
    WHERE ob.BookingID = @BookingID
    GROUP BY ob.DeliveryFee, mc.CardType
END
GO