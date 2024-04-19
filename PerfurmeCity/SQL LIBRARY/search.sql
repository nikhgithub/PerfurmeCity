ALTER PROCEDURE [dbo].[SearchProducts]
    @SearchParam NVARCHAR(255)
AS
BEGIN
    -- Normalize delimiters by replacing spaces with commas
    SET @SearchParam = REPLACE(@SearchParam, ' ', ',');

    -- Define a temporary table to store each keyword
    DECLARE @Keywords TABLE (Keyword NVARCHAR(255));
    
    -- Insert split keywords into the temporary table
    INSERT INTO @Keywords
    SELECT value AS Keyword
    FROM STRING_SPLIT(@SearchParam, ',') -- Now splitting by commas only
    WHERE value <> ''; -- Ensure empty strings are not included

    -- Use a JOIN with the temporary table to find matches in Products
    SELECT DISTINCT p.*
    FROM Products p
    INNER JOIN @Keywords k ON p.Description LIKE '%' + k.Keyword + '%' 
                             OR p.Tags LIKE '%' + k.Keyword + '%';
END;
