use ModernSchoolManagement
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].sp_AddDivision
	-- Add the parameters for the stored procedure here
	@ClassId int,
	@DivisionName nvarchar(100),
	@Description nvarchar(max),
	@Is_Active bit,
	@CreatedBy nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.SC_Division(classid,Name,Description,Is_Active,C_CreatedBy,C_CreatedDate) 
	VALUES(@ClassId,@DivisionName,@Description,@Is_Active,@CreatedBy,GETDATE());
END
GO
