PRINT N'Generating Sample sensor data, this will take some minutes'
DECLARE @DateId smallint, @DateValue date
DECLARE @RandomSeed int = 12345;
DECLARE @SinAngle decimal(9,2) = 0;
 
DECLARE date_time_cursor CURSOR  
    FOR SELECT Datum.DatumId AS DateId, Datum.Date AS DateValue FROM Datum where Datum.Date BETWEEN DATEADD(DAY,-7,GETDATE()) AND GETDATE() ORDER BY DatumId 
OPEN date_time_cursor
 
FETCH NEXT FROM date_time_cursor
INTO @DateId, @DateValue;
WHILE @@FETCH_STATUS = 0
BEGIN
   SET @SinAngle = @SinAngle + 0.01;
   DECLARE @Temperature1 decimal (9,2) = 24.5 + RAND() + 5.0 * SIN(@SinAngle);
   DECLARE @RHValue1 decimal(9,2) = 50 + RAND() + 20.0 * SIN(@SinAngle);
   DECLARE @Temperature2 decimal (9,2) = 20.5 + RAND() + 6.0 * SIN(@SinAngle + 90);
   DECLARE @RHValue2 decimal(9,2) = 60 + RAND() + 15.0 * SIN(@SinAngle + 90);
   DECLARE @Temperature3 decimal (9,2) = 22.5 + RAND() + 3.0 * SIN(@SinAngle + 45);
   DECLARE @RHValue3 decimal(9,2) = 70 + RAND() + 10.0 * SIN(@SinAngle + 45);
   DECLARE @Temperature4 decimal (9,2) = 27.5 + RAND() + 4.0 * SIN(@SinAngle + 30);
   DECLARE @RHValue4 decimal(9,2) = 35 + RAND() + 17.0 * SIN(@SinAngle + 30);
   DECLARE @Temperature5 decimal (9,2) = 10.0 + RAND() + 7.0 * SIN(@SinAngle + 60);
   DECLARE @RHValue5 decimal(9,2) = 40 + RAND() + 25.0 * SIN(@SinAngle + 60);
   DECLARE @loop_iterator AS int = 0 --starting 30 days back in time
WHILE @loop_iterator < 1 -- Vrijednosti
BEGIN

 INSERT INTO SensorReading (SensorId,DatumId,Reading,Vrijeme) VALUES
 (2,@DateId,@Temperature1, GETDATE()),
 (3,@DateId,@RHValue1, GETDATE()),
 (4,@DateId,@Temperature2, GETDATE()),
 (5,@DateId,@RHValue2, GETDATE()),
 (6,@DateId,@Temperature3, GETDATE()),
 (7,@DateId,@RHValue3, GETDATE()),
 (8,@DateId,@Temperature4, GETDATE()),
 (9,@DateId,@RHValue4, GETDATE()),
 (10,@DateId,@Temperature5, GETDATE()),
 (11,@DateId,@RHValue5, GETDATE())


 INSERT INTO EvilSensorReading (SensorId,Reading,Vrijeme) VALUES
 (2,@Temperature1, GETDATE()),
 (3,@RHValue1, GETDATE()),
 (4,@Temperature2, GETDATE()),
 (5,@RHValue2, GETDATE()),
 (6,@Temperature3, GETDATE()),
 (7,@RHValue3, GETDATE()),
 (8,@Temperature4, GETDATE()),
 (9,@RHValue4, GETDATE()),
 (10,@Temperature5, GETDATE()),
 (11,@RHValue5, GETDATE())

 SET @loop_iterator = @loop_iterator + 1
END

 FETCH NEXT FROM date_time_cursor
 INTO @DateId, @DateValue;
END;
CLOSE date_time_cursor
DEALLOCATE date_time_cursor
GO