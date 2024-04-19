CREATE FUNCTION dbo.SplitString
(
    @List NVARCHAR(MAX),
    @Delim VARCHAR(255)
)
RETURNS TABLE
AS
RETURN 
(
    SELECT value FROM STRING_SPLIT(@List, @Delim)
)
