--USER

CREATE PROCEDURE [dbo].[AI_GetUser] (	
	 @UserId VARCHAR(36) = NULL
	,@UserName NVARCHAR(100) = NULL
)
AS
	IF (@UserId IS NOT NULL)
	BEGIN
		SELECT	[UserId], [UserName], [PasswordHash], [SecurityStamp] 
		FROM	[dbo].[AspNetIdentity_User]
		WHERE	[UserId] = @UserId
	END
	ELSE
	BEGIN
		SELECT	[UserId], [UserName], [PasswordHash], [SecurityStamp] 
		FROM	[dbo].[AspNetIdentity_User]
		WHERE	[UserName] = @UserName
	END
GO

CREATE PROCEDURE [dbo].[AI_AddUser] (	
	 @UserId VARCHAR(36)
	,@UserName NVARCHAR(100)
	,@PasswordHash VARCHAR(100)
	,@SecurityStamp VARCHAR(45)
)
AS
	IF NOT EXISTS (SELECT 1 FROM [dbo].[AspNetIdentity_User] WHERE [UserId] = @UserId OR [UserName] = @UserName)
	BEGIN
		INSERT INTO [dbo].[AspNetIdentity_User] ([UserId], [UserName], [PasswordHash], [SecurityStamp])
		VALUES	(@UserId, @UserName, @PasswordHash, @SecurityStamp) 
	END
GO

CREATE PROCEDURE [dbo].[AI_SaveUser] (	
	 @UserId VARCHAR(36)
	,@UserName NVARCHAR(100)
	,@PasswordHash VARCHAR(100)
	,@SecurityStamp VARCHAR(45)
)
AS	
	UPDATE	[dbo].[AspNetIdentity_User]
	SET		[UserName] = @UserName, [PasswordHash] = @PasswordHash, [SecurityStamp] = @SecurityStamp
	WHERE	[UserId] = @UserId
GO


CREATE PROCEDURE [dbo].[AI_DeleteUser] (	
	 @UserId VARCHAR(36)
)
AS	
	DELETE FROM	[dbo].[AspNetIdentity_User] WHERE [UserId] = @UserId
GO

--ROLE

CREATE PROCEDURE [dbo].[AI_GetRole] (	
	 @RoleId VARCHAR(36) = NULL
	,@RoleName NVARCHAR(100) = NULL
)
AS
	IF (@RoleId IS NOT NULL)
	BEGIN
		SELECT	[RoleId], [RoleName], [Description]
		FROM	[dbo].[AspNetIdentity_Role]
		WHERE	[RoleId] = @RoleId
	END
	ELSE
	BEGIN
		SELECT	[RoleId], [RoleName], [Description]
		FROM	[dbo].[AspNetIdentity_Role]
		WHERE	[RoleName] = @RoleName
	END
GO

CREATE PROCEDURE [dbo].[AI_AddRole] (	
	 @RoleId VARCHAR(36)
	,@RoleName NVARCHAR(100)
	,@Description NVARCHAR(200)
)
AS
	IF NOT EXISTS (SELECT 1 FROM [dbo].[AspNetIdentity_Role] WHERE [RoleId] = @RoleId OR [RoleName] = @RoleName)
	BEGIN
		INSERT INTO [dbo].[AspNetIdentity_Role] ([RoleId], [RoleName], [Description])
		VALUES	(@RoleId, @RoleName, @Description) 
	END
GO

CREATE PROCEDURE [dbo].[AI_DeleteRole] (	
	 @RoleId VARCHAR(36)
)
AS
	DELETE FROM [dbo].[AspNetIdentity_Role] WHERE [RoleId] = @RoleId
GO


CREATE PROCEDURE [dbo].[AI_SaveRole] (	
	 @RoleId VARCHAR(36)
	,@RoleName NVARCHAR(100)
	,@Description NVARCHAR(200)
)
AS	
	UPDATE	[dbo].[AspNetIdentity_Role]
	SET		[RoleName] = @RoleName, [Description] = @Description
	WHERE	[RoleId] = @RoleId
GO

--USER CLAIM

CREATE PROCEDURE [dbo].[AI_GetUserClaim] (	
	 @UserId VARCHAR(36)
)
AS
		SELECT	[UserClaimId], [UserId], [ClaimType], [ClaimValue]
		FROM	[dbo].[AspNetIdentity_UserClaim]
		WHERE	[UserId] = @UserId
GO

CREATE PROCEDURE [dbo].[AI_AddUserClaim] (	
	 @UserId VARCHAR(36)
	,@ClaimType VARCHAR(100)
	,@ClaimValue  VARCHAR(100)
)
AS
	IF NOT EXISTS (SELECT 1 FROM [dbo].[AspNetIdentity_UserClaim] WHERE [UserId] = @UserId AND [ClaimType] = @ClaimType)
	BEGIN
		INSERT INTO [dbo].[AspNetIdentity_UserClaim] ([UserId], [ClaimType], [ClaimValue])
		VALUES	(@UserId, @ClaimType, @ClaimValue) 
	END
GO

CREATE PROCEDURE [dbo].[AI_DeleteUserClaim] (	
	 @UserId VARCHAR(36)
	,@ClaimType VARCHAR(100)
	,@ClaimValue  VARCHAR(100)
)
AS	
	DELETE	FROM [dbo].[AspNetIdentity_UserClaim] WHERE [UserId] = @UserId AND [ClaimType] = @ClaimType AND [ClaimValue] = @ClaimValue
GO

CREATE PROCEDURE [dbo].[AI_DeleteUserClaimAllByUserId] (	
	 @UserId VARCHAR(36)
)
AS	
	DELETE	FROM [dbo].[AspNetIdentity_UserClaim] WHERE [UserId] = @UserId
GO

--USER LOGIN

CREATE PROCEDURE [dbo].[AI_GetUserLogin] (	
	 @UserId VARCHAR(36)
)
AS
		SELECT	[UserId], [ProviderKey], [LoginProvider]
		FROM	[dbo].[AspNetIdentity_UserLogin]
		WHERE	[UserId] = @UserId
GO

CREATE PROCEDURE [dbo].[AI_GetUserIdByLogin] (	
	 @ProviderKey VARCHAR(100)
	 ,@LoginProvider VARCHAR(100)
)
AS
		SELECT	[UserId], [ProviderKey], [LoginProvider]
		FROM	[dbo].[AspNetIdentity_UserLogin]
		WHERE	[ProviderKey] = @ProviderKey AND [LoginProvider] = @LoginProvider
GO

CREATE PROCEDURE [dbo].[AI_AddUserLogin] (	
	 @UserId VARCHAR(36)
	,@ProviderKey VARCHAR(100)
	,@LoginProvider  VARCHAR(100)
)
AS
		INSERT INTO [dbo].[AspNetIdentity_UserLogin] ([UserId], [ProviderKey], [LoginProvider])
		VALUES	(@UserId, @ProviderKey, @LoginProvider) 
GO

CREATE PROCEDURE [dbo].[AI_DeleteUserLogin] (	
	 @UserId VARCHAR(36)
	,@ProviderKey VARCHAR(100)
	,@LoginProvider  VARCHAR(100)
)
AS	
	DELETE	FROM [dbo].[AspNetIdentity_UserLogin] WHERE [UserId] = @UserId AND [ProviderKey] = @ProviderKey AND [LoginProvider] = @LoginProvider
GO

CREATE PROCEDURE [dbo].[AI_DeleteUserLoginAllByUserId] (	
	 @UserId VARCHAR(36)
)
AS	
	DELETE	FROM [dbo].[AspNetIdentity_UserLogin] WHERE [UserId] = @UserId
GO

--USER ROLE


CREATE PROCEDURE [dbo].[AI_GetUserRole] (	
	 @UserId VARCHAR(36)
)
AS
		SELECT	[UserId], [RoleId]
		FROM	[dbo].[AspNetIdentity_UserRole]
		WHERE	[UserId] = @UserId
GO

CREATE PROCEDURE [dbo].[AI_AddUserRole] (	
	 @UserId VARCHAR(36)
	,@RoleId VARCHAR(36)
)
AS
		INSERT INTO [dbo].[AspNetIdentity_UserRole] ([UserId], [RoleId])
		VALUES	(@UserId, @RoleId) 
GO

CREATE PROCEDURE [dbo].[AI_DeleteUserRole] (	
	 @UserId VARCHAR(36)
	,@RoleId VARCHAR(36)
)
AS	
	DELETE	FROM [dbo].[AspNetIdentity_UserRole] WHERE [UserId] = @UserId AND [RoleId] = @RoleId
GO

CREATE PROCEDURE [dbo].[AI_DeleteUserRoleAllByUserId] (	
	 @UserId VARCHAR(36)
)
AS	
	DELETE	FROM [dbo].[AspNetIdentity_UserRole] WHERE [UserId] = @UserId
GO
