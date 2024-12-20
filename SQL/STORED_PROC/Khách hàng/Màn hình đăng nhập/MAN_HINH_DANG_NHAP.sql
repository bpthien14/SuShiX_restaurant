CREATE PROCEDURE sp_CheckLogin
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
        u.UserID
    FROM CUSTOMER c
    JOIN USERS u ON c.UserID = u.UserID
    LEFT JOIN MEMBERSHIP_CARD mc ON c.CustomerID = mc.CustomerID
    WHERE (c.PhoneNumber = @LoginInput OR c.Email = @LoginInput)
    AND u.Password = @Password
    AND u.Role = 'CUSTOMER'
END
GO

