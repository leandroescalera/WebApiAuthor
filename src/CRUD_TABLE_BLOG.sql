USE bd_blog
GO
--********************************** create **********************************
IF OBJECT_ID ('dbo.[sp_blog_create]') IS NOT NULL
    DROP PROCEDURE dbo.[sp_blog_create]
GO

CREATE PROCEDURE sp_blog_create(
	@id int,
	@title VARCHAR(200),
	@thema VARCHAR(200),
	@content VARCHAR(200),
	@periodicity VARCHAR(200),
	@allow_comments BIT,
	@creation_date DATETIME,
	@update_date DATETIME
)
AS
BEGIN
	INSERT INTO blog([title],[thema],[content],[periodicity],[allow_comments],[creation_date],[update_date])
	VALUES (@title,@thema,@content,@periodicity,@allow_comments,@creation_date,@update_date)
END
GO

--********************************** update **********************************
IF OBJECT_ID ('dbo.[sp_blog_update]') IS NOT NULL
	DROP PROCEDURE dbo.[sp_blog_update]
GO

CREATE PROCEDURE sp_blog_update(
	@id int,
	@title VARCHAR(200),
	@thema VARCHAR(200),
	@content VARCHAR(200),
	@periodicity VARCHAR(200),
	@allow_comments BIT,
	@creation_date DATETIME,
	@update_date DATETIME
)
AS
BEGIN
	UPDATE blog SET title=@title,
					thema=@thema, 
					content=@content, 
					periodicity=@periodicity,
					allow_comments=@allow_comments,
					creation_date=@creation_date,
					update_date=@update_date
	WHERE id=@id
END
GO

--********************************** get blog **********************************

IF OBJECT_ID ('dbo.[sp_blog_get]') IS NOT NULL
	DROP PROCEDURE dbo.[sp_blog_get]
GO

CREATE PROCEDURE sp_blog_get(
	@id INT
)
AS
BEGIN
	SELECT * FROM blog WHERE id=@id
END 
GO

--********************************** list blog **********************************
IF OBJECT_ID ('dbo.[sp_blog_list]') IS NOT NULL
	DROP PROCEDURE dbo.[sp_blog_list]
GO

CREATE PROCEDURE sp_blog_list
AS
BEGIN
	SELECT * FROM blog
END 
GO

--********************************** delete blog **********************************
IF OBJECT_ID ('dbo.[sp_blog_delete]') IS NOT NULL
	DROP PROCEDURE dbo.[sp_blog_delete]
GO
CREATE PROCEDURE sp_blog_delete(
	@id INT
)
AS
BEGIN
	DELETE FROM blog WHERE id=@id
END
GO
