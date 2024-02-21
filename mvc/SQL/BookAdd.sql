USE [booksDb]
GO
/****** Object:  StoredProcedure [dbo].[BookAdd]    Script Date: 2/21/2024 4:59:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kairi>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BookAdd]
	-- Add the parameters for the stored procedure here
	@Id INT,
	@Title VARCHAR(50),
	@Author VARCHAR(50),
	@Price INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO books(title, author, price) VALUES (@Title, @Author, @Price)
END
