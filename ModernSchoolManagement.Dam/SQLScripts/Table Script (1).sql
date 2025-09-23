if exists (SELECT * FROM sys.databases WHERE name = 'ModernSchoolManagement')
BEGIN
use master
    drop DATABASE ModernSchoolManagement


    END
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'ModernSchoolManagement')
  BEGIN
    CREATE DATABASE ModernSchoolManagement


    END
    GO
       USE ModernSchoolManagement
    GO

/****** Object:  Table [dbo].[SC_Role]    Script Date: 19-09-2025 11:41:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Role]') AND type in (N'U'))
DROP TABLE [dbo].[SC_Role]
GO


-- Table: SC_Role
CREATE TABLE SC_Role (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
	C_CreatedBy	varchar(100),
	C_ModifiedBy	varchar(100),
	C_CreatedDate	datetime,
	C_ModifiedDate	datetime
);

-- Table: SC_Users


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Users]') AND type in (N'U'))
DROP TABLE [dbo].SC_Users
GO
CREATE TABLE SC_Users (
    UserId bigint PRIMARY KEY IDENTITY(1,1),
    RoleId INT FOREIGN KEY REFERENCES SC_Role(Id),
	Username varchar(100) unique,
    FirstName VARCHAR(100),
    LastName VARCHAR(100),
	Password_Hash	NVARCHAR(max),
    EmailId NVARCHAR(100),
    Phone NVARCHAR(15),
	Password_Salt	NVARCHAR(max),
    Is_Active BIT,
    C_CreatedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedBy VARCHAR(100),
    C_ModifiedDate DATETIME,
	Is_TwoFactor_ON	bit,
	AccessCode	int
);


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_SchoolInformation]') AND type in (N'U'))
DROP TABLE [dbo].SC_SchoolInformation
GO
-- Table: SC_SchoolInformation
CREATE TABLE SC_SchoolInformation (
    SchoolId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Address NVARCHAR(MAX),
    contactno NVARCHAR(50),
	Emailid nVARCHAR(100),    
    C_CreatedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedBy VARCHAR(100),
    C_ModifiedDate DATETIME
);

-- Table: SC_Class

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Class]') AND type in (N'U'))
DROP TABLE [dbo].SC_Class
GO
CREATE TABLE SC_Class (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Description NVARCHAR(MAX),
	Attachment NVARCHAR(MAX),
    Is_Active BIT,
    C_CreatedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedBy VARCHAR(100),
    C_ModifiedDate DATETIME
);

-- Table: SC_Subject

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Subject]') AND type in (N'U'))
DROP TABLE [dbo].SC_Subject
GO
CREATE TABLE SC_Subject (
    Id INT PRIMARY KEY IDENTITY(1,1),
    SubjectName NVARCHAR(500),
    Description NVARCHAR(MAX),
	Attachment NVARCHAR(MAX),
    Is_Active BIT,
    C_CreatedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedBy VARCHAR(100),
    C_ModifiedDate DATETIME
);

-- Table: SC_Notification

CREATE TABLE SC_Notification (
    NotificationId INT PRIMARY KEY IDENTITY(1,1),
    UserId bigint FOREIGN KEY REFERENCES SC_Users(UserId),
    NotificationType VARCHAR(500),
    Message NVARCHAR(MAX),
    objectid int,
    activitytypeid int,
    Is_Read BIT,
    notifytime datetime
);

-- Table: SC_Page
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Page]') AND type in (N'U'))
DROP TABLE [dbo].SC_Page
GO
CREATE TABLE SC_Page (
    PageId INT PRIMARY KEY IDENTITY(1,1),
    PageName VARCHAR(100),
    Path NVARCHAR(MAX),
    Description NVARCHAR(MAX)
);

-- Table: SC_RolePermission
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_RolePermission]') AND type in (N'U'))
DROP TABLE [dbo].SC_RolePermission
GO
CREATE TABLE SC_RolePermission (
    RolePermissionId INT PRIMARY KEY IDENTITY(1,1),
    RoleId INT FOREIGN KEY REFERENCES SC_Role(Id),
    PageId INT FOREIGN KEY REFERENCES SC_Page(PageId),
    ViewPermission BIT,
    ListPermission BIT,
	AddPermission BIT,
    EditPermission BIT,
    DeletePermission BIT,
    Is_Active BIT,
    C_CreatedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedBy VARCHAR(100),
    C_ModifiedDate DATETIME
);

-- Table: SC_Division
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Division]') AND type in (N'U'))
DROP TABLE [dbo].SC_Division
GO
CREATE TABLE SC_Division (
    Id INT PRIMARY KEY IDENTITY(1,1),
	classid INT FOREIGN KEY REFERENCES SC_Class(Id),
    Name VARCHAR(100),
    Description NVARCHAR(MAX),
    Is_Active BIT,
    C_CreatedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedBy VARCHAR(100),
    C_ModifiedDate DATETIME
);

-- Table: SC_AcademicYear
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_AcademicYear]') AND type in (N'U'))
DROP TABLE [dbo].SC_AcademicYear
GO
CREATE TABLE SC_AcademicYear (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AcademicName NVARCHAR(100),
    StartDate DATE,
    EndDate DATE,
    Is_Active BIT,
    C_CreatedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedBy VARCHAR(100),
    C_ModifiedDate DATETIME
);

-- Table: SC_Course
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Course]') AND type in (N'U'))
DROP TABLE [dbo].SC_Course
GO
CREATE TABLE SC_Course (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CourseName VARCHAR(500),
    Description NVARCHAR(MAX),
    AcademicYearId INT FOREIGN KEY REFERENCES SC_AcademicYear(Id),
    Is_Active BIT,
    C_CreatedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedBy VARCHAR(100),
    C_ModifiedDate DATETIME
);

-- Table: SC_CourseDetail
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_CourseDetail]') AND type in (N'U'))
DROP TABLE [dbo].SC_CourseDetail
GO
CREATE TABLE SC_CourseDetail (
    CourseDetailId INT PRIMARY KEY IDENTITY(1,1),
    CourseId INT FOREIGN KEY REFERENCES SC_Course(Id),
    SubjectId INT FOREIGN KEY REFERENCES SC_Subject(Id)
);

-- Table: SC_CourseAttachment
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_CourseAttachment]') AND type in (N'U'))
DROP TABLE [dbo].SC_CourseAttachment
GO
CREATE TABLE SC_CourseAttachment (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CourseDetailId INT FOREIGN KEY REFERENCES SC_CourseDetail(CourseDetailId),
    AttachmentType VARCHAR(100),
    Attachment NVARCHAR(MAX)
);

-- Table: SC_UserAactivity
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_UserAactivity]') AND type in (N'U'))
DROP TABLE [dbo].SC_UserAactivity
GO
CREATE TABLE SC_UserAactivity (
    UserId bigint  FOREIGN KEY REFERENCES SC_Users(UserId),
    activitytypeid INT,
    message VARCHAR(50),
    object_id INT,
	activitydate DATETIME,
	operationby INT,
	userrole INT,
    devicedetail NVARCHAR(MAX)
);

-- Table: SC_ActivityType
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_ActivityType]') AND type in (N'U'))
DROP TABLE [dbo].SC_ActivityType
GO
CREATE TABLE SC_ActivityType (
    Id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(100),
	description VARCHAR(MAX)
);

-- Table: SC_Class_History
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Class_History]') AND type in (N'U'))
DROP TABLE [dbo].SC_Class_History
GO
CREATE TABLE SC_Class_History (
    id INT PRIMARY KEY IDENTITY(1,1),
    objectid INT,
	name NVARCHAR(100),
    description NVARCHAR(MAX),
    is_active BIT,
    C_CreatedBy VARCHAR(100),
    C_ModifiedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedDate DATETIME,
    ActionDate DATETIME,
    actiontypeid INT
);

-- Table: SC_NavigationLog
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_NavigationLog]') AND type in (N'U'))
DROP TABLE [dbo].SC_NavigationLog
GO
CREATE TABLE SC_NavigationLog (
    Id INT PRIMARY KEY IDENTITY(1,1),
	UserId BIGINT FOREIGN KEY REFERENCES SC_Users(UserId),
	PageId INT FOREIGN KEY REFERENCES SC_Page(PageId),
	ActionTime DATETIME
);

-- Table: SC_Users_History
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Users_History]') AND type in (N'U'))
DROP TABLE [dbo].SC_Users_History
GO
CREATE TABLE SC_Users_History (
    id INT PRIMARY KEY IDENTITY(1,1),
    objectid INT,
	name NVARCHAR(100),
    description NVARCHAR(MAX),
    is_active BIT,
    C_CreatedBy VARCHAR(100),
    C_ModifiedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedDate DATETIME,
    ActionDate DATETIME,
    actiontypeid INT
);

-- Table: SC_SchoolInformation_History
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_SchoolInformation_History]') AND type in (N'U'))
DROP TABLE [dbo].SC_SchoolInformation_History
GO
CREATE TABLE SC_SchoolInformation_History (
    id INT PRIMARY KEY IDENTITY(1,1),
    objectid INT,
	name NVARCHAR(100),
    description NVARCHAR(MAX),
    is_active BIT,
    C_CreatedBy VARCHAR(100),
    C_ModifiedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedDate DATETIME,
    ActionDate DATETIME,
    actiontypeid INT
);

-- Table: SC_Notification_History
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Notification_History]') AND type in (N'U'))
DROP TABLE [dbo].SC_Notification_History
GO
CREATE TABLE SC_Notification_History (
    id INT PRIMARY KEY IDENTITY(1,1),
    objectid INT,
	name NVARCHAR(100),
    description NVARCHAR(MAX),
    is_active BIT,
    C_CreatedBy VARCHAR(100),
    C_ModifiedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedDate DATETIME,
    ActionDate DATETIME,
    actiontypeid INT
);

-- Table: SC_Division_History
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Division_History]') AND type in (N'U'))
DROP TABLE [dbo].SC_Division_History
GO
CREATE TABLE SC_Division_History (
    id INT PRIMARY KEY IDENTITY(1,1),
    objectid INT,
	name NVARCHAR(100),
    description NVARCHAR(MAX),
    is_active BIT,
    C_CreatedBy VARCHAR(100),
    C_ModifiedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedDate DATETIME,
    ActionDate DATETIME,
    actiontypeid INT
);

-- Table: SC_Subject_History
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Subject_History]') AND type in (N'U'))
DROP TABLE [dbo].SC_Subject_History
GO
CREATE TABLE SC_Subject_History (
    id INT PRIMARY KEY IDENTITY(1,1),
    objectid INT,
	name NVARCHAR(100),
    description NVARCHAR(MAX),
    is_active BIT,
    C_CreatedBy VARCHAR(100),
    C_ModifiedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedDate DATETIME,
    ActionDate DATETIME,
    actiontypeid INT
);

-- Table: SC_AcedemicYear_History
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_AcedemicYear_History]') AND type in (N'U'))
DROP TABLE [dbo].SC_AcedemicYear_History
GO
CREATE TABLE SC_AcedemicYear_History (
    id INT PRIMARY KEY IDENTITY(1,1),
    objectid INT,
	name NVARCHAR(100),
    description NVARCHAR(MAX),
    is_active BIT,
    C_CreatedBy VARCHAR(100),
    C_ModifiedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedDate DATETIME,
    ActionDate DATETIME,
    actiontypeid INT
);

-- Table: SC_Course_History
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SC_Course_History]') AND type in (N'U'))
DROP TABLE [dbo].SC_Course_History
GO
CREATE TABLE SC_Course_History (
    id INT PRIMARY KEY IDENTITY(1,1),
    objectid INT,
	name NVARCHAR(100),
    description NVARCHAR(MAX),
    is_active BIT,
    C_CreatedBy VARCHAR(100),
    C_ModifiedBy VARCHAR(100),
    C_CreatedDate DATETIME,
    C_ModifiedDate DATETIME,
    ActionDate DATETIME,
    actiontypeid INT
);
