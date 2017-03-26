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



declare @lat decimal(9,6) = 47.9898
,@lon decimal(9,6) = -122.3434;
declare @g geography  = geography::Point(@lat,@lon,4326)
--select Location.STDistance(@g);


 select geography::STGeomFromText('POINT(-122.0 37.0)', 4326).STDistance(@g)

 --select geography::Point(@lat1, @lon1, 4326).STDistance(geography::Point(@lat2, @lon2, 4326))