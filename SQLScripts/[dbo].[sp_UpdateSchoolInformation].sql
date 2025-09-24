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
CREATE OR ALTER PROCEDURE [dbo].[sp_UpdateSchoolInformation]
	-- Add the parameters for the stored procedure here
	@SchoolId nvarchar(100),
	@SchoolName nvarchar(100),
	@Address nvarchar(max),
	@PhoneNumber nvarchar(50),
	@EmailId nvarchar(100),
	@ModifiedBy nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.SC_SchoolInformation 
	SET Name=@SchoolName,Address=@Address,contactno=@PhoneNumber,EmailId=@EmailId,C_ModifiedBy = @ModifiedBy,C_ModifiedDate = GETDATE()
	WHERE SchoolId=@SchoolId;
	
END
