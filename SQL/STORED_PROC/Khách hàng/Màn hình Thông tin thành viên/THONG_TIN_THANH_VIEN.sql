-- Lấy thông tin thành viên
CREATE PROCEDURE sp_GetMemberInfo
    @CustomerID VARCHAR(255)
AS
BEGIN
    SELECT 
        c.FullName,
        c.PhoneNumber,
        c.Email,
        c.Gender,
        mc.CardType,
        mc.AccumulatedPoints,
        mc.RegistrationDate,
        CASE 
            WHEN mc.CardType = 'MEMBER' AND mc.AccumulatedPoints < 100 
                THEN 100 - mc.AccumulatedPoints
            WHEN mc.CardType = 'SILVER' AND mc.AccumulatedPoints < 200 
                THEN 200 - mc.AccumulatedPoints
            ELSE 0
        END AS PointsToNextTier
    FROM CUSTOMER c
    LEFT JOIN MEMBERSHIP_CARD mc ON c.CustomerID = mc.CustomerID
    WHERE c.CustomerID = @CustomerID
END
GO