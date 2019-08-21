DECLARE @loop_iterator AS int = -60 --starting 30 days back in time
DECLARE @date_var AS Date = DATEADD(DAY,@loop_iterator,GETDATE())
WHILE @loop_iterator < 65506 -- maximum for small int; change if using different datatype
BEGIN
   DECLARE @temp_date AS date = DATEADD(DAY,@loop_iterator,@date_var)
   INSERT INTO Datum VALUES(@temp_date);
   SET @loop_iterator = @loop_iterator + 1
END
GO