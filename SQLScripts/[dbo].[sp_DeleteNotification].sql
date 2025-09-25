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
CREATE OR ALTER PROCEDURE [dbo].[sp_DeleteNotification]
	-- Add the parameters for the stored procedure here
	@NotificationId int
	
AS
BEGIN TRANSACTION T1
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE 
	@UserId int,
	@NotificationType nvarchar(500),
	@Message nvarchar(max),
	@Object_Id int,
	@ActivityTypeId int,
	@Is_read bit,
	@NotifyTime datetime

    -- Insert statements for procedure here
	SELECT @UserId=UserId,@NotificationType=NotificationType,@Message=Message,@Object_Id = Object_Id,@ActivityTypeId=activitytypeid,@Is_read=Is_Read,@NotifyTime=notifytime
	FROM  dbo.SC_Notification
	WHERE NotificationId=@NotificationId;

	DELETE  
	FROM dbo.SC_Notification  
	WHERE NotificationId=@NotificationId;

	INSERT INTO [dbo].[SC_Notification_History](objectid,UserId,NotificationType,Message,Object_Id,activitytypeid,Is_Read,notifytime, ActionDate,actiontypeid)
	VALUES(@NotificationId,@UserId,@NotificationType,@Message,@Object_Id,@ActivityTypeId,@Is_read,@NotifyTime,getdate(),'1');

	COMMIT TRANSACTION T1
END TRY
BEGIN CATCH
	Rollback TRANSACTION T1
END CATCH


