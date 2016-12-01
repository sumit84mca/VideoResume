CREATE TABLE [dbo].[AspNetIdentity_User] (
	 UserId VARCHAR(36) NOT NULL PRIMARY KEY
	,UserName NVARCHAR(100) NULL UNIQUE
	,PasswordHash VARCHAR(100) NULL
	,SecurityStamp VARCHAR(45) NULL
  )
GO

CREATE TABLE [dbo].[AspNetIdentity_Role] (
	 RoleId VARCHAR(36) NOT NULL PRIMARY KEY
	,RoleName NVARCHAR(100) NULL UNIQUE
	,[Description] NVARCHAR(200) NULL
)
GO

CREATE TABLE [dbo].[AspNetIdentity_UserClaim] (
   UserClaimId INT NOT NULL IDENTITY(1,1) PRIMARY KEY
  ,UserId VARCHAR(36) NULL --REFERENCES [dbo].[User](UserId)
  ,ClaimType VARCHAR(100) NULL
  ,ClaimValue VARCHAR(100) NULL
)
GO

CREATE TABLE [dbo].[AspNetIdentity_UserLogin] (
   UserId VARCHAR(36) NOT NULL --REFERENCES [dbo].[User](UserId)
  ,ProviderKey VARCHAR(100) NULL
  ,LoginProvider VARCHAR(100) NULL
)
GO

CREATE TABLE [dbo].[AspNetIdentity_UserRole] (
   UserId VARCHAR(36) NOT NULL --REFERENCES [dbo].[User](UserId)
  ,RoleId VARCHAR(36) NOT NULL --REFERENCES [dbo].[Role](RoleId)
   PRIMARY KEY (UserId, RoleId),
)