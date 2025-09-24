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
CREATE OR ALTER PROCEDURE [dbo].[sp_AddSchoolInformation]
	-- Add the parameters for the stored procedure here
	@SchoolName nvarchar(100),
	@Address nvarchar(max),
	@PhoneNumber nvarchar(50),
	@EmailId nvarchar(100),
	@CreatedBy nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.SC_SchoolInformation(Name,Address,contactno,EmailId,C_CreatedBy,C_CreatedDate) 
	VALUES(@SchoolName,@Address,@PhoneNumber,@EmailId,@CreatedBy,GETDATE());
END
GO
