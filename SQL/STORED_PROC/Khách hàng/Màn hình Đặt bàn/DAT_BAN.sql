-- Lấy danh sách chi nhánh theo khu vực
CREATE PROCEDURE sp_GetBranchesByArea
    @RegionID INT
AS
BEGIN
    SELECT 
        b.BranchID,
        b.BranchName,
        b.Address,
        b.OpeningTime,
        b.ClosingTime,
        b.BranchPhoneNumber,
        b.HasCarParking,
        b.HasBikeParking
    FROM BRANCH b
    WHERE b.RegionID = @RegionID
END
GO

-- Tạo đơn đặt bàn
CREATE PROCEDURE sp_CreateBooking
    @CustomerID VARCHAR(255),
    @BranchID VARCHAR(255),
    @BookingDate DATE,
    @ArrivalTime TIME,
    @GuestCount INT,
    @Notes VARCHAR(255),
    @GuestName VARCHAR(255),
    @GuestPhone VARCHAR(255)
AS
BEGIN
    INSERT INTO ONLINE_BOOKING (
        CustomerID, 
        BranchID, 
        BookingDate,
        ArrivalTime,
        GuestCount,
        Notes,
        GuestName,
        GuestPhone
    )
    VALUES (
        @CustomerID,
        @BranchID,
        @BookingDate,
        @ArrivalTime,
        @GuestCount,
        @Notes,
        @GuestName,
        @GuestPhone
    )
    
    SELECT SCOPE_IDENTITY() AS BookingID
END
GO