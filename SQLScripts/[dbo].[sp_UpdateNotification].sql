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
CREATE OR ALTER PROCEDURE [dbo].[sp_UpdateNotification]
	-- Add the parameters for the stored procedure here
	@NotificationId int,
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
	UPDATE dbo.SC_Notification 
	SET UserId=@UserId,NotificationType=@NotificationType,Message=@Message,object_id=@Object_Id,activitytypeid=@ActivityTypeId,Is_Read=@Is_read,notifytime=@NotifyTime
	WHERE NotificationId=@NotificationId;
	
END
