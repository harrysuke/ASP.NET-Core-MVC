USE [booksDb]
GO
/****** Object:  StoredProcedure [dbo].[BookEdit]    Script Date: 2/21/2024 5:00:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BookEdit]
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
	UPDATE books SET title=@Title, author=@Author, price=@Price WHERE id=@Id
END
