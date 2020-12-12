/*
 Navicat Premium Data Transfer

 Source Server         : Test001
 Source Server Type    : SQL Server
 Source Server Version : 12005000
 Source Host           : 118.25.177.48:1433
 Source Catalog        : Test001
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 12005000
 File Encoding         : 65001

 Date: 13/12/2020 01:22:44
*/


-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type IN ('U'))
	DROP TABLE [dbo].[__EFMigrationsHistory]
GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
  [MigrationId] nvarchar(150) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [ProductVersion] nvarchar(32) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[__EFMigrationsHistory] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201212152354_20201212', N'3.1.8')
GO


-- ----------------------------
-- Table structure for ApiResource
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ApiResource]') AND type IN ('U'))
	DROP TABLE [dbo].[ApiResource]
GO

CREATE TABLE [dbo].[ApiResource] (
  [Id] uniqueidentifier  NOT NULL,
  [Enabled] bit  NOT NULL,
  [Name] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [DisplayName] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Description] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ShowInDiscoveryDocument] bit  NOT NULL,
  [AllowedAccessTokenSigningAlgorithms] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [LastAccessed] datetime2(7)  NULL,
  [NonEditable] bit  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ApiResource] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ApiResource
-- ----------------------------
INSERT INTO [dbo].[ApiResource] ([Id], [Enabled], [Name], [DisplayName], [Description], [ShowInDiscoveryDocument], [AllowedAccessTokenSigningAlgorithms], [LastAccessed], [NonEditable], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-ACB0-49E6-8479-85EBE06100D7', N'1', N'Destiny.Core.Flow.API', NULL, NULL, N'1', NULL, NULL, N'0', NULL, NULL, N'0', NULL, N'2020-01-01 08:12:42.7416890')
GO


-- ----------------------------
-- Table structure for ApiResourceClaim
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ApiResourceClaim]') AND type IN ('U'))
	DROP TABLE [dbo].[ApiResourceClaim]
GO

CREATE TABLE [dbo].[ApiResourceClaim] (
  [Id] uniqueidentifier  NOT NULL,
  [Type] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ApiResourceId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ApiResourceClaim] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ApiResourceClaim
-- ----------------------------
INSERT INTO [dbo].[ApiResourceClaim] ([Id], [Type], [ApiResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-ACB7-4EB7-88B7-87E9E51A6007', N'role', N'08D8869F-ACB0-49E6-8479-85EBE06100D7', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ApiResourceClaim] ([Id], [Type], [ApiResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-ACB7-4405-885A-E6A2297572F3', N'name', N'08D8869F-ACB0-49E6-8479-85EBE06100D7', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO


-- ----------------------------
-- Table structure for ApiResourceProperty
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ApiResourceProperty]') AND type IN ('U'))
	DROP TABLE [dbo].[ApiResourceProperty]
GO

CREATE TABLE [dbo].[ApiResourceProperty] (
  [Id] uniqueidentifier  NOT NULL,
  [Key] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Value] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ApiResourceId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ApiResourceProperty] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ApiResourceProperty
-- ----------------------------

-- ----------------------------
-- Table structure for ApiResourceScope
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ApiResourceScope]') AND type IN ('U'))
	DROP TABLE [dbo].[ApiResourceScope]
GO

CREATE TABLE [dbo].[ApiResourceScope] (
  [Id] uniqueidentifier  NOT NULL,
  [Scope] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ApiResourceId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ApiResourceScope] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ApiResourceScope
-- ----------------------------
INSERT INTO [dbo].[ApiResourceScope] ([Id], [Scope], [ApiResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-ACB3-4FB6-834A-50915114A00D', N'Destiny.Core.Flow.API', N'08D8869F-ACB0-49E6-8479-85EBE06100D7', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO


-- ----------------------------
-- Table structure for ApiResourceSecret
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ApiResourceSecret]') AND type IN ('U'))
	DROP TABLE [dbo].[ApiResourceSecret]
GO

CREATE TABLE [dbo].[ApiResourceSecret] (
  [Id] uniqueidentifier  NOT NULL,
  [Description] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Value] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Expiration] datetime2(7)  NULL,
  [Type] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Created] datetime2(7)  NOT NULL,
  [ApiResourceId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ApiResourceSecret] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ApiResourceSecret
-- ----------------------------
INSERT INTO [dbo].[ApiResourceSecret] ([Id], [Description], [Value], [Expiration], [Type], [Created], [ApiResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-ACB6-43EC-8E97-7EEA6DE49FB7', NULL, N'xWXRHbA1kGBJxxiRIToBpsW6yC3SRq+TM8AAze3owyw=', NULL, N'SharedSecret', N'2001-01-01 00:00:00.0000000', N'08D8869F-ACB0-49E6-8479-85EBE06100D7', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO


-- ----------------------------
-- Table structure for ApiScope
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ApiScope]') AND type IN ('U'))
	DROP TABLE [dbo].[ApiScope]
GO

CREATE TABLE [dbo].[ApiScope] (
  [Id] uniqueidentifier  NOT NULL,
  [Enabled] bit  NOT NULL,
  [Name] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [DisplayName] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Description] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ShowInDiscoveryDocument] bit  NOT NULL,
  [Required] bit  NOT NULL,
  [Emphasize] bit  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ApiScope] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ApiScope
-- ----------------------------
INSERT INTO [dbo].[ApiScope] ([Id], [Enabled], [Name], [DisplayName], [Description], [ShowInDiscoveryDocument], [Required], [Emphasize], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B157-4C78-88C5-EC663B46B413', N'1', N'Destiny.Core.Flow.API', N'Destiny.Core.Flow.API', NULL, N'1', N'0', N'0', NULL, NULL, N'0', NULL, N'2020-01-01 08:12:50.6149780')
GO


-- ----------------------------
-- Table structure for ApiScopeClaim
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ApiScopeClaim]') AND type IN ('U'))
	DROP TABLE [dbo].[ApiScopeClaim]
GO

CREATE TABLE [dbo].[ApiScopeClaim] (
  [Id] uniqueidentifier  NOT NULL,
  [Type] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ScopeId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ApiScopeClaim] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ApiScopeClaim
-- ----------------------------

-- ----------------------------
-- Table structure for ApiScopeProperty
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ApiScopeProperty]') AND type IN ('U'))
	DROP TABLE [dbo].[ApiScopeProperty]
GO

CREATE TABLE [dbo].[ApiScopeProperty] (
  [Id] uniqueidentifier  NOT NULL,
  [Key] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Value] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ScopeId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ApiScopeProperty] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ApiScopeProperty
-- ----------------------------

-- ----------------------------
-- Table structure for Client
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Client]') AND type IN ('U'))
	DROP TABLE [dbo].[Client]
GO

CREATE TABLE [dbo].[Client] (
  [Id] uniqueidentifier  NOT NULL,
  [Enabled] bit DEFAULT (CONVERT([bit],(1))) NOT NULL,
  [ClientId] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ProtocolType] nvarchar(max) COLLATE Chinese_PRC_CI_AS DEFAULT (N'oidc') NULL,
  [RequireClientSecret] bit DEFAULT (CONVERT([bit],(1))) NOT NULL,
  [ClientName] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Description] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ClientUri] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [LogoUri] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [RequireConsent] bit  NOT NULL,
  [AllowRememberConsent] bit DEFAULT (CONVERT([bit],(1))) NOT NULL,
  [AlwaysIncludeUserClaimsInIdToken] bit  NOT NULL,
  [RequirePkce] bit DEFAULT (CONVERT([bit],(1))) NOT NULL,
  [AllowPlainTextPkce] bit  NOT NULL,
  [RequireRequestObject] bit  NOT NULL,
  [AllowAccessTokensViaBrowser] bit  NOT NULL,
  [FrontChannelLogoutUri] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [FrontChannelLogoutSessionRequired] bit DEFAULT (CONVERT([bit],(1))) NOT NULL,
  [BackChannelLogoutUri] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [BackChannelLogoutSessionRequired] bit DEFAULT (CONVERT([bit],(1))) NOT NULL,
  [AllowOfflineAccess] bit  NOT NULL,
  [IdentityTokenLifetime] int DEFAULT ((300)) NOT NULL,
  [AllowedIdentityTokenSigningAlgorithms] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [AccessTokenLifetime] int DEFAULT ((3600)) NOT NULL,
  [AuthorizationCodeLifetime] int DEFAULT ((300)) NOT NULL,
  [ConsentLifetime] int  NULL,
  [AbsoluteRefreshTokenLifetime] int DEFAULT ((2592000)) NOT NULL,
  [SlidingRefreshTokenLifetime] int DEFAULT ((2592000)) NOT NULL,
  [RefreshTokenUsage] int DEFAULT ((-1)) NOT NULL,
  [UpdateAccessTokenClaimsOnRefresh] bit  NOT NULL,
  [RefreshTokenExpiration] int DEFAULT ((-1)) NOT NULL,
  [AccessTokenType] int  NOT NULL,
  [EnableLocalLogin] bit DEFAULT (CONVERT([bit],(1))) NOT NULL,
  [IncludeJwtId] bit  NOT NULL,
  [AlwaysSendClientClaims] bit  NOT NULL,
  [ClientClaimsPrefix] nvarchar(max) COLLATE Chinese_PRC_CI_AS DEFAULT (N'client_') NULL,
  [PairWiseSubjectSalt] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [LastAccessed] datetime2(7)  NULL,
  [UserSsoLifetime] int  NULL,
  [UserCodeType] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [DeviceCodeLifetime] int DEFAULT ((300)) NOT NULL,
  [NonEditable] bit  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[Client] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Client
-- ----------------------------
INSERT INTO [dbo].[Client] ([Id], [Enabled], [ClientId], [ProtocolType], [RequireClientSecret], [ClientName], [Description], [ClientUri], [LogoUri], [RequireConsent], [AllowRememberConsent], [AlwaysIncludeUserClaimsInIdToken], [RequirePkce], [AllowPlainTextPkce], [RequireRequestObject], [AllowAccessTokensViaBrowser], [FrontChannelLogoutUri], [FrontChannelLogoutSessionRequired], [BackChannelLogoutUri], [BackChannelLogoutSessionRequired], [AllowOfflineAccess], [IdentityTokenLifetime], [AllowedIdentityTokenSigningAlgorithms], [AccessTokenLifetime], [AuthorizationCodeLifetime], [ConsentLifetime], [AbsoluteRefreshTokenLifetime], [SlidingRefreshTokenLifetime], [RefreshTokenUsage], [UpdateAccessTokenClaimsOnRefresh], [RefreshTokenExpiration], [AccessTokenType], [EnableLocalLogin], [IncludeJwtId], [AlwaysSendClientClaims], [ClientClaimsPrefix], [PairWiseSubjectSalt], [LastAccessed], [UserSsoLifetime], [UserCodeType], [DeviceCodeLifetime], [NonEditable], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F6-441C-8F0F-6C24AB0DEDC5', N'1', N'DestinyCoreFlowReactClientpwd', N'oidc', N'1', N'Destiny.Core.Flow.ReactClientpwd', NULL, NULL, NULL, N'0', N'1', N'0', N'1', N'0', N'0', N'1', NULL, N'1', NULL, N'1', N'0', N'300', NULL, N'3600', N'300', NULL, N'2592000', N'1296000', N'1', N'0', N'1', N'0', N'1', N'1', N'0', N'client_', NULL, NULL, NULL, NULL, N'300', N'0', NULL, NULL, N'0', NULL, N'2020-01-01 08:12:51.5564730')
GO

INSERT INTO [dbo].[Client] ([Id], [Enabled], [ClientId], [ProtocolType], [RequireClientSecret], [ClientName], [Description], [ClientUri], [LogoUri], [RequireConsent], [AllowRememberConsent], [AlwaysIncludeUserClaimsInIdToken], [RequirePkce], [AllowPlainTextPkce], [RequireRequestObject], [AllowAccessTokensViaBrowser], [FrontChannelLogoutUri], [FrontChannelLogoutSessionRequired], [BackChannelLogoutUri], [BackChannelLogoutSessionRequired], [AllowOfflineAccess], [IdentityTokenLifetime], [AllowedIdentityTokenSigningAlgorithms], [AccessTokenLifetime], [AuthorizationCodeLifetime], [ConsentLifetime], [AbsoluteRefreshTokenLifetime], [SlidingRefreshTokenLifetime], [RefreshTokenUsage], [UpdateAccessTokenClaimsOnRefresh], [RefreshTokenExpiration], [AccessTokenType], [EnableLocalLogin], [IncludeJwtId], [AlwaysSendClientClaims], [ClientClaimsPrefix], [PairWiseSubjectSalt], [LastAccessed], [UserSsoLifetime], [UserCodeType], [DeviceCodeLifetime], [NonEditable], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', N'1', N'DestinyCoreFlowReactClient', N'oidc', N'1', N'Destiny.Core.Flow.ReactClient', NULL, NULL, NULL, N'0', N'1', N'0', N'1', N'0', N'0', N'1', NULL, N'1', NULL, N'1', N'0', N'300', NULL, N'3600', N'300', NULL, N'2592000', N'1296000', N'1', N'0', N'1', N'0', N'1', N'1', N'0', N'client_', NULL, NULL, NULL, NULL, N'300', N'0', NULL, NULL, N'0', NULL, N'2020-01-01 08:12:51.5564690')
GO


-- ----------------------------
-- Table structure for ClientClaim
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientClaim]') AND type IN ('U'))
	DROP TABLE [dbo].[ClientClaim]
GO

CREATE TABLE [dbo].[ClientClaim] (
  [Id] uniqueidentifier  NOT NULL,
  [Type] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Value] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ClientId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ClientClaim] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ClientClaim
-- ----------------------------

-- ----------------------------
-- Table structure for ClientCorsOrigin
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientCorsOrigin]') AND type IN ('U'))
	DROP TABLE [dbo].[ClientCorsOrigin]
GO

CREATE TABLE [dbo].[ClientCorsOrigin] (
  [Id] uniqueidentifier  NOT NULL,
  [Origin] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ClientId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ClientCorsOrigin] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ClientCorsOrigin
-- ----------------------------
INSERT INTO [dbo].[ClientCorsOrigin] ([Id], [Origin], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F1-4535-846E-572E5A038C41', N'http://localhost:8848', N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientCorsOrigin] ([Id], [Origin], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F1-4F87-846D-72ED46D64378', N'https://admin.destinycore.club', N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientCorsOrigin] ([Id], [Origin], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F6-4950-8262-D68B06C0DA74', N'http://localhost:8080', N'08D8869F-B1F6-441C-8F0F-6C24AB0DEDC5', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO


-- ----------------------------
-- Table structure for ClientGrantType
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientGrantType]') AND type IN ('U'))
	DROP TABLE [dbo].[ClientGrantType]
GO

CREATE TABLE [dbo].[ClientGrantType] (
  [Id] uniqueidentifier  NOT NULL,
  [GrantType] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ClientId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ClientGrantType] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ClientGrantType
-- ----------------------------
INSERT INTO [dbo].[ClientGrantType] ([Id], [GrantType], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F6-497E-812E-0D6109761888', N'password', N'08D8869F-B1F6-441C-8F0F-6C24AB0DEDC5', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientGrantType] ([Id], [GrantType], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F2-4253-82BB-89078F7C9CF1', N'implicit', N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO


-- ----------------------------
-- Table structure for ClientIdPRestriction
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientIdPRestriction]') AND type IN ('U'))
	DROP TABLE [dbo].[ClientIdPRestriction]
GO

CREATE TABLE [dbo].[ClientIdPRestriction] (
  [Id] uniqueidentifier  NOT NULL,
  [Provider] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ClientId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ClientIdPRestriction] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ClientIdPRestriction
-- ----------------------------

-- ----------------------------
-- Table structure for ClientPostLogoutRedirectUri
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientPostLogoutRedirectUri]') AND type IN ('U'))
	DROP TABLE [dbo].[ClientPostLogoutRedirectUri]
GO

CREATE TABLE [dbo].[ClientPostLogoutRedirectUri] (
  [Id] uniqueidentifier  NOT NULL,
  [PostLogoutRedirectUri] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ClientId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ClientPostLogoutRedirectUri] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ClientPostLogoutRedirectUri
-- ----------------------------
INSERT INTO [dbo].[ClientPostLogoutRedirectUri] ([Id], [PostLogoutRedirectUri], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F5-4551-8D15-0C0B2F2EE2D0', N'https://admin.destinycore.club', N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientPostLogoutRedirectUri] ([Id], [PostLogoutRedirectUri], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F6-4A12-8910-CF1907318679', N'http://localhost:8080', N'08D8869F-B1F6-441C-8F0F-6C24AB0DEDC5', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientPostLogoutRedirectUri] ([Id], [PostLogoutRedirectUri], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F4-4B57-8F3F-F5B6F2497718', N'http://localhost:8848', N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO


-- ----------------------------
-- Table structure for ClientProperty
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientProperty]') AND type IN ('U'))
	DROP TABLE [dbo].[ClientProperty]
GO

CREATE TABLE [dbo].[ClientProperty] (
  [Id] uniqueidentifier  NOT NULL,
  [Key] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Value] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ClientId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ClientProperty] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ClientProperty
-- ----------------------------

-- ----------------------------
-- Table structure for ClientRedirectUri
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientRedirectUri]') AND type IN ('U'))
	DROP TABLE [dbo].[ClientRedirectUri]
GO

CREATE TABLE [dbo].[ClientRedirectUri] (
  [Id] uniqueidentifier  NOT NULL,
  [RedirectUri] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ClientId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ClientRedirectUri] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ClientRedirectUri
-- ----------------------------
INSERT INTO [dbo].[ClientRedirectUri] ([Id], [RedirectUri], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F5-483A-8B67-307E262FFAB2', N'http://localhost:8848/callback', N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientRedirectUri] ([Id], [RedirectUri], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F6-4A2A-8E54-45C198A635F4', N'http://localhost:8080/LoginedCallbackView', N'08D8869F-B1F6-441C-8F0F-6C24AB0DEDC5', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientRedirectUri] ([Id], [RedirectUri], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F6-43F9-8429-C7A848D06557', N'https://admin.destinycore.club/callback', N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO


-- ----------------------------
-- Table structure for ClientScope
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientScope]') AND type IN ('U'))
	DROP TABLE [dbo].[ClientScope]
GO

CREATE TABLE [dbo].[ClientScope] (
  [Id] uniqueidentifier  NOT NULL,
  [Scope] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ClientId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ClientScope] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ClientScope
-- ----------------------------
INSERT INTO [dbo].[ClientScope] ([Id], [Scope], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F6-499C-884D-156482E422F2', N'openid', N'08D8869F-B1F6-441C-8F0F-6C24AB0DEDC5', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientScope] ([Id], [Scope], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F6-49DD-89BA-254CBA63EE21', N'Destiny.Core.Flow.API', N'08D8869F-B1F6-441C-8F0F-6C24AB0DEDC5', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientScope] ([Id], [Scope], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F3-49B1-8A77-93DA5FF6A286', N'roles', N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientScope] ([Id], [Scope], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F2-4F29-82C3-B4CBDF24C3F1', N'openid', N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientScope] ([Id], [Scope], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F6-49B5-8484-BA28DCBA1A72', N'profile', N'08D8869F-B1F6-441C-8F0F-6C24AB0DEDC5', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientScope] ([Id], [Scope], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F6-49CA-812D-E5B838508F24', N'roles', N'08D8869F-B1F6-441C-8F0F-6C24AB0DEDC5', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientScope] ([Id], [Scope], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F3-49C5-8842-EE503E31C4DE', N'Destiny.Core.Flow.API', N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientScope] ([Id], [Scope], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F3-4998-864D-F02F80C3B3C3', N'profile', N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO


-- ----------------------------
-- Table structure for ClientSecret
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientSecret]') AND type IN ('U'))
	DROP TABLE [dbo].[ClientSecret]
GO

CREATE TABLE [dbo].[ClientSecret] (
  [Id] uniqueidentifier  NOT NULL,
  [Description] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Value] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Expiration] datetime2(7)  NULL,
  [Type] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Created] datetime2(7)  NOT NULL,
  [ClientId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ClientSecret] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ClientSecret
-- ----------------------------
INSERT INTO [dbo].[ClientSecret] ([Id], [Description], [Value], [Expiration], [Type], [Created], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F6-49F7-85CA-5875A3F49E3C', NULL, N'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=', NULL, N'SharedSecret', N'2001-01-01 00:00:00.0000000', N'08D8869F-B1F6-441C-8F0F-6C24AB0DEDC5', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[ClientSecret] ([Id], [Description], [Value], [Expiration], [Type], [Created], [ClientId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B1F3-4C91-80EC-C5A091C924DF', NULL, N'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=', NULL, N'SharedSecret', N'2001-01-01 00:00:00.0000000', N'08D8869F-B1E7-455A-8CE5-FD3801D6D881', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO


-- ----------------------------
-- Table structure for DataDictionary
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[DataDictionary]') AND type IN ('U'))
	DROP TABLE [dbo].[DataDictionary]
GO

CREATE TABLE [dbo].[DataDictionary] (
  [Id] uniqueidentifier  NOT NULL,
  [Title] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Value] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Remark] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ParentId] uniqueidentifier  NOT NULL,
  [Sort] int DEFAULT ((0)) NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL,
  [Description] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Code] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[DataDictionary] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of DataDictionary
-- ----------------------------
INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D82662-1D88-4784-8FFC-03A23023ABB0', N'测试1的二儿子', N'我是2号', N'2', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 20:50:11.7049150', NULL, N'没得')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83EC7-D2DB-41FC-8448-07F9F5169902', N'asd asd asd asd asd ', N'a sdas dasd asd asd asd ', N'd asd asd asd asd asd asd as', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:58:42.9737370', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D844A8-1655-434C-8115-08680E4266E3', N'dasd asd as', N'asd asdas ', N'asd asd asd ', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 09:26:39.2522560', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83E0C-07F8-400A-8432-0B4AC2D77DEF', N'lalalalalalalalalala', N'lalalalalalalalalala', N'lalalalalalalalalala', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:34:26.6943730', NULL, N'lalalalalalalalalala')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83EC6-6E6E-4FF0-8646-0BD55696C2B4', N'sd asd ', N'strasd asd ing', N'sad asd asd asd asd ', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:48:44.9953950', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D844BA-9FAD-44C3-8EE8-15D97ACEE5D8', N'asd as ', N'asd as ', N'asd as ', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 11:39:20.6460180', NULL, N'asd as asd ')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D82733-E913-4292-8372-193035B29218', N'string', N'string', N'string', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 13:51:57.9728100', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83E0C-5025-4B19-8E9C-2660D16628A9', N'lalalalalalalalalala', N'lalalalalalalalalala', N'lalalalalalalalalala', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:36:27.8097370', NULL, N'lalalalalalalalalala')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83EC6-C998-41E7-81B3-276718254343', N'asd asd asd asd asd ', N'a sdas dasd asd asd asd ', N'd asd asd asd asd asd asd as', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:51:17.9388680', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83E5D-9DF7-4785-82C0-2B2E7499FD6E', N'asd ad w309joiejro934ow4io', N'w309joiejro934ow4io23423o0', N'w309joiejro934ow4io2342', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 09:18:27.6037470', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'3FA85F64-5717-4562-B3FC-2C963F66AF11', N'sad', N'asd', N'asda', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 01:00:07.3569330', NULL, N'dfsdf')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'sd ad ad ad d', N'stri asd ad ng', N'asd a das ', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-07 21:41:57.9570790', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'3FA85F64-5717-4562-B3FC-2C963F66AFCC', N'sfsdf', N'sfsdf', N'sdfds', N'00000000-0000-0000-0000-000000000000', N'1', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 00:03:37.1417050', NULL, N'sdf')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83E5E-615B-4997-8BC3-2D1E602B256D', N'asd ad w309joiejro934ow4io', N'w309joiejro934ow4io23423o0', N'w309joiejro934ow4io2342', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 09:23:55.4153920', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D88E28-E101-4593-8CF0-350B8672059A', N'测试1', N'这是一个测试', N'没有', N'08D82351-7A5D-439D-842D-8554E57406B7', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:22:26.9067650', NULL, N'1')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D844BB-6AA6-47E6-80FB-3551F667EE50', N'asd as ', N'asd as ', N'asd as ', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 11:45:01.1563040', NULL, N'asd as asd ')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D844B9-B14D-4CD6-89D8-363B688CCB51', N'asd as ', N'asd as ', N'asd as ', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 11:32:40.6962140', NULL, N'asd as asd ')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D86446-5A1F-44A3-8A89-48191103DADA', N'string', N'string', N'string', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-09 15:07:39.5403170', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83E0D-1127-4224-84C5-4FED00CEFA8E', N'lalalalalalalalalala', N'lalalalalalalalalala', N'lalalalalalalalalala', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:41:51.6001230', NULL, N'lalalalalalalalalala')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D844BA-BABC-495F-8462-5EE2F8353FB3', N'asd as ', N'asd as ', N'asd as ', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 11:40:06.0350780', NULL, N'asd as asd ')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D84251-D179-40C9-852D-667084E28D4F', N'asd ad asd as', N'asdas sad as', N'asd asd a ', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 10:04:04.6790020', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83EC7-44F3-41AF-8070-68C9CC8241DA', N'asd asd asd asd asd ', N'a sdas dasd asd asd asd ', N'd asd asd asd asd asd asd as', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:54:44.8943200', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D86445-F1D1-4275-87B2-69CE6A46E03F', N'string', N'string', N'string', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-09 15:04:44.4930080', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D845DF-C59A-4164-88C8-7CDFD069300F', N'asdsa das ', N'asd asd as ', N'asd as das ', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:37:46.7979270', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D84051-6345-4027-8C19-7DAD771CBAAD', N'asd asd ad ', N'asd asd as', N'asd asd asd ', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 20:55:57.4753530', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83EC9-F176-4E84-8821-7EA5B923BA99', N'asd asd asd asd asd ', N'a sdas dasd asd asd asd ', N'd asd asd asd asd asd asd as', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:13:53.3205330', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D82351-7A5D-439D-842D-8554E57406B7', N'sad asd as ', N'asd asd ', N'striasdas ng', N'00000000-0000-0000-0000-000000000000', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 23:13:32.4966240', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83E0B-B964-43D5-821B-9B20479957FA', N'lalalalalalalalalala', N'lalalalalalalalalala', N'lalalalalalalalalala', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:32:14.8635160', NULL, N'lalalalalalalalalala')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D844BA-9A95-4351-83FA-9DD8BFDAAE9F', N'asd as ', N'asd as ', N'asd as ', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 11:39:12.0756510', NULL, N'asd as asd ')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D84250-3D17-43BB-8A87-AB22367BC036', N'asd a23234', N'324234234234', N'23423423432', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 09:52:46.2347480', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D86446-ABA8-4355-8130-B79704E6440E', N'string', N'string', N'string', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-09 15:09:56.2987780', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D84250-47A3-49E3-8B97-BC0EC9808E84', N'asd a23234', N'324234234234', N'23423423432', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 09:53:03.9639920', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D88E28-6AEA-4992-8819-BCDE88814A4B', N'1', N'1', N'1', N'08D82351-7A5D-439D-842D-8554E57406B7', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:19:11.6294040', NULL, N'1')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83E5E-5A25-4B5F-8F4F-CB1ED2D997B3', N'asd ad w309joiejro934ow4io', N'w309joiejro934ow4io23423o0', N'w309joiejro934ow4io2342', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 09:23:43.2962340', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D82733-FB28-4645-8465-CF7C622FCD65', N'121212', N'121212', N'12121212', N'08D82351-7A5D-439D-842D-8554E57406B7', N'121212', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 13:52:28.3457020', NULL, N'121212121ds21asd2as1')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D844A9-FDDD-44D9-8DC5-D541E351E658', N'strasdasd ing', N'asd asd ', N'asd asd ', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 09:40:17.2053820', NULL, N'asd asdas ')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83EC6-E3BB-4DA4-8CCC-D988116EB33B', N'asd asd asd asd asd ', N'a sdas dasd asd asd asd ', N'd asd asd asd asd asd asd as', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:52:01.8106700', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83EC7-0EB8-4AE6-8D1C-E3E86F2118C7', N'asd asd asd asd asd ', N'a sdas dasd asd asd asd ', N'd asd asd asd asd asd asd as', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:53:13.9156550', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83ECD-104B-4BE5-89BC-E41EC068E264', N'sdas1 21d 321d32 as1d3as1 d3as1d 3', N'sdas1 21d 321d32 as1d3as1 d3as1d 3', N'sdas1 21d 321d32 as1d3as1 d3as1d 3', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:36:13.5156460', NULL, N'string')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D82410-187F-4405-841E-EE019E7D120A', N'测试2', N'我是2号11111是的ad阿萨德阿萨德阿萨德 阿萨德as的', N'22222222222222222', N'08D82351-7A5D-439D-842D-8554E57406B7', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 14:50:40.7407560', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 21:58:02.1784060', NULL, N'11')
GO

INSERT INTO [dbo].[DataDictionary] ([Id], [Title], [Value], [Remark], [ParentId], [Sort], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D86D15-6625-4FA6-8F64-F7143B7AC16D', N'string', N'string', N'string', N'00000000-0000-0000-0000-000000000000', N'0', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-01 20:09:54.8336710', NULL, N'string')
GO


-- ----------------------------
-- Table structure for DeviceFlowCodes
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[DeviceFlowCodes]') AND type IN ('U'))
	DROP TABLE [dbo].[DeviceFlowCodes]
GO

CREATE TABLE [dbo].[DeviceFlowCodes] (
  [Id] uniqueidentifier  NOT NULL,
  [DeviceCode] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [UserCode] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [SubjectId] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [SessionId] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ClientId] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Description] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Expiration] datetime2(7)  NULL,
  [ConsumedTime] datetime2(7)  NULL,
  [Data] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[DeviceFlowCodes] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of DeviceFlowCodes
-- ----------------------------

-- ----------------------------
-- Table structure for Function
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Function]') AND type IN ('U'))
	DROP TABLE [dbo].[Function]
GO

CREATE TABLE [dbo].[Function] (
  [Id] uniqueidentifier  NOT NULL,
  [Name] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit DEFAULT (CONVERT([bit],(0))) NOT NULL,
  [IsEnabled] bit DEFAULT (CONVERT([bit],(1))) NOT NULL,
  [Description] nvarchar(1000) COLLATE Chinese_PRC_CI_AS  NULL,
  [LinkUrl] nvarchar(500) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Function] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Function
-- ----------------------------
INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'08D88652-B0A5-4A6A-833C-2E37AD6990EC', N'测试001', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:01:38.1754300', NULL, NULL, N'1', N'1', NULL, N'测试001')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'08D88653-1208-45B5-89F3-9A9F6093845A', N'sdsfs', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:04:21.5862790', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:04:32.3631840', N'1', N'1', N'sssss', N'1212')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'08D87DAE-18E4-494A-8252-A7EB862C2388', N'dd', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:03:16.8147360', NULL, NULL, N'1', N'1', N'1212', N'1212')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'DC8BDF59-1827-4E1A-8067-AC2C0176D440', N'功能管理-异步删除功能', NULL, N'2020-01-09 22:44:42.6615000', NULL, NULL, N'0', N'1', NULL, N'function/deleteasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'3DEE8FFD-1F3C-4105-80C4-AC2C0176D440', N'菜单管理-异步得到菜单下的按钮', NULL, N'2020-01-09 22:44:42.6615260', NULL, NULL, N'0', N'1', NULL, N'menu/getmenuchildrenbuttonasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'94D0E63E-04E8-4206-8380-AC2C0176D440', N'菜单管理-删除菜单', NULL, N'2020-01-09 22:44:42.6615160', NULL, NULL, N'0', N'1', NULL, N'menu/deleteasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'EB1BC3F5-014C-4399-8982-AC2C0176D440', N'功能管理-异步得到功能分页', NULL, N'2020-01-09 22:44:42.6615050', NULL, NULL, N'0', N'1', NULL, N'function/getfunctionpageasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'ECA617AD-BEDF-4BD2-8999-AC2C0176D440', N'角色管理-异步得到角色下拉数据', NULL, N'2020-01-09 22:44:42.6615600', NULL, NULL, N'0', N'1', NULL, N'role/getroleselectlistasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'A855299F-4021-4ED5-8B76-AC2C0176D440', N'用户管理-异步更新用户', NULL, N'2020-01-09 22:44:42.6615650', NULL, NULL, N'0', N'1', NULL, N'user/updateasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'09DC98F3-3824-410F-8D77-AC2C0176D440', N'用户管理-异步删除用户', NULL, N'2020-01-09 22:44:42.6615670', NULL, NULL, N'0', N'1', NULL, N'user/deleteasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'9210C150-0E02-4BD2-8E44-AC2C0176D440', N'菜单管理-登录成功之后获取用户菜单树', NULL, N'2020-01-09 22:44:42.6615220', NULL, NULL, N'1', N'1', NULL, N'menu/getusermenutreeasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'AC94955B-1818-4A74-8E90-AC2C0176D440', N'数据字典-根据id获取数据字典详情', NULL, N'2020-01-09 22:44:42.6614940', NULL, NULL, N'0', N'1', NULL, N'datadictionary/getdatadictionnnarylistasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'99C943DD-1482-45F3-913E-AC2C0176D440', N'功能管理-异步更新功能', NULL, N'2020-01-09 22:44:42.6614980', NULL, NULL, N'0', N'1', NULL, N'function/updateasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'118C42F7-7D58-4DF7-91DF-AC2C0176D440', N'角色管理-异步创建角色', NULL, N'2020-01-09 22:44:42.6615520', NULL, NULL, N'0', N'1', NULL, N'role/createasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'A2E962C4-7A09-4E6A-9703-AC2C0176D440', N'数据字典-分页获取数据字典', NULL, N'2020-01-09 22:44:42.6614680', NULL, NULL, N'0', N'1', NULL, N'datadictionary/getpagelistasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'959745A0-9BF0-446F-975C-AC2C0176D440', N'权限管理-异步得到权限集合', NULL, N'2020-01-09 22:44:42.6615410', NULL, NULL, N'0', N'1', NULL, N'permission/getpermissionlistasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'87F92AD7-D1BD-4A2F-9998-AC2C0176D440', N'组织架构管理-获取组织架构', NULL, N'2020-01-09 22:44:42.6615330', NULL, NULL, N'1', N'1', NULL, N'organization/getasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'F16DC63B-5958-4FEF-9C74-AC2C0176D440', N'角色管理-异步得到角色分页', NULL, N'2020-01-09 22:44:42.6615430', NULL, NULL, N'0', N'1', NULL, N'role/getrolepageasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'62155E9C-48E9-4B52-A04F-AC2C0176D440', N'菜单管理-根据登录账号获取菜单', NULL, N'2020-01-09 22:44:42.6615200', NULL, NULL, N'0', N'1', NULL, N'menu/getmenuasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'E82440DE-6D62-4EB8-A052-AC2C0176D440', N'菜单管理-获取一个菜单', NULL, N'2020-01-09 22:44:42.6615180', NULL, NULL, N'0', N'1', NULL, N'menu/loadformmenuasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'5CF76B4A-CE23-4A1D-A071-AC2C0176D440', N'用户管理-异步得到分页', NULL, N'2020-01-09 22:44:42.6615710', NULL, NULL, N'0', N'1', NULL, N'user/getuserpageasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'C60A6D1C-A76D-4543-A266-AC2C0176D440', N'数据字典-异步创建数据字典', NULL, N'2020-01-09 22:44:42.6614870', NULL, NULL, N'0', N'1', NULL, N'datadictionary/createasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'0D5A194B-F9B3-4F29-A2AC-AC2C0176D440', N'用户管理-异步加载用户', NULL, N'2020-01-09 22:44:42.6615690', NULL, NULL, N'0', N'1', NULL, N'user/loadasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'90A05DD2-AA52-40CB-A30C-AC2C0176D440', N'菜单管理-修改菜单', NULL, N'2020-01-09 22:44:42.6615140', NULL, NULL, N'0', N'1', NULL, N'menu/updatemenuasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'3FC810CF-C30C-448A-A577-AC2C0176D440', N'菜单管理-获取登录用户权限菜单', NULL, N'2020-01-09 22:44:42.6615280', NULL, NULL, N'0', N'1', NULL, N'menu/getmenulistasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'A3B4DA8D-5536-4001-AB64-AC2C0176D440', N'用户管理-异步创建用户', NULL, N'2020-01-09 22:44:42.6615620', NULL, NULL, N'0', N'1', NULL, N'user/createasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'DBEE031F-3100-494B-AB6D-AC2C0176D440', N'角色管理-异步创建或添加角色', NULL, N'2020-01-09 22:44:42.6615580', NULL, NULL, N'0', N'1', NULL, N'role/addorupdateasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'E3147913-003E-4CEC-AF12-AC2C0176D440', N'菜单管理-获取表格菜单信息', NULL, N'2020-01-09 22:44:42.6615090', NULL, NULL, N'0', N'1', NULL, N'menu/gettableasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'0C66B541-250C-4F8F-B0F4-AC2C0176D440', N'角色管理-异步更新角色', NULL, N'2020-01-09 22:44:42.6615540', NULL, NULL, N'0', N'1', NULL, N'role/updateasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'867155D3-A3CA-4CB8-B13C-AC2C0176D440', N'数据字典-修改一个数据字典', NULL, N'2020-01-09 22:44:42.6614850', NULL, NULL, N'0', N'1', NULL, N'datadictionary/updateasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'29F1C09E-947E-4961-B1E8-AC2C0176D440', N'组织架构管理-异步删除组织架构', NULL, N'2020-01-09 22:44:42.6615390', NULL, NULL, N'0', N'1', NULL, N'organization/deleteasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'90E36B1E-2CF0-442D-B260-AC2C0176D440', N'角色管理-异步删除角色', NULL, N'2020-01-09 22:44:42.6615560', NULL, NULL, N'0', N'1', NULL, N'role/deleteasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'765852F3-FAF4-4AB8-B2C2-AC2C0176D440', N'功能管理-异步获取功能下拉框列表', NULL, N'2020-01-09 22:44:42.6615070', NULL, NULL, N'0', N'1', NULL, N'function/getfunctionselectlistitemasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'76C79539-E581-4D53-B5BB-AC2C0176D440', N'数据字典-异步删除数据字典', NULL, N'2020-01-09 22:44:42.6614890', NULL, NULL, N'0', N'1', NULL, N'datadictionary/deleteasyc')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'E474363A-292C-4014-B68E-AC2C0176D440', N'组织架构管理-异步修改组织架构', NULL, N'2020-01-09 22:44:42.6615370', NULL, NULL, N'0', N'1', NULL, N'organization/updateasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'BA275142-01E5-4621-B822-AC2C0176D440', N'菜单管理-异步得到菜单树数据', NULL, N'2020-01-09 22:44:42.6615240', NULL, NULL, N'0', N'1', NULL, N'menu/getmenutreeasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'765545FA-F77F-434C-B8F0-AC2C0176D440', N'功能管理-异步创建功能', NULL, N'2020-01-09 22:44:42.6614960', NULL, NULL, N'0', N'1', NULL, N'function/createasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'A6CF7520-DCDD-4AB3-B8F1-AC2C0176D440', N'组织架构管理-异步创建组织架构', NULL, N'2020-01-09 22:44:42.6615350', NULL, NULL, N'0', N'1', NULL, N'organization/createasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'8C5AEE5E-0466-4F01-BCF0-AC2C0176D440', N'菜单管理-添加菜单', NULL, N'2020-01-09 22:44:42.6615120', NULL, NULL, N'0', N'1', NULL, N'menu/addmenuasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'4E9E5E40-10B1-4170-BD99-AC2C0176D440', N'菜单管理-异步到菜单功能集合', NULL, N'2020-01-09 22:44:42.6615310', NULL, NULL, N'1', N'1', NULL, N'menu/getmenufunctionlistasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'B97A7C88-8FF6-4F4E-BDE8-AC2C0176D440', N'数据字典-异步查询数据字典', NULL, N'2020-01-09 22:44:42.6614920', NULL, NULL, N'0', N'1', NULL, N'datadictionary/gettableasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'7633BECD-2B7E-463C-9430-AC6000EABA15', N'用户管理-用户分配角色', NULL, N'2020-01-01 14:14:36.8682320', NULL, NULL, N'0', N'1', NULL, N'user/allocationroleasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'2951A7A7-FBA7-4F5E-9A92-AC6000EABA15', N'代码生成器-得到C#类型转成下拉项', NULL, N'2020-01-01 14:14:36.8682270', NULL, NULL, N'0', N'1', NULL, N'codegenerator/getcsharptypetoselectitem')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'C2D45602-939B-4724-A18E-AC6000EABA15', N'身份管理-更改密码', NULL, N'2020-01-01 14:14:36.8682300', NULL, NULL, N'0', N'1', NULL, N'identity/changepassword')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'CBB3626A-DED7-4F11-A8EC-AC6000EABA15', N'代码生成器-代码生成', NULL, N'2020-01-01 14:14:36.8681870', NULL, NULL, N'0', N'1', NULL, N'codegenerator/generatecode')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'2C4A8E2F-AAB6-4A81-80D0-AC6500BEB968', N'角色管理-异步设置角色菜单', NULL, N'2020-01-01 11:34:24.3479920', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:03:02.1664150', N'0', N'1', N'角色管理-异步设置角色菜单', N'role/setrolemenuasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'C1355FA8-DA88-4430-8BB5-AC6500BEB968', N'菜单管理-异步得到所有菜单', NULL, N'2020-01-01 11:34:24.3479870', NULL, N'2020-01-01 20:13:53.8933330', N'0', N'1', NULL, N'menu/getallmenutreeasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'D726E21A-2116-4CC8-94C5-AC6500BEB968', N'菜单管理-异步得到菜单分页数据', NULL, N'2020-01-01 11:34:24.3479010', NULL, NULL, N'0', N'1', NULL, N'menu/getmenupageasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'8C583E7B-CA86-4AE3-98C0-AC65015CB437', N'功能管理-异步加载功能', NULL, N'2020-01-01 21:09:35.5400310', NULL, NULL, N'1', N'1', NULL, N'function/loadasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'1CCD98A0-98C2-45D0-A134-AC65015CB437', N'功能管理-异步创建或更新功能', NULL, N'2020-01-01 21:09:35.5400620', NULL, NULL, N'1', N'1', NULL, N'function/addorupdateasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'C07F91D6-A3C3-4568-956F-AC65016D85CF', N'功能管理-异步加载功能', NULL, N'2020-01-01 22:10:49.6493280', NULL, NULL, N'1', N'1', NULL, N'function/loadasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'45742F74-D765-450F-BD06-AC65016D85CF', N'功能管理-异步创建或更新功能', NULL, N'2020-01-01 22:10:49.6493670', NULL, NULL, N'1', N'1', NULL, N'function/addorupdateasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'ED9F3B62-EADB-42B3-86A8-AC650183E2E0', N'功能管理-异步加载功能', NULL, N'2020-01-01 23:32:15.0395220', NULL, NULL, N'1', N'1', NULL, N'function/loadasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'E0F91CAB-BA4F-470D-A0C6-AC650183E2E1', N'功能管理-异步创建或更新功能', NULL, N'2020-01-01 23:32:15.0395540', NULL, NULL, N'1', N'1', NULL, N'function/addorupdateasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'3F5894F2-4414-4051-97B1-AC66014ECC2B', N'功能管理-异步创建或更新功能', NULL, N'2020-01-01 20:18:57.6341870', NULL, NULL, N'1', N'1', NULL, N'function/addorupdateasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'C5387A19-59E9-4EC4-A5A1-AC66014ECC2B', N'功能管理-异步加载功能', NULL, N'2020-01-01 20:18:57.6341650', NULL, NULL, N'1', N'1', NULL, N'function/loadasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'67CB5BAA-11FC-4E6E-9E00-AC67014D67C5', N'功能管理-异步创建或更新功能', NULL, N'2020-01-01 20:13:53.5059570', NULL, NULL, N'0', N'1', NULL, N'function/addorupdateasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'A2D1C6AD-3E09-4035-A4A7-AC67014D67C5', N'功能管理-异步加载功能', NULL, N'2020-01-01 20:13:53.5059340', NULL, NULL, N'0', N'1', NULL, N'function/loadasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'7BCB4CA3-E859-4CED-8FE0-AC69015BD28B', N'用户管理-异步得到所有用户', NULL, N'2020-01-01 21:06:22.9702960', NULL, NULL, N'0', N'1', NULL, N'user/getusersasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'AED9B271-7C06-4AE9-98E9-AC69015BD28B', N'菜单功能-根据菜单ID得到菜单功能分页', NULL, N'2020-01-01 21:06:22.9702930', NULL, NULL, N'0', N'1', NULL, N'menufunction/getmenufunctionbymenuidpageasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'6631DBC0-4AE2-4081-B22C-AC69015BD28B', N'菜单功能-批量添加功能菜单', NULL, N'2020-01-01 21:06:22.9702160', NULL, NULL, N'0', N'1', NULL, N'menufunction/batchaddmenufunctionasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'EF241596-B9B4-474A-BA25-AC69015BD28B', N'菜单功能-批量删除功能菜单', NULL, N'2020-01-01 21:06:22.9702870', NULL, NULL, N'0', N'1', NULL, N'menufunction/batchdeletemenufunctionasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'E50CA2EC-4CAA-46FB-823A-AC7100871CC6', N'菜单管理-获取Vue动态路由菜单', NULL, N'2020-01-01 08:11:55.7545240', NULL, NULL, N'0', N'1', NULL, N'menu/getvuedynamicroutertreeasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'96B8D267-5CC6-489B-8558-AC7100871CC6', N'组织架构管理-表单加载组织架构', NULL, N'2020-01-01 08:11:55.7545510', NULL, NULL, N'0', N'1', NULL, N'organization/loadformorganizationasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'4EC2EA42-9D19-48B3-9217-AC7100871CC6', N'组织架构管理-异步得到组织架构分页数据', NULL, N'2020-01-01 08:11:55.7545530', NULL, NULL, N'0', N'1', NULL, N'organization/getpageorganizationasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'5DB63E92-2520-4072-A34D-AC7100871CC6', N'组织架构管理-获取组织架构', NULL, N'2020-01-01 08:11:55.7545480', NULL, NULL, N'0', N'1', NULL, N'organization/getorganizationtreeasync')
GO

INSERT INTO [dbo].[Function] ([Id], [Name], [CreatorUserId], [CreatedTime], [LastModifierUserId], [LastModifionTime], [IsDeleted], [IsEnabled], [Description], [LinkUrl]) VALUES (N'B9C764FC-B409-4DD6-B8D2-AC7100871CC6', N'用户管理-获取所有用户列表', NULL, N'2020-01-01 08:11:55.7545550', NULL, NULL, N'0', N'1', NULL, N'user/getuserstoselectlistitemasync')
GO


-- ----------------------------
-- Table structure for IdentityResource
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[IdentityResource]') AND type IN ('U'))
	DROP TABLE [dbo].[IdentityResource]
GO

CREATE TABLE [dbo].[IdentityResource] (
  [Id] uniqueidentifier  NOT NULL,
  [Enabled] bit  NOT NULL,
  [Name] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [DisplayName] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Description] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ShowInDiscoveryDocument] bit  NOT NULL,
  [Required] bit  NOT NULL,
  [Emphasize] bit  NOT NULL,
  [NonEditable] bit  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[IdentityResource] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of IdentityResource
-- ----------------------------
INSERT INTO [dbo].[IdentityResource] ([Id], [Enabled], [Name], [DisplayName], [Description], [ShowInDiscoveryDocument], [Required], [Emphasize], [NonEditable], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-49A5-8E0B-728A713C05E6', N'1', N'roles', N'角色', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', NULL, N'2020-01-01 08:12:52.5349530')
GO

INSERT INTO [dbo].[IdentityResource] ([Id], [Enabled], [Name], [DisplayName], [Description], [ShowInDiscoveryDocument], [Required], [Emphasize], [NonEditable], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27C-48D9-8426-89F7EE384C52', N'1', N'openid', N'Your user identifier', NULL, N'1', N'1', N'0', N'0', NULL, NULL, N'0', NULL, N'2020-01-01 08:12:52.5349460')
GO

INSERT INTO [dbo].[IdentityResource] ([Id], [Enabled], [Name], [DisplayName], [Description], [ShowInDiscoveryDocument], [Required], [Emphasize], [NonEditable], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', N'1', N'profile', N'User profile', N'Your user profile information (first name, last name, etc.)', N'1', N'0', N'1', N'0', NULL, NULL, N'0', NULL, N'2020-01-01 08:12:52.5349510')
GO


-- ----------------------------
-- Table structure for IdentityResourceClaim
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[IdentityResourceClaim]') AND type IN ('U'))
	DROP TABLE [dbo].[IdentityResourceClaim]
GO

CREATE TABLE [dbo].[IdentityResourceClaim] (
  [Id] uniqueidentifier  NOT NULL,
  [Type] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [IdentityResourceId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[IdentityResourceClaim] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of IdentityResourceClaim
-- ----------------------------
INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-489F-8E5E-0515A8E37D95', N'family_name', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-4904-8C67-11453A0C4E87', N'profile', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-48F1-8D69-29FD293BA24E', N'preferred_username', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27D-4DFC-8D09-367CCD8AD175', N'sub', N'08D8869F-B27C-48D9-8426-89F7EE384C52', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-49BC-86E4-397E22DE917E', N'role', N'08D8869F-B27E-49A5-8E0B-728A713C05E6', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-4947-802C-558C9F9F24C4', N'gender', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-48B4-8B98-63D94AD1AB42', N'given_name', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-4933-8939-8F1F4594685A', N'website', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-495B-8033-916A2995AAE5', N'birthdate', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-4994-8D74-B1C9B22E39DA', N'updated_at', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-48DD-8853-BA91CDD95BAA', N'nickname', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-48C8-882A-CCBB737972CE', N'middle_name', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-4888-8233-D7E468BB1A70', N'name', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-4981-8AC7-DA688F5B4B00', N'locale', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-496E-8190-DE50505DB14B', N'zoneinfo', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[IdentityResourceClaim] ([Id], [Type], [IdentityResourceId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8869F-B27E-4920-8184-F35C2E5C24CD', N'picture', N'08D8869F-B27E-4860-8E98-CFBC5B2678FE', NULL, NULL, N'0', NULL, N'2001-01-01 00:00:00.0000000')
GO


-- ----------------------------
-- Table structure for IdentityResourceProperty
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[IdentityResourceProperty]') AND type IN ('U'))
	DROP TABLE [dbo].[IdentityResourceProperty]
GO

CREATE TABLE [dbo].[IdentityResourceProperty] (
  [Id] uniqueidentifier  NOT NULL,
  [Key] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Value] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [IdentityResourceId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[IdentityResourceProperty] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of IdentityResourceProperty
-- ----------------------------

-- ----------------------------
-- Table structure for Menu
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu]') AND type IN ('U'))
	DROP TABLE [dbo].[Menu]
GO

CREATE TABLE [dbo].[Menu] (
  [Id] uniqueidentifier  NOT NULL,
  [Name] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Sort] int DEFAULT ((0)) NOT NULL,
  [Path] nvarchar(200) COLLATE Chinese_PRC_CI_AS  NULL,
  [ParentId] uniqueidentifier DEFAULT ('00000000-0000-0000-0000-000000000000') NOT NULL,
  [Icon] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Description] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ParentNumber] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Component] nvarchar(400) COLLATE Chinese_PRC_CI_AS  NULL,
  [Redirect] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Depth] int  NOT NULL,
  [Type] int  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit DEFAULT (CONVERT([bit],(0))) NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL,
  [Layout] nvarchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsHide] bit DEFAULT (CONVERT([bit],(0))) NOT NULL,
  [EventName] nvarchar(100) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Menu] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Menu
-- ----------------------------
INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D87F3D-AF0A-4B21-8560-00F12F32B1C4', N'顶级菜单', N'0', NULL, N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:43:37.9334720', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88B12-49E2-4921-87D3-08CF62180851', N'测试40001', N'0', NULL, N'08D88B12-0CF1-4822-8EF6-D6CB3BD00CAC', NULL, NULL, NULL, NULL, NULL, N'4', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:03:13.8181310', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'F2144584-CD8C-499C-E04B-08D89EC12BA4', N'222', N'9', N'', N'FD8A36D4-D6D8-A6BB-2924-77455100A305', N'', N'', N'FD8A36D4-D6D8-A6BB-2924-77455100A305', N'', NULL, N'2', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-12-13 01:12:57.0829435', N'', N'0', N'')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'92FA6A54-FF81-4AD0-E04C-08D89EC12BA4', N'2', N'10', N'', N'F2144584-CD8C-499C-E04B-08D89EC12BA4', N'', N'', N'FD8A36D4-D6D8-A6BB-2924-77455100A305.F2144584-CD8C-499C-E04B-08D89EC12BA4', N'', NULL, N'3', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-12-13 01:13:02.9828666', N'', N'0', N'')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'F9E7F5B9-0BCA-4BDB-E04D-08D89EC12BA4', N'w', N'10', N'', N'F2144584-CD8C-499C-E04B-08D89EC12BA4', N'', N'', N'FD8A36D4-D6D8-A6BB-2924-77455100A305.F2144584-CD8C-499C-E04B-08D89EC12BA4', N'', NULL, N'3', N'5', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-12-13 01:13:23.6771657', N'', N'0', N'')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88598-B792-4BBA-850E-0A15A2644A1C', N'分配权限', N'4', NULL, N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:01:33.5353380', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:50:23.4294610', NULL, N'0', N'handleAuth')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC', N'角色管理', N'2', N'/identity/role', N'FD8A36D4-D6D8-A6BB-2924-77455100A305', N'的撒所大所多撒as', N'角色管理', N'fd8a36d4-d6d8-a6bb-2924-77455100a305', N'identity/role-managerment/role-managerment', NULL, N'2', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:11:01.0207940', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 19:44:58.7374440', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BD9-5550-4DB7-8EE9-0FC027E5B289', N'添加组织机构树', N'0', NULL, N'08D88598-8230-4D89-892B-E8D34EA95E9A', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:53:11.7198470', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:48:02.8449600', NULL, N'0', N'handleAddTree')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D87FFE-C251-4779-8054-15C04038A8F1', N'数据审计', N'2', N'/system/auditentry', N'08D88645-31BD-42E5-8211-753786AAF90B', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88645-31bd-42e5-8211-753786aaf90b', N'system/audit-entry-managerment/audit-entry-managerment', NULL, N'3', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:20:11.8910570', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:45:43.1451330', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88973-2861-4537-8923-194AFB2D213C', N'查询菜单树', N'0', NULL, N'08D815D8-DAE5-4891-83D3-38A134D63506', NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:31:36.4374780', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BDA-B12E-4AD2-8C19-1BA86E696050', N'查询组织构', N'0', NULL, N'08D88598-8230-4D89-892B-E8D34EA95E9A', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', NULL, NULL, N'3', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:57:46.4682150', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BD8-4BC8-4952-8603-1C232987CE0B', N'编辑功能', N'0', NULL, N'08D815D8-DAE5-4891-83D3-38A134D63506', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:41:16.2257310', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:40:37.3556720', NULL, N'0', N'handleEditMenuFunction')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D86484-8C20-4AA8-8A80-1ECB288BEABC', N'代码生成器管理', N'5', N'/system/codeGenerator', N'FD8A36D4-D6D8-A6BB-2924-77455100A305', N'primary', NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305', N'system/code-generator-managerment/code-generator', NULL, N'2', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:11:23.9822730', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:32:52.2323840', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88C91-A02E-42DC-8672-220082FC01E1', N'查看菜单删除', N'0', NULL, N'08D815D8-DAE5-4891-83D3-38A134D63506', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', NULL, NULL, N'3', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:47:15.8449970', NULL, N'0', N'deleteFun')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88B11-DD48-4EB6-80D2-2348CB7C9229', N'测试1100', N'0', NULL, N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, N'1', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:00:11.5904050', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BD8-A84F-434E-8E97-255BAB78CCF2', N'分配菜单功能', N'0', NULL, N'08D815D8-DAE5-4891-83D3-38A134D63506', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', NULL, NULL, N'3', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:43:12.5882520', NULL, N'0', N'showAddMenuFunction')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88B12-386A-4AC9-8876-26AC352CE412', N'测试4000', N'0', NULL, N'08D88B12-0CF1-4822-8EF6-D6CB3BD00CAC', NULL, NULL, NULL, NULL, NULL, N'4', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:02:44.5110370', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BD8-87B6-4737-8F8B-2778C807FE43', N'删除功能', N'0', NULL, N'08D815D8-DAE5-4891-83D3-38A134D63506', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', NULL, NULL, N'3', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:42:17.8994120', NULL, N'0', N'handleDeleteMenuFunction')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BDA-448C-42E7-8F54-2CF879CD1AD5', N'查询菜单功能', N'0', NULL, N'08D815D8-DAE5-4891-83D3-38A134D63506', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', NULL, NULL, N'3', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:54:44.2092940', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D8835A-97B2-44AC-8B53-31DD9226B33C', N'测试菜单', N'0', N'11', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9', N'33', N'44444', NULL, N'22', NULL, N'0', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 04:20:38.8163730', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BD7-2037-4B83-8204-31E2CF867FC3', N'删除', N'0', N'handleDelete', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-f67c-4299-8d3a-c3243fcb5bc7', NULL, NULL, N'3', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:32:14.7425250', NULL, N'0', N'handleDelete')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BD9-BB50-4E9C-8669-3393ABE8D475', N'修改', N'0', NULL, N'08D88598-8230-4D89-892B-E8D34EA95E9A', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', NULL, NULL, N'3', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:50:53.9729130', NULL, N'0', N'handleUpdate')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D84375-234A-48C6-83E8-36B6134F4439', N'修改', N'1', N'update', N'08D815D8-DAE5-4891-83D3-38A134D63506', N'primary', NULL, NULL, N'update', NULL, N'0', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 20:49:25.4747780', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88B12-63DF-4C3C-82FA-37CA19168C34', N'测试2220', N'0', NULL, N'08D88B11-DD48-4EB6-80D2-2348CB7C9229', NULL, NULL, NULL, NULL, NULL, N'2', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:03:57.4205010', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D815D8-DAE5-4891-83D3-38A134D63506', N'菜单管理', N'3', N'/identity/menu', N'FD8A36D4-D6D8-A6BB-2924-77455100A305', N'`', NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305', N'identity/menu-managerment/menu-managerment', NULL, N'2', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:11:14.5822770', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 19:47:20.2518030', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D81DD2-DC25-4FFA-8518-4B28558BA714', N'添加', N'1', N'add', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC', N'primary', N'阿萨德啊的', N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc', N'add', NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:00:40.7989890', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 23:24:34.6735980', NULL, N'0', N'handleAdd')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88973-3848-4139-8979-50BA65AA6985', N'查询菜单树', N'0', NULL, N'08D815D8-DAE5-4891-83D3-38A134D63506', NULL, NULL, NULL, NULL, NULL, N'0', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:32:03.1409330', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D87FFE-50DB-4B11-8FFA-55602E216862', N'操作审计', N'1', N'/system/auditlog', N'08D88645-31BD-42E5-8211-753786AAF90B', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88645-31bd-42e5-8211-753786aaf90b', N'system/audit-log-managerment/audit-log-managerment', NULL, N'3', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:20:02.9255750', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:42:32.6317010', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D8835A-BE60-46A2-8C50-5599EB14CA25', N'测试菜单', N'1', N'11', N'08D815D8-DAE5-4891-83D3-38A134D63506', N'11', N'11', NULL, N'11', NULL, N'0', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 04:22:08.8662580', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 04:21:43.7203340', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D84450-78CF-499B-897C-56A4304F139F', N'删除', N'4', N'delete', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9', N'primary', NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9', N'primary', NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:22:28.2851260', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:59:28.7866650', NULL, N'0', N'handleDelete')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D83C69-A522-4175-8E0C-5EFC57FD6456', N'修改', N'2', N'update', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC', N'Default', N'as as as sa', N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc', N'dasda', NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:00:54.9172670', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:39:31.2499510', NULL, N'0', N'handleUpdate')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88597-A9D2-467D-84CF-73ED0F9C04D3', N'修改', N'7', NULL, N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-f67c-4299-8d3a-c3243fcb5bc7', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:32:41.5919350', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:42:50.8619180', NULL, N'0', N'handleUpdate')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BD9-AC4F-4261-8FD2-743DB9AF6739', N'添加', N'0', NULL, N'08D88598-8230-4D89-892B-E8D34EA95E9A', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', NULL, NULL, N'3', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:50:28.7955580', NULL, N'0', N'handleAdd')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88645-31BD-42E5-8211-753786AAF90B', N'审计管理', N'5', N'/layout-empty', N'FD8A36D4-D6D8-A6BB-2924-77455100A305', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305', NULL, NULL, N'2', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:19:05.8486390', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:25:01.7764950', N'/layout', N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'FD8A36D4-D6D8-A6BB-2924-77455100A305', N'系统管理', N'1', N'/layout', N'00000000-0000-0000-0000-000000000000', N'1', NULL, NULL, NULL, NULL, N'1', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:09:15.2538540', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:59:20.4191330', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88B11-EF3A-40EA-8BCF-7769B6FD295A', N'测试2000', N'0', NULL, N'08D88B11-DD48-4EB6-80D2-2348CB7C9229', NULL, NULL, NULL, NULL, NULL, N'2', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:00:41.7182600', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88598-3180-446C-8A9F-79AF05025956', N'生成代码', N'9', NULL, N'08D86484-8C20-4AA8-8A80-1ECB288BEABC', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d86484-8c20-4aa8-8a80-1ecb288beabc', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 20:56:55.9649960', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:46:38.4938000', NULL, N'0', N'save')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BD9-8BB4-45AE-83A3-79C4C7949A22', N'删除组织架构树', N'0', NULL, N'08D88598-8230-4D89-892B-E8D34EA95E9A', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:59:07.5050760', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:49:34.0940160', NULL, N'0', N'handleDeleteTree')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88973-A35E-4936-84CF-7D8A715F12D2', N'删除菜单', N'0', NULL, N'08D815D8-DAE5-4891-83D3-38A134D63506', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:38:56.6698680', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:35:02.8050650', NULL, N'0', N'handleDeleteTreeMenu')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D84378-A754-4829-8AB2-83D25AB2A125', N'添加子级', N'3', N'addchildren', N'08D815D8-DAE5-4891-83D3-38A134D63506', N'primary', NULL, NULL, N'addchildren', NULL, N'0', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:14:35.5393190', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88CE3-E97B-4E97-86EC-93733E04940B', N'测试菜单', N'9', NULL, N'FD8A36D4-D6D8-A6BB-2924-77455100A305', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305', NULL, NULL, N'2', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 07:36:17.5233180', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88597-EB63-428C-8422-9480FC807C31', N'查询', N'8', NULL, N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-f67c-4299-8d3a-c3243fcb5bc7', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:17:50.3646390', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:44:40.8624360', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88973-93B1-4093-889D-97BEDABC2233', N'菜单添加', N'0', NULL, N'08D815D8-DAE5-4891-83D3-38A134D63506', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:38:07.9835970', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:34:36.5017960', NULL, N'0', N'handleAddTreeMenu')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D87F4D-3C74-45AD-89CE-97F8AD9AC389', N'超级顶级菜单', N'0', NULL, N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:34:57.6389930', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D84376-ACC6-4924-8116-9D7AF9EA87CE', N'添加', N'2', N'add', N'08D815D8-DAE5-4891-83D3-38A134D63506', N'primary', NULL, NULL, N'add', NULL, N'0', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 04:25:45.5086680', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:00:25.6812160', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88B06-C494-477C-89C2-A40C2F406EB4', N'测试', N'5', NULL, N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:40:45.1547230', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88598-4B78-42F3-86E2-A6602135964B', N'查询', N'10', NULL, N'08D87FFE-50DB-4B11-8FFA-55602E216862', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88645-31bd-42e5-8211-753786aaf90b.08d87ffe-50db-4b11-8ffa-55602e216862', NULL, NULL, N'4', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:22:44.1073640', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:47:22.0615170', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D87F3D-D022-4E91-871A-A7465821647B', N'子', N'0', NULL, N'08D87F3D-AF0A-4B21-8560-00F12F32B1C4', NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:44:33.4599160', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88598-7120-46AB-85B4-A7F40AF04D3A', N'查询', N'11', NULL, N'08D87FFE-C251-4779-8054-15C04038A8F1', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88645-31bd-42e5-8211-753786aaf90b.08d87ffe-c251-4779-8054-15c04038a8f1', NULL, NULL, N'4', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:20:44.6920800', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:48:25.2397780', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D87F41-BB8B-4571-85AB-A8128B61761A', N'顶级菜单', N'0', NULL, N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:12:36.8613560', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D84450-4C1F-4F06-8652-AB6A2C1C888F', N'修改', N'3', N'update', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9', N'primary', NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9', N'primary', NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:06:05.7284960', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:58:13.8147880', NULL, N'0', N'handleUpdate')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D87F40-8A48-4E2D-8A7B-AF6D885C3AE6', N'测试菜单', N'0', NULL, N'FD8A36D4-D6D8-A6BB-2924-77455100A305', NULL, NULL, NULL, NULL, NULL, N'0', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:04:04.7588740', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88596-CB6B-43E1-84FB-B5A0A194E545', N'删除', N'3', NULL, N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:01:20.9988710', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:36:37.7316350', NULL, N'0', N'handleDelete')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BD9-66E3-4001-8B57-BD83187C2BFC', N'更新组织机构树', N'0', NULL, N'08D88598-8230-4D89-892B-E8D34EA95E9A', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', NULL, NULL, N'3', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:48:32.3239980', NULL, N'0', N'handleEditTree')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BD9-CDFC-48A6-8958-BEF859429E8E', N'删除', N'0', NULL, N'08D88598-8230-4D89-892B-E8D34EA95E9A', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', NULL, NULL, N'3', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:51:25.2967080', NULL, N'0', N'handleDelete')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D87F24-EB03-460C-8BF0-C04B595214F0', N'测试菜单9', N'4449', N'1119', N'FD8A36D4-D6D8-A6BB-2924-77455100A305', N'3339', N'5559', NULL, N'2229', NULL, N'0', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:32:08.5375630', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 19:46:21.1164920', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88C90-8D28-42EC-8F52-C0838B9EA12F', N'得到C#类型', N'0', NULL, N'08D86484-8C20-4AA8-8A80-1ECB288BEABC', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d86484-8c20-4aa8-8a80-1ecb288beabc', NULL, NULL, N'3', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:39:34.4021500', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7', N'功能管理', N'4', N'/identity/function', N'FD8A36D4-D6D8-A6BB-2924-77455100A305', N'`', NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305', N'identity/function-managerment/function-managerment', NULL, N'2', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:11:18.7471060', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 19:48:06.5371290', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88973-4EBE-43B6-83FD-D1343E3C3DB3', N'查询菜单分页表格', N'0', NULL, N'08D815D8-DAE5-4891-83D3-38A134D63506', NULL, NULL, NULL, NULL, NULL, N'0', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:32:40.8256580', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D8896E-5FB8-447E-86CE-D3E1548F65F0', N'数据字典', N'8', N'/system/dictionary', N'FD8A36D4-D6D8-A6BB-2924-77455100A305', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305', N'system/data-dictionary-managerment/data-dictionary-managerment', NULL, N'2', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:11:39.0624050', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:57:21.7872180', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D84379-A770-4AB0-8882-D65FE6996556', N'修改', N'2', N'update', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7', N'primary', NULL, NULL, N'update', NULL, N'0', N'5', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:21:45.2205930', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88B12-0CF1-4822-8EF6-D6CB3BD00CAC', N'测试3000', N'10', NULL, N'08D88B11-EF3A-40EA-8BCF-7769B6FD295A', NULL, NULL, NULL, NULL, NULL, N'3', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:01:31.5749450', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D84379-988D-4FF9-8F47-DB14075ADDC2', N'添加', N'6', N'add', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7', N'primary', NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-f67c-4299-8d3a-c3243fcb5bc7', N'add', NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:30:33.4135920', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:21:20.2469920', NULL, N'0', N'handleAdd')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88597-6B34-4F44-8261-DCFA2736E8FE', N'查询', N'5', NULL, N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:17:09.7989330', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:41:05.8113090', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BDA-A94D-40E5-82AE-DD6F5F728265', N'查询组织构架树', N'0', NULL, N'08D88598-8230-4D89-892B-E8D34EA95E9A', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', NULL, NULL, N'3', N'5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:57:33.2454030', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88594-14AE-4DE2-8E55-DFDF1E41E40D', N'用户分配角色', N'5', NULL, N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:06:43.4143170', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:17:12.1574620', NULL, N'0', N'allocationRole')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88BD8-177C-40FE-82B6-E4E6484F7C95', N'添加功能', N'0', NULL, N'08D815D8-DAE5-4891-83D3-38A134D63506', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:40:06.6766210', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:39:09.6119870', NULL, N'0', N'handleAddMenuFunction')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88B12-762B-4D04-8BF1-E73104B8F2D9', N'测试2221', N'0', NULL, N'08D88B11-DD48-4EB6-80D2-2348CB7C9229', NULL, NULL, NULL, NULL, NULL, N'2', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:04:28.1177610', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88973-9A33-4A25-8252-E8BFF2507CFB', N'修改菜单', N'0', NULL, N'08D815D8-DAE5-4891-83D3-38A134D63506', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:38:29.2958510', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:34:47.4241110', NULL, N'0', N'handleEditTreeMenu')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88598-8230-4D89-892B-E8D34EA95E9A', N'组织架构', N'7', N'/system/organization', N'FD8A36D4-D6D8-A6BB-2924-77455100A305', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305', N'identity/organization-managerment/organization-managerment', NULL, N'2', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:11:34.6203050', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:48:53.8687100', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D8444F-875E-4A45-861D-F12DBB72C463', N'添加', N'2', N'add', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9', N'primary', N'asdsad asd asd ', N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9', N'primary', NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:05:39.8191160', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:52:43.6772070', NULL, N'0', N'handleAdd')
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D8437D-752A-4633-8AD9-F1E44F005B8D', N'查看功能', N'2', N'select', N'08D815D8-DAE5-4891-83D3-38A134D63506', N'primary', NULL, NULL, N'select', NULL, N'0', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:48:58.8607980', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D88595-506F-4B2B-8583-FE22DDDB3FED', N'查询', N'1', NULL, N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9', NULL, NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9', NULL, NULL, N'3', N'5', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:27:56.1729160', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:26:01.9042830', NULL, N'0', NULL)
GO

INSERT INTO [dbo].[Menu] ([Id], [Name], [Sort], [Path], [ParentId], [Icon], [Description], [ParentNumber], [Component], [Redirect], [Depth], [Type], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Layout], [IsHide], [EventName]) VALUES (N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9', N'用户管理', N'1', N'/identity/user', N'FD8A36D4-D6D8-A6BB-2924-77455100A305', N'1', NULL, N'fd8a36d4-d6d8-a6bb-2924-77455100a305', N'identity/user-managerment/user-managerment', NULL, N'2', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:09:28.5226710', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:59:20.4191330', NULL, N'0', NULL)
GO


-- ----------------------------
-- Table structure for MenuFunction
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[MenuFunction]') AND type IN ('U'))
	DROP TABLE [dbo].[MenuFunction]
GO

CREATE TABLE [dbo].[MenuFunction] (
  [Id] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL,
  [MenuId] uniqueidentifier  NOT NULL,
  [FunctionId] uniqueidentifier  NOT NULL
)
GO

ALTER TABLE [dbo].[MenuFunction] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of MenuFunction
-- ----------------------------
INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'06E87652-5DAF-4E18-9EE7-AC2C0177079C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:45:26.4855360', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC', N'F16DC63B-5958-4FEF-9C74-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'627DD793-1437-4586-8DB0-AC2C0177198A', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:45:41.7878630', N'08D81DD2-DC25-4FFA-8518-4B28558BA714', N'118C42F7-7D58-4DF7-91DF-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'4AB1B9E0-64A8-43D8-B692-AC2C0177198A', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:45:41.7878740', N'08D81DD2-DC25-4FFA-8518-4B28558BA714', N'DBEE031F-3100-494B-AB6D-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'EFE85D61-A7F2-400D-9221-AC2C01772DCB', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:45:59.0709030', N'08D83C69-A522-4175-8E0C-5EFC57FD6456', N'0C66B541-250C-4F8F-B0F4-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'20016F47-BD07-4556-A02B-AC2C01777074', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:46:55.9521790', N'08D815D8-DAE5-4891-83D3-38A134D63506', N'765852F3-FAF4-4AB8-B2C2-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'EC9C9A94-25E5-4F28-B12F-AC2C01777074', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:46:55.9521620', N'08D815D8-DAE5-4891-83D3-38A134D63506', N'E3147913-003E-4CEC-AF12-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'CFE49A81-3F50-4FF7-AA58-AC2C017782BB', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:47:11.5512430', N'08D8437D-752A-4633-8AD9-F1E44F005B8D', N'4E9E5E40-10B1-4170-BD99-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'94C5D1C6-727B-45FC-9F8E-AC2C01779F03', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:47:35.6829200', N'08D84378-A754-4829-8AB2-83D25AB2A125', N'8C5AEE5E-0466-4F01-BCF0-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'6F9AD0DE-FFDC-4C7D-81F5-AC2C0177B1FD', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:47:51.8780940', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7', N'EB1BC3F5-014C-4399-8982-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'FEB382BA-9319-4216-9340-AC2C0177BCBE', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:48:01.0527190', N'08D84379-988D-4FF9-8F47-DB14075ADDC2', N'765545FA-F77F-434C-B8F0-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'EE93B9D3-B573-4370-9E5C-AC2C0177CECB', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:48:16.4573420', N'08D81DD2-DC25-4FFA-8518-4B28558BA714', N'DBEE031F-3100-494B-AB6D-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'934BD70D-434D-4914-A8DE-AC2C0177CECB', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:48:16.4573690', N'08D81DD2-DC25-4FFA-8518-4B28558BA714', N'118C42F7-7D58-4DF7-91DF-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'BBA04877-CFB0-4519-B190-AC2C0177E9D9', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:48:39.5445990', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9', N'5CF76B4A-CE23-4A1D-A071-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'A7AD4C47-3D2F-45E2-92D4-AC2C0177F765', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:48:51.1037650', N'08D8444F-875E-4A45-861D-F12DBB72C463', N'A3B4DA8D-5536-4001-AB64-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'8BA07F0A-22E9-4A5B-8C72-AC2C01780673', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:49:03.9515240', N'08D84450-4C1F-4F06-8652-AB6A2C1C888F', N'0D5A194B-F9B3-4F29-A2AC-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'F3ECBC67-36C2-49C7-9763-AC2C01780673', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:49:03.9516130', N'08D84450-4C1F-4F06-8652-AB6A2C1C888F', N'A855299F-4021-4ED5-8B76-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'A3FC1341-A631-4476-A46D-AC2C0178171D', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:49:18.1706010', N'08D84450-78CF-499B-897C-56A4304F139F', N'09DC98F3-3824-410F-8D77-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'357B6553-28E8-4CAB-9169-AC2C017B7B83', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 23:01:39.2024430', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9', N'5CF76B4A-CE23-4A1D-A071-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'7F3E2AFF-933C-4ABC-B8D5-AC2C017B7B83', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 23:01:39.2024650', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9', N'ECA617AD-BEDF-4BD2-8999-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'D2ECB133-7E64-4F4C-82E6-AC69000118A7', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:03:59.7724500', N'08D81DD2-DC25-4FFA-8518-4B28558BA714', N'118C42F7-7D58-4DF7-91DF-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'952689B7-2812-4A4D-9A26-AC69000118B3', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:03:59.7725020', N'08D81DD2-DC25-4FFA-8518-4B28558BA714', N'DBEE031F-3100-494B-AB6D-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'5DB69995-3CFC-480A-A302-AC6C012DEE79', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 18:19:18.0269510', N'08D87FFE-C251-4779-8054-15C04038A8F1', N'AED9B271-7C06-4AE9-98E9-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'0EF3C625-CCD8-4EF6-A5AB-AC6C012DEE79', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 18:19:18.0268790', N'08D87FFE-C251-4779-8054-15C04038A8F1', N'7BCB4CA3-E859-4CED-8FE0-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'D620ECB3-773D-4CE7-A5C4-AC6C01646326', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:37:34.1260390', N'08D87FFE-C251-4779-8054-15C04038A8F1', N'2C4A8E2F-AAB6-4A81-80D0-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'F1B9320E-0C82-44D6-AEFB-AC6D00114B0E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 01:02:57.8464940', N'08D87FFE-C251-4779-8054-15C04038A8F1', N'7BCB4CA3-E859-4CED-8FE0-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'DEB1E19A-EC51-4E49-8D70-AC6D0014FD99', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 01:16:25.6036740', N'08D87FFE-C251-4779-8054-15C04038A8F1', N'7BCB4CA3-E859-4CED-8FE0-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'0565D2DC-BEBB-453C-8058-AC6D0015B7A6', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 01:19:04.3036600', N'08D87FFE-C251-4779-8054-15C04038A8F1', N'7BCB4CA3-E859-4CED-8FE0-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'CA3CA8B1-10C3-4417-B6B4-AC6D0018DF76', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 01:30:33.6357820', N'08D87FFE-C251-4779-8054-15C04038A8F1', N'7BCB4CA3-E859-4CED-8FE0-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'6933EE17-94F8-4AFE-BE13-AC6D001B20DD', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 01:38:46.3434760', N'08D87FFE-C251-4779-8054-15C04038A8F1', N'7BCB4CA3-E859-4CED-8FE0-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'BB2FD922-569E-4368-976B-AC6D0048548C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 04:23:20.8392810', N'08D87FFE-C251-4779-8054-15C04038A8F1', N'7BCB4CA3-E859-4CED-8FE0-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'E62F34FD-8F35-4A49-8F56-AC6D00485F2D', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 04:23:29.9142150', N'08D87FFE-C251-4779-8054-15C04038A8F1', N'2C4A8E2F-AAB6-4A81-80D0-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'0910EF92-3A67-4174-BC2D-AC6D00CC3BED', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 12:23:35.6989980', N'08D87FFE-C251-4779-8054-15C04038A8F1', N'7BCB4CA3-E859-4CED-8FE0-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'96BC850A-316C-4B7C-8564-AC7000038453', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:12:48.4452400', N'08D84450-78CF-499B-897C-56A4304F139F', N'7BCB4CA3-E859-4CED-8FE0-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'1E2462BC-FB8F-4307-9ABB-AC700003E6D1', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:14:12.4835880', N'08D84450-78CF-499B-897C-56A4304F139F', N'0D5A194B-F9B3-4F29-A2AC-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'F861A6D4-C8CB-4707-989C-AC70000423CB', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:15:04.5206730', N'08D84450-4C1F-4F06-8652-AB6A2C1C888F', N'5CF76B4A-CE23-4A1D-A071-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'798B2ED4-DD8A-4D7D-92F1-AC70000430AE', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:15:15.5163720', N'08D84450-78CF-499B-897C-56A4304F139F', N'5CF76B4A-CE23-4A1D-A071-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'CD384FC3-7A70-400D-997E-AC7000047405', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:16:12.9782070', N'08D8444F-875E-4A45-861D-F12DBB72C463', N'5CF76B4A-CE23-4A1D-A071-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'BC534B0E-1B38-4367-90A5-AC700004881C', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:16:30.1206220', N'08D8444F-875E-4A45-861D-F12DBB72C463', N'0D5A194B-F9B3-4F29-A2AC-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'B20CEB17-C415-4ABD-9936-AC700005768E', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:19:53.5949180', N'08D88594-14AE-4DE2-8E55-DFDF1E41E40D', N'ECA617AD-BEDF-4BD2-8999-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'D3054273-8E3A-4F5C-9DEB-AC700005F5D1', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:21:42.1909030', N'08D88594-14AE-4DE2-8E55-DFDF1E41E40D', N'0D5A194B-F9B3-4F29-A2AC-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'7C2E982F-6C4E-4EB1-BEB6-AC7000060D69', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:22:02.3425040', N'08D88594-14AE-4DE2-8E55-DFDF1E41E40D', N'7633BECD-2B7E-463C-9430-AC6000EABA15')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'7405181E-BB7C-41E0-959E-AC70000779FB', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:27:13.4456870', N'08D88595-506F-4B2B-8583-FE22DDDB3FED', N'5CF76B4A-CE23-4A1D-A071-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'699CA32E-9D3B-4397-A4F7-AC7000098700', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:34:41.4411200', N'08D83C69-A522-4175-8E0C-5EFC57FD6456', N'F16DC63B-5958-4FEF-9C74-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'995C25FC-3FF6-41AC-BFB6-AC70000992D0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:34:51.5239570', N'08D81DD2-DC25-4FFA-8518-4B28558BA714', N'F16DC63B-5958-4FEF-9C74-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'B807AF19-0D5D-4E0A-A3D3-AC700009AD40', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:35:14.0874990', N'08D83C69-A522-4175-8E0C-5EFC57FD6456', N'F16DC63B-5958-4FEF-9C74-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'451BBCC1-8F6A-4D1F-AD79-AC700009DFE6', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:35:57.3029390', N'08D83C69-A522-4175-8E0C-5EFC57FD6456', N'DBEE031F-3100-494B-AB6D-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'B5EA4C4F-9BC3-4270-91E3-AC70000A5090', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:37:33.4427130', N'08D88596-CB6B-43E1-84FB-B5A0A194E545', N'90E36B1E-2CF0-442D-B260-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'9306B567-668B-42DF-9707-AC70000A5F79', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:37:46.1700190', N'08D88596-CB6B-43E1-84FB-B5A0A194E545', N'F16DC63B-5958-4FEF-9C74-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'C063D319-0584-4623-A0F6-AC70000B5EF7', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:41:24.1876080', N'08D88597-6B34-4F44-8261-DCFA2736E8FE', N'F16DC63B-5958-4FEF-9C74-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'66EC1F44-5F3C-43B1-B5FC-AC70000B8EA8', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:42:04.8968480', N'08D84379-988D-4FF9-8F47-DB14075ADDC2', N'67CB5BAA-11FC-4E6E-9E00-AC67014D67C5')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'35FAD571-F4B2-4A07-B494-AC70000BA158', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:42:20.8303500', N'08D84379-988D-4FF9-8F47-DB14075ADDC2', N'A2D1C6AD-3E09-4035-A4A7-AC67014D67C5')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'49B88CC0-1117-4AB3-9AE4-AC70000BE5DB', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:43:19.2986620', N'08D88597-A9D2-467D-84CF-73ED0F9C04D3', N'67CB5BAA-11FC-4E6E-9E00-AC67014D67C5')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'C71F9D27-AB6B-4AEE-AB2D-AC70000BF42E', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:43:31.5150680', N'08D88597-A9D2-467D-84CF-73ED0F9C04D3', N'A2D1C6AD-3E09-4035-A4A7-AC67014D67C5')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'7EC7F438-136C-4A2E-8503-AC70000C00E1', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:43:42.3610480', N'08D88597-A9D2-467D-84CF-73ED0F9C04D3', N'EB1BC3F5-014C-4399-8982-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'A00459CC-A1A4-4DE7-A42E-AC70000C2A7C', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:44:17.8578690', N'08D88597-A9D2-467D-84CF-73ED0F9C04D3', N'99C943DD-1482-45F3-913E-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'B2E84B2C-4276-4156-A6D8-AC70000C59DC', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:44:58.2841550', N'08D88597-EB63-428C-8422-9480FC807C31', N'EB1BC3F5-014C-4399-8982-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'FBC30F25-0E94-4A3C-B5F2-AC70000C918C', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:45:45.8021530', N'08D84379-988D-4FF9-8F47-DB14075ADDC2', N'EB1BC3F5-014C-4399-8982-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'4AB350F1-06A6-4E6B-8B8B-AC70000CE28C', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:46:54.9243380', N'08D88598-3180-446C-8A9F-79AF05025956', N'CBB3626A-DED7-4F11-A8EC-AC6000EABA15')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'E6112DDC-D7A5-47C8-ACD9-AC70000CE28C', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:46:54.9243340', N'08D88598-3180-446C-8A9F-79AF05025956', N'2951A7A7-FBA7-4F5E-9A92-AC6000EABA15')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'FE700FBA-27BB-4CF6-A46B-AC70000E427A', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:51:55.2360990', N'08D88598-B792-4BBA-850E-0A15A2644A1C', N'BA275142-01E5-4621-B822-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'EB8E0898-615C-495C-BE04-AC70000E8794', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:52:54.2023770', N'08D88598-B792-4BBA-850E-0A15A2644A1C', N'2C4A8E2F-AAB6-4A81-80D0-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'F89481A8-528B-46F9-88BB-AC7701830120', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:29:02.3960930', N'08D88973-A35E-4936-84CF-7D8A715F12D2', N'4EC2EA42-9D19-48B3-9217-AC7100871CC6')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'CE1962ED-BFF4-4C98-AA22-AC7701830120', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:29:02.3960660', N'08D88B12-49E2-4921-87D3-08CF62180851', N'4EC2EA42-9D19-48B3-9217-AC7100871CC6')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'D60C8E69-D470-434D-B1C3-AC7701830120', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:29:02.3960770', N'08D88973-A35E-4936-84CF-7D8A715F12D2', N'B9C764FC-B409-4DD6-B8D2-AC7100871CC6')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'F8F9972D-103F-45BE-B2C5-AC7701830120', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:29:02.3959900', N'08D88B12-49E2-4921-87D3-08CF62180851', N'B9C764FC-B409-4DD6-B8D2-AC7100871CC6')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'7C8BAC46-FF4D-48EE-9CB5-AC780007B481', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:28:03.2077210', N'08D88973-3848-4139-8979-50BA65AA6985', N'C1355FA8-DA88-4430-8BB5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'E62537CE-93CC-4708-B881-AC780008076D', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:29:13.9636860', N'08D88973-4EBE-43B6-83FD-D1343E3C3DB3', N'D726E21A-2116-4CC8-94C5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'894637E5-0006-4203-9328-AC7800088560', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:31:01.4404110', N'08D88973-93B1-4093-889D-97BEDABC2233', N'E82440DE-6D62-4EB8-A052-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'BA48F62B-2F3B-43AE-B7D8-AC7800088560', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:31:01.4404230', N'08D88973-9A33-4A25-8252-E8BFF2507CFB', N'E82440DE-6D62-4EB8-A052-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'0EB90072-BBA4-4284-9819-AC780008EE9F', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:32:31.2502440', N'08D88973-9A33-4A25-8252-E8BFF2507CFB', N'C1355FA8-DA88-4430-8BB5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'03DF2D22-9EF4-42A1-9E0A-AC780008EE9F', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:32:31.2502240', N'08D88973-93B1-4093-889D-97BEDABC2233', N'C1355FA8-DA88-4430-8BB5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'05B49E57-0A96-4DD3-8174-AC780008FD40', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:32:43.7337010', N'08D88973-93B1-4093-889D-97BEDABC2233', N'D726E21A-2116-4CC8-94C5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'3EB78848-F66C-473B-927D-AC780008FD40', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:32:43.7337070', N'08D88973-9A33-4A25-8252-E8BFF2507CFB', N'D726E21A-2116-4CC8-94C5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'3ED0F507-AC97-4451-B15A-AC7800090CC7', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:32:56.9837860', N'08D88973-A35E-4936-84CF-7D8A715F12D2', N'D726E21A-2116-4CC8-94C5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'B8973EE9-C0DA-4AA4-8249-AC7800091EC5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:33:12.3371490', N'08D88973-A35E-4936-84CF-7D8A715F12D2', N'C1355FA8-DA88-4430-8BB5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'C6FE1FA1-A496-4B10-9B92-AC7800093AE1', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:33:36.3253010', N'08D88973-93B1-4093-889D-97BEDABC2233', N'8C5AEE5E-0466-4F01-BCF0-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'62C4E6B8-923E-49D8-A591-AC780009490F', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:33:48.4262780', N'08D88973-9A33-4A25-8252-E8BFF2507CFB', N'90A05DD2-AA52-40CB-A30C-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'16B89A81-694D-4144-AF96-AC780009A37C', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:35:05.5880190', N'08D88973-A35E-4936-84CF-7D8A715F12D2', N'94D0E63E-04E8-4206-8380-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'7B644241-3502-4731-92E2-AC78000A7133', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:38:01.1326490', N'08D88BD8-177C-40FE-82B6-E4E6484F7C95', N'C1355FA8-DA88-4430-8BB5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'73E45298-CBA6-4698-A023-AC78000A7133', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:38:01.1326550', N'08D88BD8-4BC8-4952-8603-1C232987CE0B', N'C1355FA8-DA88-4430-8BB5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'E7A9641C-DBC8-40AF-9FA6-AC78000A80CB', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:38:14.4379760', N'08D88BD8-4BC8-4952-8603-1C232987CE0B', N'D726E21A-2116-4CC8-94C5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'28B68521-16AA-4695-A00F-AC78000A80CB', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:38:14.4379610', N'08D88BD8-177C-40FE-82B6-E4E6484F7C95', N'D726E21A-2116-4CC8-94C5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'61262A28-4811-488A-8C38-AC78000AB82B', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:39:01.6927200', N'08D88BD8-4BC8-4952-8603-1C232987CE0B', N'E82440DE-6D62-4EB8-A052-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'2D95CA98-84AC-491A-9F69-AC78000AB82B', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:39:01.6926630', N'08D88BD8-177C-40FE-82B6-E4E6484F7C95', N'E82440DE-6D62-4EB8-A052-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'37515766-93B6-4E12-AD44-AC78000AE590', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:39:40.4274800', N'08D88BD8-87B6-4737-8F8B-2778C807FE43', N'C1355FA8-DA88-4430-8BB5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'C3377449-E130-4238-B705-AC78000AFBAA', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:39:59.2889170', N'08D88BD8-87B6-4737-8F8B-2778C807FE43', N'D726E21A-2116-4CC8-94C5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'5DD6E40A-50CE-4DDC-BE37-AC78000B28B6', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:40:37.7285340', N'08D88BD8-177C-40FE-82B6-E4E6484F7C95', N'8C5AEE5E-0466-4F01-BCF0-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'8F81136D-3F06-4C51-B0AB-AC78000B3936', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:40:51.8094410', N'08D88BD8-4BC8-4952-8603-1C232987CE0B', N'90A05DD2-AA52-40CB-A30C-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'9D332C63-7B27-4866-90A9-AC78000B4A08', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:41:06.1598680', N'08D88BD8-87B6-4737-8F8B-2778C807FE43', N'94D0E63E-04E8-4206-8380-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'862C19CA-ED7D-47D5-B146-AC78000B8400', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:41:55.6291000', N'08D88BD8-A84F-434E-8E97-255BAB78CCF2', N'D726E21A-2116-4CC8-94C5-AC6500BEB968')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'EF87DECE-7A42-41F0-BED3-AC78000BA08C', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:42:19.9869780', N'08D88BD8-A84F-434E-8E97-255BAB78CCF2', N'EB1BC3F5-014C-4399-8982-AC2C0176D440')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'AF87EF27-7FA6-43CB-A8EB-AC78000BAB4E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:42:29.1693130', N'08D88BD8-A84F-434E-8E97-255BAB78CCF2', N'B9C764FC-B409-4DD6-B8D2-AC7100871CC6')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'E3627B72-2C15-40C9-9210-AC78000BB4FF', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:42:37.4395240', N'08D88BD8-A84F-434E-8E97-255BAB78CCF2', N'6631DBC0-4AE2-4081-B22C-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'862ACD14-9344-4D6A-9840-AC78000BF94E', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:43:35.7285510', N'08D88BDA-448C-42E7-8F54-2CF879CD1AD5', N'AED9B271-7C06-4AE9-98E9-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'56AFA3C3-EAD0-4497-9246-AC78000BFF4A', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:43:40.8351360', N'08D88BDA-448C-42E7-8F54-2CF879CD1AD5', N'B9C764FC-B409-4DD6-B8D2-AC7100871CC6')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'D3F154FF-CC42-4733-B245-AC78000C1ED5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:44:07.7506840', N'08D88BDA-448C-42E7-8F54-2CF879CD1AD5', N'EF241596-B9B4-474A-BA25-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'32186630-BCA4-4B83-A607-AC780165038B', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:39:50.8586660', N'08D88C90-8D28-42EC-8F52-C0838B9EA12F', N'2951A7A7-FBA7-4F5E-9A92-AC6000EABA15')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'016B8813-5097-4D10-871A-AC78016535DE', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:40:33.7989530', N'08D88BDA-B12E-4AD2-8C19-1BA86E696050', N'4EC2EA42-9D19-48B3-9217-AC7100871CC6')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'528027BE-AD16-4EAD-9228-AC7801654A80', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:40:51.4069680', N'08D88BDA-A94D-40E5-82AE-DD6F5F728265', N'5DB63E92-2520-4072-A34D-AC7100871CC6')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'5BC6E96F-20CD-4745-A95C-AC7801676F8C', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:48:39.9282230', N'08D88C91-A02E-42DC-8672-220082FC01E1', N'EF241596-B9B4-474A-BA25-AC69015BD28B')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'8E28973D-8E65-41F1-8856-AC79007E1471', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 07:39:02.5650850', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9', N'5DB63E92-2520-4072-A34D-AC7100871CC6')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'C7905B24-6001-4FC0-A41B-AC79007E1471', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 07:39:02.5650450', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9', N'96B8D267-5CC6-489B-8558-AC7100871CC6')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'B8C18118-5221-4AA3-B8E9-AC79007E1471', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 07:39:02.5650890', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC', N'96B8D267-5CC6-489B-8558-AC7100871CC6')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'FF2AF41F-FA8A-4859-BBC7-AC79007E1471', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 07:39:02.5650920', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC', N'5DB63E92-2520-4072-A34D-AC7100871CC6')
GO

INSERT INTO [dbo].[MenuFunction] ([Id], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [MenuId], [FunctionId]) VALUES (N'0710CE97-76C0-4F7B-8BE5-AC79016F08E5', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:16:19.9640190', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC', N'F16DC63B-5958-4FEF-9C74-AC2C0176D440')
GO


-- ----------------------------
-- Table structure for Organizated
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Organizated]') AND type IN ('U'))
	DROP TABLE [dbo].[Organizated]
GO

CREATE TABLE [dbo].[Organizated] (
  [Id] uniqueidentifier  NOT NULL,
  [ParentId] uniqueidentifier DEFAULT ('00000000-0000-0000-0000-000000000000') NULL,
  [Name] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [LadingCadre] uniqueidentifier DEFAULT ('00000000-0000-0000-0000-000000000000') NULL,
  [ParentNumber] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Depth] int DEFAULT ((0)) NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL,
  [Description] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [FirstLeader] uniqueidentifier  NULL,
  [SecondLeader] uniqueidentifier  NULL
)
GO

ALTER TABLE [dbo].[Organizated] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Organizated
-- ----------------------------
INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'77563996-82A4-44AA-99A7-0437FF1C3D7A', N'5F9A19AB-5900-4CE8-8E1B-9E750159616C', N'三组', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'string', N'2', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 17:02:37.7486990', NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'08D88332-BC27-463C-892F-1383AC12A827', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'asdasdasdasdasdasd', N'00000000-0000-0000-0000-000000000000', NULL, N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:35:20.1222190', NULL, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000')
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'50AF9919-FD41-44F6-BCBD-279782808E60', N'24031049-DED0-437F-B208-7C49EB3A360A', N'二组', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'string', N'2', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 17:02:09.3687510', NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'00000000-0000-0000-0000-000000000000', N'集团', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'string', N'0', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 16:58:44.6993520', NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'08D88609-D109-409C-8D35-3C8D07068997', N'00000000-0000-0000-0000-000000000000', N'asdasda', N'08D82B86-ABB8-4276-8159-B7D7508B61A0', NULL, N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 14:19:59.2558700', NULL, N'08D82B86-ABB8-4276-8159-B7D7508B61A0', NULL)
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'08D7DEC0-F25B-40A0-80F6-42EA3FE85CBA', N'5F9A19AB-5900-4CE8-8E1B-9E750159616C', N'五组', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'string', N'2', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 17:07:37.7306920', NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'08D88623-0917-4220-8598-51A295203F06', N'24031049-DED0-437F-B208-7C49EB3A360A', N'asdasdas', N'08D8476B-A962-4E7D-84CC-0344B552AE40', NULL, N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 17:20:18.0529670', NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'08D88645-8E90-4CCB-8593-66EBACD3DBC3', N'FB426E46-D63E-49A5-9B2B-6E5538835C6D', N'23', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', NULL, N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:27:37.5631630', NULL, N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL)
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'FB426E46-D63E-49A5-9B2B-6E5538835C6D', N'5F9A19AB-5900-4CE8-8E1B-9E750159616C', N'四组', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'string', N'2', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 17:02:43.0437240', NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'08D88332-7DEC-42CF-8042-7705023CC2CF', N'24031049-DED0-437F-B208-7C49EB3A360A', N'132asd13asd13 as21d3a ', N'00000000-0000-0000-0000-000000000000', NULL, N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:33:35.7004330', NULL, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000')
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'24031049-DED0-437F-B208-7C49EB3A360A', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'二部', N'08D8476B-A962-4E7D-84CC-0344B552AE40', N'string', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 17:21:24.7749930', N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 17:01:37.0671390', NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'08D88333-1AC2-4E58-8136-865D1E3AD3C1', N'24031049-DED0-437F-B208-7C49EB3A360A', N'大黄瓜开发保龄球部门', N'00000000-0000-0000-0000-000000000000', NULL, N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:37:58.8474440', NULL, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000')
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'08D8832D-2E57-4B6B-868C-94612B9ADFFF', N'24031049-DED0-437F-B208-7C49EB3A360A', N'123486', N'00000000-0000-0000-0000-000000000000', NULL, N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:55:34.7035690', NULL, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000')
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'5F9A19AB-5900-4CE8-8E1B-9E750159616C', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'一部', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'string', N'1', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 17:01:29.0809680', NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Organizated] ([Id], [ParentId], [Name], [LadingCadre], [ParentNumber], [Depth], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [FirstLeader], [SecondLeader]) VALUES (N'32534CF8-10CC-47E3-A324-D2D868E2A0FA', N'24031049-DED0-437F-B208-7C49EB3A360A', N'一组', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'string', N'2', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 17:02:03.8833630', NULL, NULL, NULL)
GO


-- ----------------------------
-- Table structure for PersistedGrant
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[PersistedGrant]') AND type IN ('U'))
	DROP TABLE [dbo].[PersistedGrant]
GO

CREATE TABLE [dbo].[PersistedGrant] (
  [Id] uniqueidentifier  NOT NULL,
  [Key] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Type] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [SubjectId] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [SessionId] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ClientId] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Description] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Expiration] datetime2(7)  NULL,
  [ConsumedTime] datetime2(7)  NULL,
  [Data] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit  NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[PersistedGrant] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of PersistedGrant
-- ----------------------------

-- ----------------------------
-- Table structure for Role
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type IN ('U'))
	DROP TABLE [dbo].[Role]
GO

CREATE TABLE [dbo].[Role] (
  [Id] uniqueidentifier  NOT NULL,
  [Name] nvarchar(10) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [NormalizedName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ConcurrencyStamp] nvarchar(256) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsAdmin] bit  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit DEFAULT (CONVERT([bit],(0))) NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL,
  [Description] nvarchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [Code] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Role] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Role
-- ----------------------------
INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7EFE8-73AD-4FF4-880A-014F8265028F', N'1111111', N'1111111', N'517eccfb-dd4c-4d3c-a486-dc1e169925df', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 13:03:14.8446470', N'111111', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7EFFB-1540-44F9-8D4D-03E2E90CBA99', N'sadaws', N'SADAWS', N'f9218004-8a5b-45e7-88a4-27ddcc1ba51e', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 15:16:36.8578800', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7E43F-C369-4631-8F72-160649A6DC9E', N'4334534345', N'4334534345', N'241a705c-391a-4396-80bd-2229126f1e45', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 16:58:00.8748210', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D879C4-D9C9-4199-8AF1-1D6EC030D568', N'121212', N'121212', N'ffb7d74c-b2d8-43fc-8eeb-c578f9230f2b', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:11:05.4334100', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:36:04.7309740', N'232323', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D879C4-7A63-451D-8D01-233EF0F0D169', N'测试100', N'测试100', N'636b7a6e-433b-4d7b-b475-89af5e917baa', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:33:24.6798190', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83C6E-99EF-48FC-8E1D-26CB57A7BFCC', N'mokai', N'MOKAI', N'f896f748-bbf8-4260-a9b6-79b991b277da', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:14:59.9602300', N'asdasdasddasd ad ', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'asdasds', N'ASDASDS', N'a11eb243-d0d3-47af-9315-20bd89188920', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 16:33:00.1342250', N'asdas', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D84051-CFDB-441D-8481-2D83A8F1A412', N'测试001', N'测试001', N'e6ff85c8-181e-4149-9a24-0c233d85d9eb', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 20:58:59.6704680', N'11', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83C76-2B1E-4794-8B2F-3A2AFF1EDAE2', N'更新', N'更新', N'ef8653b3-cf06-463e-82e6-896bf493d0e7', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:09:10.0147880', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83C6C-D151-41A5-8866-3A3D54D5B31E', N'测试', N'测试', N'2f125e2b-5e64-4b86-8cea-263e824a8d03', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:02:13.8525040', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D809FA-9DD4-4CAC-884A-3C0AEDC16A99', N'大黄瓜', N'大黄瓜', N'39e30d59-2148-488a-a3e4-58de58982636', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 09:18:46.7336280', N'帅气的大黄瓜18CM', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D879C4-4667-491B-8638-3E76A99539CF', N'1212', N'1212', N'28db0709-6d90-42dd-b539-bb6e9fe659ca', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:31:57.4354260', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83C75-F9BE-44FB-8749-4067FD99AA2E', N'测试9090', N'测试9090', N'afa41a23-4f33-4388-b398-dc66d38d352a', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:07:47.1476680', N'12', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D809FA-D07A-4321-89AF-424C8790E811', N'Test112', N'TEST112', N'384c8d5b-e6e2-4ddf-aab8-9a8936f19207', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 09:20:11.7066110', N'1212', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7EFE7-B536-4BD0-8D7E-47E081ABC01F', N'testaa', N'TESTAA', N'c9ee1e4e-1b76-46e7-b1c6-36bbf9ef33b9', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 12:57:55.2956330', N'sadas', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D879C4-CB1C-405A-80DC-524AB719DE98', N'222', N'222', N'1d209c8f-3cde-4bfe-9849-e84d566e2789', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:35:40.1085310', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D87A8F-A202-4101-8E95-5302975CC2EE', N'测试删除1', N'测试删除1', N'5c9f7137-ced3-4edb-8478-138ea9735913', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:48:01.5796880', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:47:38.9574940', N'111', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83C75-7A73-42E2-8D1A-61EE41251508', N'测试0000', N'测试0000', N'5280985b-a87d-469a-8bc5-ad27b718ff68', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:04:13.5915090', N'测试0000', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83C6F-DE31-4B2C-847E-625131CC76BA', N'测试1000', N'测试1000', N'82494cb9-feef-46da-92b9-edb326e7d66b', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:24:03.9471130', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D88001-7F99-4DAC-8283-63EE7048010B', N'系统默认', N'系统默认', N'6b8cfb8c-8fd7-4539-88cf-2116d011f5d7', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:53:19.6998900', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:05:19.6692740', N'默认所有查询权限', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7EFE9-854A-463B-83FF-6BFC203DF30A', N'122', N'122', N'c2f4586d-3727-4a45-8994-426c13413fb7', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 13:10:53.8876390', N'111', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7EFE7-97F8-4262-877D-6F72B76C333B', N'test', N'TEST', N'e076aed8-f60a-4bd8-8c22-d0eb167bd0b6', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 12:57:06.2150110', N'sadas', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D88D5B-C231-4790-862D-7FF71EEA370D', N'Test2000', N'TEST2000', N'd1a7a291-7286-4505-b229-5b8b09ac41dd', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:54:11.2482110', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D80A10-221F-48F3-83EA-81E35CA1CF6B', N'Test1000', N'TEST1000', N'6d1323dd-3d80-4eef-b163-1b3cc6e6700d', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 19:52:48.0932160', N'12', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'大黄瓜', N'大黄瓜', N'bbb1a081-acb2-4f1c-9568-27a8d0093962', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:34:57.1331600', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D84051-84DA-4677-84F5-8CACA636C052', N'测试', N'测试', N'0b5377bd-455f-408d-8b96-4b4a3e66b45c', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 20:56:53.7938960', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7E440-C641-4B91-87D8-9A80BB083415', N'23423', N'23423', N'94b9684b-5a0e-48f4-bf72-24ba18501c21', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 17:05:15.1447290', N'3423', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D884C5-8901-443C-8B07-9B57FA0096CF', N'测试11111', N'测试11111', N'92839048-493c-4a2c-b031-059407bffbd1', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 16:53:09.2667200', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:38:41.4634870', N'jhjk333', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D8404E-6F15-4C8A-87A6-9D9CF5AB487B', N'测试', N'测试', N'3a7611c6-c170-4f48-8011-c0c82f6d72e6', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 20:34:48.8248750', N'1212122', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', N'通用测试', N'通用测试', N'7a791ad6-102b-4cb1-a401-3b1f41adfcf2', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:12:50.4649390', N'asdasd asd asd as', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7F000-CAF0-42D1-8F97-A54365BC436B', N'1211', N'1211', N'0bff92da-9284-4d88-bca1-1c6d20be52c2', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 15:57:29.1393620', N'222', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D8857D-25B9-401A-858B-AC876D914C0A', N'121212ssss', N'121212SSSS', N'0ebfebb2-961d-4833-8fb8-556d5041067a', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:33:22.9100670', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:33:02.2870510', N'1212', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'系统管理员', N'系统管理员', N'08f674c0-2296-42ff-8df1-b9a0d33a8583', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 22:38:12.0573920', N'拥有系统上所有有权限请不要删除!', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D8404D-F83C-4791-8410-BA0D52FE5CEB', N'测试001', N'测试001', N'd33d3289-ee50-4e42-bd13-580969ddd6be', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 20:31:29.3973510', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', N'asdas', N'ASDAS', N'aef1aeda-24f5-40ad-8ce8-d7e9ef93e12f', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 16:53:15.9221600', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7EFE8-6928-442D-8B08-C732918A525D', N'asdas`111', N'ASDAS`111', N'42eae52f-e94b-4e2e-b937-a1a454e8a61d', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 13:02:57.1909560', N'sadas', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7E43F-8187-4124-879D-C80D973CA626', N'2131231', N'2131231', N'0781fef7-d155-444f-87fa-6b6ace9865a9', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 16:56:10.3397600', N'1231231', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D879C4-C502-445F-8340-CA9EDFBD6F49', N'瓜瓜', N'瓜瓜', N'aff6da3c-83e5-4219-81ac-d6ec32dc76ed', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:35:29.8735070', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7E43F-4EF1-4349-8FB0-CF493929D335', N'asdas23232', N'ASDAS23232', N'd68660a2-83d7-4246-81cb-012280aea4f3', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 16:54:45.4711200', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7EFF8-D254-4848-80DA-D4693602966C', N'111', N'111', N'145dfdab-5141-4bcc-90db-b8fd1b4b4f7a', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 15:00:25.5895340', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83C74-37DE-48E2-856D-D613E9D69713', N'测试删除', N'测试删除', N'b16b44db-43cf-407a-b31d-362e27480972', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:55:12.3836780', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83C6D-15A6-441B-8E58-DA9A34209708', N'测试001', N'测试001', N'0e5ef854-0a5f-429f-a163-83e70a25cc0b', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:04:08.5150920', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7EFFA-61C7-4D33-848E-E2C27C49D566', N'333', N'333', N'a2a76b86-c824-46e2-8175-76fc57d62a19', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 15:11:35.7561030', N'333', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D879C4-BF21-4FA8-82B3-E725B79B8FCC', N'测试201', N'测试201', N'2bff5716-283c-40db-9d29-3b2c4caae3e7', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:35:20.0147570', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D883E1-E9EC-4529-8B71-E81D154E4847', N'测试封装', N'测试封装', N'62adf14b-2db3-452c-bb45-6839d4a72a8f', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 20:29:18.8114210', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7EFE9-43F3-4400-8BDE-F67CDE1B9541', N'22', N'22', N'e415d625-66a8-4fa6-9819-913b8a4fba36', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 13:09:04.2646600', N'222', NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D7EFFA-EA96-4E7B-8ABA-F8FC030295CF', N'222222', N'222222', N'6f7fcf47-321a-4e70-9e3a-5e1b894da74c', N'0', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 15:15:25.2833400', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D879C4-B899-4CDE-8A7E-F9E0C929AB9C', N'大帅瓜', N'大帅瓜', N'4b31b0f0-7613-4180-9871-a614f20ca21f', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:35:09.0561640', NULL, NULL)
GO

INSERT INTO [dbo].[Role] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [IsAdmin], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description], [Code]) VALUES (N'08D83C6E-2502-4A77-88A7-FC6C637409A9', N'测试0011', N'测试0011', N'7ccc9b0f-194e-4d10-847f-4e7fe3a99cd4', N'0', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:11:43.7923330', N'12', NULL)
GO


-- ----------------------------
-- Table structure for RoleClaim
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleClaim]') AND type IN ('U'))
	DROP TABLE [dbo].[RoleClaim]
GO

CREATE TABLE [dbo].[RoleClaim] (
  [Id] uniqueidentifier  NOT NULL,
  [RoleId] uniqueidentifier  NOT NULL,
  [ClaimType] nvarchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [ClaimValue] nvarchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit DEFAULT (CONVERT([bit],(0))) NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[RoleClaim] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of RoleClaim
-- ----------------------------

-- ----------------------------
-- Table structure for RoleMenu
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleMenu]') AND type IN ('U'))
	DROP TABLE [dbo].[RoleMenu]
GO

CREATE TABLE [dbo].[RoleMenu] (
  [Id] uniqueidentifier  NOT NULL,
  [RoleId] uniqueidentifier  NOT NULL,
  [MenuId] uniqueidentifier  NOT NULL
)
GO

ALTER TABLE [dbo].[RoleMenu] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of RoleMenu
-- ----------------------------
INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-42DD-8F4F-01173E7E0304', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88BD8-4BC8-4952-8603-1C232987CE0B')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-F9DE-4ACF-8728-02E31AA82F58', N'08D83C75-F9BE-44FB-8749-4067FD99AA2E', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4315-8881-030933DD69E9', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88BD9-8BB4-45AE-83A3-79C4C7949A22')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-46A3-8B33-050FFE03C628', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BDA-448C-42E7-8F54-2CF879CD1AD5')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-466B-88D9-089C8A2B4F78', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-42CF-8071-0A356E8B5AC1', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D8896E-5FB8-447E-86CE-D3E1548F65F0')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88DF6-4728-4FC4-83E4-0A4F651026C7', N'08D879C4-B899-4CDE-8A7E-F9E0C929AB9C', N'08D84378-A754-4829-8AB2-83D25AB2A125')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D82739-D0C3-4416-8280-0A68E334C2A4', N'08D7F000-CAF0-42D1-8F97-A54365BC436B', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-476D-8C70-0ED9054C6003', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88597-A9D2-467D-84CF-73ED0F9C04D3')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4233-810A-0F4C16FBB9FA', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88973-4EBE-43B6-83FD-D1343E3C3DB3')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-42B4-83C1-0F946F1B9626', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D87FFE-C251-4779-8054-15C04038A8F1')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-424E-8FF5-11817FBAE63A', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88973-A35E-4936-84CF-7D8A715F12D2')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404E-8455-4A3D-853C-12E6F8821E71', N'08D8404E-6F15-4C8A-87A6-9D9CF5AB487B', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4926-88EC-14794C8FD816', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88645-31BD-42E5-8211-753786AAF90B')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404D-FAD0-4985-81E7-16B961954139', N'08D8404D-F83C-4791-8410-BA0D52FE5CEB', N'08D812BB-E756-4C73-8106-3B70A641385A')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-45E0-8176-16C94ED0B4EA', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88596-CB6B-43E1-84FB-B5A0A194E545')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-41AC-818D-172CC95D8FFE', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D84375-234A-48C6-83E8-36B6134F4439')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88D5B-CDF8-48FC-88D6-1A50584CF9EA', N'08D88D5B-C231-4790-862D-7FF71EEA370D', N'FD8A36D4-D6D8-A6BB-2924-77455100A305')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-F9DE-4B3C-8192-1A6B6572990B', N'08D83C75-F9BE-44FB-8749-4067FD99AA2E', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-48CB-8D40-1C71892B46FC', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BD9-8BB4-45AE-83A3-79C4C7949A22')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4878-8CB8-2141F64C4A3E', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D86484-8C20-4AA8-8A80-1ECB288BEABC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C7A-A513-47C7-8C06-22DC0B289F74', N'08D83C76-2B1E-4794-8B2F-3A2AFF1EDAE2', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-48D8-88AA-22E67FDE3B62', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BD9-AC4F-4261-8FD2-743DB9AF6739')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4807-817F-243DFF0AAC48', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D84450-4C1F-4F06-8652-AB6A2C1C888F')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-7A81-4393-8961-24CCF784C547', N'08D83C75-7A73-42E2-8D1A-61EE41251508', N'08D815D9-93F2-4F7C-8FCE-8FA321933EB3')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-423A-8BED-256B26CC7009', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88973-93B1-4093-889D-97BEDABC2233')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-41FC-829D-25F614E55944', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D84450-78CF-499B-897C-56A4304F139F')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-46B9-820B-2761D0787362', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D8444F-875E-4A45-861D-F12DBB72C463')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4935-87C7-27E9AE7E5F0B', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D87FFE-50DB-4B11-8FFA-55602E216862')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404D-FAD1-44B5-8F03-292CC4384E48', N'08D8404D-F83C-4791-8410-BA0D52FE5CEB', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-42D6-89AE-2A8953C66031', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88BD8-177C-40FE-82B6-E4E6484F7C95')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-41E1-8F0D-2BC49B0C820F', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D8444F-875E-4A45-861D-F12DBB72C463')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4694-861D-2BD8620463B6', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BD8-A84F-434E-8E97-255BAB78CCF2')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6E-26B5-4372-8FE6-2C5E57B55DC0', N'08D83C6E-2502-4A77-88A7-FC6C637409A9', N'08D812BB-E756-4C73-8106-3B70A641385A')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-45FD-8A21-2D504E19C6B0', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88598-B792-4BBA-850E-0A15A2644A1C')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-45AE-8510-2E3DAE70F03A', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D84051-8908-4169-83F6-2E5CFB0C9496', N'08D84051-84DA-4677-84F5-8CACA636C052', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6E-26B5-4488-8C1F-2F30466543B0', N'08D83C6E-2502-4A77-88A7-FC6C637409A9', N'08D815D9-93F2-4F7C-8FCE-8FA321933EB3')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8273A-79C8-4BB7-8C5E-35BC9FEE228D', N'08D80A10-221F-48F3-83EA-81E35CA1CF6B', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C74-3801-47AB-8751-35FEAC1875A4', N'08D83C74-37DE-48E2-856D-D613E9D69713', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88DF6-4726-489C-8FB7-369FD2BB4B22', N'08D879C4-B899-4CDE-8A7E-F9E0C929AB9C', N'08D84375-234A-48C6-83E8-36B6134F4439')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-41F3-8BEC-382C7EB99A17', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D84450-4C1F-4F06-8652-AB6A2C1C888F')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6F-DE68-47CB-82FE-38356A58B6A1', N'08D83C6F-DE31-4B2C-847E-625131CC76BA', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-41C8-85B9-391F7ECE61E9', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D8437D-752A-4633-8AD9-F1E44F005B8D')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D84051-8908-41A9-8F45-39C24DC05267', N'08D84051-84DA-4677-84F5-8CACA636C052', N'08D815D9-93F2-4F7C-8FCE-8FA321933EB3')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4260-8EA5-3A2705B125B7', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88597-EB63-428C-8422-9480FC807C31')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6F-DE68-4795-8C1F-3C608436892A', N'08D83C6F-DE31-4B2C-847E-625131CC76BA', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4326-8B25-3CDB5F94FA60', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88BD9-BB50-4E9C-8669-3393ABE8D475')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4621-82C6-3E595782849F', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88973-3848-4139-8979-50BA65AA6985')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404E-8455-479D-8871-3F8B2CF3CF4B', N'08D8404E-6F15-4C8A-87A6-9D9CF5AB487B', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404D-FAD1-449E-8CE4-4132B85C3007', N'08D8404D-F83C-4791-8410-BA0D52FE5CEB', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-413C-8630-455414D608DA', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4685-86B6-460ADA4426B0', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BD8-87B6-4737-8F8B-2778C807FE43')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D84051-8908-4208-8DE8-473DEEE3EEB2', N'08D84051-84DA-4677-84F5-8CACA636C052', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6F-DE68-4756-8F3C-48CC8FAC93B4', N'08D83C6F-DE31-4B2C-847E-625131CC76BA', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6D-53EC-4CC1-8FE5-4F25DB3C23E8', N'08D83C6D-15A6-441B-8E58-DA9A34209708', N'08D812BB-E756-4C73-8106-3B70A641385A')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404D-FAD1-4463-8759-51CF8B5FB059', N'08D8404D-F83C-4791-8410-BA0D52FE5CEB', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6D-53EE-437C-8FBB-5309C26260F9', N'08D83C6D-15A6-441B-8E58-DA9A34209708', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-474D-85B5-53E349E43823', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D84379-988D-4FF9-8F47-DB14075ADDC2')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D84051-8907-45BD-8E22-5543B0236404', N'08D84051-84DA-4677-84F5-8CACA636C052', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C7A-A513-48AE-8993-5581AEDE09ED', N'08D83C76-2B1E-4794-8B2F-3A2AFF1EDAE2', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F05-4513-8ED0-5606424A0E64', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4912-8693-571D8EA382B6', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BDA-B12E-4AD2-8C19-1BA86E696050')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-420E-83CE-5741B4C1D407', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88596-CB6B-43E1-84FB-B5A0A194E545')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4206-8587-5884B412647B', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'FD8A36D4-D6D8-A6BB-2924-77455100A305')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88DF6-4728-4FD5-8714-58ABC77F141E', N'08D879C4-B899-4CDE-8A7E-F9E0C929AB9C', N'08D8437D-752A-4633-8AD9-F1E44F005B8D')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-48BE-8CF4-5CC063C1A582', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BD9-66E3-4001-8B57-BD83187C2BFC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C74-3801-47F8-87DF-626C596B0B84', N'08D83C74-37DE-48E2-856D-D613E9D69713', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-431F-84CD-65D2B5406AE6', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88BD9-AC4F-4261-8FD2-743DB9AF6739')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-4677-8D4F-6856D70A5F6A', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D84375-234A-48C6-83E8-36B6134F4439')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-7A81-4388-8B82-689333C4F01E', N'08D83C75-7A73-42E2-8D1A-61EE41251508', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-7A81-4352-8344-68EE5EFEAE2B', N'08D83C75-7A73-42E2-8D1A-61EE41251508', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-46E6-83EA-6A060773D67A', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88C91-A02E-42DC-8672-220082FC01E1')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-46AD-87D5-6BD2DF6D91AE', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-42E8-8BFF-6CD6448F2B11', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88BD8-87B6-4737-8F8B-2778C807FE43')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D850E1-C198-4625-821A-6DEDB8F951D3', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-46C6-852C-707637B77E7E', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D84450-4C1F-4F06-8652-AB6A2C1C888F')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6D-53EE-42CF-8C60-70AD8426ED07', N'08D83C6D-15A6-441B-8E58-DA9A34209708', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6D-53EE-436A-8CE4-71E927E3D086', N'08D83C6D-15A6-441B-8E58-DA9A34209708', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D847D1-7A66-4B9F-89EA-7256D0A5D1CD', N'08D84051-CFDB-441D-8481-2D83A8F1A412', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-42FD-819E-72607985C38C', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88BD7-2037-4B83-8204-31E2CF867FC3')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D84051-8908-419A-8CC5-73DEE23CC73B', N'08D84051-84DA-4677-84F5-8CACA636C052', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF07-419D-827F-766309ACA7D5', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'FD8A36D4-D6D8-A6BB-2924-77455100A305')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-479E-8832-768D05AE4871', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88597-EB63-428C-8422-9480FC807C31')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-41A3-8446-77252976F1F8', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404E-8453-4ED3-85C7-7A1A01C3EA04', N'08D8404E-6F15-4C8A-87A6-9D9CF5AB487B', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6F-DE68-47D6-8D66-7A54015C331C', N'08D83C6F-DE31-4B2C-847E-625131CC76BA', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-47E2-8E71-7B117791B6C8', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D850E1-C198-468F-8CA9-7B11C2C6606E', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4946-84A8-7BE6FDADCA4E', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88598-4B78-42F3-86E2-A6602135964B')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4242-826C-7C3204C1555B', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88973-9A33-4A25-8252-E8BFF2507CFB')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-7A81-431B-8593-7D10E1CFEA21', N'08D83C75-7A73-42E2-8D1A-61EE41251508', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4953-889C-7E17BC6FED73', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D87FFE-C251-4779-8054-15C04038A8F1')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-46DB-8F01-7E598BA3E965', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D86484-8C20-4AA8-8A80-1ECB288BEABC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404D-FAD1-44AB-8453-7EB2AB179688', N'08D8404D-F83C-4791-8410-BA0D52FE5CEB', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404E-8453-4F6C-8A21-80F628F3BDB0', N'08D8404E-6F15-4C8A-87A6-9D9CF5AB487B', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6E-99F3-47F9-8F21-83762DCE8508', N'08D83C6E-99EF-48FC-8E1D-26CB57A7BFCC', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6E-26B5-4458-8D35-8491C14070EB', N'08D83C6E-2502-4A77-88A7-FC6C637409A9', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4828-86A8-87603842F1B9', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D84450-78CF-499B-897C-56A4304F139F')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4293-8FFA-87C83B2019B9', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D86484-8C20-4AA8-8A80-1ECB288BEABC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6E-26B5-43FE-83E4-88A42EFAF790', N'08D83C6E-2502-4A77-88A7-FC6C637409A9', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C7A-A513-48A2-892E-8B4C27693C7A', N'08D83C76-2B1E-4794-8B2F-3A2AFF1EDAE2', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D847D1-7A66-4BA8-84FC-8B4F10063C63', N'08D84051-CFDB-441D-8481-2D83A8F1A412', N'08D84375-234A-48C6-83E8-36B6134F4439')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-45D2-89FD-8D142F01109F', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6F-DE68-47A4-8300-8F3505C90F87', N'08D83C6F-DE31-4B2C-847E-625131CC76BA', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-F9DE-4BD4-8C1C-90926C1A4896', N'08D83C75-F9BE-44FB-8749-4067FD99AA2E', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D84051-8908-4215-8B44-909D4B8DB14E', N'08D84051-84DA-4677-84F5-8CACA636C052', N'08D812BB-E756-4C73-8106-3B70A641385A')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404D-FAD1-44C1-8656-91BF10DD6890', N'08D8404D-F83C-4791-8410-BA0D52FE5CEB', N'08D815D9-93F2-4F7C-8FCE-8FA321933EB3')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D850E1-C198-4572-84C9-926F31F37D7E', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', N'FD8A36D4-D6D8-A6BB-2924-77455100A305')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-429B-8FCF-94994C3B2B54', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D87FFE-50DB-4B11-8FFA-55602E216862')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4268-8CCB-962623694134', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88594-14AE-4DE2-8E55-DFDF1E41E40D')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-47BB-8B51-97447DE7858C', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BD7-2037-4B83-8204-31E2CF867FC3')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-F9DE-4BF1-8A60-97867D8AF1B3', N'08D83C75-F9BE-44FB-8749-4067FD99AA2E', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D847D1-7A66-4B35-8523-98342EC632F0', N'08D84051-CFDB-441D-8481-2D83A8F1A412', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C74-3801-4797-80E9-9BF0A6539D8F', N'08D83C74-37DE-48E2-856D-D613E9D69713', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-42BC-86BC-9E12D1BE39F5', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88598-7120-46AB-85B4-A7F40AF04D3A')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-48F8-8C7E-9F477B68AF44', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BD9-CDFC-48A6-8958-BEF859429E8E')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-48AF-8413-9FA45BFDC82A', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BD9-5550-4DB7-8EE9-0FC027E5B289')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-462F-8521-A059F929A858', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D847D1-7A66-4B8F-8452-A0F71E00B4C7', N'08D84051-CFDB-441D-8481-2D83A8F1A412', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8273A-79C8-4B79-8C4C-A23A6606C74B', N'08D80A10-221F-48F3-83EA-81E35CA1CF6B', N'08D815D8-AC6D-4DF5-8113-ECB81EE27DF2')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D82739-D0C3-4457-829C-A4B10F66C50E', N'08D7F000-CAF0-42D1-8F97-A54365BC436B', N'08D815D8-AC6D-4DF5-8113-ECB81EE27DF2')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-F9DE-4C07-8E83-A60B76E910F3', N'08D83C75-F9BE-44FB-8749-4067FD99AA2E', N'08D815D9-93F2-4F7C-8FCE-8FA321933EB3')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6E-26B5-446C-87DC-A64ACDE8F83A', N'08D83C6E-2502-4A77-88A7-FC6C637409A9', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D82739-D0C2-44D3-8B0C-A69F151592EF', N'08D7F000-CAF0-42D1-8F97-A54365BC436B', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4289-8CD4-A99A63A00CBB', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88645-31BD-42E5-8211-753786AAF90B')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4256-89C2-A9B479AACB7C', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88597-A9D2-467D-84CF-73ED0F9C04D3')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-432D-8FE8-AAA8E3B09C10', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88BD9-CDFC-48A6-8958-BEF859429E8E')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-463F-8148-AACBCB310C6D', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88973-93B1-4093-889D-97BEDABC2233')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C74-3801-473A-8D55-AB183CDF3E0D', N'08D83C74-37DE-48E2-856D-D613E9D69713', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-41DA-850B-AC659F170971', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404D-FAD1-442E-88C5-ACD17F047DC1', N'08D8404D-F83C-4791-8410-BA0D52FE5CEB', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6F-DE67-4834-8017-AD9BFA48A478', N'08D83C6F-DE31-4B2C-847E-625131CC76BA', N'08D812BB-E756-4C73-8106-3B70A641385A')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404E-8453-4D38-852A-AE1BC5A06A04', N'08D8404E-6F15-4C8A-87A6-9D9CF5AB487B', N'08D812BB-E756-4C73-8106-3B70A641385A')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D850E1-C198-4655-8170-AF4C7863D8CA', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4678-851E-AF5C4E15916F', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BD8-4BC8-4952-8603-1C232987CE0B')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D850E1-C196-42E4-8B84-AFB031F7BE12', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-44E2-8786-B0B23A6E2C63', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D84051-8908-41EC-8391-B0BF058138F0', N'08D84051-84DA-4677-84F5-8CACA636C052', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4178-811B-B1F10679FEC4', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6D-53EE-43AB-8B19-B262622B3F07', N'08D83C6D-15A6-441B-8E58-DA9A34209708', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C74-3801-47E8-8C90-B30520D60CB4', N'08D83C74-37DE-48E2-856D-D613E9D69713', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4631-835A-B32AE97082EB', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88973-4EBE-43B6-83FD-D1343E3C3DB3')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-42A7-880E-B850EB0C2F68', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88598-4B78-42F3-86E2-A6602135964B')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D84051-8908-41DC-87BD-B91E9602987C', N'08D84051-84DA-4677-84F5-8CACA636C052', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-F9DE-4B64-8F1C-BB2AAAD9A844', N'08D83C75-F9BE-44FB-8749-4067FD99AA2E', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4306-8C90-BCF64195AB26', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88BD9-5550-4DB7-8EE9-0FC027E5B289')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4905-8CA4-BE17C13F9933', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BDA-A94D-40E5-82AE-DD6F5F728265')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4228-8AEB-BF1B0220F36E', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88973-3848-4139-8979-50BA65AA6985')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-430E-842A-BF82D85C3294', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88BD9-66E3-4001-8B57-BD83187C2BFC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-47FA-804C-C2C49BC1B72C', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D8444F-875E-4A45-861D-F12DBB72C463')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-7A81-437C-8ACF-C373E177D2E7', N'08D83C75-7A73-42E2-8D1A-61EE41251508', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404D-FAD1-4472-8963-C7F64EF2936C', N'08D8404D-F83C-4791-8410-BA0D52FE5CEB', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404E-8455-4898-8669-CA06E3E1EAC0', N'08D8404E-6F15-4C8A-87A6-9D9CF5AB487B', N'08D83D35-9456-4C13-8004-FF7F8E3FE2E9')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-4690-84C5-CB15A25E262B', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-460F-8B6A-CB756B19A208', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4220-809D-CECD1545D786', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88598-B792-4BBA-850E-0A15A2644A1C')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-48A2-89F1-CED7FC3ACD5B', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88598-8230-4D89-892B-E8D34EA95E9A')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-7A81-4344-821F-CF606D1D1A6A', N'08D83C75-7A73-42E2-8D1A-61EE41251508', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8404E-8455-4976-813A-CF89006CC717', N'08D8404E-6F15-4C8A-87A6-9D9CF5AB487B', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6E-26B5-4439-83CF-D1B134ED87E0', N'08D83C6E-2502-4A77-88A7-FC6C637409A9', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88DF6-4728-4F56-84F6-D2173DF75E12', N'08D879C4-B899-4CDE-8A7E-F9E0C929AB9C', N'08D84376-ACC6-4924-8116-9D7AF9EA87CE')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6E-99F3-4EC5-8F4B-D4E00DBB1DF7', N'08D83C6E-99EF-48FC-8E1D-26CB57A7BFCC', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-F9DD-4E0C-8CC6-D6672982121D', N'08D83C75-F9BE-44FB-8749-4067FD99AA2E', N'08D812BB-E756-4C73-8106-3B70A641385A')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4594-8B11-D74A50D2D78D', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D81DD2-DC25-4FFA-8518-4B28558BA714')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6D-53EE-43B7-8344-D849464781AA', N'08D83C6D-15A6-441B-8E58-DA9A34209708', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-45F0-834F-D902319B9AD2', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88597-6B34-4F44-8261-DCFA2736E8FE')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4861-8991-D90B2CC32FE8', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88595-506F-4B2B-8583-FE22DDDB3FED')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-42F5-8A2B-DAD9276C53D6', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88BD8-A84F-434E-8E97-255BAB78CCF2')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6E-26B5-43E4-8D0C-DBABE1388A0B', N'08D83C6E-2502-4A77-88A7-FC6C637409A9', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-41D2-8A6E-DD55E5B6C91C', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D84379-988D-4FF9-8F47-DB14075ADDC2')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4270-868E-DEB7EDD8634A', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88595-506F-4B2B-8583-FE22DDDB3FED')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-472B-8BFD-DF251A9EBE32', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D815D8-F67C-4299-8D3A-C3243FCB5BC7')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-484B-8288-DF53A76629BA', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88594-14AE-4DE2-8E55-DFDF1E41E40D')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4282-84C0-DF930227545F', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88598-8230-4D89-892B-E8D34EA95E9A')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C74-3800-4D6C-8A48-E129313E1CB2', N'08D83C74-37DE-48E2-856D-D613E9D69713', N'08D812BB-E756-4C73-8106-3B70A641385A')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4886-85BA-E47A645210D2', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88598-3180-446C-8A9F-79AF05025956')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-41C0-804B-E5B57BE6180B', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D84378-A754-4829-8AB2-83D25AB2A125')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-465B-8DBB-E653924E3507', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88973-A35E-4936-84CF-7D8A715F12D2')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-463E-83D1-E74564DB83CC', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C6E-99F3-4ED2-889E-EB03CD1E5904', N'08D83C6E-99EF-48FC-8E1D-26CB57A7BFCC', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88D5B-CDF9-48E3-8FBE-EB96AD778E51', N'08D88D5B-C231-4790-862D-7FF71EEA370D', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-4215-8CC0-EC2EFA712DFE', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88597-6B34-4F44-8261-DCFA2736E8FE')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-4685-8261-EC81B79B2494', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D84376-ACC6-4924-8116-9D7AF9EA87CE')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C7A-A513-4864-87B5-EED96A67CCBE', N'08D83C76-2B1E-4794-8B2F-3A2AFF1EDAE2', N'08D83C69-A522-4175-8E0C-5EFC57FD6456')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8273A-79C8-4B36-8DC4-F0C6371E812B', N'08D80A10-221F-48F3-83EA-81E35CA1CF6B', N'08D815D8-868F-45CC-8FDF-0DFF5ACAC7FC')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-41B7-8EE1-F2B0B8D284DE', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D84376-ACC6-4924-8116-9D7AF9EA87CE')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-469F-89B6-F3CF3EA05AB1', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D84379-988D-4FF9-8F47-DB14075ADDC2')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F99-4DF7-8B7E-F40740EC879A', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'FD8A36D4-D6D8-A6BB-2924-77455100A305')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-416D-8FF6-F471C3987FEC', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D87E4F-8F9C-46D1-87FE-F47D5CA6A78F', N'08D879C4-B17E-48C7-8457-83A57A10EEDB', N'08D84450-78CF-499B-897C-56A4304F139F')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D88BDA-1F06-427A-8A4C-F85D03D691C7', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', N'08D88598-3180-446C-8A9F-79AF05025956')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-48E9-8358-F89953EC40C4', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BD9-BB50-4E9C-8669-3393ABE8D475')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D83C75-7A80-499A-8EDA-F89ACB423EB0', N'08D83C75-7A73-42E2-8D1A-61EE41251508', N'08D812BB-E756-4C73-8106-3B70A641385A')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-464C-81D5-F94BA490DA05', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88973-9A33-4A25-8252-E8BFF2507CFB')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4668-8D4C-FBB582451D45', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88BD8-177C-40FE-82B6-E4E6484F7C95')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4893-8297-FC0F910AA40E', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88C90-8D28-42EC-8F52-C0838B9EA12F')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D8273A-79C8-4B9A-8196-FC9040CCB163', N'08D80A10-221F-48F3-83EA-81E35CA1CF6B', N'08D815D8-DAE5-4891-83D3-38A134D63506')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4971-82DC-FCB4C988DE55', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D8896E-5FB8-447E-86CE-D3E1548F65F0')
GO

INSERT INTO [dbo].[RoleMenu] ([Id], [RoleId], [MenuId]) VALUES (N'08D89D0E-AF0E-4960-8357-FE3CAA782A15', N'08D88001-7F99-4DAC-8283-63EE7048010B', N'08D88598-7120-46AB-85B4-A7F40AF04D3A')
GO


-- ----------------------------
-- Table structure for User
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type IN ('U'))
	DROP TABLE [dbo].[User]
GO

CREATE TABLE [dbo].[User] (
  [Id] uniqueidentifier  NOT NULL,
  [UserName] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [NormalizedUserName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [NickName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Email] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [NormalizeEmail] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [EmailConfirmed] bit  NOT NULL,
  [PasswordHash] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [HeadImg] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [SecurityStamp] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [ConcurrencyStamp] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [PhoneNumber] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [PhoneNumberConfirmed] bit  NOT NULL,
  [TwoFactorEnabled] bit  NOT NULL,
  [LockoutEnd] datetimeoffset(7)  NULL,
  [LockoutEnabled] bit DEFAULT (CONVERT([bit],(0))) NOT NULL,
  [AccessFailedCount] int DEFAULT ((0)) NOT NULL,
  [IsSystem] bit  NOT NULL,
  [Sex] int  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit DEFAULT (CONVERT([bit],(0))) NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL,
  [Description] nvarchar(500) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[User] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of User
-- ----------------------------
INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D8476B-A962-4E7D-84CC-0344B552AE40', N'Test001', N'TEST001', N'1212', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAEKBZYO2xoCSVSSKmQyEgPmuV8mVMQt/yLnqaAdcqPiiZ3XBkKMj7sY9wL8bn/Yd8Jw==', NULL, N'B645HJXOQYBCTN37BAXO2GVUT6NVHUXU', N'1e4ff377-54f0-489e-bf46-fb483aba0354', NULL, N'0', N'0', NULL, N'1', N'2', N'1', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-12-13 01:12:44.8349124', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:51:40.1552560', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D888CB-8DE4-43EB-840F-0F13D0A8874B', N'FSDFSF', N'FSDFSF', N'sdfsfsf', NULL, NULL, N'0', NULL, NULL, N'TE6GL5CNESVFUEPHTOHRC57I4BHC5H5C', N'33d12389-e5b7-40dd-9193-181c2e1a83b5', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 02:31:51.2895920', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D88DE7-CA60-4916-8ED4-0F9B08543569', N'1111', N'1111', N'111111', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAEIPN+qrZAtVkv+ZVDsELkErsAC4pac8T7cCjLyHbrxezVs9gkVJ6lj91L5lln42XxQ==', NULL, N'5PVZ6HO6NVOHMICFPHH4RZUIQREHDUIR', N'5a0934e6-ced1-4d40-85db-a9bfc548e680', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 14:48:25.9340800', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 14:36:34.4913150', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D874CD-7D18-4427-83A7-135C5CAE2941', N'ASS122', N'ASS122', N'ASS122', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAEIqvYsQ++aC9+hnk2ZvMerHaw33K7ijjkkTIV3ShXh7Ve7SxwpFv9zwFsdq6J6WE1g==', NULL, N'4LXXYGKXVR7PEBZY4LGSBBKMWGJPOCVT', N'958f9f10-69a9-469f-b7e9-da468ed8a345', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 13:54:22.4287160', N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 15:55:18.8482980', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'string748687789', N'STRING748687789', N'string45455445544554', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAEMS6tmv/L4i6uiXQfIKTLP3Q6IkA6nxWW1LsRfBR9YLWP0Ul6U1nwE1OpwQbmXhsmw==', NULL, N'JQMDXWWAM6ORVVK6X6ECCOV7OSYGDSIA', N'd4a6b747-99a3-4a1b-8863-c6fa380d337a', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 14:58:31.8760720', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 20:36:12.8500510', N'string')
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D88933-BEFC-4A48-845A-4133A61C8214', N'TestAuit111', N'TESTAUIT111', N'asfa', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAEO4cPsCSwOyY1SPaD7kB6R3/6ImTkbAolC7uyNiG/M3FpI9UF1wWglWLMbQ4OLWWMw==', NULL, N'5BJV5XYNN5NCLH5ZTTRNTJU2W36XCYM5', N'fa863095-e832-4ace-8f45-2832ab55d1c0', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 16:52:57.1050310', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 14:57:41.3200050', N'1')
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D888C3-0B2C-4C87-8329-64B4506EC2F2', N'test000012222211', N'TEST000012222211', N'测试12111', NULL, NULL, N'0', NULL, NULL, N'5J4GHJ4HES5SPNKNWAQNBTFR5LANIHVG', N'45fa5f39-5dfa-49c9-9df1-e5dc6c019e42', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 01:30:50.8982930', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D888BE-ADC9-4887-8001-661CA4F45AA6', N'test00001', N'TEST00001', N'测试', NULL, NULL, N'0', NULL, NULL, N'5IW34S77HLWVUBZTHYDMWP2732KDN2MR', N'8639d8b2-a0ba-4fec-a7a1-4ae59757562a', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:59:41.3447160', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D888BF-3D6F-4A61-8FAD-6786021119E3', N'test000011', N'TEST000011', N'测试1', NULL, NULL, N'0', NULL, NULL, N'AO7GULXE5ZV3NWRL4LVL56FDM27BSUPL', N'e2559a87-1ac9-42f6-9b4e-24982f07b3ba', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 01:03:42.3772390', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D888C0-D502-4A27-8510-68E61C637DC7', N'test0000122', N'TEST0000122', N'测试12', NULL, NULL, N'0', NULL, NULL, N'4PXOB5KADVEC2DMFHLTANNKEJYWZXVLO', N'209fc125-7c2a-40f4-88da-f201bb98aad9', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 01:15:06.1408660', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D8819D-C546-44DE-80C5-7FB55FD06A82', N'wzwzwzwzw', N'WZWZWZWZW', N'wzwzwzwzw', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAELHgDpf826D9z0+2yuVOof7DffM+DAg5XMCK79mJKCXVyjr7Wket3hSvQ6hETkKy4w==', NULL, N'WSMR4ATZVNEXS7QGDVWJJ2HSYW2M4FX7', N'874e5268-2788-443b-9634-22474c086548', NULL, N'0', N'0', NULL, N'1', N'0', N'1', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 23:16:29.2103220', N'string')
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D888C2-685F-4288-8844-8458298D8914', N'test0000122222', N'TEST0000122222', N'测试1211', NULL, NULL, N'0', NULL, NULL, N'FI4TKE4EUOAWYD4MKPRHOGGP5KQTRVL4', N'7d4f9f50-620e-4357-b6fc-67b77ff9a872', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 01:26:19.7988780', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D88DE9-8C72-45ED-889F-8B978E8AACAC', N'DHGTEST', N'DHGTEST', N'DHGTEST', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAEAjE+oF7Q1IdRanlVuiqNjG7pxuJsMq9CPpozOfbUNAW2w2bU+vvv0Do/CcyM8443Q==', NULL, N'GYTYLX3KF5UM5I7TJKZZ27NI2KOOIASS', N'2f4b9fa9-a778-446b-a871-651a3e9fc8ba', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 14:54:19.3016060', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 14:49:09.5909550', N'大黄瓜测试专用')
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D8915C-4688-4235-8834-9B828AC7B445', N'Test100000', N'TEST100000', N'测试100000', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAEILGIj6z/swMzCwuePRSlf9Ou7QHqgwIU0X6i4g8TJLfJjU/DBNrEZ+AEwujRsp8wQ==', NULL, N'IAPE7ZTIZ4FZMJH3VWXHNZL7IVU2MEF7', N'44f0c1c9-5113-4602-97ee-5d2cf506f179', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:07:57.8908380', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D89926-0367-4ABE-8DAC-B5CC881F0CC5', N'Test8888', N'TEST8888', N'Test8888', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAEJQMNngsGWOH63MHY5vhnYsZAjGQbn/hvsghjQmUfimsnt4QSo35BOdMtRi48HZR5A==', NULL, N'5AL2GK6Z5OFLNWVNKCS2E6KORV7WVJME', N'a4251836-9e3a-46fe-ac30-c50c2eae69be', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-02 21:59:41.7455830', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D82B86-ABB8-4276-8159-B7D7508B61A0', N'Test002', N'TEST002', N'Test002', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAEKb9X4psRNVe1Nka28ta/JITPAxwMePVyt9H1WUCRLzzf+bZEllY8kG57NyF0SgrOQ==', NULL, N'KBZ6UMAFLYDFX5DYYT64C5TAY7YX35KU', N'dbbb56fc-b3ba-4e41-b235-f40c4e8c0676', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-02 23:04:22.7197810', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 09:54:27.9211170', N'asdsadsadsaasdsadasdasdasdasdas da sa dasd asd as dasda sd a')
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D88A2C-D58D-4502-8115-C1B9AC1BB76F', N'Test1000', N'TEST1000', N'Test1000', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAEGolnkmZ1/zGPu+Kby688VKEsr6jglPF25EGTyjm99XlXbk1Dig2DNEN+FKxjvwHsA==', NULL, N'CSQWTU33BUKDTFYWLTJLXKHWBA2BBGX5', N'b8abb8a3-0813-4724-b1f8-518fd5fde535', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 00:40:22.8411410', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 20:40:43.8628040', N'测试专用')
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D888CD-E0A1-40A2-81CC-C28D9597F29A', N'1212', N'1212', N'dssdfsdfsf', NULL, NULL, N'0', NULL, NULL, N'2FHAQCJB7LP6DK2YEKTYQBGXC5JZMBOJ', N'0dd1875e-c59d-47ff-8f00-bad5587f21c1', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 02:48:29.0932830', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D888CE-C53D-49C5-84AE-C424AFA6DD01', N'222232323', N'222232323', N'222222222222222', NULL, NULL, N'0', NULL, NULL, N'QXGLS7VDUK6A7DC4Y465M2QMYBJHXDKF', N'749e8202-cb57-4d9c-b285-7482113930ee', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 02:54:52.6708680', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D879B9-3BCF-459B-8F66-D68102FA8E2A', N'admindd_12', N'ADMINDD_12', N'12', NULL, NULL, N'0', NULL, NULL, N'6YY7EMPZQM2S6DWNXY6RVJFL3VX32HQG', N'a39dbe92-3663-4a3d-bfde-ead944d17339', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 22:12:55.1983020', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D88D56-9598-42C4-84DF-D9B341F2AD76', N'TEST003', N'TEST003', N'TEST003', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAECA5uZ0iQWg4S+sJPDhDh2wzpMdH52Kl+427OVPxlfyOEPfRwTyaj8a0RrkYaCjyHQ==', NULL, N'2FXY3D3W57GT2ROOEONOCDDSLNMX4EI7', N'c99b4949-9ba4-4eba-9688-49ff6cb9c825', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:17:08.9244260', N'132456')
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D888CD-2F45-43C3-81E4-DABBC79BC8DC', N'zzzzz', N'ZZZZZ', N'sdfszzzzfsf', NULL, NULL, N'0', NULL, NULL, N'IHECUJDFENZ2NVZW7KQLEKVOJXITWT76', N'01065dde-35c0-4a98-8d98-7060ab360f1c', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 02:43:31.5657760', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D89211-7FF6-4AFF-8B74-DBBC82BF6D9D', N'Test20000', N'TEST20000', N'Test20000', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAECmE8gxgAglYg9Ncxc4VjV2KmS48MbMbMR+v17ED4iU45GWzopOjVqN8u7r2CcCpgw==', NULL, N'5SP5GWW23HSQSXDF6MLK2E5TDSIQYBS6', N'301fbec6-402a-4803-9393-d9027f5e3d8d', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:45:23.1366050', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:45:13.1529010', NULL)
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'Admin', N'ADMIN', N'管理员', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAEEPWhHPCHU1i6Z0ayoApKGbPlZUb38RUdJg4QjUcccVhUSto0sRZtLOXfwWUJ+P2Xw==', NULL, N'3OWMGQAK5ZTXMSV6OFSGIWWWNIWJ2SX6', N'0286cab6-8a4a-44ed-9a97-86b0506c65c3', NULL, N'0', N'0', N'2020-01-01 08:53:58.9311790', N'0', N'0', N'1', N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-02 23:03:06.3298370', N'0', NULL, N'2020-01-06 22:38:12.0950390', N'系统管理员拥有所有权限')
GO

INSERT INTO [dbo].[User] ([Id], [UserName], [NormalizedUserName], [NickName], [Email], [NormalizeEmail], [EmailConfirmed], [PasswordHash], [HeadImg], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsSystem], [Sex], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime], [Description]) VALUES (N'08D88D5B-B5EC-4A96-8CF1-E0EDAEE1423A', N'Test2000', N'TEST2000', N'Test2000', NULL, NULL, N'0', N'AQAAAAEAACcQAAAAEBF/HlmbR9F4fQ7RSpQ42zSKUBMWFlxy9dFrT1nwv6XzmNeU+TOXAxK5/ozqjEGb3g==', NULL, N'XI2RXKKV32UMF2EFTGCKN5DXVZHJ2JK3', N'f77faab3-74c3-4a36-b90f-dd1970c7a9b4', NULL, N'0', N'0', NULL, N'1', N'0', N'0', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:55:40.5615380', N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:53:50.6226360', NULL)
GO


-- ----------------------------
-- Table structure for UserClaim
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UserClaim]') AND type IN ('U'))
	DROP TABLE [dbo].[UserClaim]
GO

CREATE TABLE [dbo].[UserClaim] (
  [Id] uniqueidentifier  NOT NULL,
  [UserId] uniqueidentifier  NOT NULL,
  [ClaimType] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [ClaimValue] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit DEFAULT (CONVERT([bit],(0))) NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[UserClaim] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of UserClaim
-- ----------------------------

-- ----------------------------
-- Table structure for UserRole
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRole]') AND type IN ('U'))
	DROP TABLE [dbo].[UserRole]
GO

CREATE TABLE [dbo].[UserRole] (
  [Id] uniqueidentifier  NOT NULL,
  [UserId] uniqueidentifier  NOT NULL,
  [RoleId] uniqueidentifier  NOT NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit DEFAULT (CONVERT([bit],(0))) NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[UserRole] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of UserRole
-- ----------------------------
INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8797B-B730-4968-8344-00297C4AB938', N'08D8476B-A962-4E7D-84CC-0344B552AE40', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 14:52:33.4099060')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D83DFD-B2D2-48F9-82E9-017E376F2E79', N'08D83DFD-B27E-47D1-8991-9747EF675A1D', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:51:50.9079180')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8797C-E368-4375-87B0-0590968572DB', N'08D8476B-A962-4E7D-84CC-0344B552AE40', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 15:00:57.1086140')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D88865-93CD-4715-8E57-06DB7CAA342E', N'08D82B86-ABB8-4276-8159-B7D7508B61A0', N'08D88001-7F99-4DAC-8283-63EE7048010B', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 14:21:52.5405700')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F005-4A08-4CDD-81D3-07F8F80FB300', N'08D7F005-49D3-4031-8AD9-48A05173AB98', N'08D7E43F-4EF1-4349-8FB0-CF493929D335', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 16:29:40.3805080')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80557-154A-4235-86C8-0A8EEB174BFF', N'08D80557-1534-4C1F-8A7E-E129B8F27A91', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-05 11:38:05.0394220')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F005-6328-4E2F-8612-0C6EDF0A4ED0', N'08D7F005-630A-4890-8CA6-ACBBA9F2F780', N'08D7E43F-4EF1-4349-8FB0-CF493929D335', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 16:30:22.5340790')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D83D37-AB24-43EC-86B8-0C859A25C89A', N'08D83D37-A51A-4FD2-86DE-B41EC38FD244', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:14:17.6663930')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E1E-17EB-4C35-8D44-0CD0ACFBBA81', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 23:42:48.6058370')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D83DFE-FA1B-4BF1-870A-0D0DA8E995CD', N'08D83DFE-EC17-4390-8EC5-2782D375A606', N'08D83C76-2B1E-4794-8B2F-3A2AFF1EDAE2', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:01:00.0029780')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8451D-E415-46A9-8B50-0DB6332C1FC3', N'08D8451D-A86B-4720-8AF9-AE955ACFC5EB', N'08D84051-CFDB-441D-8481-2D83A8F1A412', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:29:55.5901000')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80557-0BDD-4311-81FA-0DCCF1D75BC1', N'08D80557-0BB3-4453-8F6F-05DB14D9B68B', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-05 11:37:49.2239910')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D850D4-599E-4028-87FB-1006E0F8E0FF', N'08D82B86-ABB8-4276-8159-B7D7508B61A0', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 21:13:43.9590750')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8273A-E58C-47AD-8CB1-10DDE1FC8E70', N'08D820C8-C1E9-4356-8D0B-74D3E6A796B2', N'08D80A10-221F-48F3-83EA-81E35CA1CF6B', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 22:41:58.5699390')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D820BB-1668-4AE8-8A60-14773B1E64D4', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'08D7E440-C641-4B91-87D8-9A80BB083415', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 16:11:57.9851270')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80ED1-AFA6-4D42-8F39-15ED873C98CE', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'08D80E1E-12D6-461F-8A94-E9C864DE6A14', N'2020-01-06 21:08:23.0822600')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D83DFB-8096-4C86-8835-168CB5F6B162', N'08D83DFB-804A-406F-8702-32103EB32506', N'08D83C76-2B1E-4794-8B2F-3A2AFF1EDAE2', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:36:07.6369110')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8273C-7867-4AAD-8CF8-17AB4BBB0F7D', N'08D8273C-7823-430C-8BA7-A85C1494AFBD', N'08D80A10-221F-48F3-83EA-81E35CA1CF6B', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 14:53:14.4488130')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D820C8-AD31-4F56-83EA-1B66DAEAF166', N'08D7E605-ABB6-4BB0-8DCF-650872AD9E4A', N'08D7E440-C641-4B91-87D8-9A80BB083415', NULL, NULL, N'0', N'08D7E60C-FB44-4122-894B-1171470D9248', N'2020-01-07 17:49:14.4068470')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E1F-45DF-477C-86D0-1C1928EF9457', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 23:51:15.1971650')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E23-0214-4A1E-8A6C-1F080DD06DF8', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 00:17:59.4472050')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7E921-7665-4035-81BB-2139D66B61C4', N'08D7E921-75EC-41AE-8729-5223BE30A75B', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 22:03:42.5737050')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E1E-1BBB-4AD4-8E3D-21C5D19E73B1', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 23:42:55.0015880')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7E921-5132-49A6-8451-23D2224F8D28', N'08D7E921-5092-4D2B-8386-2BAA014C2B1C', N'08D7E43F-8187-4124-879D-C80D973CA626', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 22:02:40.1674320')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8451D-A8E3-4D18-873F-251D163BE129', N'08D8451D-A86B-4720-8AF9-AE955ACFC5EB', N'08D83C76-2B1E-4794-8B2F-3A2AFF1EDAE2', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:28:16.2791050')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F018-486F-48C5-866F-25592F374C5E', N'08D7E605-ABB6-4BB0-8DCF-650872AD9E4A', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 18:45:38.1365320')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F0D5-18F4-4C70-815D-2868FE06D36E', N'08D7F0D5-0191-4DD8-8A85-49F06AA28F6B', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 17:17:13.3608360')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D820C8-AD40-41F5-8E20-2CB295BD109B', N'08D7E605-ABB6-4BB0-8DCF-650872AD9E4A', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', NULL, NULL, N'0', N'08D7E60C-FB44-4122-894B-1171470D9248', N'2020-01-07 17:49:14.5128870')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D850E1-DE02-43EC-869E-2CFF7369524A', N'08D8476B-A962-4E7D-84CC-0344B552AE40', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:50:29.5475150')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8451D-A8C6-437A-8A94-2E771E31748A', N'08D8451D-A86B-4720-8AF9-AE955ACFC5EB', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:28:16.0849070')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F018-A0AA-496E-8F61-2ED405675083', N'08D7F018-A070-4F95-864D-53A14F37FA67', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 18:48:06.1629700')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D820BA-B781-4C75-8624-329F7E2B6927', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'08D7E440-C641-4B91-87D8-9A80BB083415', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 16:09:18.7520340')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8451E-9CDD-4A43-8EF9-34B95B12DB2C', N'08D8451D-A86B-4720-8AF9-AE955ACFC5EB', N'08D84051-CFDB-441D-8481-2D83A8F1A412', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:35:05.6030770')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D82B86-ABDD-4F86-8576-351F232661A3', N'08D82B86-ABB8-4276-8159-B7D7508B61A0', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 09:54:28.1982530')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D82B88-88CD-4514-898F-448DB8C6E4BD', N'08D82B86-ABB8-4276-8159-B7D7508B61A0', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 10:07:48.3627560')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F0D5-0258-4ABA-832A-466710AFEE9E', N'08D7F0D5-0191-4DD8-8A85-49F06AA28F6B', N'08D7EFE7-97F8-4262-877D-6F72B76C333B', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 17:16:35.4278420')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7E921-516F-4279-8282-479530B9250B', N'08D7E921-5092-4D2B-8386-2BAA014C2B1C', N'08D7E440-C641-4B91-87D8-9A80BB083415', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 22:02:40.5645370')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7E921-7646-44C0-84FE-48D6D102C907', N'08D7E921-75EC-41AE-8729-5223BE30A75B', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 22:03:42.3723420')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8273C-9AC6-4823-8AAD-4A33C5844413', N'08D8273C-9AAD-4190-8484-9AB01953CCEC', N'08D80A10-221F-48F3-83EA-81E35CA1CF6B', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 14:54:12.1143300')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8476B-A9C3-44C8-8028-4A77A692E1AB', N'08D8476B-A962-4E7D-84CC-0344B552AE40', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:51:40.8139910')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80796-5BA3-4A80-86B2-4C64259878B4', N'08D80796-5B8D-4821-8310-6FF589ABD11D', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 08:16:03.6862680')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80557-E198-4BF9-8413-536D3C349600', N'08D80557-E180-44F4-82ED-15B15797FAC1', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-05 11:43:47.8100980')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80ED1-0793-48C8-8D87-547ACBDA2342', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'08D80E1E-12D6-461F-8A94-E9C864DE6A14', N'2020-01-06 21:03:41.0983120')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F0D5-1938-4980-8A4F-5C4730F38AB9', N'08D7F0D5-0191-4DD8-8A85-49F06AA28F6B', N'08D7E440-C641-4B91-87D8-9A80BB083415', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 17:17:13.8052900')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80ED1-F375-489A-8732-5C7061CAB0CA', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'1', N'08D80E1E-12D6-461F-8A94-E9C864DE6A14', N'2020-01-06 21:10:16.8443420')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F0D5-01FB-45AA-886D-5D5D2B8B6292', N'08D7F0D5-0191-4DD8-8A85-49F06AA28F6B', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 17:16:34.8154480')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8451E-9CBE-4139-8A4C-5D9493A547F0', N'08D8451D-A86B-4720-8AF9-AE955ACFC5EB', N'08D83C76-2B1E-4794-8B2F-3A2AFF1EDAE2', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:35:05.3962030')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80ED0-6D83-43C9-8291-6356BE88FD9A', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'08D80E1E-12D6-461F-8A94-E9C864DE6A14', N'2020-01-06 20:59:22.5998230')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E1E-C80A-4090-8E16-6395DF943917', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 23:47:44.0832200')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8797C-8CC9-4708-8A97-64E2D56FAEB2', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 14:58:31.7841020')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D820C4-E404-4346-8B14-6C20DBF62ABB', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'B8551E97-0723-47FC-BD7E-AFF35BB1B1E7', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 17:22:08.4067830')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E22-9B06-4F72-8FD1-6EFEE14F1FF9', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 00:15:06.5295540')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80600-A9B6-4C5B-8FCD-7081AB8569E1', N'08D80600-A9A1-4B1B-848A-915218C2C9F0', N'08D7EFE7-B536-4BD0-8D7E-47E081ABC01F', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 07:51:59.0016520')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8451D-A902-43E0-8BCD-73224C63B232', N'08D8451D-A86B-4720-8AF9-AE955ACFC5EB', N'08D84051-CFDB-441D-8481-2D83A8F1A412', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:28:16.4788340')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7E920-8BD6-4BE2-8B2B-751408EF20E2', N'08D7E605-ABB6-4BB0-8DCF-650872AD9E4A', N'08D7E440-C641-4B91-87D8-9A80BB083415', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 21:57:09.0360310')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F005-49FE-40E3-8699-7BC7EE7EF670', N'08D7F005-49D3-4031-8AD9-48A05173AB98', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 16:29:40.3097100')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D83D3F-E55B-4089-8302-859A9701FA22', N'08D82B86-ABB8-4276-8159-B7D7508B61A0', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:13:11.2955990')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F018-3205-42B7-83CE-8B4CBFD2AFDB', N'08D7E605-ABB6-4BB0-8DCF-650872AD9E4A', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 18:45:00.5290140')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F0D5-023A-4084-8965-91864BD2D05D', N'08D7F0D5-0191-4DD8-8A85-49F06AA28F6B', N'08D7E440-C641-4B91-87D8-9A80BB083415', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 17:16:35.2268620')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D82BAD-60F3-495D-8D77-938F6630762C', N'08D82B86-ABB8-4276-8159-B7D7508B61A0', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 14:31:32.8707490')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E1D-EE26-4FEC-8AE7-939CB3D294F0', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 23:41:38.5297150')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D88A31-B780-415C-89FA-A250263380C2', N'08D88A2C-D58D-4502-8115-C1B9AC1BB76F', N'08D88001-7F99-4DAC-8283-63EE7048010B', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:15:40.9351760')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D83DFC-89E0-40AB-8F80-A803A0811FE4', N'08D83DFB-804A-406F-8702-32103EB32506', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 21:43:32.6909890')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F0D5-1955-4654-8FCB-A9FD6D075C09', N'08D7F0D5-0191-4DD8-8A85-49F06AA28F6B', N'08D7EFE7-97F8-4262-877D-6F72B76C333B', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 17:17:13.9940060')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F0D5-1911-4492-88CF-AA1F837E010E', N'08D7F0D5-0191-4DD8-8A85-49F06AA28F6B', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 17:17:13.5476920')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80ED1-EFAE-4755-85C0-AB23D1EF24F4', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'08D80E1E-12D6-461F-8A94-E9C864DE6A14', N'2020-01-06 21:10:10.5059740')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8451D-E3F7-4CB5-8408-ADF60072E789', N'08D8451D-A86B-4720-8AF9-AE955ACFC5EB', N'08D83C76-2B1E-4794-8B2F-3A2AFF1EDAE2', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:29:55.3959490')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D83DFE-EC78-4ABD-80D8-B09CA724A3DA', N'08D83DFE-EC17-4390-8EC5-2782D375A606', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 22:00:37.1237150')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8053A-6661-44C4-8766-B1769539BFC9', N'08D80538-412D-4C37-8338-E5885F8BCDAE', N'08D7EFF8-D254-4848-80DA-D4693602966C', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-05 16:12:45.6815220')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E22-CD64-42D5-809A-C1687D25403F', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 00:16:31.0486340')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8273A-84D0-4419-85F9-C25B7E3844AD', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D80A10-221F-48F3-83EA-81E35CA1CF6B', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 22:39:16.2737980')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80538-4194-4218-84A6-C6677FB4B9B7', N'08D80538-412D-4C37-8338-E5885F8BCDAE', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 15:57:24.9452990')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7E921-7628-4A00-88E2-CA40529081C6', N'08D7E921-75EC-41AE-8729-5223BE30A75B', N'08D7E43F-4EF1-4349-8FB0-CF493929D335', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 22:03:42.1780580')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F018-3F17-4F79-8384-CDE06FDB9ABB', N'08D7E605-ABB6-4BB0-8DCF-650872AD9E4A', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 18:45:22.4630220')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7E921-50F5-4605-8702-D18AE8EA90D8', N'08D7E921-5092-4D2B-8386-2BAA014C2B1C', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 22:02:39.7658170')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D84451-C1C8-4550-8CB5-D4717FA9550F', N'08D84451-C188-4131-88F3-832DD407B123', N'08D83C76-2B1E-4794-8B2F-3A2AFF1EDAE2', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:08:40.7085260')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D84451-C973-4470-8E88-D59799F04A05', N'08D84451-C188-4131-88F3-832DD407B123', N'08D83C76-2B1E-4794-8B2F-3A2AFF1EDAE2', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:08:53.5738380')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F018-3EF8-4099-8E0C-D599519E317A', N'08D7E605-ABB6-4BB0-8DCF-650872AD9E4A', N'08D7E440-C641-4B91-87D8-9A80BB083415', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 18:45:22.2534040')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E1F-21CA-4012-8871-D5D51D069AD9', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 23:50:14.6580610')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D82B86-DA51-4920-8C6C-DC5EFE9780B9', N'08D82B86-ABB8-4276-8159-B7D7508B61A0', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-07 09:55:46.1311380')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7E921-5150-445D-8EA6-DFB3621EFC2C', N'08D7E921-5092-4D2B-8386-2BAA014C2B1C', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 22:02:40.3620600')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E1D-E406-4D43-842D-E057143DEF00', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 23:41:21.5411610')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D820C8-C202-45E1-8F24-E110FB2BD758', N'08D820C8-C1E9-4356-8D0B-74D3E6A796B2', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'1', N'08D7E60C-FB44-4122-894B-1171470D9248', N'2020-01-07 17:49:49.3407620')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F005-6331-4D26-88E7-E1C9302F6626', N'08D7F005-630A-4890-8CA6-ACBBA9F2F780', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 16:30:22.5926280')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E22-A2E2-472B-8489-E44313560F80', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 00:15:19.7345730')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F018-4853-47F9-8319-E4947FC2C0B7', N'08D7E605-ABB6-4BB0-8DCF-650872AD9E4A', N'08D7E440-C641-4B91-87D8-9A80BB083415', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 18:45:37.9524350')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E1D-7807-4DFC-8DD3-E4BF2F60F092', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 23:38:20.3313600')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8797C-2028-4D77-8623-EB59329A2973', N'08D8476B-A962-4E7D-84CC-0344B552AE40', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 14:55:29.5372170')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F005-631F-4FF1-860C-EBA1872FAF36', N'08D7F005-630A-4890-8CA6-ACBBA9F2F780', N'08D7E43F-1991-496A-8BFC-BDA023FD6A1B', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 16:30:22.4757600')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F018-31E3-4C1F-82E1-ECED9A3BC2F9', N'08D7E605-ABB6-4BB0-8DCF-650872AD9E4A', N'08D7E440-C641-4B91-87D8-9A80BB083415', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 18:45:00.2743360')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D88D5B-F741-4CAB-824D-F56C57E68E49', N'08D88D5B-B5EC-4A96-8CF1-E0EDAEE1423A', N'08D88D5B-C231-4790-862D-7FF71EEA370D', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-01 21:55:40.2739100')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D8451E-9CA1-4BA5-8E2C-F623A4594547', N'08D8451D-A86B-4720-8AF9-AE955ACFC5EB', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-08 23:35:05.2104090')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7E921-5114-488C-8AEC-F759AA1AC906', N'08D7E921-5092-4D2B-8386-2BAA014C2B1C', N'08D7E43F-4EF1-4349-8FB0-CF493929D335', NULL, NULL, N'0', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 22:02:39.9703000')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7F0D5-021C-43A8-8FD5-FAC286ABEAA3', N'08D7F0D5-0191-4DD8-8A85-49F06AA28F6B', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-05 17:16:35.0315070')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D850E1-CEF8-4D4C-800C-FB540C74092D', N'08D82B86-ABB8-4276-8159-B7D7508B61A0', N'08D83C6E-4CC0-41A0-865A-9EE5B50C971C', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-09 22:50:04.3154460')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D7E920-8BFA-4C73-847F-FF5F0D41667E', N'08D7E605-ABB6-4BB0-8DCF-650872AD9E4A', N'3FA85F64-5717-4562-B3FC-2C963F66AFA6', NULL, NULL, N'1', N'00000000-0000-0000-0000-000000000000', N'2020-01-04 21:57:09.2902170')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80794-684A-433E-82E3-FFA5BAB2D6BA', N'08D80794-6833-47CA-8ADD-ECBD9A3D9A30', N'08D7EFE7-B536-4BD0-8D7E-47E081ABC01F', NULL, NULL, N'0', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 08:02:05.9171110')
GO

INSERT INTO [dbo].[UserRole] ([Id], [UserId], [RoleId], [LastModifierUserId], [LastModifionTime], [IsDeleted], [CreatorUserId], [CreatedTime]) VALUES (N'08D80E20-E492-4F5B-88F6-FFD310622ABD', N'08D7E60D-385B-4015-8CD2-22394B43F428', N'08D7E43F-C369-4631-8F72-160649A6DC9E', NULL, NULL, N'1', N'A1E89F45-4FA8-4751-9DF9-DEC86F7E6C14', N'2020-01-06 00:02:50.9287700')
GO


-- ----------------------------
-- Table structure for UserToken
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UserToken]') AND type IN ('U'))
	DROP TABLE [dbo].[UserToken]
GO

CREATE TABLE [dbo].[UserToken] (
  [Id] uniqueidentifier  NOT NULL,
  [UserId] uniqueidentifier  NOT NULL,
  [LoginProvider] nvarchar(450) COLLATE Chinese_PRC_CI_AS  NULL,
  [Name] nvarchar(450) COLLATE Chinese_PRC_CI_AS  NULL,
  [Value] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [LastModifierUserId] uniqueidentifier  NULL,
  [LastModifionTime] datetime2(7)  NULL,
  [IsDeleted] bit DEFAULT (CONVERT([bit],(0))) NOT NULL,
  [CreatorUserId] uniqueidentifier  NULL,
  [CreatedTime] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[UserToken] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of UserToken
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE [dbo].[__EFMigrationsHistory] ADD CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table ApiResource
-- ----------------------------
ALTER TABLE [dbo].[ApiResource] ADD CONSTRAINT [PK_ApiResource] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ApiResourceClaim
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ApiResourceClaim_ApiResourceId]
ON [dbo].[ApiResourceClaim] (
  [ApiResourceId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ApiResourceClaim
-- ----------------------------
ALTER TABLE [dbo].[ApiResourceClaim] ADD CONSTRAINT [PK_ApiResourceClaim] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ApiResourceProperty
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ApiResourceProperty_ApiResourceId]
ON [dbo].[ApiResourceProperty] (
  [ApiResourceId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ApiResourceProperty
-- ----------------------------
ALTER TABLE [dbo].[ApiResourceProperty] ADD CONSTRAINT [PK_ApiResourceProperty] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ApiResourceScope
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ApiResourceScope_ApiResourceId]
ON [dbo].[ApiResourceScope] (
  [ApiResourceId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ApiResourceScope
-- ----------------------------
ALTER TABLE [dbo].[ApiResourceScope] ADD CONSTRAINT [PK_ApiResourceScope] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ApiResourceSecret
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ApiResourceSecret_ApiResourceId]
ON [dbo].[ApiResourceSecret] (
  [ApiResourceId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ApiResourceSecret
-- ----------------------------
ALTER TABLE [dbo].[ApiResourceSecret] ADD CONSTRAINT [PK_ApiResourceSecret] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table ApiScope
-- ----------------------------
ALTER TABLE [dbo].[ApiScope] ADD CONSTRAINT [PK_ApiScope] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ApiScopeClaim
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ApiScopeClaim_ScopeId]
ON [dbo].[ApiScopeClaim] (
  [ScopeId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ApiScopeClaim
-- ----------------------------
ALTER TABLE [dbo].[ApiScopeClaim] ADD CONSTRAINT [PK_ApiScopeClaim] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ApiScopeProperty
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ApiScopeProperty_ScopeId]
ON [dbo].[ApiScopeProperty] (
  [ScopeId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ApiScopeProperty
-- ----------------------------
ALTER TABLE [dbo].[ApiScopeProperty] ADD CONSTRAINT [PK_ApiScopeProperty] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Client
-- ----------------------------
ALTER TABLE [dbo].[Client] ADD CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ClientClaim
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ClientClaim_ClientId]
ON [dbo].[ClientClaim] (
  [ClientId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ClientClaim
-- ----------------------------
ALTER TABLE [dbo].[ClientClaim] ADD CONSTRAINT [PK_ClientClaim] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ClientCorsOrigin
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ClientCorsOrigin_ClientId]
ON [dbo].[ClientCorsOrigin] (
  [ClientId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ClientCorsOrigin
-- ----------------------------
ALTER TABLE [dbo].[ClientCorsOrigin] ADD CONSTRAINT [PK_ClientCorsOrigin] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ClientGrantType
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ClientGrantType_ClientId]
ON [dbo].[ClientGrantType] (
  [ClientId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ClientGrantType
-- ----------------------------
ALTER TABLE [dbo].[ClientGrantType] ADD CONSTRAINT [PK_ClientGrantType] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ClientIdPRestriction
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ClientIdPRestriction_ClientId]
ON [dbo].[ClientIdPRestriction] (
  [ClientId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ClientIdPRestriction
-- ----------------------------
ALTER TABLE [dbo].[ClientIdPRestriction] ADD CONSTRAINT [PK_ClientIdPRestriction] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ClientPostLogoutRedirectUri
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ClientPostLogoutRedirectUri_ClientId]
ON [dbo].[ClientPostLogoutRedirectUri] (
  [ClientId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ClientPostLogoutRedirectUri
-- ----------------------------
ALTER TABLE [dbo].[ClientPostLogoutRedirectUri] ADD CONSTRAINT [PK_ClientPostLogoutRedirectUri] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ClientProperty
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ClientProperty_ClientId]
ON [dbo].[ClientProperty] (
  [ClientId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ClientProperty
-- ----------------------------
ALTER TABLE [dbo].[ClientProperty] ADD CONSTRAINT [PK_ClientProperty] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ClientRedirectUri
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ClientRedirectUri_ClientId]
ON [dbo].[ClientRedirectUri] (
  [ClientId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ClientRedirectUri
-- ----------------------------
ALTER TABLE [dbo].[ClientRedirectUri] ADD CONSTRAINT [PK_ClientRedirectUri] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ClientScope
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ClientScope_ClientId]
ON [dbo].[ClientScope] (
  [ClientId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ClientScope
-- ----------------------------
ALTER TABLE [dbo].[ClientScope] ADD CONSTRAINT [PK_ClientScope] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table ClientSecret
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ClientSecret_ClientId]
ON [dbo].[ClientSecret] (
  [ClientId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ClientSecret
-- ----------------------------
ALTER TABLE [dbo].[ClientSecret] ADD CONSTRAINT [PK_ClientSecret] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table DataDictionary
-- ----------------------------
ALTER TABLE [dbo].[DataDictionary] ADD CONSTRAINT [PK_DataDictionary] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table DeviceFlowCodes
-- ----------------------------
ALTER TABLE [dbo].[DeviceFlowCodes] ADD CONSTRAINT [PK_DeviceFlowCodes] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Function
-- ----------------------------
ALTER TABLE [dbo].[Function] ADD CONSTRAINT [PK_Function] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table IdentityResource
-- ----------------------------
ALTER TABLE [dbo].[IdentityResource] ADD CONSTRAINT [PK_IdentityResource] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table IdentityResourceClaim
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_IdentityResourceClaim_IdentityResourceId]
ON [dbo].[IdentityResourceClaim] (
  [IdentityResourceId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table IdentityResourceClaim
-- ----------------------------
ALTER TABLE [dbo].[IdentityResourceClaim] ADD CONSTRAINT [PK_IdentityResourceClaim] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table IdentityResourceProperty
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_IdentityResourceProperty_IdentityResourceId]
ON [dbo].[IdentityResourceProperty] (
  [IdentityResourceId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table IdentityResourceProperty
-- ----------------------------
ALTER TABLE [dbo].[IdentityResourceProperty] ADD CONSTRAINT [PK_IdentityResourceProperty] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Menu
-- ----------------------------
ALTER TABLE [dbo].[Menu] ADD CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table MenuFunction
-- ----------------------------
ALTER TABLE [dbo].[MenuFunction] ADD CONSTRAINT [PK_MenuFunction] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Organizated
-- ----------------------------
ALTER TABLE [dbo].[Organizated] ADD CONSTRAINT [PK_Organizated] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table PersistedGrant
-- ----------------------------
ALTER TABLE [dbo].[PersistedGrant] ADD CONSTRAINT [PK_PersistedGrant] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Role
-- ----------------------------
ALTER TABLE [dbo].[Role] ADD CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table RoleClaim
-- ----------------------------
ALTER TABLE [dbo].[RoleClaim] ADD CONSTRAINT [PK_RoleClaim] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table RoleMenu
-- ----------------------------
ALTER TABLE [dbo].[RoleMenu] ADD CONSTRAINT [PK_RoleMenu] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table User
-- ----------------------------
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table UserClaim
-- ----------------------------
ALTER TABLE [dbo].[UserClaim] ADD CONSTRAINT [PK_UserClaim] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table UserRole
-- ----------------------------
ALTER TABLE [dbo].[UserRole] ADD CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table UserToken
-- ----------------------------
ALTER TABLE [dbo].[UserToken] ADD CONSTRAINT [PK_UserToken] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table ApiResourceClaim
-- ----------------------------
ALTER TABLE [dbo].[ApiResourceClaim] ADD CONSTRAINT [FK_ApiResourceClaim_ApiResource_ApiResourceId] FOREIGN KEY ([ApiResourceId]) REFERENCES [dbo].[ApiResource] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ApiResourceProperty
-- ----------------------------
ALTER TABLE [dbo].[ApiResourceProperty] ADD CONSTRAINT [FK_ApiResourceProperty_ApiResource_ApiResourceId] FOREIGN KEY ([ApiResourceId]) REFERENCES [dbo].[ApiResource] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ApiResourceScope
-- ----------------------------
ALTER TABLE [dbo].[ApiResourceScope] ADD CONSTRAINT [FK_ApiResourceScope_ApiResource_ApiResourceId] FOREIGN KEY ([ApiResourceId]) REFERENCES [dbo].[ApiResource] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ApiResourceSecret
-- ----------------------------
ALTER TABLE [dbo].[ApiResourceSecret] ADD CONSTRAINT [FK_ApiResourceSecret_ApiResource_ApiResourceId] FOREIGN KEY ([ApiResourceId]) REFERENCES [dbo].[ApiResource] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ApiScopeClaim
-- ----------------------------
ALTER TABLE [dbo].[ApiScopeClaim] ADD CONSTRAINT [FK_ApiScopeClaim_ApiScope_ScopeId] FOREIGN KEY ([ScopeId]) REFERENCES [dbo].[ApiScope] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ApiScopeProperty
-- ----------------------------
ALTER TABLE [dbo].[ApiScopeProperty] ADD CONSTRAINT [FK_ApiScopeProperty_ApiScope_ScopeId] FOREIGN KEY ([ScopeId]) REFERENCES [dbo].[ApiScope] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ClientClaim
-- ----------------------------
ALTER TABLE [dbo].[ClientClaim] ADD CONSTRAINT [FK_ClientClaim_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ClientCorsOrigin
-- ----------------------------
ALTER TABLE [dbo].[ClientCorsOrigin] ADD CONSTRAINT [FK_ClientCorsOrigin_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ClientGrantType
-- ----------------------------
ALTER TABLE [dbo].[ClientGrantType] ADD CONSTRAINT [FK_ClientGrantType_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ClientIdPRestriction
-- ----------------------------
ALTER TABLE [dbo].[ClientIdPRestriction] ADD CONSTRAINT [FK_ClientIdPRestriction_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ClientPostLogoutRedirectUri
-- ----------------------------
ALTER TABLE [dbo].[ClientPostLogoutRedirectUri] ADD CONSTRAINT [FK_ClientPostLogoutRedirectUri_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ClientProperty
-- ----------------------------
ALTER TABLE [dbo].[ClientProperty] ADD CONSTRAINT [FK_ClientProperty_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ClientRedirectUri
-- ----------------------------
ALTER TABLE [dbo].[ClientRedirectUri] ADD CONSTRAINT [FK_ClientRedirectUri_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ClientScope
-- ----------------------------
ALTER TABLE [dbo].[ClientScope] ADD CONSTRAINT [FK_ClientScope_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ClientSecret
-- ----------------------------
ALTER TABLE [dbo].[ClientSecret] ADD CONSTRAINT [FK_ClientSecret_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table IdentityResourceClaim
-- ----------------------------
ALTER TABLE [dbo].[IdentityResourceClaim] ADD CONSTRAINT [FK_IdentityResourceClaim_IdentityResource_IdentityResourceId] FOREIGN KEY ([IdentityResourceId]) REFERENCES [dbo].[IdentityResource] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table IdentityResourceProperty
-- ----------------------------
ALTER TABLE [dbo].[IdentityResourceProperty] ADD CONSTRAINT [FK_IdentityResourceProperty_IdentityResource_IdentityResourceId] FOREIGN KEY ([IdentityResourceId]) REFERENCES [dbo].[IdentityResource] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

