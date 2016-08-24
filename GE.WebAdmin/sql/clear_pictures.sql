DECLARE @result TABLE(id UNIQUEIDENTIFIER)

INSERT INTO @result
SELECT dp.Id FROM D_PICTURE AS dp WHERE dp.Id IN (SELECT anu.AvatarId FROM AspNetUsers AS anu)

INSERT INTO @result
SELECT dp.Id FROM D_PICTURE AS dp WHERE dp.Id IN (SELECT daa.PictureId FROM D_AUTHOR_APHORISM AS daa)

INSERT INTO @result
SELECT dp.Id FROM D_PICTURE AS dp WHERE dp.Id IN (SELECT db.PictureId FROM D_BANNER AS db)

INSERT INTO @result
SELECT dp.Id FROM D_PICTURE AS dp WHERE dp.Id IN (SELECT dg.FrontPictureId FROM D_GAME AS dg)
OR dp.Id IN (SELECT dg.GoodPictureId FROM D_GAME AS dg)
OR dp.Id IN (SELECT dg.BadPictureId FROM D_GAME AS dg)

INSERT INTO @result
SELECT dp.Id FROM D_PICTURE AS dp WHERE dp.Id IN (SELECT dmc.FrontPictureId FROM D_MATERIAL_CATEGORY AS dmc)

DECLARE @value NVARCHAR(MAX)
DECLARE c CURSOR FORWARD_ONLY LOCAL FAST_FORWARD FOR
SELECT dss.[Value] FROM D_SITE_SETTING AS dss
OPEN c
FETCH NEXT FROM c INTO @value
WHILE @@FETCH_STATUS=0
BEGIN
	BEGIN TRY
		DECLARE @pictureId UNIQUEIDENTIFIER
		SET @pictureId=CAST(@value AS UNIQUEIDENTIFIER)
		IF EXISTS(SELECT dp.Id FROM D_PICTURE AS dp WHERE Id=@pictureId)
			INSERT INTO @result VALUES(@pictureId)
	END TRY
	BEGIN CATCH
		
	END CATCH
	FETCH NEXT FROM c INTO @value
END
CLOSE c
DEALLOCATE c

INSERT INTO @result
SELECT dp.Id FROM D_PICTURE AS dp WHERE dp.Id IN (SELECT dsts.PictureId FROM D_SITE_TEST_SUBJECT AS dsts)

INSERT INTO @result
SELECT dp.Id FROM D_PICTURE AS dp WHERE dp.Id IN (SELECT dm.FrontPictureId FROM DV_MATERIAL AS dm)

INSERT INTO @result
SELECT dp.Id FROM D_PICTURE AS dp WHERE dp.Id IN (SELECT dp2.Id
                                                    FROM D_PICTURE AS dp2 JOIN DV_MATERIAL AS dm ON dm.Html LIKE '%'+cast(dp2.Id AS NVARCHAR(128))+'%')


SELECT dp.Id FROM D_PICTURE AS dp WHERE dp.Id NOT IN(SELECT Id FROM @result)