-- Lấy danh sách món ăn theo danh mục
CREATE PROCEDURE sp_GetMenuByCategory
    @CategoryID VARCHAR(255) = NULL,
    @SearchText NVARCHAR(100) = NULL,
    @BranchID VARCHAR(255) = NULL
AS
BEGIN
    SELECT 
        mi.ItemID,
        mi.ItemName,
        mi.CurrentPrice,
        mi.DeliveryAvailable,
        mc.CategoryName,
        CASE 
            WHEN mia.IsAvailable = 1 THEN N'Còn món'
            ELSE N'Hết món'
        END AS AvailabilityStatus
    FROM MENU_ITEM mi
    JOIN MENU_CATEGORY mc ON mi.CategoryID = mc.CategoryID
    LEFT JOIN MENU_ITEM_AVAILABILITY mia ON mi.ItemID = mia.ItemID 
        AND (@BranchID IS NULL OR mia.BranchID = @BranchID)
    WHERE (@CategoryID IS NULL OR mi.CategoryID = @CategoryID)
    AND (@SearchText IS NULL 
        OR mi.ItemName LIKE N'%' + @SearchText + N'%')
    ORDER BY mc.CategoryName, mi.ItemName
END
GO