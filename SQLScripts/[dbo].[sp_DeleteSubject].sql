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
CREATE OR ALTER PROCEDURE [dbo].[sp_DeleteSubject]
	-- Add the parameters for the stored procedure here
	@SubjectId int
	
AS
BEGIN TRANSACTION T1
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE 
	@SubjectName nvarchar(500),
	@Description nvarchar(max),
	@Attachment nvarchar(max),
	@Is_Active bit,
	@CreatedBy nvarchar(100),
	@CreatedDate datetime,
	@ModifiedBy nvarchar(100),
	@ModifiedDate datetime

    -- Insert statements for procedure here
	SELECT @SubjectName=SubjectName,@Description=Description,@Attachment=Attachment,@Is_Active = Is_Active,@CreatedBy=C_CreatedBy,@CreatedDate=C_CreatedDate,@ModifiedBy=C_ModifiedBy,@ModifiedDate=C_ModifiedDate
	FROM  dbo.SC_Subject
	WHERE Id=@SubjectId;

	DELETE  
	FROM dbo.SC_Subject  
	WHERE Id=@SubjectId;

	INSERT INTO [dbo].[SC_Subject_History](objectid,SubjectName,description,Attachment,is_active,C_CreatedBy,C_CreatedDate,C_ModifiedBy,C_ModifiedDate,ActionDate,actiontypeid)
	VALUES(@SubjectId,@SubjectName,@Description,@Attachment,@Is_Active,@CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate,GETDATE(),'1');

	COMMIT TRANSACTION T1
END TRY
BEGIN CATCH
	Rollback TRANSACTION T1
END CATCH


