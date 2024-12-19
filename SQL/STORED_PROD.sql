USE SUSHI_X
GO
-- KICH BAN 1 (MO TA UPDATE SAU)
CREATE PROCEDURE GetItemRevenue
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        mi.ItemID, 
        mi.ItemName, 
        SUM(od.Quantity) AS TotalQuantity, 
        SUM(od.Quantity * mi.CurrentPrice) AS TotalRevenue
    FROM 
        ORDER_DETAIL od
    INNER JOIN 
        MENU_ITEM mi ON od.ItemID = mi.ItemID
    INNER JOIN 
        ORDER_TABLE ot ON od.OrderID = ot.OrderID
    WHERE 
        ot.OrderDate BETWEEN @StartDate AND @EndDate
    GROUP BY 
        mi.ItemID, mi.ItemName
    ORDER BY 
        TotalRevenue DESC;
END

GO
EXEC GetItemRevenue '2023-01-01', '2023-12-31';
GO
-- KICH BAN 2 (MO TA UPDATE SAU)
CREATE PROCEDURE GetBranchRevenue
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        b.BranchID,
        b.BranchName, 
        SUM(i.FinalAmount) AS TotalRevenue
    FROM 
        INVOICE i
    JOIN 
        ORDER_TABLE ot ON i.OrderID = ot.OrderID
    JOIN 
        BRANCH b ON ot.BranchID = b.BranchID
    WHERE 
        i.CreatedAt BETWEEN @StartDate AND @EndDate
    GROUP BY 
        b.BranchID, b.BranchName
    ORDER BY 
        TotalRevenue DESC;
END
GO

EXEC GetBranchRevenue '2023-01-01', '2023-12-31';

GO
-- KICH BAN 3 (MO TA UPDATE SAU)
CREATE PROCEDURE GetStaffRevenue
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        s.StaffID,
        s.FullName,
        COUNT(i.InvoiceID) AS TotalOrders,
        SUM(i.FinalAmount) AS TotalRevenue
    FROM 
        INVOICE i
    JOIN 
        ORDER_TABLE ot ON i.OrderID = ot.OrderID
    JOIN 
        STAFF s ON ot.StaffID = s.StaffID
    WHERE 
        i.CreatedAt BETWEEN @StartDate AND @EndDate
    GROUP BY 
        s.StaffID, s.FullName
    ORDER BY 
        TotalRevenue DESC;
END
GO

EXEC GetStaffRevenue '2023-01-01', '2023-12-31';
GO
-- KICH BAN 4 (MO TA UPDATE SAU)
CREATE PROCEDURE UpdateDepartmentSalary
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
GO

EXEC UpdateDepartmentSalary 
    @DepartmentID = 'DP01882',
    @BranchID = 'BR00342',
    @NewSalary = 25855.5;
GO
-- KICH BAN 5 (MO TA UPDATE SAU)
CREATE PROCEDURE AnalyzeMonthlyRevenue
    @Year INT
AS
BEGIN
    SELECT 
        MONTH(i.CreatedAt) AS Month,
        SUM(i.FinalAmount) AS TotalRevenue
    FROM 
        INVOICE i
    WHERE 
        YEAR(i.CreatedAt) = @Year
    GROUP BY 
        MONTH(i.CreatedAt)
    ORDER BY 
        Month;
END
GO
EXEC AnalyzeMonthlyRevenue @Year = 2024;
GO