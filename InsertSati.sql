DECLARE @loop_iterator AS int =0 --starting 30 days back in time
WHILE @loop_iterator < 24 -- maximum for small int; change if using different datatype
BEGIN
   INSERT INTO Sat VALUES(@loop_iterator);
   SET @loop_iterator = @loop_iterator + 1
END
GO