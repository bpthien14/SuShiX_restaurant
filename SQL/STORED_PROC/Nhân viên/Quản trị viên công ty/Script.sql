CREATE OR ALTER PROCEDURE sp_GetRevenueStatisticsByBranch
    @StartDate DATE,
    @EndDate DATE,
    @BranchID VARCHAR(255)
AS
BEGIN
    SELECT RevenueData.BranchName AS N'Chi Nhánh', 
           CAST(RevenueData.RevenueDate AS DATE) AS N'Ngày', 
           COUNT(*) AS N'Số đơn', 
           ROUND(SUM(RevenueData.TotalRevenue), 2) AS N'Tổng Doanh Thu', 
           ROUND(AVG(RevenueData.TotalRevenue), 2) AS N'Trung Bình'
    FROM (
        SELECT BRANCH.BranchName, 
               ORDER_INVOICE.CreatedAt AS RevenueDate, 
               ORDER_INVOICE.FinalAmount AS TotalRevenue
        FROM ORDER_INVOICE
        JOIN ORDER_TABLE ON ORDER_INVOICE.OrderID = ORDER_TABLE.OrderID
        JOIN BRANCH ON ORDER_TABLE.BranchID = BRANCH.BranchID
        WHERE CAST(ORDER_INVOICE.CreatedAt AS DATE) BETWEEN @StartDate AND @EndDate
        AND BRANCH.BranchID = @BranchID

        UNION ALL

        SELECT BRANCH.BranchName, 
               BOOKING_INVOICE.CreatedAt AS RevenueDate, 
               BOOKING_INVOICE.FinalAmount AS TotalRevenue
        FROM BOOKING_INVOICE
        JOIN ONLINE_BOOKING ON BOOKING_INVOICE.BookingID = ONLINE_BOOKING.BookingID
        JOIN BRANCH ON ONLINE_BOOKING.BranchID = BRANCH.BranchID
        WHERE CAST(BOOKING_INVOICE.CreatedAt AS DATE) BETWEEN @StartDate AND @EndDate
        AND BRANCH.BranchID = @BranchID
    ) AS RevenueData
    GROUP BY RevenueData.BranchName, RevenueData.RevenueDate
    ORDER BY RevenueData.RevenueDate;
END
GO
--Để xác định trạng thái món chạy hay chậm, chúng ta cần stored procedure tính toán dựa trên doanh thu và số lượng bán:
CREATE OR ALTER PROCEDURE sp_GetMenuItemStatus
    @BranchID VARCHAR(255) = NULL,
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    WITH ItemStats AS (
        -- Tính tổng doanh thu và số lượng cho từng món
        SELECT 
            mi.ItemID,
            mi.ItemName,
			ot.OrderDate,
            SUM(od.Quantity) as TotalQuantity,
            SUM(od.Quantity * mi.CurrentPrice) as TotalRevenue,
            -- Tính phần trăm đóng góp vào tổng doanh thu
            (SUM(od.Quantity * mi.CurrentPrice) * 100.0 / 
             SUM(SUM(od.Quantity * mi.CurrentPrice)) OVER()) as RevenuePercentage,
            -- Xếp hạng theo doanh thu
            ROW_NUMBER() OVER(ORDER BY SUM(od.Quantity * mi.CurrentPrice) DESC) as RankByRevenue,
            -- Tổng số món để tính phân vị
            COUNT(*) OVER() as TotalItems
        FROM MENU_ITEM mi
        JOIN ORDER_DETAIL od ON mi.ItemID = od.ItemID
        JOIN ORDER_TABLE ot ON od.OrderID = ot.OrderID
        JOIN BRANCH b ON ot.BranchID = b.BranchID
        WHERE (@BranchID IS NULL OR ot.BranchID = @BranchID)
        AND ot.OrderDate BETWEEN @FromDate AND @ToDate
        GROUP BY mi.ItemID, mi.ItemName, ot.OrderDate
    )
    SELECT 
		RankByRevenue AS N'Top Doanh Thu',
		OrderDate AS N'Ngày',
        ItemName AS N'Tên Món',
        TotalQuantity AS N'Số lượng bán',
        ROUND(TotalRevenue, 2) AS N'Tổng Doanh Thu',
		ROUND(RevenuePercentage, 2) N'Doanh thu Trung Bình',
        CASE 
            WHEN RankByRevenue <= (TotalItems * 0.2) THEN N'Món chạy' -- Top 20%
            WHEN RankByRevenue > (TotalItems * 0.8) THEN N'Món chậm' -- Bottom 20%
            ELSE N'Món bình thường' -- Middle 60%
        END AS N'Đánh giá'
    FROM ItemStats
    ORDER BY RankByRevenue;
END

