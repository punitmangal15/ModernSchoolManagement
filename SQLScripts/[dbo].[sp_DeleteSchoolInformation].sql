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
CREATE OR ALTER PROCEDURE [dbo].[sp_DeleteSchoolInformation]
	-- Add the parameters for the stored procedure here
	@SchoolId nvarchar(100)
	
AS
BEGIN TRANSACTION T1
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE 
	@SchoolName nvarchar(100),
	@Address nvarchar(max),
	@PhoneNumber nvarchar(50),
	@EmailId nvarchar(100),
	@CreatedBy nvarchar(100),
	@CreatedDate datetime,
	@ModifiedBy nvarchar(100),
	@ModifiedDate datetime

    -- Insert statements for procedure here
	SELECT @SchoolName=Name,@Address=Address,@PhoneNumber = contactno,@EmailId = Emailid,@CreatedBy=C_CreatedBy,@CreatedDate=C_CreatedDate,@ModifiedBy=C_ModifiedBy,@ModifiedDate=C_ModifiedDate
	FROM  dbo.SC_SchoolInformation  
	WHERE SchoolId=@SchoolId;

	DELETE  
	FROM dbo.SC_SchoolInformation  
	WHERE SchoolId=@SchoolId;

	INSERT INTO [dbo].[SC_SchoolInformation_History](objectid, Name,Address,contactno,Emailid,C_CreatedBy,C_CreatedDate,C_ModifiedBy,C_ModifiedDate,ActionDate,actiontypeid)
	VALUES(@SchoolId,@SchoolName,@Address,@PhoneNumber,@EmailId,@CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate,GETDATE(),'1');

	COMMIT TRANSACTION T1
END TRY
BEGIN CATCH
	Rollback TRANSACTION T1
END CATCH


