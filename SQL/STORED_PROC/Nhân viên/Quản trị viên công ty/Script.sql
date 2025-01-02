CREATE OR ALTER PROCEDURE sp_GetRevenueStatisticsByBranch
    @StartDate DATE,
    @EndDate DATE,
    @BranchID VARCHAR(255)
AS
BEGIN
    SELECT 
        b.BranchName AS N'Chi Nhánh',
        CAST(bi.CreatedAt AS DATE) AS N'Ngày',
        COUNT(*) AS N'Số đơn',
        ROUND(SUM(bi.FinalAmount), 2) AS N'Tổng Doanh Thu',
        ROUND(AVG(bi.FinalAmount), 2) AS N'Trung Bình'
    FROM BOOKING_INVOICE bi
    JOIN ONLINE_BOOKING ob ON bi.BookingID = ob.BookingID
    JOIN BRANCH b ON ob.BranchID = b.BranchID
    WHERE CAST(bi.CreatedAt AS DATE) BETWEEN @StartDate AND @EndDate
    AND (@BranchID IS NULL OR b.BranchID = @BranchID)
    GROUP BY b.BranchName, CAST(bi.CreatedAt AS DATE)
    ORDER BY CAST(bi.CreatedAt AS DATE);
END;
GO

CREATE OR ALTER PROCEDURE sp_GetMenuItemStatus
    @BranchID VARCHAR(255),
    @FromDate DATE,
    @ToDate DATE,
    @ItemID VARCHAR(255)
AS
BEGIN
    WITH ItemStats AS (
        -- Tính tổng doanh thu và số lượng cho từng món
        SELECT 
            mi.ItemID,
            mi.ItemName,
            CAST(ob.BookingDate AS DATE) as OrderDate,
            SUM(obo.Quantity) as TotalQuantity,
            SUM(obo.Quantity * obo.UnitPrice) as TotalRevenue,
            -- Tính phần trăm đóng góp vào tổng doanh thu
            (SUM(obo.Quantity * obo.UnitPrice) * 100.0 / 
             SUM(SUM(obo.Quantity * obo.UnitPrice)) OVER()) as RevenuePercentage,
            -- Xếp hạng theo doanh thu
            ROW_NUMBER() OVER(ORDER BY SUM(obo.Quantity * obo.UnitPrice) DESC) as RankByRevenue,
            -- Tổng số món để tính phân vị
            COUNT(*) OVER() as TotalItems
        FROM MENU_ITEM mi
        JOIN ONLINE_BOOKING_ORDER obo ON mi.ItemID = obo.ItemID
        JOIN ONLINE_BOOKING ob ON obo.BookingID = ob.BookingID
        JOIN BRANCH b ON ob.BranchID = b.BranchID
        WHERE (@BranchID IS NULL OR ob.BranchID = @BranchID)
        AND (@ItemID IS NULL OR mi.ItemID = @ItemID)
        AND ob.BookingDate BETWEEN @FromDate AND @ToDate
        AND ob.Status != 'CANCELLED'  -- Không tính đơn đã hủy
        GROUP BY mi.ItemID, mi.ItemName, CAST(ob.BookingDate AS DATE)
    )
    SELECT 
        RankByRevenue AS N'Xếp hạng',
        OrderDate AS N'Ngày',
        ItemName AS N'Tên Món',
        TotalQuantity AS N'Số lượng bán',
        ROUND(TotalRevenue, 2) AS N'Tổng Doanh Thu',
        ROUND(RevenuePercentage, 2) AS N'Doanh thu Trung Bình',
        CASE 
            WHEN RankByRevenue <= (TotalItems * 0.2) THEN N'Món chạy' -- Top 20%
            WHEN RankByRevenue > (TotalItems * 0.8) THEN N'Món chậm' -- Bottom 20%
            ELSE N'Món bình thường' -- Middle 60%
        END AS N'Đánh giá'
    FROM ItemStats
    ORDER BY RankByRevenue;
END;

CREATE OR ALTER PROCEDURE sp_GetStaffStatistics
    @BranchID VARCHAR(255) = NULL,   -- Allow NULL for BranchID
    @DepartmentID VARCHAR(255) = NULL, -- Allow NULL for DepartmentID
    @RegionID INT  
AS
BEGIN
    SELECT 
        s.FullName AS N'Họ Tên',
		r.RegionName N'Khu Vực',
        b.BranchName N'Chi Nhánh',
        d.DepartmentName N'Bộ Phận',
		s.PhoneNumber N'SĐT',
        s.Salary N'Lương'
    FROM STAFF s
    JOIN BRANCH b ON s.BranchID = b.BranchID
    JOIN DEPARTMENT d ON s.DepartmentID = d.DepartmentID
    JOIN REGION r ON b.RegionID = r.RegionID
    WHERE (@BranchID IS NULL OR s.BranchID = @BranchID)
      AND (@DepartmentID IS NULL OR s.DepartmentID = @DepartmentID)
      AND (@RegionID = -1  OR b.RegionID = @RegionID)
    ORDER BY s.Salary DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdateDepartmentSalary
    @DepartmentID VARCHAR(255),
    @BranchID VARCHAR(255),
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
            -- Kiểm tra bộ phận và chi nhánh có tồn tại
            IF NOT EXISTS (SELECT 1 FROM DEPARTMENT WHERE DepartmentID = @DepartmentID)
            BEGIN
                RAISERROR('Bộ phận không tồn tại!', 16, 1);
                RETURN;
            END

            IF NOT EXISTS (SELECT 1 FROM BRANCH WHERE BranchID = @BranchID)
            BEGIN
                RAISERROR('Chi nhánh không tồn tại!', 16, 1);
                RETURN;
            END

            -- Cập nhật lương cho nhân viên
            UPDATE STAFF
            SET Salary = @NewSalary
            WHERE DepartmentID = @DepartmentID 
            AND BranchID = @BranchID;

            -- Kiểm tra số lượng bản ghi đã cập nhật
            IF @@ROWCOUNT = 0
            BEGIN
                RAISERROR('Không có nhân viên nào được cập nhật!', 16, 1);
                RETURN;
            END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
go
CREATE OR ALTER PROCEDURE sp_CheckLogin_Staff
    @LoginInput NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    SELECT 
        s.StaffID, 
		s.BranchID,
        s.FullName, 
        s.PhoneNumber,
        u.UserID, 
        u.Role
    FROM STAFF s
    JOIN USERS u ON s.UserID = u.UserID
    WHERE (s.PhoneNumber = @LoginInput OR u.Username = @LoginInput)
      AND u.Password = @Password
      AND (u.Role = 'Manager' OR u.Role = 'admin');
END;
GO


