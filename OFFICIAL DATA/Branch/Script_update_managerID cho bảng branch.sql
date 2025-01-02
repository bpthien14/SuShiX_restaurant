-- 1. Xóa khóa ngoại nếu đã tồn tại
IF EXISTS (
    SELECT * 
    FROM sys.foreign_keys 
    WHERE name = 'FK_Branch_Manager'
)
BEGIN
    ALTER TABLE BRANCH
    DROP CONSTRAINT FK_Branch_Manager;
END

-- 2. Set tất cả ManagerID về NULL
UPDATE BRANCH
SET ManagerID = NULL;

-- 3. Kiểm tra xem đã reset thành công chưa
SELECT COUNT(*) as TotalBranches, 
       SUM(CASE WHEN ManagerID IS NULL THEN 1 ELSE 0 END) as NullManagerCount
FROM BRANCH;

GO


-- 1. Tạo bảng tạm để lưu danh sách managers
WITH NumberedManagers AS (
    SELECT 
        StaffID,
        ROW_NUMBER() OVER (ORDER BY NEWID()) as ManagerNumber,
        (SELECT COUNT(*) FROM STAFF WHERE DepartmentID = 'DEPT_MGR') as TotalManagers
    FROM STAFF 
    WHERE DepartmentID = 'DEPT_MGR'
),
-- 2. Đánh số thứ tự cho các chi nhánh
NumberedBranches AS (
    SELECT 
        BranchID,
        ROW_NUMBER() OVER (ORDER BY NEWID()) as BranchNumber
    FROM BRANCH
)
-- 3. Update ManagerID cho từng chi nhánh
UPDATE b
SET b.ManagerID = m.StaffID
FROM BRANCH b
JOIN NumberedBranches nb ON b.BranchID = nb.BranchID
JOIN NumberedManagers m ON ((nb.BranchNumber - 1) % m.TotalManagers) + 1 = m.ManagerNumber;

-- 4. Kiểm tra phân bổ
SELECT 
    s.FullName as ManagerName,
    COUNT(*) as BranchCount,
    STRING_AGG(LEFT(b.BranchName, 30), '; ') as Branches
FROM BRANCH b
JOIN STAFF s ON b.ManagerID = s.StaffID
GROUP BY s.FullName
ORDER BY BranchCount DESC;

-- 5. Kiểm tra tổng quan
SELECT 
    MIN(BranchCount) as MinBranches,
    MAX(BranchCount) as MaxBranches,
    AVG(CAST(BranchCount as FLOAT)) as AvgBranches
FROM (
    SELECT 
        s.StaffID,
        COUNT(*) as BranchCount
    FROM BRANCH b
    JOIN STAFF s ON b.ManagerID = s.StaffID
    GROUP BY s.StaffID
) t;

-- 6. Kiểm tra chi nhánh chưa có manager
SELECT COUNT(*) as BranchesWithoutManager
FROM BRANCH
WHERE ManagerID IS NULL;

-- Update cho các chi nhánh chưa có manager
WITH AvailableManagers AS (
    SELECT s.StaffID
    FROM STAFF s
    WHERE s.DepartmentID = 'DEPT_MGR'
    AND NOT EXISTS (
        SELECT 1 
        FROM BRANCH b 
        WHERE b.ManagerID = s.StaffID
    )
)
UPDATE b
SET b.ManagerID = (
    SELECT TOP 1 StaffID
    FROM AvailableManagers
    ORDER BY NEWID()
)
FROM BRANCH b
WHERE b.ManagerID IS NULL;

-- Kiểm tra kết quả
SELECT 
    COUNT(*) as TotalBranches,
    SUM(CASE WHEN ManagerID IS NULL THEN 1 ELSE 0 END) as NullManagerCount
FROM BRANCH;

-- Xem phân bổ chi nhánh cho các manager
SELECT 
    s.FullName as ManagerName,
    COUNT(*) as BranchCount
FROM BRANCH b
JOIN STAFF s ON b.ManagerID = s.StaffID
GROUP BY s.FullName
ORDER BY BranchCount DESC;