-- 4. Xác nhận đơn hàng và tạo hóa đơn
CREATE PROCEDURE sp_ConfirmBookingOrder
    @BookingID INT,
    @CustomerID VARCHAR(255)
AS
BEGIN
    DECLARE @OrderID VARCHAR(255)
    DECLARE @CardID VARCHAR(255)
    DECLARE @TotalAmount FLOAT = 0
    DECLARE @Discount FLOAT = 0
    DECLARE @FinalAmount FLOAT = 0

    -- Tạo OrderID mới
    SET @OrderID = CONCAT('ORD', FORMAT(GETDATE(), 'yyyyMMddHHmmss'))

    -- Lấy CardID của khách hàng
    SELECT @CardID = CardID 
    FROM MEMBERSHIP_CARD 
    WHERE CustomerID = @CustomerID

    -- Tạo ORDER_TABLE
    INSERT INTO ORDER_TABLE (
        OrderID,
        OrderDate,
        CustomerID,
        BranchID
    )
    SELECT 
        @OrderID,
        GETDATE(),
        ob.CustomerID,
        ob.BranchID
    FROM ONLINE_BOOKING ob
    WHERE ob.BookingID = @BookingID

    -- Chuyển món từ ONLINE_BOOKING_ORDER sang ORDER_DETAIL
    INSERT INTO ORDER_DETAIL (OrderID, ItemID, Quantity)
    SELECT @OrderID, ItemID, Quantity
    FROM ONLINE_BOOKING_ORDER
    WHERE BookingID = @BookingID

    -- Tính tổng tiền
    SELECT @TotalAmount = SUM(mi.CurrentPrice * obo.Quantity)
    FROM ONLINE_BOOKING_ORDER obo
    JOIN MENU_ITEM mi ON obo.ItemID = mi.ItemID
    WHERE obo.BookingID = @BookingID

    -- Tính giảm giá dựa trên loại thẻ
    SELECT @Discount = 
        CASE 
            WHEN CardType = 'GOLD' THEN @TotalAmount * 0.15
            WHEN CardType = 'SILVER' THEN @TotalAmount * 0.10
            ELSE @TotalAmount * 0.05
        END
    FROM MEMBERSHIP_CARD
    WHERE CardID = @CardID

    SET @FinalAmount = @TotalAmount - @Discount

    -- Tạo INVOICE
    INSERT INTO INVOICE (
        InvoiceID,
        OrderID,
        CardID,
        TotalAmount,
        Discount,
        FinalAmount,
        CreatedAt
    )
    VALUES (
        CONCAT('INV', FORMAT(GETDATE(), 'yyyyMMddHHmmss')),
        @OrderID,
        @CardID,
        @TotalAmount,
        @Discount,
        @FinalAmount,
        GETDATE()
    )

    -- Cập nhật điểm tích lũy
    UPDATE MEMBERSHIP_CARD
    SET AccumulatedPoints = AccumulatedPoints + FLOOR(@FinalAmount / 100000)
    WHERE CardID = @CardID

    -- Trả về thông tin hóa đơn
    SELECT 
        @TotalAmount as TotalAmount,
        @Discount as Discount,
        @FinalAmount as FinalAmount,
        FLOOR(@FinalAmount / 100000) as EarnedPoints
END
GO

-- Hủy đơn đặt bàn và món đã chọn
CREATE PROCEDURE sp_CancelBookingOrder
    @BookingID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        -- 1. Xóa các món đã chọn trong ONLINE_BOOKING_ORDER
        DELETE FROM ONLINE_BOOKING_ORDER
        WHERE BookingID = @BookingID

        -- 2. Xóa đơn đặt bàn trong ONLINE_BOOKING
        DELETE FROM ONLINE_BOOKING
        WHERE BookingID = @BookingID

        COMMIT TRANSACTION
        
        -- Trả về kết quả thành công
        SELECT 'Success' AS Result
    END TRY
    BEGIN CATCH
        -- Nếu có lỗi thì rollback
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION

        -- Trả về thông tin lỗi
        SELECT 
            'Error' AS Result,
            ERROR_MESSAGE() AS ErrorMessage,
            ERROR_NUMBER() AS ErrorNumber
    END CATCH
END
GO