﻿/************************************************************
 * Code formatted by SoftTree SQL Assistant © v6.5.278
 * Time: 04.10.2016 11:30:30
 ************************************************************/

/*******************************************
 * Получить игру
 *******************************************/
IF OBJECT_ID(N'dbo.get_game', N'P') IS NOT NULL
    DROP PROCEDURE dbo.get_game;
GO
CREATE PROCEDURE dbo.get_game
	@id INT
AS
BEGIN
	SELECT TOP(2) dg.*,
	       dp.Id,
	       dp.Caption,
	       dp2.Id,
	       dp2.Caption,
	       dp3.Id,
	       dp3.Caption
	FROM   D_GAME               AS dg
	       LEFT JOIN D_PICTURE  AS dp
	            ON  dp.Id = dg.FrontPictureId
	       LEFT JOIN D_PICTURE  AS dp2
	            ON  dp2.Id = dg.GoodPictureId
	       LEFT JOIN D_PICTURE  AS dp3
	            ON  dp3.Id = dg.BadPictureId
	WHERE  dg.Id = 1
END
GO

/*******************************************
 * Добавить категорию материалов (переопределено)
 *******************************************/
IF OBJECT_ID(N'dbo.add_material_category', N'P') IS NOT NULL
    DROP PROCEDURE dbo.add_material_category;
GO
CREATE PROCEDURE dbo.add_material_category
	@categoryId NVARCHAR(128),
	@title NVARCHAR(100),
	@mct INT,
	@pcid NVARCHAR(128),
	@pictureId UNIQUEIDENTIFIER,
	@gameId INT
AS
BEGIN
	IF NOT EXISTS (
	       SELECT TOP 1 dmc.Id
	       FROM   D_MATERIAL_CATEGORY AS dmc
	       WHERE  dmc.Id = @categoryId
	   )
	BEGIN
	    DECLARE @date DATETIME = GETDATE()
	    INSERT INTO D_MATERIAL_CATEGORY
	      (
	        Id,
	        Title,
	        ModelCoreType,
	        ParentId,
	        FrontPictureId,
	        DateCreate,
	        GameId,
	        Discriminator
	      )
	    VALUES
	      (
	        @categoryId,
	        @title,
	        @mct,
	        @pcid,
	        @pictureId,
	        @date,
	        @gameId,
	        'SxMaterialCategory'
	      )
	    
	    EXEC dbo.get_material_category @categoryId
	END
END
GO

/*******************************************
 * Обновить категорию материалов
 *******************************************/
IF OBJECT_ID(N'dbo.update_material_category', N'P') IS NOT NULL
    DROP PROCEDURE dbo.update_material_category;
GO
CREATE PROCEDURE dbo.update_material_category
	@oldCategoryId NVARCHAR(128),
	@categoryId NVARCHAR(128),
	@title NVARCHAR(100),
	@mct INT,
	@pcid NVARCHAR(128),
	@pictureId UNIQUEIDENTIFIER,
	@gameId INT
AS
BEGIN
	IF (@oldCategoryId = @categoryId)
	BEGIN
	    UPDATE D_MATERIAL_CATEGORY
	    SET    Title              = @title,
	           ModelCoreType      = @mct,
	           ParentId           = @pcid,
	           FrontPictureId     = @pictureId
	    WHERE  Id                 = @categoryId
	END
	ELSE
	BEGIN
	    IF NOT EXISTS (
	           SELECT TOP 1 dmc.Id
	           FROM   D_MATERIAL_CATEGORY AS dmc
	           WHERE  dmc.Id = @categoryId
	       )
	    BEGIN
	        BEGIN TRANSACTION
	        
	        ALTER TABLE [dbo].[DV_MATERIAL] DROP CONSTRAINT 
	        [FK_dbo.DV_MATERIAL_dbo.D_MATERIAL_CATEGORY_CategoryId];
	        
	        UPDATE DV_MATERIAL
	        SET    CategoryId = @categoryId
	        WHERE  CategoryId = @oldCategoryId
	        
	        --PRINT '1'
	        
	        UPDATE D_MATERIAL_CATEGORY
	        SET    ParentId = @categoryId
	        WHERE  ParentId = @oldCategoryId
	        
	        --PRINT '2'
	        
	        UPDATE D_MATERIAL_CATEGORY
	        SET    Id = @categoryId,
	               Title = @title,
	               ModelCoreType = @mct,
	               ParentId = @pcid,
	               FrontPictureId = @pictureId,
	               GameId = @gameId
	        WHERE  Id = @oldCategoryId
	        
	        --PRINT '3'
	        
	        ALTER TABLE [dbo].[DV_MATERIAL]  
	        WITH CHECK ADD CONSTRAINT 
	             [FK_dbo.DV_MATERIAL_dbo.D_MATERIAL_CATEGORY_CategoryId] FOREIGN 
	             KEY([CategoryId])
	             REFERENCES [dbo].[D_MATERIAL_CATEGORY] ([Id]);
	        
	        --PRINT '4'
	        
	        ALTER TABLE [dbo].[DV_MATERIAL] CHECK CONSTRAINT 
	        [FK_dbo.DV_MATERIAL_dbo.D_MATERIAL_CATEGORY_CategoryId];
	        
	        --PRINT '5'
	        
	        COMMIT TRANSACTION
	    END
	END
	
	EXEC dbo.get_material_category @categoryId
END
GO

/*******************************************
* удалить автора афоризмов
*******************************************/
IF OBJECT_ID(N'dbo.del_author_aphorism', N'P') IS NOT NULL
    DROP PROCEDURE dbo.del_author_aphorism;
GO
CREATE PROCEDURE dbo.del_author_aphorism
	@authorId INT
AS
BEGIN
	UPDATE D_APHORISM
	SET    AuthorId = NULL
	WHERE  AuthorId = @authorId
	
	DELETE 
	FROM   D_AUTHOR_APHORISM
	WHERE  Id = @authorId
END
GO

/*******************************************
* получить игры для материалов
*******************************************/
IF OBJECT_ID(N'dbo.get_material_games', N'P') IS NOT NULL
    DROP PROCEDURE dbo.get_material_games;
GO
CREATE PROCEDURE dbo.get_material_games
	@id INT,
	@mct INT
AS
BEGIN
	SELECT TOP(2)
		dg.Id,
		dg.Title,
		da.GameVersion AS ArticleGameVersion,
		dn.GameVersion AS NewsGameVersion
	FROM   DV_MATERIAL          AS dm
	       LEFT JOIN D_ARTICLE  AS da
	            ON  da.ModelCoreType = dm.ModelCoreType
	            AND da.Id = dm.Id
	       LEFT JOIN D_NEWS     AS dn
	            ON  dn.ModelCoreType = dm.ModelCoreType
	            AND dn.Id = dm.Id
	       JOIN D_GAME          AS dg
	            ON  dg.Id = da.GameId OR dg.Id = dn.GameId
	WHERE  dm.Id = @id
	       AND dm.ModelCoreType = @mct
END
GO

/*******************************************
 * добавить тест сайта
 *******************************************/
IF OBJECT_ID(N'dbo.add_site_test', N'P') IS NOT NULL
    DROP PROCEDURE dbo.add_site_test;
GO
CREATE PROCEDURE dbo.add_site_test
	@title NVARCHAR(200),
	@desc NVARCHAR(1000),
	@rules NVARCHAR(MAX),
	@titleUrl VARCHAR(255),
	@type INT,
	@show BIT
AS
BEGIN
	IF NOT EXISTS (
	       SELECT TOP(1) *
	       FROM   D_SITE_TEST AS dst
	       WHERE  dst.TitleUrl = @titleUrl
	   )
	BEGIN
	    INSERT INTO D_SITE_TEST
	      (
	        Title,
	        [Description],
	        Rules,
	        DateUpdate,
	        DateCreate,
	        TitleUrl,
	        [Type],
	        Show,
	        ViewsCount,
	        ShowSubjectDesc
	      )
	    VALUES
	      (
	        @title,
	        @desc,
	        @rules,
	        GETDATE(),
	        GETDATE(),
	        @titleUrl,
	        @type,
	        @show,
	        0,
	        0
	      )
	    
	    DECLARE @id INT
	    SET @id = @@identity
	    
	    SELECT TOP(2) *
	    FROM   D_SITE_TEST AS dst
	    WHERE  dst.Id = @id
	END
END
GO

/*******************************************
 * Правила теста
 *******************************************/
IF OBJECT_ID(N'dbo.get_site_test_rules', N'P') IS NOT NULL
    DROP PROCEDURE dbo.get_site_test_rules;
GO
CREATE PROCEDURE dbo.get_site_test_rules
	@testId INT
AS
BEGIN
	SELECT TOP 1 dst.Title,
	       dst.Rules
	FROM   D_SITE_TEST AS dst
	WHERE  dst.Id = @testId
END
GO


 
/*******************************************
 * удалить тест сайта
 *******************************************/
IF OBJECT_ID(N'dbo.del_site_test', N'P') IS NOT NULL
    DROP PROCEDURE dbo.del_site_test;
GO
CREATE PROCEDURE dbo.del_site_test
	@testId INT
AS
	BEGIN TRANSACTION
	
	DELETE 
	FROM   D_SITE_TEST_ANSWER
	WHERE  SubjectId IN (SELECT dsts.Id
	                     FROM   D_SITE_TEST_SUBJECT AS dsts
	                     WHERE  dsts.TestId = @testId)
	
	DELETE 
	FROM   D_SITE_TEST
	WHERE  Id = @testId
	
	COMMIT TRANSACTION
GO

/*******************************************
 * добавить вопрос теста
 *******************************************/
IF OBJECT_ID(N'dbo.add_site_test_question', N'P') IS NOT NULL
    DROP PROCEDURE dbo.add_site_test_question;
GO
CREATE PROCEDURE dbo.add_site_test_question
	@testId INT,
	@text NVARCHAR(500)
AS
BEGIN
	IF NOT EXISTS (
	       SELECT TOP(1) *
	       FROM   D_SITE_TEST_QUESTION AS dstq
	       WHERE  dstq.TestId = @testId
	              AND dstq.[Text] = @text
	   )
	BEGIN
	    INSERT INTO D_SITE_TEST_QUESTION
	      (
	        TestId,
	        [Text],
	        DateUpdate,
	        DateCreate
	      )
	    VALUES
	      (
	        @testId,
	        @text,
	        GETDATE(),
	        GETDATE()
	      )
	    
	    DECLARE @id INT
	    SET @id = @@identity
	    
	    INSERT INTO D_SITE_TEST_ANSWER
	      (
	        QuestionId,
	        SubjectId,
	        DateUpdate,
	        DateCreate,
	        IsCorrect
	      )
	    SELECT @id,
	           dsts.Id,
	           GETDATE(),
	           GETDATE(),
	           0
	    FROM   D_SITE_TEST_SUBJECT AS dsts
	    WHERE  dsts.TestId = @testId
	    
	    SELECT TOP(1) *
	    FROM   D_SITE_TEST_QUESTION AS dstq
	    WHERE  dstq.Id = @id
	END
END
GO



 /*******************************************
 * удалить вопрос теста
 *******************************************/
IF OBJECT_ID(N'dbo.del_site_test_question', N'P') IS NOT NULL
    DROP PROCEDURE dbo.del_site_test_question;
GO
CREATE PROCEDURE dbo.del_site_test_question
	@questionId INT
AS
	BEGIN TRANSACTION
	
	DELETE 
	FROM   D_SITE_TEST_ANSWER
	WHERE  QuestionId = @questionId
	
	DELETE 
	FROM   D_SITE_TEST_QUESTION
	WHERE  Id = @questionId
	
	COMMIT TRANSACTION
GO

/*******************************************
 * добавить объект теста
 *******************************************/
IF OBJECT_ID(N'dbo.add_site_test_subject', N'P') IS NOT NULL
    DROP PROCEDURE dbo.add_site_test_subject;
GO
CREATE PROCEDURE dbo.add_site_test_subject
	@testId INT,
	@title NVARCHAR(400),
	@desc NVARCHAR(MAX),
	@pictureId UNIQUEIDENTIFIER
AS
BEGIN
	IF NOT EXISTS (
	       SELECT TOP(1) *
	       FROM   D_SITE_TEST_SUBJECT AS dsts
	       WHERE  dsts.TestId = @testId
	              AND dsts.Title = @title
	   )
	BEGIN
	    INSERT INTO D_SITE_TEST_SUBJECT
	      (
	        Title,
	        [Description],
	        TestId,
	        DateUpdate,
	        DateCreate,
	        PictureId
	      )
	    VALUES
	      (
	        @title,
	        @desc,
	        @testId,
	        GETDATE(),
	        GETDATE(),
	        @pictureId
	      )
	    
	    DECLARE @id INT
	    SET @id = @@identity
	    
	    INSERT INTO D_SITE_TEST_ANSWER
	      (
	        QuestionId,
	        SubjectId,
	        DateUpdate,
	        DateCreate,
	        IsCorrect
	      )
	    SELECT dstq.Id,
	           @id,
	           GETDATE(),
	           GETDATE(),
	           0
	    FROM   D_SITE_TEST_QUESTION AS dstq
	    WHERE  dstq.TestId = @testId
	    
	    SELECT TOP(1) *
	    FROM   D_SITE_TEST_SUBJECT AS dsts
	    WHERE  dsts.Id = @id
	END
END
GO

/*******************************************
 * удалить объект теста
 *******************************************/
IF OBJECT_ID(N'dbo.del_site_test_subject', N'P') IS NOT NULL
    DROP PROCEDURE dbo.del_site_test_subject;
GO
CREATE PROCEDURE dbo.del_site_test_subject
	@subjectId INT
AS
	BEGIN TRANSACTION
	
	DELETE 
	FROM   D_SITE_TEST_ANSWER
	WHERE  SubjectId = @subjectId
	
	DELETE 
	FROM   D_SITE_TEST_SUBJECT
	WHERE  Id = @subjectId
	
	COMMIT TRANSACTION
GO

/*******************************************
 * Страницы прохождения теста
 *******************************************/
IF OBJECT_ID(N'dbo.get_site_test_page', N'P') IS NOT NULL
    DROP PROCEDURE dbo.get_site_test_page;
GO
CREATE PROCEDURE dbo.get_site_test_page
	@titleUrl VARCHAR(255)
AS
BEGIN
	SELECT TOP(1) *
	FROM   D_SITE_TEST_ANSWER         AS dsta
	       JOIN D_SITE_TEST_QUESTION  AS dstq
	            ON  dstq.Id = dsta.QuestionId
	       JOIN D_SITE_TEST_SUBJECT   AS dsts
	            ON  dsts.Id = dsta.SubjectId
	       JOIN D_SITE_TEST           AS dst
	            ON  dst.Id = dstq.TestId
	            AND dst.TitleUrl = @titleUrl
	            AND dst.Show = 1
	ORDER BY
	       NEWID()
END
GO

/*******************************************
 * Тип для предыдущих ответов теста
 *******************************************/
IF OBJECT_ID(N'dbo.get_site_test_next_guess_step', N'P') IS NOT NULL
    DROP PROCEDURE dbo.get_site_test_next_guess_step;
GO

IF TYPE_ID(N'dbo.OldSiteTestStepGuess') IS NOT NULL
    DROP TYPE dbo.OldSiteTestStepGuess
GO

CREATE TYPE dbo.OldSiteTestStepGuess AS TABLE 
(QuestionId INT, IsCorrect BIT, [Order] INT);  
GO

/*******************************************
 * Следующий вопрос теста Guess
 *******************************************/
CREATE PROCEDURE dbo.get_site_test_next_guess_step
	@oldSteps dbo.OldSiteTestStepGuess READONLY,
	@subjectsCount INT OUTPUT
AS
BEGIN
	DECLARE @subjects TABLE (SubjectId INT)
	DECLARE @questions TABLE (QuestionId INT)
	
	BEGIN
		DECLARE @questionId     INT,
		        @isCorrect      INT
		
		DECLARE c CURSOR FORWARD_ONLY LOCAL READ_ONLY 
		FOR
		    SELECT os.QuestionId,
		           os.IsCorrect
		    FROM   @oldSteps AS os
		    ORDER BY
		           os.[Order]
		
		OPEN c
		FETCH NEXT FROM c INTO @questionId, @isCorrect
		WHILE @@FETCH_STATUS = 0
		BEGIN
		    INSERT INTO @subjects
		    SELECT DISTINCT dsta.SubjectId
		    FROM   D_SITE_TEST_ANSWER AS dsta
		    WHERE  dsta.QuestionId = @questionId
		           AND dsta.IsCorrect = @isCorrect
		           AND (
		                   dsta.SubjectId IN (SELECT s.SubjectId
		                                      FROM   @subjects AS s)
		                   OR (
		                          SELECT COUNT(1)
		                          FROM   @subjects
		                      ) = 0
		               )
		    
		    DELETE 
		    FROM   @subjects
		    WHERE  SubjectId IN (SELECT DISTINCT dsta.SubjectId
		                         FROM   D_SITE_TEST_ANSWER AS dsta
		                         WHERE  dsta.QuestionId = @questionId
		                                AND dsta.IsCorrect <> @isCorrect)
		    
		    FETCH NEXT FROM c INTO @questionId, @isCorrect
		END
		CLOSE c
		DEALLOCATE c
	END
	
	INSERT INTO @questions
	SELECT dsta.QuestionId
	FROM   D_SITE_TEST_ANSWER  AS dsta
	       JOIN @subjects      AS s
	            ON  s.SubjectId = dsta.SubjectId
	WHERE  dsta.QuestionId NOT IN (SELECT os.QuestionId
	                               FROM   @oldSteps AS os)
	       AND dsta.IsCorrect = 1
	
	SELECT @subjectsCount = COUNT(DISTINCT s.SubjectId)
	FROM   @subjects AS s
	
	IF (@subjectsCount > 1)
	    SELECT TOP(1) *
	    FROM   D_SITE_TEST_ANSWER         AS dsta
	           JOIN @questions            AS q
	                ON  q.QuestionId = dsta.QuestionId
	           JOIN D_SITE_TEST_QUESTION  AS dstq
	                ON  dstq.Id = dsta.QuestionId
	           JOIN D_SITE_TEST_SUBJECT   AS dsts
	                ON  dsts.Id = dsta.SubjectId
	           JOIN D_SITE_TEST           AS dst
	                ON  dst.Id = dstq.TestId
	ELSE
	    SELECT TOP(1) *
	    FROM   D_SITE_TEST_ANSWER         AS dsta
	           JOIN D_SITE_TEST_QUESTION  AS dstq
	                ON  dstq.Id = dsta.QuestionId
	           JOIN D_SITE_TEST_SUBJECT   AS dsts
	                ON  dsts.Id = dsta.SubjectId
	                AND dsts.Id IN (SELECT s.SubjectId
	                                FROM   @subjects AS s)
	           JOIN D_SITE_TEST           AS dst
	                ON  dst.Id = dstq.TestId
END
GO

/*******************************************
 * Тип для предыдущих ответов теста
 *******************************************/
IF OBJECT_ID(N'dbo.get_site_test_next_normal_step', N'P') IS NOT NULL
    DROP PROCEDURE dbo.get_site_test_next_normal_step;
GO

IF OBJECT_ID(N'dbo.get_site_test_normal_results', N'P') IS NOT NULL
    DROP PROCEDURE dbo.get_site_test_normal_results;
GO

IF TYPE_ID(N'dbo.OldSiteTestStepNormal') IS NOT NULL
    DROP TYPE dbo.OldSiteTestStepNormal
GO

CREATE TYPE dbo.OldSiteTestStepNormal AS TABLE 
(QuestionId INT, SubjectId INT);  
GO 

/*******************************************
 * Следующий вопрос теста Normal
 *******************************************/
CREATE PROCEDURE dbo.get_site_test_next_normal_step
	@oldSteps dbo.OldSiteTestStepNormal READONLY,
	@subjectsCount INT OUTPUT,
	@allSubjectsCount INT OUTPUT
AS
BEGIN
	DECLARE @testId INT
	SELECT TOP(1) @testId = dsts.TestId
	FROM   D_SITE_TEST_SUBJECT  AS dsts
	       JOIN @oldSteps       AS os
	            ON  os.SubjectId = dsts.Id
	
	SELECT @allSubjectsCount = COUNT(DISTINCT dsts.Id)
	FROM   D_SITE_TEST_SUBJECT AS dsts
	WHERE  dsts.TestId = @testId
	
	SELECT @subjectsCount = COUNT(DISTINCT dsts.Id)
	FROM   D_SITE_TEST_SUBJECT AS dsts
	WHERE  dsts.Id NOT IN (SELECT os.SubjectId
	                       FROM   @oldSteps AS os)
	       AND dsts.TestId = @testId
	
	IF (@subjectsCount > 0)
	    SELECT TOP 1 *
	    FROM   D_SITE_TEST_ANSWER         AS dsta
	           JOIN D_SITE_TEST_QUESTION  AS dstq
	                ON  dstq.Id = dsta.QuestionId
	           JOIN D_SITE_TEST_SUBJECT   AS dsts
	                ON  dsts.Id = dsta.SubjectId
	           JOIN D_SITE_TEST           AS dst
	                ON  dst.Id = dstq.TestId
	                AND dst.Show = 1
	                AND dst.Id = @testId
	    WHERE  dsts.Id NOT IN (SELECT os.SubjectId
	                           FROM   @oldSteps AS os)
	ELSE
	    SELECT TOP 1 *
	    FROM   D_SITE_TEST_ANSWER         AS dsta
	           JOIN D_SITE_TEST_QUESTION  AS dstq
	                ON  dstq.Id = dsta.QuestionId
	           JOIN D_SITE_TEST_SUBJECT   AS dsts
	                ON  dsts.Id = dsta.SubjectId
	           JOIN D_SITE_TEST           AS dst
	                ON  dst.Id = dstq.TestId
	                AND dst.Show = 1
	                AND dst.Id = @testId
	    ORDER BY
	           NEWID()
END
GO

/*******************************************
 * Вопросы к объекту теста normal
 *******************************************/
IF OBJECT_ID(N'dbo.get_site_test_normal_questions', N'P') IS NOT NULL
    DROP PROCEDURE dbo.get_site_test_normal_questions;
GO
CREATE PROCEDURE dbo.get_site_test_normal_questions
	@testId INT,
	@subjectId INT,
	@amount INT = 3
AS
BEGIN
	DECLARE @trueQuestionId INT
	SELECT @trueQuestionId = dsta.QuestionId
	FROM   D_SITE_TEST_ANSWER AS dsta
	WHERE  dsta.SubjectId = @subjectId
	       AND dsta.IsCorrect = 1
	
	SELECT NEWID(),
	       x.*
	FROM   (
	           SELECT TOP(@amount) dstq.*
	           FROM   D_SITE_TEST_QUESTION AS dstq
	                  JOIN D_SITE_TEST AS dst
	                       ON  dst.Id = dstq.TestId
	                       AND dst.Id = @testId
	                       AND dst.Show = 1
	           WHERE  dstq.Id NOT IN (SELECT TOP 1 dstq.Id
	                                  FROM   D_SITE_TEST_QUESTION AS dstq
	                                  WHERE  dstq.Id = @trueQuestionId)
	           ORDER BY
	                  NEWID()
	           UNION ALL
	           SELECT TOP 1 *
	           FROM   D_SITE_TEST_QUESTION AS dstq
	           WHERE  dstq.Id = @trueQuestionId
	       ) x
	ORDER BY
	       1
END
GO

/*******************************************
 * Результаты теста Normal
 *******************************************/
CREATE PROCEDURE dbo.get_site_test_normal_results
	@subjectId INT
AS
BEGIN
	DECLARE @testId INT
	SELECT TOP 1 @testId = dsts.TestId
	FROM   D_SITE_TEST_SUBJECT AS dsts
	WHERE  dsts.Id = @subjectId
	
	SELECT *
	FROM   D_SITE_TEST_ANSWER         AS dsta
	       JOIN D_SITE_TEST_QUESTION  AS dstq
	            ON  dstq.Id = dsta.QuestionId
	       JOIN D_SITE_TEST_SUBJECT   AS dsts
	            ON  dsts.Id = dsta.SubjectId
	       JOIN D_SITE_TEST           AS dst
	            ON  dst.Id = dstq.TestId
	            AND dst.Id = @testId
	WHERE  dsta.IsCorrect = 1
END
GO