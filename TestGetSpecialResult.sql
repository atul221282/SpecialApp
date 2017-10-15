DECLARE @p0 FLOAT = -34.809964;
DECLARE @p1 FLOAT = 138.680274;

SELECT S.Id, geography::STGeomFromText( L.Location,4236)
FROM Special S 
INNER JOIN SpecialLocation SL ON S.Id = SL.SpecialId
INNER JOIN [dbo].[Location] L ON SL.LocationId = L.Id
WHERE
geography::Point(@p0, @p1, 4326).STDistance(geography::Point(@p0, @p1, 4326)) <=4000;