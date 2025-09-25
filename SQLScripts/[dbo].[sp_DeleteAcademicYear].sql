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
CREATE OR ALTER PROCEDURE [dbo].[sp_DeleteAcademicYear]
	-- Add the parameters for the stored procedure here
	@AcademicYearId int
	
AS
BEGIN TRANSACTION T1
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE 
	@AcademicYearName nvarchar(100),
	@Startdate datetime,
	@Enddate datetime,
	@Is_Active bit,
	@CreatedBy nvarchar(100),
	@CreatedDate datetime,
	@ModifiedBy nvarchar(100),
	@ModifiedDate datetime

    -- Insert statements for procedure here
	SELECT @AcademicYearName=AcademicName,@Startdate=StartDate,@Enddate=EndDate,@Is_Active = Is_Active,@CreatedBy=C_CreatedBy,@CreatedDate=C_CreatedDate,@ModifiedBy=C_ModifiedBy,@ModifiedDate=C_ModifiedDate
	FROM  dbo.SC_AcademicYear
	WHERE Id=@AcademicYearId;

	DELETE  
	FROM dbo.SC_AcademicYear  
	WHERE Id=@AcademicYearId;

	INSERT INTO [dbo].[SC_AcademicYear_History](objectid, AcademicName,startdate,enddate,is_active,C_CreatedBy,C_CreatedDate,C_ModifiedBy,C_ModifiedDate,ActionDate,actiontypeid)
	VALUES(@AcademicYearId,@AcademicYearName,@Startdate,@Enddate,@Is_Active,@CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate,GETDATE(),'1');

	COMMIT TRANSACTION T1
END TRY
BEGIN CATCH
	Rollback TRANSACTION T1
END CATCH


