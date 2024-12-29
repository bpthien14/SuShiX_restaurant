CREATE or ALTER PROCEDURE sp_CheckLogin
    @LoginInput VARCHAR(50),  -- Có thể là SĐT hoặc Email
    @Password VARCHAR(100)
AS
BEGIN
    SELECT 
        c.CustomerID, 
        c.FullName,
        c.PhoneNumber,
        c.Email,
        mc.CardType,
        mc.AccumulatedPoints,
        u.UserID,
		u.Role
    FROM CUSTOMER c
    JOIN USERS u ON c.UserID = u.UserID
    LEFT JOIN MEMBERSHIP_CARD mc ON c.CustomerID = mc.CustomerID
    WHERE (c.PhoneNumber = @LoginInput OR c.Email = @LoginInput OR u.Username = @LoginInput)
    AND u.Password = @Password
END
GO

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
