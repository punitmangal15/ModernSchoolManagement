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
CREATE OR ALTER PROCEDURE [dbo].sp_AddNotification
	-- Add the parameters for the stored procedure here
	@UserId int,
	@NotificationType nvarchar(500),
	@Message nvarchar(max),
	@Object_Id int,
	@ActivityTypeId int,
	@Is_read bit,
	@NotifyTime datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.SC_Notification(UserId,NotificationType,Message,Object_Id,activitytypeid,Is_Read,notifytime) 
	VALUES(@UserId,@NotificationType,@Message,@Object_Id,@ActivityTypeId,@Is_read,@NotifyTime);
	
END
GO
