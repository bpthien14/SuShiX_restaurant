--Để xác định trạng thái món chạy hay chậm, chúng ta cần stored procedure tính toán dựa trên doanh thu và số lượng bán:
CREATE PROCEDURE sp_GetMenuItemStatus
    @BranchID VARCHAR(255) = NULL,
    @RegionID INT = NULL,
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    WITH ItemStats AS (
        -- Tính tổng doanh thu và số lượng cho từng món
        SELECT 
            mi.ItemID,
            mi.ItemName,
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
        AND (@RegionID IS NULL OR b.RegionID = @RegionID)
        AND ot.OrderDate BETWEEN @FromDate AND @ToDate
        GROUP BY mi.ItemID, mi.ItemName
    )
    SELECT 
        ItemID,
        ItemName,
        TotalQuantity,
        TotalRevenue,
        RankByRevenue,
        CASE 
            WHEN RankByRevenue <= (TotalItems * 0.2) THEN N'Món chạy' -- Top 20%
            WHEN RankByRevenue > (TotalItems * 0.8) THEN N'Món chậm' -- Bottom 20%
            ELSE N'Món bình thường' -- Middle 60%
        END as ItemStatus,
        RevenuePercentage
    FROM ItemStats
    ORDER BY RankByRevenue;
END

