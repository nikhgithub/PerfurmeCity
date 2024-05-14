CREATE PROCEDURE sp_Login
    @Email NVARCHAR(100),
    @Mobile NVARCHAR(15),
    @Password NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserID INT;

    -- Check if user exists based on email
    SELECT @UserID = UserID
    FROM Users
    WHERE Email = @Email AND Password = @Password;

    -- If user exists based on email, return UserID
    IF @UserID IS NOT NULL
    BEGIN
        SELECT @UserID AS UserID;
        RETURN 1; -- Success
    END;

    -- Check if user exists based on mobile number
    SELECT @UserID = UserID
    FROM Users
    WHERE Mobile = @Mobile AND Password = @Password;

    -- If user exists based on mobile number, return UserID
    IF @UserID IS NOT NULL
    BEGIN
        SELECT @UserID AS UserID;
        RETURN 1; -- Success
    END;

    -- If user does not exist based on email or mobile number, return error code
    RETURN -1; -- User not found
END;
