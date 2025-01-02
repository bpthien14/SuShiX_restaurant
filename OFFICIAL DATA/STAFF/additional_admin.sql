UPDATE USERS 
SET Role = 'ADMIN'
WHERE UserID IN (
    -- Lấy UserID của một số nhân viên BOD và MGR
    SELECT s.UserID
    FROM STAFF s
    WHERE s.DepartmentID IN ('DEPT_BOD', 'DEPT_MGR')
    AND s.EndDate IS NULL  -- Đang còn làm việc
    AND EXISTS (
        -- Kiểm tra thâm niên > 5 năm
        SELECT 1 
        WHERE DATEDIFF(YEAR, s.StartDate, GETDATE()) > 5
    )
)
OR UserID IN (
    -- Danh sách cụ thể một số UserID được chọn làm admin
    'db3cc3be-5f91-4aa7-9c7b-78c5cb018bbd',  -- Hoàng Minh (BOD)
    '0c4d7e51-b894-43f9-b9d8-cf2b1b107f7a',  -- Phan Minh (MGR)
    '581fe177-b10b-4178-a5a7-1a8f35994f92'   -- Nguyễn Thị (MGR)
);