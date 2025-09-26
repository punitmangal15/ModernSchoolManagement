USE [ModernSchoolManagement]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddSchool]    Script Date: 2025-09-24 12:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_UpdateSubject]
	-- Add the parameters for the stored procedure here
	@SubjectId int,
	@SubjectName nvarchar(500),
	@Description nvarchar(max),
	@Attachment nvarchar(max),
	@Is_Active bit,
	@ModifiedBy nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.SC_Subject 
	SET SubjectName=@SubjectName,Description=@Description,Attachment=@Attachment,Is_Active=@Is_Active,C_ModifiedBy = @ModifiedBy,C_ModifiedDate = GETDATE()
	WHERE Id=@SubjectId;
	
END
