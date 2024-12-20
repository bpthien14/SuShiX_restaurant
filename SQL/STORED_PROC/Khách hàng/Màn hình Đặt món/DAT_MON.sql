-- 1. Lấy danh sách món ăn theo danh mục cho màn hình Chọn món
CREATE PROCEDURE sp_GetMenuItemsForBooking
    @BranchID VARCHAR(255),
    @CategoryID VARCHAR(255) = NULL,
    @SearchText NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        mi.ItemID,
        mi.ItemName,
        mi.CurrentPrice,
        mc.CategoryName,
        mia.IsAvailable
    FROM MENU_ITEM mi
    JOIN MENU_CATEGORY mc ON mi.CategoryID = mc.CategoryID
    JOIN MENU_ITEM_AVAILABILITY mia ON mi.ItemID = mia.ItemID 
        AND mia.BranchID = @BranchID
    WHERE (@CategoryID IS NULL OR mi.CategoryID = @CategoryID)
    AND (@SearchText IS NULL OR mi.ItemName LIKE N'%' + @SearchText + N'%')
    AND mia.IsAvailable = 1
    ORDER BY mc.CategoryName, mi.ItemName
END
GO

-- 2. Lấy danh sách món đã chọn cho booking
CREATE PROCEDURE sp_GetBookingOrderItems
    @BookingID INT
AS
BEGIN
    SELECT 
        mi.ItemName,
        obo.Quantity,
        mi.CurrentPrice,
        (mi.CurrentPrice * obo.Quantity) as SubTotal
    FROM ONLINE_BOOKING_ORDER obo
    JOIN MENU_ITEM mi ON obo.ItemID = mi.ItemID
    WHERE obo.BookingID = @BookingID
END
GO

-- 3. Thêm món vào đơn đặt bàn
CREATE PROCEDURE sp_AddItemToBooking
    @BookingID INT,
    @ItemID VARCHAR(255),
    @Quantity INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM ONLINE_BOOKING_ORDER 
              WHERE BookingID = @BookingID AND ItemID = @ItemID)
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