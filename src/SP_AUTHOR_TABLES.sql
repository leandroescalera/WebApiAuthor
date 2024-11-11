USE bd_blog
GO

--********************************** create **********************************
IF OBJECT_ID ('dbo.[SP_REGISTER_AUTHOR]') IS NOT NULL
    DROP PROCEDURE dbo.[SP_REGISTER_AUTHOR]
GO

CREATE PROCEDURE SP_REGISTER_AUTHOR(
@names VARCHAR(150),
@firstSurname VARCHAR(150),
@secondSurname VARCHAR(150),
@birthDate DATETIME,
@countryResidence VARCHAR(100),
@mail VARCHAR(250)
)
AS
BEGIN
	INSERT author([names_], [first_surname], [second_surname], [birth_date], [country_residence], [mail])
	VALUES (@names, @firstSurname,@secondSurname,@birthDate,@countryResidence,@mail)

END
GO

--********************************** update **********************************
IF OBJECT_ID ('dbo.[SP_UPDATE_AUTHOR]') IS NOT NULL
    DROP PROCEDURE dbo.[SP_UPDATE_AUTHOR]
GO

CREATE PROCEDURE SP_UPDATE_AUTHOR(
@id int,
@names VARCHAR(150),
@firstSurname VARCHAR(150),
@secondSurname VARCHAR(150),
@birthDate DATETIME,
@countryResidence VARCHAR(100),
@mail VARCHAR(250)
)
AS
BEGIN
	UPDATE author SET names_=@names, first_surname=@firstSurname, second_surname=@secondSurname, birth_date=@birthDate, country_residence=@countryResidence, mail=@mail
	WHERE id=@id
END
GO

--********************************** get one **********************************
IF OBJECT_ID ('dbo.[SP_GET_AUTHOR]') IS NOT NULL
    DROP PROCEDURE dbo.[SP_GET_AUTHOR]
GO
CREATE PROCEDURE SP_GET_AUTHOR(
@id int
)
AS
BEGIN
	SELECT * FROM author WHERE id = @id
END
GO

--********************************** get list **********************************
IF OBJECT_ID ('dbo.[SP_LIST_AUTHORS]') IS NOT NULL
    DROP PROCEDURE dbo.[SP_LIST_AUTHORS]
GO
CREATE PROCEDURE SP_LIST_AUTHORS
AS
BEGIN
	SELECT * FROM author
END
GO

--********************************** delete **********************************
IF OBJECT_ID ('dbo.[SP_DELETE_AUTHOR]') IS NOT NULL
    DROP PROCEDURE dbo.[SP_DELETE_AUTHOR]
GO
CREATE PROCEDURE SP_DELETE_AUTHOR(
@id int
)
AS
BEGIN
	DELETE FROM author WHERE id = @id
END
GO