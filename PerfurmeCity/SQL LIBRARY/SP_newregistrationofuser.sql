CREATE PROCEDURE sp_SaveRegistrationDetails
    @Name NVARCHAR(100),
    @Age INT,
    @Gender NVARCHAR(10),
    @Mobile NVARCHAR(20),
    @Email NVARCHAR(100),
    @Password NVARCHAR(100)
AS
BEGIN
    -- Check if email or mobile number already exists
    IF EXISTS (SELECT 1 FROM Users WHERE Email = @Email OR Mobile = @Mobile)
    BEGIN
        -- Return error code indicating user already exists
        RETURN -1;
    END

    -- If user does not exist, insert new record
    INSERT INTO Users (Name, Age, Gender, Mobile, Email, Password)
    VALUES (@Name, @Age, @Gender, @Mobile, @Email, @Password)

    -- Return success code indicating successful insertion
    RETURN 1;
END
