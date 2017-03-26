--convert long and lat to geography
declare @Longitude as FLOAT = 102.333;
declare @Latitude as FLOAT = 89.121212;
 select geography::STGeomFromText('POINT(' + CAST(@Longitude AS VARCHAR(20)) + ' ' + 
                    CAST(@Latitude AS VARCHAR(20)) + ')', 4326)

--========================================================================================================================================
--lets say u want to find all Point Of Interests in a 1KM circle. (note i'm using KM not miles .. and no, this is not some anti-us thing).
-- First create a Point.
-- Format is Longitude, Latitude and then SRID .. which means sorta like 'this is a GPS location'
DECLARE @point GEOGRAPHY = GEOGRAPHY::STGeomFromText('POINT(-73.9920 40.7316)', 4326);
-- Now lets grab all POI's in a 500 meter _radius_ <- that means a 1km circle.
SELECT Id, Name
FROM someDatabase.dbo.PointOfInterests a
WHERE @point.STBuffer(500).STIntersects(a.CentrePoint) = 1



declare @lat decimal(9,6) = -34.809964
,@lon decimal(9,6) = 138.680274;
declare @g geography  = geography::Point(@lat,@lon,4326)
--select Location.STDistance(@g);


 --select geography::STGeomFromText('POINT(-122.0 37.0)', 4326).STDistance(@g)

 select Id, L.Latitude, L.Longitude, geography::Point(L.Latitude, L.Longitude, 4326).STDistance(geography::Point(@lat, @lon, 4326)) from
 [dbo].[Location] L

 select getdate()

 SET IDENTITY_INSERT [dbo].[Location] ON
INSERT INTO [dbo].[Location] ([AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], 
[IsDeleted], [Latitude], [Longitude]) 
	VALUES (N'system', N'3/26/2017 8:40:56 PM +10:30', N'system', N'3/26/2017 8:40:56 PM +10:30', 0, -34.809964, 138.680274)

INSERT INTO [dbo].[Location] ([AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], 
[IsDeleted], [Latitude], [Longitude]) 
	VALUES (N'system', N'3/26/2017 8:40:56 PM +10:30', N'system', N'3/26/2017 8:40:56 PM +10:30', 0, -34.774642, 138.672661)
SET IDENTITY_INSERT [dbo].[Location] OFF
