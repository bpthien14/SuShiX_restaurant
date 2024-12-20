CREATE PROCEDURE sp_GetCustomerDashboard
    @CustomerID VARCHAR(255)
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
    WHERE c.CustomerID = @CustomerID;

    -- Đơn đặt bàn đang chờ
    SELECT COUNT(*) AS PendingBookings
    FROM ONLINE_BOOKING ob
    WHERE ob.CustomerID = @CustomerID 
    AND ob.BookingDate >= CAST(GETDATE() AS DATE);

    -- Đơn hàng đang xử lý
    SELECT COUNT(*) AS ProcessingOrders
    FROM ORDER_TABLE ot
    JOIN INVOICE i ON ot.OrderID = i.OrderID
    WHERE ot.CustomerID = @CustomerID 
    AND i.CreatedAt = CAST(GETDATE() AS DATE);

    -- Lịch sử đơn hàng gần nhất
    SELECT TOP 5
        ot.OrderID,
        ot.OrderDate,
        b.BranchName,
        i.FinalAmount
    FROM ORDER_TABLE ot
    JOIN BRANCH b ON ot.BranchID = b.BranchID
    JOIN INVOICE i ON ot.OrderID = i.OrderID
    WHERE ot.CustomerID = @CustomerID
    ORDER BY ot.OrderDate DESC;
END
GO