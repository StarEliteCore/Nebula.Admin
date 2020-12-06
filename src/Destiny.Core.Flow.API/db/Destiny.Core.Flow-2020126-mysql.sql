/*
 Navicat Premium Data Transfer

 Source Server         : Destiny.Core.Flow
 Source Server Type    : MySQL
 Source Server Version : 80019
 Source Host           : 47.100.213.49:3307
 Source Schema         : Destiny.Core.Flow

 Target Server Type    : MySQL
 Target Server Version : 80019
 File Encoding         : 65001

 Date: 06/12/2020 18:46:05
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for ApiResource
-- ----------------------------
DROP TABLE IF EXISTS `ApiResource`;
CREATE TABLE `ApiResource`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Enabled` tinyint(1) NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `DisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ShowInDiscoveryDocument` tinyint(1) NOT NULL,
  `AllowedAccessTokenSigningAlgorithms` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `LastAccessed` datetime(6) NULL DEFAULT NULL,
  `NonEditable` tinyint(1) NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ApiResource
-- ----------------------------
INSERT INTO `ApiResource` VALUES ('08d8869f-acb0-49e6-8479-85ebe06100d7', 1, 'Destiny.Core.Flow.API', NULL, NULL, 1, NULL, NULL, 0, NULL, NULL, 0, NULL, '2020-11-12 08:12:42.741689');

-- ----------------------------
-- Table structure for ApiResourceClaim
-- ----------------------------
DROP TABLE IF EXISTS `ApiResourceClaim`;
CREATE TABLE `ApiResourceClaim`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ApiResourceId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ApiResourceClaim_ApiResourceId`(`ApiResourceId`) USING BTREE,
  CONSTRAINT `FK_ApiResourceClaim_ApiResource_ApiResourceId` FOREIGN KEY (`ApiResourceId`) REFERENCES `ApiResource` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ApiResourceClaim
-- ----------------------------
INSERT INTO `ApiResourceClaim` VALUES ('08d8869f-acb7-4405-885a-e6a2297572f3', 'name', '08d8869f-acb0-49e6-8479-85ebe06100d7', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ApiResourceClaim` VALUES ('08d8869f-acb7-4eb7-88b7-87e9e51a6007', 'role', '08d8869f-acb0-49e6-8479-85ebe06100d7', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');

-- ----------------------------
-- Table structure for ApiResourceProperty
-- ----------------------------
DROP TABLE IF EXISTS `ApiResourceProperty`;
CREATE TABLE `ApiResourceProperty`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Key` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ApiResourceId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ApiResourceProperty_ApiResourceId`(`ApiResourceId`) USING BTREE,
  CONSTRAINT `FK_ApiResourceProperty_ApiResource_ApiResourceId` FOREIGN KEY (`ApiResourceId`) REFERENCES `ApiResource` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ApiResourceProperty
-- ----------------------------

-- ----------------------------
-- Table structure for ApiResourceScope
-- ----------------------------
DROP TABLE IF EXISTS `ApiResourceScope`;
CREATE TABLE `ApiResourceScope`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Scope` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ApiResourceId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ApiResourceScope_ApiResourceId`(`ApiResourceId`) USING BTREE,
  CONSTRAINT `FK_ApiResourceScope_ApiResource_ApiResourceId` FOREIGN KEY (`ApiResourceId`) REFERENCES `ApiResource` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ApiResourceScope
-- ----------------------------
INSERT INTO `ApiResourceScope` VALUES ('08d8869f-acb3-4fb6-834a-50915114a00d', 'Destiny.Core.Flow.API', '08d8869f-acb0-49e6-8479-85ebe06100d7', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');

-- ----------------------------
-- Table structure for ApiResourceSecret
-- ----------------------------
DROP TABLE IF EXISTS `ApiResourceSecret`;
CREATE TABLE `ApiResourceSecret`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Expiration` datetime(6) NULL DEFAULT NULL,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Created` datetime(6) NOT NULL,
  `ApiResourceId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ApiResourceSecret_ApiResourceId`(`ApiResourceId`) USING BTREE,
  CONSTRAINT `FK_ApiResourceSecret_ApiResource_ApiResourceId` FOREIGN KEY (`ApiResourceId`) REFERENCES `ApiResource` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ApiResourceSecret
-- ----------------------------
INSERT INTO `ApiResourceSecret` VALUES ('08d8869f-acb6-43ec-8e97-7eea6de49fb7', NULL, 'xWXRHbA1kGBJxxiRIToBpsW6yC3SRq+TM8AAze3owyw=', NULL, 'SharedSecret', '0001-01-01 00:00:00.000000', '08d8869f-acb0-49e6-8479-85ebe06100d7', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');

-- ----------------------------
-- Table structure for ApiScope
-- ----------------------------
DROP TABLE IF EXISTS `ApiScope`;
CREATE TABLE `ApiScope`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Enabled` tinyint(1) NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `DisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ShowInDiscoveryDocument` tinyint(1) NOT NULL,
  `Required` tinyint(1) NOT NULL,
  `Emphasize` tinyint(1) NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ApiScope
-- ----------------------------
INSERT INTO `ApiScope` VALUES ('08d8869f-b157-4c78-88c5-ec663b46b413', 1, 'Destiny.Core.Flow.API', 'Destiny.Core.Flow.API', NULL, 1, 0, 0, NULL, NULL, 0, NULL, '2020-11-12 08:12:50.614978');

-- ----------------------------
-- Table structure for ApiScopeClaim
-- ----------------------------
DROP TABLE IF EXISTS `ApiScopeClaim`;
CREATE TABLE `ApiScopeClaim`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ScopeId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ApiScopeClaim_ScopeId`(`ScopeId`) USING BTREE,
  CONSTRAINT `FK_ApiScopeClaim_ApiScope_ScopeId` FOREIGN KEY (`ScopeId`) REFERENCES `ApiScope` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ApiScopeClaim
-- ----------------------------

-- ----------------------------
-- Table structure for ApiScopeProperty
-- ----------------------------
DROP TABLE IF EXISTS `ApiScopeProperty`;
CREATE TABLE `ApiScopeProperty`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Key` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ScopeId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ApiScopeProperty_ScopeId`(`ScopeId`) USING BTREE,
  CONSTRAINT `FK_ApiScopeProperty_ApiScope_ScopeId` FOREIGN KEY (`ScopeId`) REFERENCES `ApiScope` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ApiScopeProperty
-- ----------------------------

-- ----------------------------
-- Table structure for Client
-- ----------------------------
DROP TABLE IF EXISTS `Client`;
CREATE TABLE `Client`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Enabled` tinyint(1) NOT NULL DEFAULT 1,
  `ClientId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ProtocolType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `RequireClientSecret` tinyint(1) NOT NULL DEFAULT 1,
  `ClientName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientUri` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `LogoUri` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `RequireConsent` tinyint(1) NOT NULL,
  `AllowRememberConsent` tinyint(1) NOT NULL DEFAULT 1,
  `AlwaysIncludeUserClaimsInIdToken` tinyint(1) NOT NULL,
  `RequirePkce` tinyint(1) NOT NULL DEFAULT 1,
  `AllowPlainTextPkce` tinyint(1) NOT NULL,
  `RequireRequestObject` tinyint(1) NOT NULL,
  `AllowAccessTokensViaBrowser` tinyint(1) NOT NULL,
  `FrontChannelLogoutUri` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `FrontChannelLogoutSessionRequired` tinyint(1) NOT NULL DEFAULT 1,
  `BackChannelLogoutUri` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `BackChannelLogoutSessionRequired` tinyint(1) NOT NULL DEFAULT 1,
  `AllowOfflineAccess` tinyint(1) NOT NULL,
  `IdentityTokenLifetime` int(0) NOT NULL DEFAULT 300,
  `AllowedIdentityTokenSigningAlgorithms` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `AccessTokenLifetime` int(0) NOT NULL DEFAULT 3600,
  `AuthorizationCodeLifetime` int(0) NOT NULL DEFAULT 300,
  `ConsentLifetime` int(0) NULL DEFAULT NULL,
  `AbsoluteRefreshTokenLifetime` int(0) NOT NULL DEFAULT 2592000,
  `SlidingRefreshTokenLifetime` int(0) NOT NULL DEFAULT 2592000,
  `RefreshTokenUsage` int(0) NOT NULL DEFAULT -1,
  `UpdateAccessTokenClaimsOnRefresh` tinyint(1) NOT NULL,
  `RefreshTokenExpiration` int(0) NOT NULL DEFAULT -1,
  `AccessTokenType` int(0) NOT NULL,
  `EnableLocalLogin` tinyint(1) NOT NULL DEFAULT 1,
  `IncludeJwtId` tinyint(1) NOT NULL,
  `AlwaysSendClientClaims` tinyint(1) NOT NULL,
  `ClientClaimsPrefix` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `PairWiseSubjectSalt` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `LastAccessed` datetime(6) NULL DEFAULT NULL,
  `UserSsoLifetime` int(0) NULL DEFAULT NULL,
  `UserCodeType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `DeviceCodeLifetime` int(0) NOT NULL DEFAULT 300,
  `NonEditable` tinyint(1) NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Client
-- ----------------------------
INSERT INTO `Client` VALUES ('08d8869f-b1e7-455a-8ce5-fd3801d6d881', 1, 'DestinyCoreFlowReactClient', 'oidc', 1, 'Destiny.Core.Flow.ReactClient', NULL, NULL, NULL, 0, 1, 0, 1, 0, 0, 1, NULL, 1, NULL, 1, 0, 300, NULL, 3600, 300, NULL, 2592000, 1296000, 1, 0, 1, 0, 1, 1, 0, 'client_', NULL, NULL, NULL, NULL, 300, 0, NULL, NULL, 0, NULL, '2020-11-12 08:12:51.556469');
INSERT INTO `Client` VALUES ('08d8869f-b1f6-441c-8f0f-6c24ab0dedc5', 1, 'DestinyCoreFlowReactClientpwd', 'oidc', 1, 'Destiny.Core.Flow.ReactClientpwd', NULL, NULL, NULL, 0, 1, 0, 1, 0, 0, 1, NULL, 1, NULL, 1, 0, 300, NULL, 3600, 300, NULL, 2592000, 1296000, 1, 0, 1, 0, 1, 1, 0, 'client_', NULL, NULL, NULL, NULL, 300, 0, NULL, NULL, 0, NULL, '2020-11-12 08:12:51.556473');

-- ----------------------------
-- Table structure for ClientClaim
-- ----------------------------
DROP TABLE IF EXISTS `ClientClaim`;
CREATE TABLE `ClientClaim`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ClientClaim_ClientId`(`ClientId`) USING BTREE,
  CONSTRAINT `FK_ClientClaim_Client_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Client` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ClientClaim
-- ----------------------------

-- ----------------------------
-- Table structure for ClientCorsOrigin
-- ----------------------------
DROP TABLE IF EXISTS `ClientCorsOrigin`;
CREATE TABLE `ClientCorsOrigin`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Origin` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ClientCorsOrigin_ClientId`(`ClientId`) USING BTREE,
  CONSTRAINT `FK_ClientCorsOrigin_Client_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Client` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ClientCorsOrigin
-- ----------------------------
INSERT INTO `ClientCorsOrigin` VALUES ('08d8869f-b1f1-4535-846e-572e5a038c41', 'http://localhost:8848', '08d8869f-b1e7-455a-8ce5-fd3801d6d881', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientCorsOrigin` VALUES ('08d8869f-b1f1-4f87-846d-72ed46d64378', 'https://admin.destinycore.club', '08d8869f-b1e7-455a-8ce5-fd3801d6d881', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientCorsOrigin` VALUES ('08d8869f-b1f6-4950-8262-d68b06c0da74', 'http://localhost:8080', '08d8869f-b1f6-441c-8f0f-6c24ab0dedc5', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');

-- ----------------------------
-- Table structure for ClientGrantType
-- ----------------------------
DROP TABLE IF EXISTS `ClientGrantType`;
CREATE TABLE `ClientGrantType`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `GrantType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ClientGrantType_ClientId`(`ClientId`) USING BTREE,
  CONSTRAINT `FK_ClientGrantType_Client_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Client` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ClientGrantType
-- ----------------------------
INSERT INTO `ClientGrantType` VALUES ('08d8869f-b1f2-4253-82bb-89078f7c9cf1', 'implicit', '08d8869f-b1e7-455a-8ce5-fd3801d6d881', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientGrantType` VALUES ('08d8869f-b1f6-497e-812e-0d6109761888', 'password', '08d8869f-b1f6-441c-8f0f-6c24ab0dedc5', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');

-- ----------------------------
-- Table structure for ClientIdPRestriction
-- ----------------------------
DROP TABLE IF EXISTS `ClientIdPRestriction`;
CREATE TABLE `ClientIdPRestriction`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Provider` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ClientIdPRestriction_ClientId`(`ClientId`) USING BTREE,
  CONSTRAINT `FK_ClientIdPRestriction_Client_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Client` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ClientIdPRestriction
-- ----------------------------

-- ----------------------------
-- Table structure for ClientPostLogoutRedirectUri
-- ----------------------------
DROP TABLE IF EXISTS `ClientPostLogoutRedirectUri`;
CREATE TABLE `ClientPostLogoutRedirectUri`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PostLogoutRedirectUri` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ClientPostLogoutRedirectUri_ClientId`(`ClientId`) USING BTREE,
  CONSTRAINT `FK_ClientPostLogoutRedirectUri_Client_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Client` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ClientPostLogoutRedirectUri
-- ----------------------------
INSERT INTO `ClientPostLogoutRedirectUri` VALUES ('08d8869f-b1f4-4b57-8f3f-f5b6f2497718', 'http://localhost:8848', '08d8869f-b1e7-455a-8ce5-fd3801d6d881', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientPostLogoutRedirectUri` VALUES ('08d8869f-b1f5-4551-8d15-0c0b2f2ee2d0', 'https://admin.destinycore.club', '08d8869f-b1e7-455a-8ce5-fd3801d6d881', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientPostLogoutRedirectUri` VALUES ('08d8869f-b1f6-4a12-8910-cf1907318679', 'http://localhost:8080', '08d8869f-b1f6-441c-8f0f-6c24ab0dedc5', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');

-- ----------------------------
-- Table structure for ClientProperty
-- ----------------------------
DROP TABLE IF EXISTS `ClientProperty`;
CREATE TABLE `ClientProperty`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Key` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ClientProperty_ClientId`(`ClientId`) USING BTREE,
  CONSTRAINT `FK_ClientProperty_Client_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Client` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ClientProperty
-- ----------------------------

-- ----------------------------
-- Table structure for ClientRedirectUri
-- ----------------------------
DROP TABLE IF EXISTS `ClientRedirectUri`;
CREATE TABLE `ClientRedirectUri`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RedirectUri` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ClientRedirectUri_ClientId`(`ClientId`) USING BTREE,
  CONSTRAINT `FK_ClientRedirectUri_Client_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Client` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ClientRedirectUri
-- ----------------------------
INSERT INTO `ClientRedirectUri` VALUES ('08d8869f-b1f5-483a-8b67-307e262ffab2', 'http://localhost:8848/callback', '08d8869f-b1e7-455a-8ce5-fd3801d6d881', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientRedirectUri` VALUES ('08d8869f-b1f6-43f9-8429-c7a848d06557', 'https://admin.destinycore.club/callback', '08d8869f-b1e7-455a-8ce5-fd3801d6d881', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientRedirectUri` VALUES ('08d8869f-b1f6-4a2a-8e54-45c198a635f4', 'http://localhost:8080/LoginedCallbackView', '08d8869f-b1f6-441c-8f0f-6c24ab0dedc5', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');

-- ----------------------------
-- Table structure for ClientScope
-- ----------------------------
DROP TABLE IF EXISTS `ClientScope`;
CREATE TABLE `ClientScope`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Scope` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ClientScope_ClientId`(`ClientId`) USING BTREE,
  CONSTRAINT `FK_ClientScope_Client_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Client` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ClientScope
-- ----------------------------
INSERT INTO `ClientScope` VALUES ('08d8869f-b1f2-4f29-82c3-b4cbdf24c3f1', 'openid', '08d8869f-b1e7-455a-8ce5-fd3801d6d881', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientScope` VALUES ('08d8869f-b1f3-4998-864d-f02f80c3b3c3', 'profile', '08d8869f-b1e7-455a-8ce5-fd3801d6d881', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientScope` VALUES ('08d8869f-b1f3-49b1-8a77-93da5ff6a286', 'roles', '08d8869f-b1e7-455a-8ce5-fd3801d6d881', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientScope` VALUES ('08d8869f-b1f3-49c5-8842-ee503e31c4de', 'Destiny.Core.Flow.API', '08d8869f-b1e7-455a-8ce5-fd3801d6d881', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientScope` VALUES ('08d8869f-b1f6-499c-884d-156482e422f2', 'openid', '08d8869f-b1f6-441c-8f0f-6c24ab0dedc5', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientScope` VALUES ('08d8869f-b1f6-49b5-8484-ba28dcba1a72', 'profile', '08d8869f-b1f6-441c-8f0f-6c24ab0dedc5', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientScope` VALUES ('08d8869f-b1f6-49ca-812d-e5b838508f24', 'roles', '08d8869f-b1f6-441c-8f0f-6c24ab0dedc5', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientScope` VALUES ('08d8869f-b1f6-49dd-89ba-254cba63ee21', 'Destiny.Core.Flow.API', '08d8869f-b1f6-441c-8f0f-6c24ab0dedc5', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');

-- ----------------------------
-- Table structure for ClientSecret
-- ----------------------------
DROP TABLE IF EXISTS `ClientSecret`;
CREATE TABLE `ClientSecret`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Expiration` datetime(6) NULL DEFAULT NULL,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Created` datetime(6) NOT NULL,
  `ClientId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_ClientSecret_ClientId`(`ClientId`) USING BTREE,
  CONSTRAINT `FK_ClientSecret_Client_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Client` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of ClientSecret
-- ----------------------------
INSERT INTO `ClientSecret` VALUES ('08d8869f-b1f3-4c91-80ec-c5a091c924df', NULL, 'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=', NULL, 'SharedSecret', '0001-01-01 00:00:00.000000', '08d8869f-b1e7-455a-8ce5-fd3801d6d881', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `ClientSecret` VALUES ('08d8869f-b1f6-49f7-85ca-5875a3f49e3c', NULL, 'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=', NULL, 'SharedSecret', '0001-01-01 00:00:00.000000', '08d8869f-b1f6-441c-8f0f-6c24ab0dedc5', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');

-- ----------------------------
-- Table structure for DataDictionary
-- ----------------------------
DROP TABLE IF EXISTS `DataDictionary`;
CREATE TABLE `DataDictionary`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Title` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Remark` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ParentId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Sort` int(0) NOT NULL DEFAULT 0,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of DataDictionary
-- ----------------------------
INSERT INTO `DataDictionary` VALUES ('08d82351-7a5d-439d-842d-8554e57406b7', 'sad asd as ', 'asd asd ', 'striasdas ng', '00000000-0000-0000-0000-000000000000', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-08 23:13:32.496624', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d82410-187f-4405-841e-ee019e7d120a', '测试2', '我是2号11111是的ad阿萨德阿萨德阿萨德 阿萨德as的', '22222222222222222', '08d82351-7a5d-439d-842d-8554e57406b7', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-09 21:58:02.178406', NULL, '11', '2020-11-22 14:50:40.740756');
INSERT INTO `DataDictionary` VALUES ('08d82662-1d88-4784-8ffc-03a23023abb0', '测试1的二儿子', '我是2号', '2', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-12 20:50:11.704915', NULL, '没得', NULL);
INSERT INTO `DataDictionary` VALUES ('08d82733-e913-4292-8372-193035b29218', 'string', 'string', 'string', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-13 13:51:57.972810', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d82733-fb28-4645-8465-cf7c622fcd65', '121212', '121212', '12121212', '08d82351-7a5d-439d-842d-8554e57406b7', 121212, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-13 13:52:28.345702', NULL, '121212121ds21asd2as1', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83e0b-b964-43d5-821b-9b20479957fa', 'lalalalalalalalalala', 'lalalalalalalalalala', 'lalalalalalalalalala', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-11 23:32:14.863516', NULL, 'lalalalalalalalalala', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83e0c-07f8-400a-8432-0b4ac2d77def', 'lalalalalalalalalala', 'lalalalalalalalalala', 'lalalalalalalalalala', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-11 23:34:26.694373', NULL, 'lalalalalalalalalala', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83e0c-5025-4b19-8e9c-2660d16628a9', 'lalalalalalalalalala', 'lalalalalalalalalala', 'lalalalalalalalalala', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-11 23:36:27.809737', NULL, 'lalalalalalalalalala', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83e0d-1127-4224-84c5-4fed00cefa8e', 'lalalalalalalalalala', 'lalalalalalalalalala', 'lalalalalalalalalala', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-11 23:41:51.600123', NULL, 'lalalalalalalalalala', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83e5d-9df7-4785-82c0-2b2e7499fd6e', 'asd ad w309joiejro934ow4io', 'w309joiejro934ow4io23423o0', 'w309joiejro934ow4io2342', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 09:18:27.603747', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83e5e-5a25-4b5f-8f4f-cb1ed2d997b3', 'asd ad w309joiejro934ow4io', 'w309joiejro934ow4io23423o0', 'w309joiejro934ow4io2342', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 09:23:43.296234', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83e5e-615b-4997-8bc3-2d1e602b256d', 'asd ad w309joiejro934ow4io', 'w309joiejro934ow4io23423o0', 'w309joiejro934ow4io2342', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 09:23:55.415392', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83ec6-6e6e-4ff0-8646-0bd55696c2b4', 'sd asd ', 'strasd asd ing', 'sad asd asd asd asd ', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 21:48:44.995395', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83ec6-c998-41e7-81b3-276718254343', 'asd asd asd asd asd ', 'a sdas dasd asd asd asd ', 'd asd asd asd asd asd asd as', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 21:51:17.938868', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83ec6-e3bb-4da4-8ccc-d988116eb33b', 'asd asd asd asd asd ', 'a sdas dasd asd asd asd ', 'd asd asd asd asd asd asd as', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 21:52:01.810670', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83ec7-0eb8-4ae6-8d1c-e3e86f2118c7', 'asd asd asd asd asd ', 'a sdas dasd asd asd asd ', 'd asd asd asd asd asd asd as', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 21:53:13.915655', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83ec7-44f3-41af-8070-68c9cc8241da', 'asd asd asd asd asd ', 'a sdas dasd asd asd asd ', 'd asd asd asd asd asd asd as', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 21:54:44.894320', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83ec7-d2db-41fc-8448-07f9f5169902', 'asd asd asd asd asd ', 'a sdas dasd asd asd asd ', 'd asd asd asd asd asd asd as', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 21:58:42.973737', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83ec9-f176-4e84-8821-7ea5b923ba99', 'asd asd asd asd asd ', 'a sdas dasd asd asd asd ', 'd asd asd asd asd asd asd as', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 22:13:53.320533', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d83ecd-104b-4be5-89bc-e41ec068e264', 'sdas1 21d 321d32 as1d3as1 d3as1d 3', 'sdas1 21d 321d32 as1d3as1 d3as1d 3', 'sdas1 21d 321d32 as1d3as1 d3as1d 3', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 22:36:13.515646', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d84051-6345-4027-8c19-7dad771cbaad', 'asd asd ad ', 'asd asd as', 'asd asd asd ', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-14 20:55:57.475353', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d84250-3d17-43bb-8a87-ab22367bc036', 'asd a23234', '324234234234', '23423423432', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-17 09:52:46.234748', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d84250-47a3-49e3-8b97-bc0ec9808e84', 'asd a23234', '324234234234', '23423423432', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-17 09:53:03.963992', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d84251-d179-40c9-852d-667084e28d4f', 'asd ad asd as', 'asdas sad as', 'asd asd a ', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-17 10:04:04.679002', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d844a8-1655-434c-8115-08680e4266e3', 'dasd asd as', 'asd asdas ', 'asd asd asd ', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 09:26:39.252256', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d844a9-fddd-44d9-8dc5-d541e351e658', 'strasdasd ing', 'asd asd ', 'asd asd ', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 09:40:17.205382', NULL, 'asd asdas ', NULL);
INSERT INTO `DataDictionary` VALUES ('08d844b9-b14d-4cd6-89d8-363b688ccb51', 'asd as ', 'asd as ', 'asd as ', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 11:32:40.696214', NULL, 'asd as asd ', NULL);
INSERT INTO `DataDictionary` VALUES ('08d844ba-9a95-4351-83fa-9dd8bfdaae9f', 'asd as ', 'asd as ', 'asd as ', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 11:39:12.075651', NULL, 'asd as asd ', NULL);
INSERT INTO `DataDictionary` VALUES ('08d844ba-9fad-44c3-8ee8-15d97acee5d8', 'asd as ', 'asd as ', 'asd as ', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 11:39:20.646018', NULL, 'asd as asd ', NULL);
INSERT INTO `DataDictionary` VALUES ('08d844ba-babc-495f-8462-5ee2f8353fb3', 'asd as ', 'asd as ', 'asd as ', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 11:40:06.035078', NULL, 'asd as asd ', NULL);
INSERT INTO `DataDictionary` VALUES ('08d844bb-6aa6-47e6-80fb-3551f667ee50', 'asd as ', 'asd as ', 'asd as ', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 11:45:01.156304', NULL, 'asd as asd ', NULL);
INSERT INTO `DataDictionary` VALUES ('08d845df-c59a-4164-88c8-7cdfd069300f', 'asdsa das ', 'asd asd as ', 'asd as das ', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-21 22:37:46.797927', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d86445-f1d1-4275-87b2-69ce6a46e03f', 'string', 'string', 'string', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-09-29 15:04:44.493008', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d86446-5a1f-44a3-8a89-48191103dada', 'string', 'string', 'string', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-09-29 15:07:39.540317', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d86446-aba8-4355-8130-b79704e6440e', 'string', 'string', 'string', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-09-29 15:09:56.298778', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d86d15-6625-4fa6-8f64-f7143b7ac16d', 'string', 'string', 'string', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-10-10 20:09:54.833671', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('08d88e28-6aea-4992-8819-bcde88814a4b', '1', '1', '1', '08d82351-7a5d-439d-842d-8554e57406b7', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-21 22:19:11.629404', NULL, '1', NULL);
INSERT INTO `DataDictionary` VALUES ('08d88e28-e101-4593-8cf0-350b8672059a', '测试1', '这是一个测试', '没有', '08d82351-7a5d-439d-842d-8554e57406b7', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-21 22:22:26.906765', NULL, '1', NULL);
INSERT INTO `DataDictionary` VALUES ('3fa85f64-5717-4562-b3fc-2c963f66af11', 'sad', 'asd', 'asda', '00000000-0000-0000-0000-000000000000', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 01:00:07.356933', NULL, 'dfsdf', NULL);
INSERT INTO `DataDictionary` VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6', 'sd ad ad ad d', 'stri asd ad ng', 'asd a das ', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, '00000000-0000-0000-0000-000000000000', '2020-07-06 21:41:57.957079', NULL, 'string', NULL);
INSERT INTO `DataDictionary` VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afcc', 'sfsdf', 'sfsdf', 'sdfds', '00000000-0000-0000-0000-000000000000', 1, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-12 00:03:37.141705', NULL, 'sdf', NULL);

-- ----------------------------
-- Table structure for DeviceFlowCodes
-- ----------------------------
DROP TABLE IF EXISTS `DeviceFlowCodes`;
CREATE TABLE `DeviceFlowCodes`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DeviceCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `UserCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `SubjectId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `SessionId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Expiration` datetime(6) NULL DEFAULT NULL,
  `ConsumedTime` datetime(6) NULL DEFAULT NULL,
  `Data` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of DeviceFlowCodes
-- ----------------------------

-- ----------------------------
-- Table structure for Function
-- ----------------------------
DROP TABLE IF EXISTS `Function`;
CREATE TABLE `Function`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `IsEnabled` tinyint(1) NOT NULL DEFAULT 1,
  `Description` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LinkUrl` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Function
-- ----------------------------
INSERT INTO `Function` VALUES ('08d87dae-18e4-494a-8252-a7eb862c2388', 'dd', 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-31 23:03:16.814736', NULL, 1, 1, '1212', '1212', NULL);
INSERT INTO `Function` VALUES ('08d88652-b0a5-4a6a-833c-2e37ad6990ec', '测试001', 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 23:01:38.175430', NULL, 1, 1, NULL, '测试001', NULL);
INSERT INTO `Function` VALUES ('08d88653-1208-45b5-89f3-9a9f6093845a', 'sdsfs', 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 23:04:21.586279', 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 1, 'sssss', '1212', '2020-11-11 23:04:32.363184');
INSERT INTO `Function` VALUES ('09dc98f3-3824-410f-8d77-ac2c0176d440', '用户管理-异步删除用户', NULL, '2020-09-04 22:44:42.661567', NULL, 0, 1, NULL, 'user/deleteasync', NULL);
INSERT INTO `Function` VALUES ('0c66b541-250c-4f8f-b0f4-ac2c0176d440', '角色管理-异步更新角色', NULL, '2020-09-04 22:44:42.661554', NULL, 0, 1, NULL, 'role/updateasync', NULL);
INSERT INTO `Function` VALUES ('0d5a194b-f9b3-4f29-a2ac-ac2c0176d440', '用户管理-异步加载用户', NULL, '2020-09-04 22:44:42.661569', NULL, 0, 1, NULL, 'user/loadasync', NULL);
INSERT INTO `Function` VALUES ('118c42f7-7d58-4df7-91df-ac2c0176d440', '角色管理-异步创建角色', NULL, '2020-09-04 22:44:42.661552', NULL, 0, 1, NULL, 'role/createasync', NULL);
INSERT INTO `Function` VALUES ('1ccd98a0-98c2-45d0-a134-ac65015cb437', '功能管理-异步创建或更新功能', NULL, '2020-10-31 21:09:35.540062', NULL, 1, 1, NULL, 'function/addorupdateasync', NULL);
INSERT INTO `Function` VALUES ('2951a7a7-fba7-4f5e-9a92-ac6000eaba15', '代码生成器-得到C#类型转成下拉项', NULL, '2020-10-26 14:14:36.868227', NULL, 0, 1, NULL, 'codegenerator/getcsharptypetoselectitem', NULL);
INSERT INTO `Function` VALUES ('29f1c09e-947e-4961-b1e8-ac2c0176d440', '组织架构管理-异步删除组织架构', NULL, '2020-09-04 22:44:42.661539', NULL, 0, 1, NULL, 'organization/deleteasync', NULL);
INSERT INTO `Function` VALUES ('2c4a8e2f-aab6-4a81-80d0-ac6500beb968', '角色管理-异步设置角色菜单', NULL, '2020-10-31 11:34:24.347992', 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 1, '角色管理-异步设置角色菜单', 'role/setrolemenuasync', '2020-10-31 23:03:02.166415');
INSERT INTO `Function` VALUES ('3dee8ffd-1f3c-4105-80c4-ac2c0176d440', '菜单管理-异步得到菜单下的按钮', NULL, '2020-09-04 22:44:42.661526', NULL, 0, 1, NULL, 'menu/getmenuchildrenbuttonasync', NULL);
INSERT INTO `Function` VALUES ('3f5894f2-4414-4051-97b1-ac66014ecc2b', '功能管理-异步创建或更新功能', NULL, '2020-11-01 20:18:57.634187', NULL, 1, 1, NULL, 'function/addorupdateasync', NULL);
INSERT INTO `Function` VALUES ('3fc810cf-c30c-448a-a577-ac2c0176d440', '菜单管理-获取登录用户权限菜单', NULL, '2020-09-04 22:44:42.661528', NULL, 0, 1, NULL, 'menu/getmenulistasync', NULL);
INSERT INTO `Function` VALUES ('45742f74-d765-450f-bd06-ac65016d85cf', '功能管理-异步创建或更新功能', NULL, '2020-10-31 22:10:49.649367', NULL, 1, 1, NULL, 'function/addorupdateasync', NULL);
INSERT INTO `Function` VALUES ('4e9e5e40-10b1-4170-bd99-ac2c0176d440', '菜单管理-异步到菜单功能集合', NULL, '2020-09-04 22:44:42.661531', NULL, 1, 1, NULL, 'menu/getmenufunctionlistasync', NULL);
INSERT INTO `Function` VALUES ('4ec2ea42-9d19-48b3-9217-ac7100871cc6', '组织架构管理-异步得到组织架构分页数据', NULL, '2020-11-12 08:11:55.754553', NULL, 0, 1, NULL, 'organization/getpageorganizationasync', NULL);
INSERT INTO `Function` VALUES ('5cf76b4a-ce23-4a1d-a071-ac2c0176d440', '用户管理-异步得到分页', NULL, '2020-09-04 22:44:42.661571', NULL, 0, 1, NULL, 'user/getuserpageasync', NULL);
INSERT INTO `Function` VALUES ('5db63e92-2520-4072-a34d-ac7100871cc6', '组织架构管理-获取组织架构', NULL, '2020-11-12 08:11:55.754548', NULL, 0, 1, NULL, 'organization/getorganizationtreeasync', NULL);
INSERT INTO `Function` VALUES ('62155e9c-48e9-4b52-a04f-ac2c0176d440', '菜单管理-根据登录账号获取菜单', NULL, '2020-09-04 22:44:42.661520', NULL, 0, 1, NULL, 'menu/getmenuasync', NULL);
INSERT INTO `Function` VALUES ('6631dbc0-4ae2-4081-b22c-ac69015bd28b', '菜单功能-批量添加功能菜单', NULL, '2020-11-04 21:06:22.970216', NULL, 0, 1, NULL, 'menufunction/batchaddmenufunctionasync', NULL);
INSERT INTO `Function` VALUES ('67cb5baa-11fc-4e6e-9e00-ac67014d67c5', '功能管理-异步创建或更新功能', NULL, '2020-11-02 20:13:53.505957', NULL, 0, 1, NULL, 'function/addorupdateasync', NULL);
INSERT INTO `Function` VALUES ('7633becd-2b7e-463c-9430-ac6000eaba15', '用户管理-用户分配角色', NULL, '2020-10-26 14:14:36.868232', NULL, 0, 1, NULL, 'user/allocationroleasync', NULL);
INSERT INTO `Function` VALUES ('765545fa-f77f-434c-b8f0-ac2c0176d440', '功能管理-异步创建功能', NULL, '2020-09-04 22:44:42.661496', NULL, 0, 1, NULL, 'function/createasync', NULL);
INSERT INTO `Function` VALUES ('765852f3-faf4-4ab8-b2c2-ac2c0176d440', '功能管理-异步获取功能下拉框列表', NULL, '2020-09-04 22:44:42.661507', NULL, 0, 1, NULL, 'function/getfunctionselectlistitemasync', NULL);
INSERT INTO `Function` VALUES ('76c79539-e581-4d53-b5bb-ac2c0176d440', '数据字典-异步删除数据字典', NULL, '2020-09-04 22:44:42.661489', NULL, 0, 1, NULL, 'datadictionary/deleteasyc', NULL);
INSERT INTO `Function` VALUES ('7bcb4ca3-e859-4ced-8fe0-ac69015bd28b', '用户管理-异步得到所有用户', NULL, '2020-11-04 21:06:22.970296', NULL, 0, 1, NULL, 'user/getusersasync', NULL);
INSERT INTO `Function` VALUES ('867155d3-a3ca-4cb8-b13c-ac2c0176d440', '数据字典-修改一个数据字典', NULL, '2020-09-04 22:44:42.661485', NULL, 0, 1, NULL, 'datadictionary/updateasync', NULL);
INSERT INTO `Function` VALUES ('87f92ad7-d1bd-4a2f-9998-ac2c0176d440', '组织架构管理-获取组织架构', NULL, '2020-09-04 22:44:42.661533', NULL, 1, 1, NULL, 'organization/getasync', NULL);
INSERT INTO `Function` VALUES ('8c583e7b-ca86-4ae3-98c0-ac65015cb437', '功能管理-异步加载功能', NULL, '2020-10-31 21:09:35.540031', NULL, 1, 1, NULL, 'function/loadasync', NULL);
INSERT INTO `Function` VALUES ('8c5aee5e-0466-4f01-bcf0-ac2c0176d440', '菜单管理-添加菜单', NULL, '2020-09-04 22:44:42.661512', NULL, 0, 1, NULL, 'menu/addmenuasync', NULL);
INSERT INTO `Function` VALUES ('90a05dd2-aa52-40cb-a30c-ac2c0176d440', '菜单管理-修改菜单', NULL, '2020-09-04 22:44:42.661514', NULL, 0, 1, NULL, 'menu/updatemenuasync', NULL);
INSERT INTO `Function` VALUES ('90e36b1e-2cf0-442d-b260-ac2c0176d440', '角色管理-异步删除角色', NULL, '2020-09-04 22:44:42.661556', NULL, 0, 1, NULL, 'role/deleteasync', NULL);
INSERT INTO `Function` VALUES ('9210c150-0e02-4bd2-8e44-ac2c0176d440', '菜单管理-登录成功之后获取用户菜单树', NULL, '2020-09-04 22:44:42.661522', NULL, 1, 1, NULL, 'menu/getusermenutreeasync', NULL);
INSERT INTO `Function` VALUES ('94d0e63e-04e8-4206-8380-ac2c0176d440', '菜单管理-删除菜单', NULL, '2020-09-04 22:44:42.661516', NULL, 0, 1, NULL, 'menu/deleteasync', NULL);
INSERT INTO `Function` VALUES ('959745a0-9bf0-446f-975c-ac2c0176d440', '权限管理-异步得到权限集合', NULL, '2020-09-04 22:44:42.661541', NULL, 0, 1, NULL, 'permission/getpermissionlistasync', NULL);
INSERT INTO `Function` VALUES ('96b8d267-5cc6-489b-8558-ac7100871cc6', '组织架构管理-表单加载组织架构', NULL, '2020-11-12 08:11:55.754551', NULL, 0, 1, NULL, 'organization/loadformorganizationasync', NULL);
INSERT INTO `Function` VALUES ('99c943dd-1482-45f3-913e-ac2c0176d440', '功能管理-异步更新功能', NULL, '2020-09-04 22:44:42.661498', NULL, 0, 1, NULL, 'function/updateasync', NULL);
INSERT INTO `Function` VALUES ('a2d1c6ad-3e09-4035-a4a7-ac67014d67c5', '功能管理-异步加载功能', NULL, '2020-11-02 20:13:53.505934', NULL, 0, 1, NULL, 'function/loadasync', NULL);
INSERT INTO `Function` VALUES ('a2e962c4-7a09-4e6a-9703-ac2c0176d440', '数据字典-分页获取数据字典', NULL, '2020-09-04 22:44:42.661468', NULL, 0, 1, NULL, 'datadictionary/getpagelistasync', NULL);
INSERT INTO `Function` VALUES ('a3b4da8d-5536-4001-ab64-ac2c0176d440', '用户管理-异步创建用户', NULL, '2020-09-04 22:44:42.661562', NULL, 0, 1, NULL, 'user/createasync', NULL);
INSERT INTO `Function` VALUES ('a6cf7520-dcdd-4ab3-b8f1-ac2c0176d440', '组织架构管理-异步创建组织架构', NULL, '2020-09-04 22:44:42.661535', NULL, 0, 1, NULL, 'organization/createasync', NULL);
INSERT INTO `Function` VALUES ('a855299f-4021-4ed5-8b76-ac2c0176d440', '用户管理-异步更新用户', NULL, '2020-09-04 22:44:42.661565', NULL, 0, 1, NULL, 'user/updateasync', NULL);
INSERT INTO `Function` VALUES ('ac94955b-1818-4a74-8e90-ac2c0176d440', '数据字典-根据id获取数据字典详情', NULL, '2020-09-04 22:44:42.661494', NULL, 0, 1, NULL, 'datadictionary/getdatadictionnnarylistasync', NULL);
INSERT INTO `Function` VALUES ('aed9b271-7c06-4ae9-98e9-ac69015bd28b', '菜单功能-根据菜单ID得到菜单功能分页', NULL, '2020-11-04 21:06:22.970293', NULL, 0, 1, NULL, 'menufunction/getmenufunctionbymenuidpageasync', NULL);
INSERT INTO `Function` VALUES ('b97a7c88-8ff6-4f4e-bde8-ac2c0176d440', '数据字典-异步查询数据字典', NULL, '2020-09-04 22:44:42.661492', NULL, 0, 1, NULL, 'datadictionary/gettableasync', NULL);
INSERT INTO `Function` VALUES ('b9c764fc-b409-4dd6-b8d2-ac7100871cc6', '用户管理-获取所有用户列表', NULL, '2020-11-12 08:11:55.754555', NULL, 0, 1, NULL, 'user/getuserstoselectlistitemasync', NULL);
INSERT INTO `Function` VALUES ('ba275142-01e5-4621-b822-ac2c0176d440', '菜单管理-异步得到菜单树数据', NULL, '2020-09-04 22:44:42.661524', NULL, 0, 1, NULL, 'menu/getmenutreeasync', NULL);
INSERT INTO `Function` VALUES ('c07f91d6-a3c3-4568-956f-ac65016d85cf', '功能管理-异步加载功能', NULL, '2020-10-31 22:10:49.649328', NULL, 1, 1, NULL, 'function/loadasync', NULL);
INSERT INTO `Function` VALUES ('c1355fa8-da88-4430-8bb5-ac6500beb968', '菜单管理-异步得到所有菜单', NULL, '2020-10-31 11:34:24.347987', NULL, 0, 1, NULL, 'menu/getallmenutreeasync', '2020-11-02 20:13:53.893333');
INSERT INTO `Function` VALUES ('c2d45602-939b-4724-a18e-ac6000eaba15', '身份管理-更改密码', NULL, '2020-10-26 14:14:36.868230', NULL, 0, 1, NULL, 'identity/changepassword', NULL);
INSERT INTO `Function` VALUES ('c5387a19-59e9-4ec4-a5a1-ac66014ecc2b', '功能管理-异步加载功能', NULL, '2020-11-01 20:18:57.634165', NULL, 1, 1, NULL, 'function/loadasync', NULL);
INSERT INTO `Function` VALUES ('c60a6d1c-a76d-4543-a266-ac2c0176d440', '数据字典-异步创建数据字典', NULL, '2020-09-04 22:44:42.661487', NULL, 0, 1, NULL, 'datadictionary/createasync', NULL);
INSERT INTO `Function` VALUES ('cbb3626a-ded7-4f11-a8ec-ac6000eaba15', '代码生成器-代码生成', NULL, '2020-10-26 14:14:36.868187', NULL, 0, 1, NULL, 'codegenerator/generatecode', NULL);
INSERT INTO `Function` VALUES ('d726e21a-2116-4cc8-94c5-ac6500beb968', '菜单管理-异步得到菜单分页数据', NULL, '2020-10-31 11:34:24.347901', NULL, 0, 1, NULL, 'menu/getmenupageasync', NULL);
INSERT INTO `Function` VALUES ('dbee031f-3100-494b-ab6d-ac2c0176d440', '角色管理-异步创建或添加角色', NULL, '2020-09-04 22:44:42.661558', NULL, 0, 1, NULL, 'role/addorupdateasync', NULL);
INSERT INTO `Function` VALUES ('dc8bdf59-1827-4e1a-8067-ac2c0176d440', '功能管理-异步删除功能', NULL, '2020-09-04 22:44:42.661500', NULL, 0, 1, NULL, 'function/deleteasync', NULL);
INSERT INTO `Function` VALUES ('e0f91cab-ba4f-470d-a0c6-ac650183e2e1', '功能管理-异步创建或更新功能', NULL, '2020-10-31 23:32:15.039554', NULL, 1, 1, NULL, 'function/addorupdateasync', NULL);
INSERT INTO `Function` VALUES ('e3147913-003e-4cec-af12-ac2c0176d440', '菜单管理-获取表格菜单信息', NULL, '2020-09-04 22:44:42.661509', NULL, 0, 1, NULL, 'menu/gettableasync', NULL);
INSERT INTO `Function` VALUES ('e474363a-292c-4014-b68e-ac2c0176d440', '组织架构管理-异步修改组织架构', NULL, '2020-09-04 22:44:42.661537', NULL, 0, 1, NULL, 'organization/updateasync', NULL);
INSERT INTO `Function` VALUES ('e50ca2ec-4caa-46fb-823a-ac7100871cc6', '菜单管理-获取Vue动态路由菜单', NULL, '2020-11-12 08:11:55.754524', NULL, 0, 1, NULL, 'menu/getvuedynamicroutertreeasync', NULL);
INSERT INTO `Function` VALUES ('e82440de-6d62-4eb8-a052-ac2c0176d440', '菜单管理-获取一个菜单', NULL, '2020-09-04 22:44:42.661518', NULL, 0, 1, NULL, 'menu/loadformmenuasync', NULL);
INSERT INTO `Function` VALUES ('eb1bc3f5-014c-4399-8982-ac2c0176d440', '功能管理-异步得到功能分页', NULL, '2020-09-04 22:44:42.661505', NULL, 0, 1, NULL, 'function/getfunctionpageasync', NULL);
INSERT INTO `Function` VALUES ('eca617ad-bedf-4bd2-8999-ac2c0176d440', '角色管理-异步得到角色下拉数据', NULL, '2020-09-04 22:44:42.661560', NULL, 0, 1, NULL, 'role/getroleselectlistasync', NULL);
INSERT INTO `Function` VALUES ('ed9f3b62-eadb-42b3-86a8-ac650183e2e0', '功能管理-异步加载功能', NULL, '2020-10-31 23:32:15.039522', NULL, 1, 1, NULL, 'function/loadasync', NULL);
INSERT INTO `Function` VALUES ('ef241596-b9b4-474a-ba25-ac69015bd28b', '菜单功能-批量删除功能菜单', NULL, '2020-11-04 21:06:22.970287', NULL, 0, 1, NULL, 'menufunction/batchdeletemenufunctionasync', NULL);
INSERT INTO `Function` VALUES ('f16dc63b-5958-4fef-9c74-ac2c0176d440', '角色管理-异步得到角色分页', NULL, '2020-09-04 22:44:42.661543', NULL, 0, 1, NULL, 'role/getrolepageasync', NULL);

-- ----------------------------
-- Table structure for IdentityResource
-- ----------------------------
DROP TABLE IF EXISTS `IdentityResource`;
CREATE TABLE `IdentityResource`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Enabled` tinyint(1) NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `DisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ShowInDiscoveryDocument` tinyint(1) NOT NULL,
  `Required` tinyint(1) NOT NULL,
  `Emphasize` tinyint(1) NOT NULL,
  `NonEditable` tinyint(1) NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of IdentityResource
-- ----------------------------
INSERT INTO `IdentityResource` VALUES ('08d8869f-b27c-48d9-8426-89f7ee384c52', 1, 'openid', 'Your user identifier', NULL, 1, 1, 0, 0, NULL, NULL, 0, NULL, '2020-11-12 08:12:52.534946');
INSERT INTO `IdentityResource` VALUES ('08d8869f-b27e-4860-8e98-cfbc5b2678fe', 1, 'profile', 'User profile', 'Your user profile information (first name, last name, etc.)', 1, 0, 1, 0, NULL, NULL, 0, NULL, '2020-11-12 08:12:52.534951');
INSERT INTO `IdentityResource` VALUES ('08d8869f-b27e-49a5-8e0b-728a713c05e6', 1, 'roles', '角色', NULL, 1, 0, 0, 0, NULL, NULL, 0, NULL, '2020-11-12 08:12:52.534953');

-- ----------------------------
-- Table structure for IdentityResourceClaim
-- ----------------------------
DROP TABLE IF EXISTS `IdentityResourceClaim`;
CREATE TABLE `IdentityResourceClaim`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `IdentityResourceId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_IdentityResourceClaim_IdentityResourceId`(`IdentityResourceId`) USING BTREE,
  CONSTRAINT `FK_IdentityResourceClaim_IdentityResource_IdentityResourceId` FOREIGN KEY (`IdentityResourceId`) REFERENCES `IdentityResource` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of IdentityResourceClaim
-- ----------------------------
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27d-4dfc-8d09-367ccd8ad175', 'sub', '08d8869f-b27c-48d9-8426-89f7ee384c52', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-4888-8233-d7e468bb1a70', 'name', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-489f-8e5e-0515a8e37d95', 'family_name', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-48b4-8b98-63d94ad1ab42', 'given_name', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-48c8-882a-ccbb737972ce', 'middle_name', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-48dd-8853-ba91cdd95baa', 'nickname', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-48f1-8d69-29fd293ba24e', 'preferred_username', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-4904-8c67-11453a0c4e87', 'profile', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-4920-8184-f35c2e5c24cd', 'picture', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-4933-8939-8f1f4594685a', 'website', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-4947-802c-558c9f9f24c4', 'gender', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-495b-8033-916a2995aae5', 'birthdate', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-496e-8190-de50505db14b', 'zoneinfo', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-4981-8ac7-da688f5b4b00', 'locale', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-4994-8d74-b1c9b22e39da', 'updated_at', '08d8869f-b27e-4860-8e98-cfbc5b2678fe', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');
INSERT INTO `IdentityResourceClaim` VALUES ('08d8869f-b27e-49bc-86e4-397e22de917e', 'role', '08d8869f-b27e-49a5-8e0b-728a713c05e6', NULL, NULL, 0, NULL, '0001-01-01 00:00:00.000000');

-- ----------------------------
-- Table structure for IdentityResourceProperty
-- ----------------------------
DROP TABLE IF EXISTS `IdentityResourceProperty`;
CREATE TABLE `IdentityResourceProperty`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Key` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `IdentityResourceId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_IdentityResourceProperty_IdentityResourceId`(`IdentityResourceId`) USING BTREE,
  CONSTRAINT `FK_IdentityResourceProperty_IdentityResource_IdentityResourceId` FOREIGN KEY (`IdentityResourceId`) REFERENCES `IdentityResource` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of IdentityResourceProperty
-- ----------------------------

-- ----------------------------
-- Table structure for Menu
-- ----------------------------
DROP TABLE IF EXISTS `Menu`;
CREATE TABLE `Menu`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Sort` int(0) NOT NULL DEFAULT 0,
  `Path` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ParentId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
  `Icon` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ParentNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Component` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Depth` int(0) NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  `Type` int(0) NOT NULL DEFAULT 0,
  `Redirect` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `EventName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsHide` tinyint(1) NOT NULL DEFAULT 0,
  `Layout` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Menu
-- ----------------------------
INSERT INTO `Menu` VALUES ('08d815d8-868f-45cc-8fdf-0dff5acac7fc', '角色管理', 2, '/identity/role', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', '的撒所大所多撒as', '角色管理', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', 'identity/role-managerment/role-managerment', 2, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-21 19:44:58.737444', 0, '', '2020-11-18 00:11:01.020794', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d815d8-dae5-4891-83d3-38a134d63506', '菜单管理', 3, '/identity/menu', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', '`', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', 'identity/menu-managerment/menu-managerment', 2, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-21 19:47:20.251803', 0, '', '2020-11-18 00:11:14.582277', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d815d8-f67c-4299-8d3a-c3243fcb5bc7', '功能管理', 4, '/identity/function', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', '`', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', 'identity/function-managerment/function-managerment', 2, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-21 19:48:06.537129', 0, '', '2020-11-18 00:11:18.747106', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d81dd2-dc25-4ffa-8518-4b28558ba714', '添加', 1, 'add', '08d815d8-868f-45cc-8fdf-0dff5acac7fc', 'primary', '阿萨德啊的', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc', 'add', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-01 23:24:34.673598', 5, '', '2020-11-18 21:00:40.798989', 'handleAdd', 0, NULL);
INSERT INTO `Menu` VALUES ('08d83c69-a522-4175-8e0c-5efc57fd6456', '修改', 2, 'update', '08d815d8-868f-45cc-8fdf-0dff5acac7fc', 'Default', 'as as as sa', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc', 'dasda', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-09 21:39:31.249951', 5, '', '2020-11-18 21:00:54.917267', 'handleUpdate', 0, NULL);
INSERT INTO `Menu` VALUES ('08d83d35-9456-4c13-8004-ff7f8e3fe2e9', '用户管理', 1, '/identity/user', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', '1', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', 'identity/user-managerment/user-managerment', 2, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-10 21:59:20.419133', 0, '', '2020-11-18 00:09:28.522671', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d84375-234a-48c6-83e8-36b6134f4439', '修改', 1, 'update', '08d815d8-dae5-4891-83d3-38a134d63506', 'primary', '', NULL, 'update', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-18 20:49:25.474778', 5, '', NULL, NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d84376-acc6-4924-8116-9d7af9ea87ce', '添加', 2, 'add', '08d815d8-dae5-4891-83d3-38a134d63506', 'primary', '', NULL, 'add', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-18 21:00:25.681216', 5, '', '2020-11-08 04:25:45.508668', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d84378-a754-4829-8ab2-83d25ab2a125', '添加子级', 3, 'addchildren', '08d815d8-dae5-4891-83d3-38a134d63506', 'primary', '', NULL, 'addchildren', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-18 21:14:35.539319', 5, '', NULL, NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d84379-988d-4ff9-8f47-db14075addc2', '添加', 6, 'add', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7', 'primary', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-f67c-4299-8d3a-c3243fcb5bc7', 'add', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-18 21:21:20.246992', 5, '', '2020-11-18 23:30:33.413592', 'handleAdd', 0, NULL);
INSERT INTO `Menu` VALUES ('08d84379-a770-4ab0-8882-d65fe6996556', '修改', 2, 'update', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7', 'primary', '', NULL, 'update', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-18 21:21:45.220593', 5, '', NULL, NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d8437d-752a-4633-8ad9-f1e44f005b8d', '查看功能', 2, 'select', '08d815d8-dae5-4891-83d3-38a134d63506', 'primary', '', NULL, 'select', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-18 21:48:58.860798', 5, '', NULL, NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d8444f-875e-4a45-861d-f12dbb72c463', '添加', 2, 'add', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9', 'primary', 'asdsad asd asd ', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9', 'primary', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-19 22:52:43.677207', 5, '', '2020-11-18 21:05:39.819116', 'handleAdd', 0, NULL);
INSERT INTO `Menu` VALUES ('08d84450-4c1f-4f06-8652-ab6a2c1c888f', '修改', 3, 'update', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9', 'primary', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9', 'primary', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-19 22:58:13.814788', 5, '', '2020-11-18 21:06:05.728496', 'handleUpdate', 0, NULL);
INSERT INTO `Menu` VALUES ('08d84450-78cf-499b-897c-56a4304f139f', '删除', 4, 'delete', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9', 'primary', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9', 'primary', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-19 22:59:28.786665', 5, '', '2020-11-18 23:22:28.285126', 'handleDelete', 0, NULL);
INSERT INTO `Menu` VALUES ('08d86484-8c20-4aa8-8a80-1ecb288beabc', '代码生成器管理', 5, '/system/codeGenerator', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', 'primary', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', 'system/code-generator-managerment/code-generator', 2, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-29 22:32:52.232384', 0, '', '2020-11-18 00:11:23.982273', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d87f24-eb03-460c-8bf0-c04b595214f0', '测试菜单9', 4449, '1119', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', '3339', '5559', NULL, '2229', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-02 19:46:21.116492', 5, '', '2020-11-02 22:32:08.537563', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d87f3d-af0a-4b21-8560-00f12f32b1c4', '顶级菜单', 0, '', '00000000-0000-0000-0000-000000000000', '', '', NULL, '', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-02 22:43:37.933472', 0, '', NULL, NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d87f3d-d022-4e91-871a-a7465821647b', '子', 0, '', '08d87f3d-af0a-4b21-8560-00f12f32b1c4', '', '', NULL, '', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-02 22:44:33.459916', 0, '', NULL, NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d87f40-8a48-4e2d-8a7b-af6d885c3ae6', '测试菜单', 0, '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', '', '', NULL, '', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-02 23:04:04.758874', 0, '', NULL, NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d87f41-bb8b-4571-85ab-a8128b61761a', '顶级菜单', 0, '', '00000000-0000-0000-0000-000000000000', '', '', NULL, '', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-02 23:12:36.861356', 0, '', NULL, NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d87f4d-3c74-45ad-89ce-97f8ad9ac389', '超级顶级菜单', 0, '', '00000000-0000-0000-0000-000000000000', '', '', NULL, '', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-03 00:34:57.638993', 0, '', NULL, NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d87ffe-50db-4b11-8ffa-55602e216862', '操作审计', 1, '/system/auditlog', '08d88645-31bd-42e5-8211-753786aaf90b', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88645-31bd-42e5-8211-753786aaf90b', 'system/audit-log-managerment/audit-log-managerment', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-03 21:42:32.631701', 0, '', '2020-11-18 00:20:02.925575', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d87ffe-c251-4779-8054-15c04038a8f1', '数据审计', 2, '/system/auditentry', '08d88645-31bd-42e5-8211-753786aaf90b', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88645-31bd-42e5-8211-753786aaf90b', 'system/audit-entry-managerment/audit-entry-managerment', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-03 21:45:43.145133', 0, '', '2020-11-18 00:20:11.891057', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d8835a-97b2-44ac-8b53-31dd9226b33c', '测试菜单', 0, '11', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9', '33', '44444', NULL, '22', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-08 04:20:38.816373', 0, '', NULL, NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d8835a-be60-46a2-8c50-5599eb14ca25', '测试菜单', 1, '11', '08d815d8-dae5-4891-83d3-38a134d63506', '11', '11', NULL, '11', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-08 04:21:43.720334', 0, '', '2020-11-08 04:22:08.866258', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d88594-14ae-4de2-8e55-dfdf1e41e40d', '用户分配角色', 5, '', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:17:12.157462', 5, '', '2020-11-18 21:06:43.414317', 'allocationRole', 0, NULL);
INSERT INTO `Menu` VALUES ('08d88595-506f-4b2b-8583-fe22dddb3fed', '查询', 1, '', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:26:01.904283', 5, '', '2020-11-18 00:27:56.172916', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d88596-cb6b-43e1-84fb-b5a0a194e545', '删除', 3, '', '08d815d8-868f-45cc-8fdf-0dff5acac7fc', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:36:37.731635', 5, '', '2020-11-18 21:01:20.998871', 'handleDelete', 0, NULL);
INSERT INTO `Menu` VALUES ('08d88597-6b34-4f44-8261-dcfa2736e8fe', '查询', 5, '', '08d815d8-868f-45cc-8fdf-0dff5acac7fc', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:41:05.811309', 5, '', '2020-11-18 00:17:09.798933', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d88597-a9d2-467d-84cf-73ed0f9c04d3', '修改', 7, '', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-f67c-4299-8d3a-c3243fcb5bc7', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:42:50.861918', 5, '', '2020-11-18 23:32:41.591935', 'handleUpdate', 0, NULL);
INSERT INTO `Menu` VALUES ('08d88597-eb63-428c-8422-9480fc807c31', '查询', 8, '', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-f67c-4299-8d3a-c3243fcb5bc7', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:44:40.862436', 5, '', '2020-11-18 00:17:50.364639', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d88598-3180-446c-8a9f-79af05025956', '生成代码', 9, '', '08d86484-8c20-4aa8-8a80-1ecb288beabc', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d86484-8c20-4aa8-8a80-1ecb288beabc', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:46:38.493800', 5, '', '2020-11-18 20:56:55.964996', 'save', 0, NULL);
INSERT INTO `Menu` VALUES ('08d88598-4b78-42f3-86e2-a6602135964b', '查询', 10, '', '08d87ffe-50db-4b11-8ffa-55602e216862', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88645-31bd-42e5-8211-753786aaf90b.08d87ffe-50db-4b11-8ffa-55602e216862', '', 4, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:47:22.061517', 5, '', '2020-11-18 00:22:44.107364', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d88598-7120-46ab-85b4-a7f40af04d3a', '查询', 11, '', '08d87ffe-c251-4779-8054-15c04038a8f1', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88645-31bd-42e5-8211-753786aaf90b.08d87ffe-c251-4779-8054-15c04038a8f1', '', 4, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:48:25.239778', 5, '', '2020-11-18 00:20:44.692080', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d88598-8230-4d89-892b-e8d34ea95e9a', '组织架构', 7, '/system/organization', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', 'identity/organization-managerment/organization-managerment', 2, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:48:53.868710', 0, '', '2020-11-18 00:11:34.620305', NULL, 0, NULL);
INSERT INTO `Menu` VALUES ('08d88598-b792-4bba-850e-0a15a2644a1c', '分配权限', 4, '', '08d815d8-868f-45cc-8fdf-0dff5acac7fc', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:50:23.429461', 5, '', '2020-11-18 21:01:33.535338', 'handleAuth', 0, NULL);
INSERT INTO `Menu` VALUES ('08d88645-31bd-42e5-8211-753786aaf90b', '审计管理', 5, '/layout-empty', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', '', 2, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 21:25:01.776495', 0, '', '2020-11-18 00:19:05.848639', NULL, 0, '/layout');
INSERT INTO `Menu` VALUES ('08d8896e-5fb8-447e-86ce-d3e1548f65f0', '数据字典', 8, '/system/dictionary', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', 'system/data-dictionary-managerment/data-dictionary-managerment', 2, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 21:57:21.787218', 0, NULL, '2020-11-18 00:11:39.062405', '', 0, '');
INSERT INTO `Menu` VALUES ('08d88973-2861-4537-8923-194afb2d213c', '查询菜单树', 0, '', '08d815d8-dae5-4891-83d3-38a134d63506', '', '', NULL, '', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 22:31:36.437478', 0, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88973-3848-4139-8979-50ba65aa6985', '查询菜单树', 0, '', '08d815d8-dae5-4891-83d3-38a134d63506', '', '', NULL, '', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 22:32:03.140933', 5, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88973-4ebe-43b6-83fd-d1343e3c3db3', '查询菜单分页表格', 0, '', '08d815d8-dae5-4891-83d3-38a134d63506', '', '', NULL, '', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 22:32:40.825658', 5, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88973-93b1-4093-889d-97bedabc2233', '菜单添加', 0, '', '08d815d8-dae5-4891-83d3-38a134d63506', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 22:34:36.501796', 5, NULL, '2020-11-18 23:38:07.983597', 'handleAddTreeMenu', 0, '');
INSERT INTO `Menu` VALUES ('08d88973-9a33-4a25-8252-e8bff2507cfb', '修改菜单', 0, '', '08d815d8-dae5-4891-83d3-38a134d63506', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 22:34:47.424111', 5, NULL, '2020-11-18 23:38:29.295851', 'handleEditTreeMenu', 0, '');
INSERT INTO `Menu` VALUES ('08d88973-a35e-4936-84cf-7d8a715f12d2', '删除菜单', 0, '', '08d815d8-dae5-4891-83d3-38a134d63506', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 22:35:02.805065', 5, NULL, '2020-11-18 23:38:56.669868', 'handleDeleteTreeMenu', 0, '');
INSERT INTO `Menu` VALUES ('08d88b06-c494-477c-89c2-a40c2f406eb4', '测试', 5, '', '00000000-0000-0000-0000-000000000000', '', '', NULL, '', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-17 22:40:45.154723', 0, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88b11-dd48-4eb6-80d2-2348cb7c9229', '测试1100', 0, '', '00000000-0000-0000-0000-000000000000', '', '', NULL, '', 1, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 00:00:11.590405', 0, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88b11-ef3a-40ea-8bcf-7769b6fd295a', '测试2000', 0, '', '08d88b11-dd48-4eb6-80d2-2348cb7c9229', '', '', NULL, '', 2, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 00:00:41.718260', 0, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88b12-0cf1-4822-8ef6-d6cb3bd00cac', '测试3000', 10, '', '08d88b11-ef3a-40ea-8bcf-7769b6fd295a', '', '', NULL, '', 3, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 00:01:31.574945', 0, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88b12-386a-4ac9-8876-26ac352ce412', '测试4000', 0, '', '08d88b12-0cf1-4822-8ef6-d6cb3bd00cac', '', '', NULL, '', 4, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 00:02:44.511037', 0, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88b12-49e2-4921-87d3-08cf62180851', '测试40001', 0, '', '08d88b12-0cf1-4822-8ef6-d6cb3bd00cac', '', '', NULL, '', 4, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 00:03:13.818131', 5, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88b12-63df-4c3c-82fa-37ca19168c34', '测试2220', 0, '', '08d88b11-dd48-4eb6-80d2-2348cb7c9229', '', '', NULL, '', 2, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 00:03:57.420501', 0, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88b12-762b-4d04-8bf1-e73104b8f2d9', '测试2221', 0, '', '08d88b11-dd48-4eb6-80d2-2348cb7c9229', '', '', NULL, '', 2, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 00:04:28.117761', 0, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88bd7-2037-4b83-8204-31e2cf867fc3', '删除', 0, 'handleDelete', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-f67c-4299-8d3a-c3243fcb5bc7', '', 3, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:32:14.742525', 5, NULL, NULL, 'handleDelete', 0, '');
INSERT INTO `Menu` VALUES ('08d88bd8-177c-40fe-82b6-e4e6484f7c95', '添加功能', 0, '', '08d815d8-dae5-4891-83d3-38a134d63506', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:39:09.611987', 5, NULL, '2020-11-18 23:40:06.676621', 'handleAddMenuFunction', 0, '');
INSERT INTO `Menu` VALUES ('08d88bd8-4bc8-4952-8603-1c232987ce0b', '编辑功能', 0, '', '08d815d8-dae5-4891-83d3-38a134d63506', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:40:37.355672', 5, NULL, '2020-11-18 23:41:16.225731', 'handleEditMenuFunction', 0, '');
INSERT INTO `Menu` VALUES ('08d88bd8-87b6-4737-8f8b-2778c807fe43', '删除功能', 0, '', '08d815d8-dae5-4891-83d3-38a134d63506', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', '', 3, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:42:17.899412', 5, NULL, NULL, 'handleDeleteMenuFunction', 0, '');
INSERT INTO `Menu` VALUES ('08d88bd8-a84f-434e-8e97-255bab78ccf2', '分配菜单功能', 0, '', '08d815d8-dae5-4891-83d3-38a134d63506', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', '', 3, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:43:12.588252', 5, NULL, NULL, 'showAddMenuFunction', 0, '');
INSERT INTO `Menu` VALUES ('08d88bd9-5550-4db7-8ee9-0fc027e5b289', '添加组织机构树', 0, '', '08d88598-8230-4d89-892b-e8d34ea95e9a', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:48:02.844960', 5, NULL, '2020-11-18 23:53:11.719847', 'handleAddTree', 0, '');
INSERT INTO `Menu` VALUES ('08d88bd9-66e3-4001-8b57-bd83187c2bfc', '更新组织机构树', 0, '', '08d88598-8230-4d89-892b-e8d34ea95e9a', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', '', 3, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:48:32.323998', 5, NULL, NULL, 'handleEditTree', 0, '');
INSERT INTO `Menu` VALUES ('08d88bd9-8bb4-45ae-83a3-79c4c7949a22', '删除组织架构树', 0, '', '08d88598-8230-4d89-892b-e8d34ea95e9a', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', '', 3, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:49:34.094016', 5, NULL, '2020-11-18 23:59:07.505076', 'handleDeleteTree', 0, '');
INSERT INTO `Menu` VALUES ('08d88bd9-ac4f-4261-8fd2-743db9af6739', '添加', 0, '', '08d88598-8230-4d89-892b-e8d34ea95e9a', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', '', 3, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:50:28.795558', 5, NULL, NULL, 'handleAdd', 0, '');
INSERT INTO `Menu` VALUES ('08d88bd9-bb50-4e9c-8669-3393abe8d475', '修改', 0, '', '08d88598-8230-4d89-892b-e8d34ea95e9a', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', '', 3, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:50:53.972913', 5, NULL, NULL, 'handleUpdate', 0, '');
INSERT INTO `Menu` VALUES ('08d88bd9-cdfc-48a6-8958-bef859429e8e', '删除', 0, '', '08d88598-8230-4d89-892b-e8d34ea95e9a', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', '', 3, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:51:25.296708', 5, NULL, NULL, 'handleDelete', 0, '');
INSERT INTO `Menu` VALUES ('08d88bda-448c-42e7-8f54-2cf879cd1ad5', '查询菜单功能', 0, '', '08d815d8-dae5-4891-83d3-38a134d63506', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', '', 3, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:54:44.209294', 5, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88bda-a94d-40e5-82ae-dd6f5f728265', '查询组织构架树', 0, '', '08d88598-8230-4d89-892b-e8d34ea95e9a', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', '', 3, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:57:33.245403', 5, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88bda-b12e-4ad2-8c19-1ba86e696050', '查询组织构', 0, '', '08d88598-8230-4d89-892b-e8d34ea95e9a', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a', '', 3, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:57:46.468215', 5, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88c90-8d28-42ec-8f52-c0838b9ea12f', '得到C#类型', 0, '', '08d86484-8c20-4aa8-8a80-1ecb288beabc', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d86484-8c20-4aa8-8a80-1ecb288beabc', '', 3, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 21:39:34.402150', 5, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('08d88c91-a02e-42dc-8672-220082fc01e1', '查看菜单删除', 0, '', '08d815d8-dae5-4891-83d3-38a134d63506', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506', '', 3, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 21:47:15.844997', 5, NULL, NULL, 'deleteFun', 0, '');
INSERT INTO `Menu` VALUES ('08d88ce3-e97b-4e97-86ec-93733e04940b', '测试菜单', 9, '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', '', '', 'fd8a36d4-d6d8-a6bb-2924-77455100a305', '', 2, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-20 07:36:17.523318', 0, NULL, NULL, '', 0, '');
INSERT INTO `Menu` VALUES ('fd8a36d4-d6d8-a6bb-2924-77455100a305', '系统管理', 1, '/layout', '00000000-0000-0000-0000-000000000000', '1', '', '', '', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-10 21:59:20.419133', 0, '', '2020-11-18 00:09:15.253854', NULL, 0, NULL);

-- ----------------------------
-- Table structure for MenuFunction
-- ----------------------------
DROP TABLE IF EXISTS `MenuFunction`;
CREATE TABLE `MenuFunction`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  `MenuId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FunctionId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of MenuFunction
-- ----------------------------
INSERT INTO `MenuFunction` VALUES ('016b8813-5097-4d10-871a-ac78016535de', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 21:40:33.798953', '08d88bda-b12e-4ad2-8c19-1ba86e696050', '4ec2ea42-9d19-48b3-9217-ac7100871cc6', NULL);
INSERT INTO `MenuFunction` VALUES ('03df2d22-9ef4-42a1-9e0a-ac780008ee9f', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:32:31.250224', '08d88973-93b1-4093-889d-97bedabc2233', 'c1355fa8-da88-4430-8bb5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('0565d2dc-bebb-453c-8058-ac6d0015b7a6', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-08 01:19:04.303660', '08d87ffe-c251-4779-8054-15c04038a8f1', '7bcb4ca3-e859-4ced-8fe0-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('05b49e57-0a96-4dd3-8174-ac780008fd40', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:32:43.733701', '08d88973-93b1-4093-889d-97bedabc2233', 'd726e21a-2116-4cc8-94c5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('06e87652-5daf-4e18-9ee7-ac2c0177079c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:45:26.485536', '08d815d8-868f-45cc-8fdf-0dff5acac7fc', 'f16dc63b-5958-4fef-9c74-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('0710ce97-76c0-4f7b-8be5-ac79016f08e5', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-20 22:16:19.964019', '08d815d8-868f-45cc-8fdf-0dff5acac7fc', 'f16dc63b-5958-4fef-9c74-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('0910ef92-3a67-4174-bc2d-ac6d00cc3bed', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-08 12:23:35.698998', '08d87ffe-c251-4779-8054-15c04038a8f1', '7bcb4ca3-e859-4ced-8fe0-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('0eb90072-bba4-4284-9819-ac780008ee9f', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:32:31.250244', '08d88973-9a33-4a25-8252-e8bff2507cfb', 'c1355fa8-da88-4430-8bb5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('0ef3c625-ccd8-4ef6-a5ab-ac6c012dee79', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-07 18:19:18.026879', '08d87ffe-c251-4779-8054-15c04038a8f1', '7bcb4ca3-e859-4ced-8fe0-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('16b89a81-694d-4144-af96-ac780009a37c', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:35:05.588019', '08d88973-a35e-4936-84cf-7d8a715f12d2', '94d0e63e-04e8-4206-8380-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('1e2462bc-fb8f-4307-9abb-ac700003e6d1', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:14:12.483588', '08d84450-78cf-499b-897c-56a4304f139f', '0d5a194b-f9b3-4f29-a2ac-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('20016f47-bd07-4556-a02b-ac2c01777074', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:46:55.952179', '08d815d8-dae5-4891-83d3-38a134d63506', '765852f3-faf4-4ab8-b2c2-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('28b68521-16aa-4695-a00f-ac78000a80cb', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:38:14.437961', '08d88bd8-177c-40fe-82b6-e4e6484f7c95', 'd726e21a-2116-4cc8-94c5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('2d95ca98-84ac-491a-9f69-ac78000ab82b', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:39:01.692663', '08d88bd8-177c-40fe-82b6-e4e6484f7c95', 'e82440de-6d62-4eb8-a052-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('32186630-bca4-4b83-a607-ac780165038b', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 21:39:50.858666', '08d88c90-8d28-42ec-8f52-c0838b9ea12f', '2951a7a7-fba7-4f5e-9a92-ac6000eaba15', NULL);
INSERT INTO `MenuFunction` VALUES ('357b6553-28e8-4cab-9169-ac2c017b7b83', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 23:01:39.202443', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9', '5cf76b4a-ce23-4a1d-a071-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('35fad571-f4b2-4a07-b494-ac70000ba158', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:42:20.830350', '08d84379-988d-4ff9-8f47-db14075addc2', 'a2d1c6ad-3e09-4035-a4a7-ac67014d67c5', NULL);
INSERT INTO `MenuFunction` VALUES ('37515766-93b6-4e12-ad44-ac78000ae590', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:39:40.427480', '08d88bd8-87b6-4737-8f8b-2778c807fe43', 'c1355fa8-da88-4430-8bb5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('3eb78848-f66c-473b-927d-ac780008fd40', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:32:43.733707', '08d88973-9a33-4a25-8252-e8bff2507cfb', 'd726e21a-2116-4cc8-94c5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('3ed0f507-ac97-4451-b15a-ac7800090cc7', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:32:56.983786', '08d88973-a35e-4936-84cf-7d8a715f12d2', 'd726e21a-2116-4cc8-94c5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('451bbcc1-8f6a-4d1f-ad79-ac700009dfe6', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:35:57.302939', '08d83c69-a522-4175-8e0c-5efc57fd6456', 'dbee031f-3100-494b-ab6d-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('49b88cc0-1117-4ab3-9ae4-ac70000be5db', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:43:19.298662', '08d88597-a9d2-467d-84cf-73ed0f9c04d3', '67cb5baa-11fc-4e6e-9e00-ac67014d67c5', NULL);
INSERT INTO `MenuFunction` VALUES ('4ab1b9e0-64a8-43d8-b692-ac2c0177198a', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:45:41.787874', '08d81dd2-dc25-4ffa-8518-4b28558ba714', 'dbee031f-3100-494b-ab6d-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('4ab350f1-06a6-4e6b-8b8b-ac70000ce28c', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:46:54.924338', '08d88598-3180-446c-8a9f-79af05025956', 'cbb3626a-ded7-4f11-a8ec-ac6000eaba15', NULL);
INSERT INTO `MenuFunction` VALUES ('528027be-ad16-4ead-9228-ac7801654a80', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 21:40:51.406968', '08d88bda-a94d-40e5-82ae-dd6f5f728265', '5db63e92-2520-4072-a34d-ac7100871cc6', NULL);
INSERT INTO `MenuFunction` VALUES ('56afa3c3-ead0-4497-9246-ac78000bff4a', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:43:40.835136', '08d88bda-448c-42e7-8f54-2cf879cd1ad5', 'b9c764fc-b409-4dd6-b8d2-ac7100871cc6', NULL);
INSERT INTO `MenuFunction` VALUES ('5bc6e96f-20cd-4745-a95c-ac7801676f8c', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 21:48:39.928223', '08d88c91-a02e-42dc-8672-220082fc01e1', 'ef241596-b9b4-474a-ba25-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('5db69995-3cfc-480a-a302-ac6c012dee79', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-07 18:19:18.026951', '08d87ffe-c251-4779-8054-15c04038a8f1', 'aed9b271-7c06-4ae9-98e9-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('5dd6e40a-50ce-4ddc-be37-ac78000b28b6', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:40:37.728534', '08d88bd8-177c-40fe-82b6-e4e6484f7c95', '8c5aee5e-0466-4f01-bcf0-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('61262a28-4811-488a-8c38-ac78000ab82b', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:39:01.692720', '08d88bd8-4bc8-4952-8603-1c232987ce0b', 'e82440de-6d62-4eb8-a052-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('627dd793-1437-4586-8db0-ac2c0177198a', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:45:41.787863', '08d81dd2-dc25-4ffa-8518-4b28558ba714', '118c42f7-7d58-4df7-91df-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('62c4e6b8-923e-49d8-a591-ac780009490f', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:33:48.426278', '08d88973-9a33-4a25-8252-e8bff2507cfb', '90a05dd2-aa52-40cb-a30c-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('66ec1f44-5f3c-43b1-b5fc-ac70000b8ea8', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:42:04.896848', '08d84379-988d-4ff9-8f47-db14075addc2', '67cb5baa-11fc-4e6e-9e00-ac67014d67c5', NULL);
INSERT INTO `MenuFunction` VALUES ('6933ee17-94f8-4afe-be13-ac6d001b20dd', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-08 01:38:46.343476', '08d87ffe-c251-4779-8054-15c04038a8f1', '7bcb4ca3-e859-4ced-8fe0-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('699ca32e-9d3b-4397-a4f7-ac7000098700', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:34:41.441120', '08d83c69-a522-4175-8e0c-5efc57fd6456', 'f16dc63b-5958-4fef-9c74-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('6f9ad0de-ffdc-4c7d-81f5-ac2c0177b1fd', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:47:51.878094', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7', 'eb1bc3f5-014c-4399-8982-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('73e45298-cba6-4698-a023-ac78000a7133', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:38:01.132655', '08d88bd8-4bc8-4952-8603-1c232987ce0b', 'c1355fa8-da88-4430-8bb5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('7405181e-bb7c-41e0-959e-ac70000779fb', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:27:13.445687', '08d88595-506f-4b2b-8583-fe22dddb3fed', '5cf76b4a-ce23-4a1d-a071-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('798b2ed4-dd8a-4d7d-92f1-ac70000430ae', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:15:15.516372', '08d84450-78cf-499b-897c-56a4304f139f', '5cf76b4a-ce23-4a1d-a071-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('7b644241-3502-4731-92e2-ac78000a7133', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:38:01.132649', '08d88bd8-177c-40fe-82b6-e4e6484f7c95', 'c1355fa8-da88-4430-8bb5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('7c2e982f-6c4e-4eb1-beb6-ac7000060d69', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:22:02.342504', '08d88594-14ae-4de2-8e55-dfdf1e41e40d', '7633becd-2b7e-463c-9430-ac6000eaba15', NULL);
INSERT INTO `MenuFunction` VALUES ('7c8bac46-ff4d-48ee-9cb5-ac780007b481', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:28:03.207721', '08d88973-3848-4139-8979-50ba65aa6985', 'c1355fa8-da88-4430-8bb5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('7ec7f438-136c-4a2e-8503-ac70000c00e1', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:43:42.361048', '08d88597-a9d2-467d-84cf-73ed0f9c04d3', 'eb1bc3f5-014c-4399-8982-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('7f3e2aff-933c-4abc-b8d5-ac2c017b7b83', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 23:01:39.202465', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9', 'eca617ad-bedf-4bd2-8999-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('862acd14-9344-4d6a-9840-ac78000bf94e', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:43:35.728551', '08d88bda-448c-42e7-8f54-2cf879cd1ad5', 'aed9b271-7c06-4ae9-98e9-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('862c19ca-ed7d-47d5-b146-ac78000b8400', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:41:55.629100', '08d88bd8-a84f-434e-8e97-255bab78ccf2', 'd726e21a-2116-4cc8-94c5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('894637e5-0006-4203-9328-ac7800088560', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:31:01.440411', '08d88973-93b1-4093-889d-97bedabc2233', 'e82440de-6d62-4eb8-a052-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('8ba07f0a-22e9-4a5b-8c72-ac2c01780673', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:49:03.951524', '08d84450-4c1f-4f06-8652-ab6a2c1c888f', '0d5a194b-f9b3-4f29-a2ac-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('8e28973d-8e65-41f1-8856-ac79007e1471', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-20 07:39:02.565085', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9', '5db63e92-2520-4072-a34d-ac7100871cc6', NULL);
INSERT INTO `MenuFunction` VALUES ('8f81136d-3f06-4c51-b0ab-ac78000b3936', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:40:51.809441', '08d88bd8-4bc8-4952-8603-1c232987ce0b', '90a05dd2-aa52-40cb-a30c-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('9306b567-668b-42df-9707-ac70000a5f79', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:37:46.170019', '08d88596-cb6b-43e1-84fb-b5a0a194e545', 'f16dc63b-5958-4fef-9c74-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('934bd70d-434d-4914-a8de-ac2c0177cecb', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:48:16.457369', '08d81dd2-dc25-4ffa-8518-4b28558ba714', '118c42f7-7d58-4df7-91df-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('94c5d1c6-727b-45fc-9f8e-ac2c01779f03', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:47:35.682920', '08d84378-a754-4829-8ab2-83d25ab2a125', '8c5aee5e-0466-4f01-bcf0-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('952689b7-2812-4a4d-9a26-ac69000118b3', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-04 00:03:59.772502', '08d81dd2-dc25-4ffa-8518-4b28558ba714', 'dbee031f-3100-494b-ab6d-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('96bc850a-316c-4b7c-8564-ac7000038453', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:12:48.445240', '08d84450-78cf-499b-897c-56a4304f139f', '7bcb4ca3-e859-4ced-8fe0-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('995c25fc-3ff6-41ac-bfb6-ac70000992d0', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:34:51.523957', '08d81dd2-dc25-4ffa-8518-4b28558ba714', 'f16dc63b-5958-4fef-9c74-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('9d332c63-7b27-4866-90a9-ac78000b4a08', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:41:06.159868', '08d88bd8-87b6-4737-8f8b-2778c807fe43', '94d0e63e-04e8-4206-8380-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('a00459cc-a1a4-4de7-a42e-ac70000c2a7c', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:44:17.857869', '08d88597-a9d2-467d-84cf-73ed0f9c04d3', '99c943dd-1482-45f3-913e-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('a3fc1341-a631-4476-a46d-ac2c0178171d', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:49:18.170601', '08d84450-78cf-499b-897c-56a4304f139f', '09dc98f3-3824-410f-8d77-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('a7ad4c47-3d2f-45e2-92d4-ac2c0177f765', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:48:51.103765', '08d8444f-875e-4a45-861d-f12dbb72c463', 'a3b4da8d-5536-4001-ab64-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('af87ef27-7fa6-43cb-a8eb-ac78000bab4e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:42:29.169313', '08d88bd8-a84f-434e-8e97-255bab78ccf2', 'b9c764fc-b409-4dd6-b8d2-ac7100871cc6', NULL);
INSERT INTO `MenuFunction` VALUES ('b20ceb17-c415-4abd-9936-ac700005768e', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:19:53.594918', '08d88594-14ae-4de2-8e55-dfdf1e41e40d', 'eca617ad-bedf-4bd2-8999-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('b2e84b2c-4276-4156-a6d8-ac70000c59dc', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:44:58.284155', '08d88597-eb63-428c-8422-9480fc807c31', 'eb1bc3f5-014c-4399-8982-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('b5ea4c4f-9bc3-4270-91e3-ac70000a5090', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:37:33.442713', '08d88596-cb6b-43e1-84fb-b5a0a194e545', '90e36b1e-2cf0-442d-b260-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('b807af19-0d5d-4e0a-a3d3-ac700009ad40', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:35:14.087499', '08d83c69-a522-4175-8e0c-5efc57fd6456', 'f16dc63b-5958-4fef-9c74-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('b8973ee9-c0da-4aa4-8249-ac7800091ec5', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:33:12.337149', '08d88973-a35e-4936-84cf-7d8a715f12d2', 'c1355fa8-da88-4430-8bb5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('b8c18118-5221-4aa3-b8e9-ac79007e1471', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-20 07:39:02.565089', '08d815d8-868f-45cc-8fdf-0dff5acac7fc', '96b8d267-5cc6-489b-8558-ac7100871cc6', NULL);
INSERT INTO `MenuFunction` VALUES ('ba48f62b-2f3b-43ae-b7d8-ac7800088560', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:31:01.440423', '08d88973-9a33-4a25-8252-e8bff2507cfb', 'e82440de-6d62-4eb8-a052-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('bb2fd922-569e-4368-976b-ac6d0048548c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-08 04:23:20.839281', '08d87ffe-c251-4779-8054-15c04038a8f1', '7bcb4ca3-e859-4ced-8fe0-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('bba04877-cfb0-4519-b190-ac2c0177e9d9', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:48:39.544599', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9', '5cf76b4a-ce23-4a1d-a071-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('bc534b0e-1b38-4367-90a5-ac700004881c', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:16:30.120622', '08d8444f-875e-4a45-861d-f12dbb72c463', '0d5a194b-f9b3-4f29-a2ac-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('c063d319-0584-4623-a0f6-ac70000b5ef7', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:41:24.187608', '08d88597-6b34-4f44-8261-dcfa2736e8fe', 'f16dc63b-5958-4fef-9c74-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('c3377449-e130-4238-b705-ac78000afbaa', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:39:59.288917', '08d88bd8-87b6-4737-8f8b-2778c807fe43', 'd726e21a-2116-4cc8-94c5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('c6fe1fa1-a496-4b10-9b92-ac7800093ae1', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:33:36.325301', '08d88973-93b1-4093-889d-97bedabc2233', '8c5aee5e-0466-4f01-bcf0-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('c71f9d27-ab6b-4aee-ab2d-ac70000bf42e', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:43:31.515068', '08d88597-a9d2-467d-84cf-73ed0f9c04d3', 'a2d1c6ad-3e09-4035-a4a7-ac67014d67c5', NULL);
INSERT INTO `MenuFunction` VALUES ('c7905b24-6001-4fc0-a41b-ac79007e1471', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-20 07:39:02.565045', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9', '96b8d267-5cc6-489b-8558-ac7100871cc6', NULL);
INSERT INTO `MenuFunction` VALUES ('ca3ca8b1-10c3-4417-b6b4-ac6d0018df76', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-08 01:30:33.635782', '08d87ffe-c251-4779-8054-15c04038a8f1', '7bcb4ca3-e859-4ced-8fe0-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('cd384fc3-7a70-400d-997e-ac7000047405', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:16:12.978207', '08d8444f-875e-4a45-861d-f12dbb72c463', '5cf76b4a-ce23-4a1d-a071-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('ce1962ed-bff4-4c98-aa22-ac7701830120', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:29:02.396066', '08d88b12-49e2-4921-87d3-08cf62180851', '4ec2ea42-9d19-48b3-9217-ac7100871cc6', NULL);
INSERT INTO `MenuFunction` VALUES ('cfe49a81-3f50-4ff7-aa58-ac2c017782bb', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:47:11.551243', '08d8437d-752a-4633-8ad9-f1e44f005b8d', '4e9e5e40-10b1-4170-bd99-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('d2ecb133-7e64-4f4c-82e6-ac69000118a7', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-04 00:03:59.772450', '08d81dd2-dc25-4ffa-8518-4b28558ba714', '118c42f7-7d58-4df7-91df-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('d3054273-8e3a-4f5c-9deb-ac700005f5d1', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:21:42.190903', '08d88594-14ae-4de2-8e55-dfdf1e41e40d', '0d5a194b-f9b3-4f29-a2ac-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('d3f154ff-cc42-4733-b245-ac78000c1ed5', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:44:07.750684', '08d88bda-448c-42e7-8f54-2cf879cd1ad5', 'ef241596-b9b4-474a-ba25-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('d60c8e69-d470-434d-b1c3-ac7701830120', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:29:02.396077', '08d88973-a35e-4936-84cf-7d8a715f12d2', 'b9c764fc-b409-4dd6-b8d2-ac7100871cc6', NULL);
INSERT INTO `MenuFunction` VALUES ('d620ecb3-773d-4ce7-a5c4-ac6c01646326', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-07 21:37:34.126039', '08d87ffe-c251-4779-8054-15c04038a8f1', '2c4a8e2f-aab6-4a81-80d0-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('deb1e19a-ec51-4e49-8d70-ac6d0014fd99', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-08 01:16:25.603674', '08d87ffe-c251-4779-8054-15c04038a8f1', '7bcb4ca3-e859-4ced-8fe0-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('e3627b72-2c15-40c9-9210-ac78000bb4ff', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:42:37.439524', '08d88bd8-a84f-434e-8e97-255bab78ccf2', '6631dbc0-4ae2-4081-b22c-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('e6112ddc-d7a5-47c8-acd9-ac70000ce28c', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:46:54.924334', '08d88598-3180-446c-8a9f-79af05025956', '2951a7a7-fba7-4f5e-9a92-ac6000eaba15', NULL);
INSERT INTO `MenuFunction` VALUES ('e62537ce-93cc-4708-b881-ac780008076d', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:29:13.963686', '08d88973-4ebe-43b6-83fd-d1343e3c3db3', 'd726e21a-2116-4cc8-94c5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('e62f34fd-8f35-4a49-8f56-ac6d00485f2d', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-08 04:23:29.914215', '08d87ffe-c251-4779-8054-15c04038a8f1', '2c4a8e2f-aab6-4a81-80d0-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('e7a9641c-dbc8-40af-9fa6-ac78000a80cb', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:38:14.437976', '08d88bd8-4bc8-4952-8603-1c232987ce0b', 'd726e21a-2116-4cc8-94c5-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('eb8e0898-615c-495c-be04-ac70000e8794', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:52:54.202377', '08d88598-b792-4bba-850e-0a15a2644a1c', '2c4a8e2f-aab6-4a81-80d0-ac6500beb968', NULL);
INSERT INTO `MenuFunction` VALUES ('ec9c9a94-25e5-4f28-b12f-ac2c01777074', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:46:55.952162', '08d815d8-dae5-4891-83d3-38a134d63506', 'e3147913-003e-4cec-af12-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('ee93b9d3-b573-4370-9e5c-ac2c0177cecb', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:48:16.457342', '08d81dd2-dc25-4ffa-8518-4b28558ba714', 'dbee031f-3100-494b-ab6d-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('ef87dece-7a42-41f0-bed3-ac78000ba08c', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-19 00:42:19.986978', '08d88bd8-a84f-434e-8e97-255bab78ccf2', 'eb1bc3f5-014c-4399-8982-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('efe85d61-a7f2-400d-9221-ac2c01772dcb', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:45:59.070903', '08d83c69-a522-4175-8e0c-5efc57fd6456', '0c66b541-250c-4f8f-b0f4-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('f1b9320e-0c82-44d6-aefb-ac6d00114b0e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-08 01:02:57.846494', '08d87ffe-c251-4779-8054-15c04038a8f1', '7bcb4ca3-e859-4ced-8fe0-ac69015bd28b', NULL);
INSERT INTO `MenuFunction` VALUES ('f3ecbc67-36c2-49c7-9763-ac2c01780673', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:49:03.951613', '08d84450-4c1f-4f06-8652-ab6a2c1c888f', 'a855299f-4021-4ed5-8b76-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('f861a6d4-c8cb-4707-989c-ac70000423cb', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:15:04.520673', '08d84450-4c1f-4f06-8652-ab6a2c1c888f', '5cf76b4a-ce23-4a1d-a071-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('f89481a8-528b-46f9-88bb-ac7701830120', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:29:02.396093', '08d88973-a35e-4936-84cf-7d8a715f12d2', '4ec2ea42-9d19-48b3-9217-ac7100871cc6', NULL);
INSERT INTO `MenuFunction` VALUES ('f8f9972d-103f-45be-b2c5-ac7701830120', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-18 23:29:02.395990', '08d88b12-49e2-4921-87d3-08cf62180851', 'b9c764fc-b409-4dd6-b8d2-ac7100871cc6', NULL);
INSERT INTO `MenuFunction` VALUES ('fbc30f25-0e94-4a3c-b5f2-ac70000c918c', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:45:45.802153', '08d84379-988d-4ff9-8f47-db14075addc2', 'eb1bc3f5-014c-4399-8982-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('fe700fba-27bb-4cf6-a46b-ac70000e427a', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 00:51:55.236099', '08d88598-b792-4bba-850e-0a15a2644a1c', 'ba275142-01e5-4621-b822-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('feb382ba-9319-4216-9340-ac2c0177bcbe', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:48:01.052719', '08d84379-988d-4ff9-8f47-db14075addc2', '765545fa-f77f-434c-b8f0-ac2c0176d440', NULL);
INSERT INTO `MenuFunction` VALUES ('ff2af41f-fa8a-4859-bbc7-ac79007e1471', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-20 07:39:02.565092', '08d815d8-868f-45cc-8fdf-0dff5acac7fc', '5db63e92-2520-4072-a34d-ac7100871cc6', NULL);

-- ----------------------------
-- Table structure for Organizated
-- ----------------------------
DROP TABLE IF EXISTS `Organizated`;
CREATE TABLE `Organizated`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ParentId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT '00000000-0000-0000-0000-000000000000',
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LadingCadre` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT '00000000-0000-0000-0000-000000000000',
  `ParentNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Depth` int(0) NOT NULL DEFAULT 0,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `FirstLeader` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `SecondLeader` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Organizated
-- ----------------------------
INSERT INTO `Organizated` VALUES ('08d7dec0-f25b-40a0-80f6-42ea3fe85cba', '5f9a19ab-5900-4ce8-8e1b-9e750159616c', '五组', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 'string', 2, NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-12 17:07:37.730692', NULL, NULL, NULL, NULL);
INSERT INTO `Organizated` VALUES ('08d8832d-2e57-4b6b-868c-94612b9adfff', '24031049-ded0-437f-b208-7c49eb3a360a', '123486', '00000000-0000-0000-0000-000000000000', '', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-07 22:55:34.703569', NULL, '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000', NULL);
INSERT INTO `Organizated` VALUES ('08d88332-7dec-42cf-8042-7705023cc2cf', '24031049-ded0-437f-b208-7c49eb3a360a', '132asd13asd13 as21d3a ', '00000000-0000-0000-0000-000000000000', '', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-07 23:33:35.700433', NULL, '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000', NULL);
INSERT INTO `Organizated` VALUES ('08d88332-bc27-463c-892f-1383ac12a827', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 'asdasdasdasdasdasd', '00000000-0000-0000-0000-000000000000', '', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-07 23:35:20.122219', NULL, '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000', NULL);
INSERT INTO `Organizated` VALUES ('08d88333-1ac2-4e58-8136-865d1e3ad3c1', '24031049-ded0-437f-b208-7c49eb3a360a', '大黄瓜开发保龄球部门', '00000000-0000-0000-0000-000000000000', '', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-07 23:37:58.847444', NULL, '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000', NULL);
INSERT INTO `Organizated` VALUES ('08d88609-d109-409c-8d35-3c8d07068997', '00000000-0000-0000-0000-000000000000', 'asdasda', '08d82b86-abb8-4276-8159-b7d7508b61a0', '', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 14:19:59.255870', NULL, '08d82b86-abb8-4276-8159-b7d7508b61a0', NULL, NULL);
INSERT INTO `Organizated` VALUES ('08d88623-0917-4220-8598-51a295203f06', '24031049-ded0-437f-b208-7c49eb3a360a', 'asdasdas', '08d8476b-a962-4e7d-84cc-0344b552ae40', '', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 17:20:18.052967', NULL, NULL, NULL, NULL);
INSERT INTO `Organizated` VALUES ('08d88645-8e90-4ccb-8593-66ebacd3dbc3', 'fb426e46-d63e-49a5-9b2b-6e5538835c6d', '23', '3fa85f64-5717-4562-b3fc-2c963f66afa6', '', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-11 21:27:37.563163', NULL, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', NULL, NULL);
INSERT INTO `Organizated` VALUES ('24031049-ded0-437f-b208-7c49eb3a360a', '3fa85f64-5717-4562-b3fc-2c963f66afa6', '二部', '08d8476b-a962-4e7d-84cc-0344b552ae40', 'string', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, '00000000-0000-0000-0000-000000000000', '2020-04-12 17:01:37.067139', NULL, NULL, NULL, '2020-11-11 17:21:24.774993');
INSERT INTO `Organizated` VALUES ('32534cf8-10cc-47e3-a324-d2d868e2a0fa', '24031049-ded0-437f-b208-7c49eb3a360a', '一组', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 'string', 2, NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-12 17:02:03.883363', NULL, NULL, NULL, NULL);
INSERT INTO `Organizated` VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6', '00000000-0000-0000-0000-000000000000', '集团', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 'string', 0, NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-12 16:58:44.699352', NULL, NULL, NULL, NULL);
INSERT INTO `Organizated` VALUES ('50af9919-fd41-44f6-bcbd-279782808e60', '24031049-ded0-437f-b208-7c49eb3a360a', '二组', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 'string', 2, NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-12 17:02:09.368751', NULL, NULL, NULL, NULL);
INSERT INTO `Organizated` VALUES ('5f9a19ab-5900-4ce8-8e1b-9e750159616c', '3fa85f64-5717-4562-b3fc-2c963f66afa6', '一部', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 'string', 1, NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-12 17:01:29.080968', NULL, NULL, NULL, NULL);
INSERT INTO `Organizated` VALUES ('77563996-82a4-44aa-99a7-0437ff1c3d7a', '5f9a19ab-5900-4ce8-8e1b-9e750159616c', '三组', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 'string', 2, NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-12 17:02:37.748699', NULL, NULL, NULL, NULL);
INSERT INTO `Organizated` VALUES ('fb426e46-d63e-49a5-9b2b-6e5538835c6d', '5f9a19ab-5900-4ce8-8e1b-9e750159616c', '四组', '3fa85f64-5717-4562-b3fc-2c963f66afa6', 'string', 2, NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-12 17:02:43.043724', NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for PersistedGrant
-- ----------------------------
DROP TABLE IF EXISTS `PersistedGrant`;
CREATE TABLE `PersistedGrant`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Key` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `SubjectId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `SessionId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Expiration` datetime(6) NULL DEFAULT NULL,
  `ConsumedTime` datetime(6) NULL DEFAULT NULL,
  `Data` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of PersistedGrant
-- ----------------------------

-- ----------------------------
-- Table structure for Role
-- ----------------------------
DROP TABLE IF EXISTS `Role`;
CREATE TABLE `Role`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `NormalizedName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ConcurrencyStamp` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsAdmin` tinyint(1) NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Code` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Role
-- ----------------------------
INSERT INTO `Role` VALUES ('08d7e43f-1991-496a-8bfc-bda023fd6a1b', 'asdas', 'ASDAS', 'aef1aeda-24f5-40ad-8ce8-d7e9ef93e12f', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, '00000000-0000-0000-0000-000000000000', '2020-04-19 16:53:15.922160', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7e43f-4ef1-4349-8fb0-cf493929d335', 'asdas23232', 'ASDAS23232', 'd68660a2-83d7-4246-81cb-012280aea4f3', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-04-19 16:54:45.471120', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7e43f-8187-4124-879d-c80d973ca626', '2131231', '2131231', '0781fef7-d155-444f-87fa-6b6ace9865a9', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-04-19 16:56:10.339760', '1231231', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7e43f-c369-4631-8f72-160649a6dc9e', '4334534345', '4334534345', '241a705c-391a-4396-80bd-2229126f1e45', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-04-19 16:58:00.874821', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7e440-c641-4b91-87d8-9a80bb083415', '23423', '23423', '94b9684b-5a0e-48f4-bf72-24ba18501c21', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-04-19 17:05:15.144729', '3423', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7efe7-97f8-4262-877d-6f72b76c333b', 'test', 'TEST', 'e076aed8-f60a-4bd8-8c22-d0eb167bd0b6', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 12:57:06.215011', 'sadas', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7efe7-b536-4bd0-8d7e-47e081abc01f', 'testaa', 'TESTAA', 'c9ee1e4e-1b76-46e7-b1c6-36bbf9ef33b9', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 12:57:55.295633', 'sadas', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7efe8-6928-442d-8b08-c732918a525d', 'asdas`111', 'ASDAS`111', '42eae52f-e94b-4e2e-b937-a1a454e8a61d', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 13:02:57.190956', 'sadas', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7efe8-73ad-4ff4-880a-014f8265028f', '1111111', '1111111', '517eccfb-dd4c-4d3c-a486-dc1e169925df', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 13:03:14.844647', '111111', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7efe9-43f3-4400-8bde-f67cde1b9541', '22', '22', 'e415d625-66a8-4fa6-9819-913b8a4fba36', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 13:09:04.264660', '222', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7efe9-854a-463b-83ff-6bfc203df30a', '122', '122', 'c2f4586d-3727-4a45-8994-426c13413fb7', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 13:10:53.887639', '111', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7eff8-d254-4848-80da-d4693602966c', '111', '111', '145dfdab-5141-4bcc-90db-b8fd1b4b4f7a', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 15:00:25.589534', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7effa-61c7-4d33-848e-e2c27c49d566', '333', '333', 'a2a76b86-c824-46e2-8175-76fc57d62a19', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 15:11:35.756103', '333', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7effa-ea96-4e7b-8aba-f8fc030295cf', '222222', '222222', '6f7fcf47-321a-4e70-9e3a-5e1b894da74c', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 15:15:25.283340', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7effb-1540-44f9-8d4d-03e2e90cba99', 'sadaws', 'SADAWS', 'f9218004-8a5b-45e7-88a4-27ddcc1ba51e', 0, NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 15:16:36.857880', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d7f000-caf0-42d1-8f97-a54365bc436b', '1211', '1211', '0bff92da-9284-4d88-bca1-1c6d20be52c2', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 15:57:29.139362', '222', NULL, NULL);
INSERT INTO `Role` VALUES ('08d809fa-9dd4-4cac-884a-3c0aedc16a99', '大黄瓜', '大黄瓜', '39e30d59-2148-488a-a3e4-58de58982636', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-06 09:18:46.733628', '帅气的大黄瓜18CM', NULL, NULL);
INSERT INTO `Role` VALUES ('08d809fa-d07a-4321-89af-424c8790e811', 'Test112', 'TEST112', '384c8d5b-e6e2-4ddf-aab8-9a8936f19207', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-06 09:20:11.706611', '1212', NULL, NULL);
INSERT INTO `Role` VALUES ('08d80a10-221f-48f3-83ea-81e35ca1cf6b', 'Test1000', 'TEST1000', '6d1323dd-3d80-4eef-b163-1b3cc6e6700d', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-06 19:52:48.093216', '12', NULL, NULL);
INSERT INTO `Role` VALUES ('08d83c6c-d151-41a5-8866-3a3d54d5b31e', '测试', '测试', '2f125e2b-5e64-4b86-8cea-263e824a8d03', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-09 22:02:13.852504', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d83c6d-15a6-441b-8e58-da9a34209708', '测试001', '测试001', '0e5ef854-0a5f-429f-a163-83e70a25cc0b', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-09 22:04:08.515092', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d83c6e-2502-4a77-88a7-fc6c637409a9', '测试0011', '测试0011', '7ccc9b0f-194e-4d10-847f-4e7fe3a99cd4', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-09 22:11:43.792333', '12', NULL, NULL);
INSERT INTO `Role` VALUES ('08d83c6e-4cc0-41a0-865a-9ee5b50c971c', '通用测试', '通用测试', '7a791ad6-102b-4cb1-a401-3b1f41adfcf2', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-09 22:12:50.464939', 'asdasd asd asd as', NULL, NULL);
INSERT INTO `Role` VALUES ('08d83c6e-99ef-48fc-8e1d-26cb57a7bfcc', 'mokai', 'MOKAI', 'f896f748-bbf8-4260-a9b6-79b991b277da', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-09 22:14:59.960230', 'asdasdasddasd ad ', NULL, NULL);
INSERT INTO `Role` VALUES ('08d83c6f-de31-4b2c-847e-625131cc76ba', '测试1000', '测试1000', '82494cb9-feef-46da-92b9-edb326e7d66b', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-09 22:24:03.947113', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d83c74-37de-48e2-856d-d613e9d69713', '测试删除', '测试删除', 'b16b44db-43cf-407a-b31d-362e27480972', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-09 22:55:12.383678', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d83c75-7a73-42e2-8d1a-61ee41251508', '测试0000', '测试0000', '5280985b-a87d-469a-8bc5-ad27b718ff68', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-09 23:04:13.591509', '测试0000', NULL, NULL);
INSERT INTO `Role` VALUES ('08d83c75-f9be-44fb-8749-4067fd99aa2e', '测试9090', '测试9090', 'afa41a23-4f33-4388-b398-dc66d38d352a', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-09 23:07:47.147668', '12', NULL, NULL);
INSERT INTO `Role` VALUES ('08d83c76-2b1e-4794-8b2f-3a2aff1edae2', '更新', '更新', 'ef8653b3-cf06-463e-82e6-896bf493d0e7', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-09 23:09:10.014788', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d8404d-f83c-4791-8410-ba0d52fe5ceb', '测试001', '测试001', 'd33d3289-ee50-4e42-bd13-580969ddd6be', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-14 20:31:29.397351', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d8404e-6f15-4c8a-87a6-9d9cf5ab487b', '测试', '测试', '3a7611c6-c170-4f48-8011-c0c82f6d72e6', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-14 20:34:48.824875', '1212122', NULL, NULL);
INSERT INTO `Role` VALUES ('08d84051-84da-4677-84f5-8caca636c052', '测试', '测试', '0b5377bd-455f-408d-8b96-4b4a3e66b45c', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-14 20:56:53.793896', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d84051-cfdb-441d-8481-2d83a8f1a412', '测试001', '测试001', 'e6ff85c8-181e-4149-9a24-0c233d85d9eb', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-14 20:58:59.670468', '11', NULL, NULL);
INSERT INTO `Role` VALUES ('08d879c4-4667-491b-8638-3e76a99539cf', '1212', '1212', '28db0709-6d90-42dd-b539-bb6e9fe659ca', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 23:31:57.435426', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d879c4-7a63-451d-8d01-233ef0f0d169', '测试100', '测试100', '636b7a6e-433b-4d7b-b475-89af5e917baa', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 23:33:24.679819', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d879c4-b17e-48c7-8457-83a57a10eedb', '大黄瓜', '大黄瓜', 'bbb1a081-acb2-4f1c-9568-27a8d0093962', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 23:34:57.133160', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d879c4-b899-4cde-8a7e-f9e0c929ab9c', '大帅瓜', '大帅瓜', '4b31b0f0-7613-4180-9871-a614f20ca21f', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 23:35:09.056164', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d879c4-bf21-4fa8-82b3-e725b79b8fcc', '测试201', '测试201', '2bff5716-283c-40db-9d29-3b2c4caae3e7', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 23:35:20.014757', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d879c4-c502-445f-8340-ca9edfbd6f49', '瓜瓜', '瓜瓜', 'aff6da3c-83e5-4219-81ac-d6ec32dc76ed', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 23:35:29.873507', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d879c4-cb1c-405a-80dc-524ab719de98', '222', '222', '1d209c8f-3cde-4bfe-9849-e84d566e2789', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 23:35:40.108531', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d879c4-d9c9-4199-8af1-1d6ec030d568', '121212', '121212', 'ffb7d74c-b2d8-43fc-8eeb-c578f9230f2b', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 23:36:04.730974', '232323', NULL, '2020-10-27 23:11:05.433410');
INSERT INTO `Role` VALUES ('08d87a8f-a202-4101-8e95-5302975cc2ee', '测试删除1', '测试删除1', '5c9f7137-ced3-4edb-8478-138ea9735913', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-27 23:47:38.957494', '111', NULL, '2020-10-27 23:48:01.579688');
INSERT INTO `Role` VALUES ('08d88001-7f99-4dac-8283-63ee7048010b', '系统默认', '系统默认', '6b8cfb8c-8fd7-4539-88cf-2116d011f5d7', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-03 22:05:19.669274', '默认所有查询权限', NULL, '2020-11-11 00:53:19.699890');
INSERT INTO `Role` VALUES ('08d883e1-e9ec-4529-8b71-e81d154e4847', '测试封装', '测试封装', '62adf14b-2db3-452c-bb45-6839d4a72a8f', 0, NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-08 20:29:18.811421', '', NULL, NULL);
INSERT INTO `Role` VALUES ('08d884c5-8901-443c-8b07-9b57fa0096cf', '测试11111', '测试11111', '92839048-493c-4a2c-b031-059407bffbd1', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-09 23:38:41.463487', 'jhjk333', NULL, '2020-11-15 16:53:09.266720');
INSERT INTO `Role` VALUES ('08d8857d-25b9-401a-858b-ac876d914c0a', '121212ssss', '121212SSSS', '0ebfebb2-961d-4833-8fb8-556d5041067a', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-10 21:33:02.287051', '1212', NULL, '2020-11-10 21:33:22.910067');
INSERT INTO `Role` VALUES ('08d88d5b-c231-4790-862d-7ff71eea370d', 'Test2000', 'TEST2000', 'd1a7a291-7286-4505-b229-5b8b09ac41dd', 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-20 21:54:11.248211', NULL, NULL, NULL);
INSERT INTO `Role` VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6', 'asdasds', 'ASDASDS', 'a11eb243-d0d3-47af-9315-20bd89188920', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, '00000000-0000-0000-0000-000000000000', '2020-04-19 16:33:00.134225', 'asdas', NULL, NULL);
INSERT INTO `Role` VALUES ('b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '系统管理员', '系统管理员', '08f674c0-2296-42ff-8df1-b9a0d33a8583', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-16 22:38:12.057392', '拥有系统上所有有权限请不要删除!', NULL, NULL);

-- ----------------------------
-- Table structure for RoleClaim
-- ----------------------------
DROP TABLE IF EXISTS `RoleClaim`;
CREATE TABLE `RoleClaim`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ClaimValue` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of RoleClaim
-- ----------------------------

-- ----------------------------
-- Table structure for RoleMenu
-- ----------------------------
DROP TABLE IF EXISTS `RoleMenu`;
CREATE TABLE `RoleMenu`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MenuId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of RoleMenu
-- ----------------------------
INSERT INTO `RoleMenu` VALUES ('08d82739-d0c2-44d3-8b0c-a69f151592ef', '08d7f000-caf0-42d1-8f97-a54365bc436b', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d82739-d0c3-4416-8280-0a68e334c2a4', '08d7f000-caf0-42d1-8f97-a54365bc436b', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d82739-d0c3-4457-829c-a4b10f66c50e', '08d7f000-caf0-42d1-8f97-a54365bc436b', '08d815d8-ac6d-4df5-8113-ecb81ee27df2');
INSERT INTO `RoleMenu` VALUES ('08d8273a-79c8-4b36-8dc4-f0c6371e812b', '08d80a10-221f-48f3-83ea-81e35ca1cf6b', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d8273a-79c8-4b79-8c4c-a23a6606c74b', '08d80a10-221f-48f3-83ea-81e35ca1cf6b', '08d815d8-ac6d-4df5-8113-ecb81ee27df2');
INSERT INTO `RoleMenu` VALUES ('08d8273a-79c8-4b9a-8196-fc9040ccb163', '08d80a10-221f-48f3-83ea-81e35ca1cf6b', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d8273a-79c8-4bb7-8c5e-35bc9fee228d', '08d80a10-221f-48f3-83ea-81e35ca1cf6b', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d83c6d-53ec-4cc1-8fe5-4f25db3c23e8', '08d83c6d-15a6-441b-8e58-da9a34209708', '08d812bb-e756-4c73-8106-3b70a641385a');
INSERT INTO `RoleMenu` VALUES ('08d83c6d-53ee-42cf-8c60-70ad8426ed07', '08d83c6d-15a6-441b-8e58-da9a34209708', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d83c6d-53ee-436a-8ce4-71e927e3d086', '08d83c6d-15a6-441b-8e58-da9a34209708', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d83c6d-53ee-437c-8fbb-5309c26260f9', '08d83c6d-15a6-441b-8e58-da9a34209708', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d83c6d-53ee-43ab-8b19-b262622b3f07', '08d83c6d-15a6-441b-8e58-da9a34209708', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d83c6d-53ee-43b7-8344-d849464781aa', '08d83c6d-15a6-441b-8e58-da9a34209708', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d83c6e-26b5-4372-8fe6-2c5e57b55dc0', '08d83c6e-2502-4a77-88a7-fc6c637409a9', '08d812bb-e756-4c73-8106-3b70a641385a');
INSERT INTO `RoleMenu` VALUES ('08d83c6e-26b5-43e4-8d0c-dbabe1388a0b', '08d83c6e-2502-4a77-88a7-fc6c637409a9', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d83c6e-26b5-43fe-83e4-88a42efaf790', '08d83c6e-2502-4a77-88a7-fc6c637409a9', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d83c6e-26b5-4439-83cf-d1b134ed87e0', '08d83c6e-2502-4a77-88a7-fc6c637409a9', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d83c6e-26b5-4458-8d35-8491c14070eb', '08d83c6e-2502-4a77-88a7-fc6c637409a9', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d83c6e-26b5-446c-87dc-a64acde8f83a', '08d83c6e-2502-4a77-88a7-fc6c637409a9', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d83c6e-26b5-4488-8c1f-2f30466543b0', '08d83c6e-2502-4a77-88a7-fc6c637409a9', '08d815d9-93f2-4f7c-8fce-8fa321933eb3');
INSERT INTO `RoleMenu` VALUES ('08d83c6e-99f3-47f9-8f21-83762dce8508', '08d83c6e-99ef-48fc-8e1d-26cb57a7bfcc', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d83c6e-99f3-4ec5-8f4b-d4e00dbb1df7', '08d83c6e-99ef-48fc-8e1d-26cb57a7bfcc', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d83c6e-99f3-4ed2-889e-eb03cd1e5904', '08d83c6e-99ef-48fc-8e1d-26cb57a7bfcc', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d83c6f-de67-4834-8017-ad9bfa48a478', '08d83c6f-de31-4b2c-847e-625131cc76ba', '08d812bb-e756-4c73-8106-3b70a641385a');
INSERT INTO `RoleMenu` VALUES ('08d83c6f-de68-4756-8f3c-48cc8fac93b4', '08d83c6f-de31-4b2c-847e-625131cc76ba', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d83c6f-de68-4795-8c1f-3c608436892a', '08d83c6f-de31-4b2c-847e-625131cc76ba', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d83c6f-de68-47a4-8300-8f3505c90f87', '08d83c6f-de31-4b2c-847e-625131cc76ba', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d83c6f-de68-47cb-82fe-38356a58b6a1', '08d83c6f-de31-4b2c-847e-625131cc76ba', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d83c6f-de68-47d6-8d66-7a54015c331c', '08d83c6f-de31-4b2c-847e-625131cc76ba', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d83c74-3800-4d6c-8a48-e129313e1cb2', '08d83c74-37de-48e2-856d-d613e9d69713', '08d812bb-e756-4c73-8106-3b70a641385a');
INSERT INTO `RoleMenu` VALUES ('08d83c74-3801-473a-8d55-ab183cdf3e0d', '08d83c74-37de-48e2-856d-d613e9d69713', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d83c74-3801-4797-80e9-9bf0a6539d8f', '08d83c74-37de-48e2-856d-d613e9d69713', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d83c74-3801-47ab-8751-35feac1875a4', '08d83c74-37de-48e2-856d-d613e9d69713', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d83c74-3801-47e8-8c90-b30520d60cb4', '08d83c74-37de-48e2-856d-d613e9d69713', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d83c74-3801-47f8-87df-626c596b0b84', '08d83c74-37de-48e2-856d-d613e9d69713', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d83c75-7a80-499a-8eda-f89acb423eb0', '08d83c75-7a73-42e2-8d1a-61ee41251508', '08d812bb-e756-4c73-8106-3b70a641385a');
INSERT INTO `RoleMenu` VALUES ('08d83c75-7a81-431b-8593-7d10e1cfea21', '08d83c75-7a73-42e2-8d1a-61ee41251508', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d83c75-7a81-4344-821f-cf606d1d1a6a', '08d83c75-7a73-42e2-8d1a-61ee41251508', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d83c75-7a81-4352-8344-68ee5efeae2b', '08d83c75-7a73-42e2-8d1a-61ee41251508', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d83c75-7a81-437c-8acf-c373e177d2e7', '08d83c75-7a73-42e2-8d1a-61ee41251508', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d83c75-7a81-4388-8b82-689333c4f01e', '08d83c75-7a73-42e2-8d1a-61ee41251508', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d83c75-7a81-4393-8961-24ccf784c547', '08d83c75-7a73-42e2-8d1a-61ee41251508', '08d815d9-93f2-4f7c-8fce-8fa321933eb3');
INSERT INTO `RoleMenu` VALUES ('08d83c75-f9dd-4e0c-8cc6-d6672982121d', '08d83c75-f9be-44fb-8749-4067fd99aa2e', '08d812bb-e756-4c73-8106-3b70a641385a');
INSERT INTO `RoleMenu` VALUES ('08d83c75-f9de-4acf-8728-02e31aa82f58', '08d83c75-f9be-44fb-8749-4067fd99aa2e', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d83c75-f9de-4b3c-8192-1a6b6572990b', '08d83c75-f9be-44fb-8749-4067fd99aa2e', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d83c75-f9de-4b64-8f1c-bb2aaad9a844', '08d83c75-f9be-44fb-8749-4067fd99aa2e', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d83c75-f9de-4bd4-8c1c-90926c1a4896', '08d83c75-f9be-44fb-8749-4067fd99aa2e', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d83c75-f9de-4bf1-8a60-97867d8af1b3', '08d83c75-f9be-44fb-8749-4067fd99aa2e', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d83c75-f9de-4c07-8e83-a60b76e910f3', '08d83c75-f9be-44fb-8749-4067fd99aa2e', '08d815d9-93f2-4f7c-8fce-8fa321933eb3');
INSERT INTO `RoleMenu` VALUES ('08d83c7a-a513-47c7-8c06-22dc0b289f74', '08d83c76-2b1e-4794-8b2f-3a2aff1edae2', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d83c7a-a513-4864-87b5-eed96a67ccbe', '08d83c76-2b1e-4794-8b2f-3a2aff1edae2', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d83c7a-a513-48a2-892e-8b4c27693c7a', '08d83c76-2b1e-4794-8b2f-3a2aff1edae2', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d83c7a-a513-48ae-8993-5581aede09ed', '08d83c76-2b1e-4794-8b2f-3a2aff1edae2', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d8404d-fad0-4985-81e7-16b961954139', '08d8404d-f83c-4791-8410-ba0d52fe5ceb', '08d812bb-e756-4c73-8106-3b70a641385a');
INSERT INTO `RoleMenu` VALUES ('08d8404d-fad1-442e-88c5-acd17f047dc1', '08d8404d-f83c-4791-8410-ba0d52fe5ceb', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d8404d-fad1-4463-8759-51cf8b5fb059', '08d8404d-f83c-4791-8410-ba0d52fe5ceb', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d8404d-fad1-4472-8963-c7f64ef2936c', '08d8404d-f83c-4791-8410-ba0d52fe5ceb', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d8404d-fad1-449e-8ce4-4132b85c3007', '08d8404d-f83c-4791-8410-ba0d52fe5ceb', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9');
INSERT INTO `RoleMenu` VALUES ('08d8404d-fad1-44ab-8453-7eb2ab179688', '08d8404d-f83c-4791-8410-ba0d52fe5ceb', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d8404d-fad1-44b5-8f03-292cc4384e48', '08d8404d-f83c-4791-8410-ba0d52fe5ceb', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d8404d-fad1-44c1-8656-91bf10dd6890', '08d8404d-f83c-4791-8410-ba0d52fe5ceb', '08d815d9-93f2-4f7c-8fce-8fa321933eb3');
INSERT INTO `RoleMenu` VALUES ('08d8404e-8453-4d38-852a-ae1bc5a06a04', '08d8404e-6f15-4c8a-87a6-9d9cf5ab487b', '08d812bb-e756-4c73-8106-3b70a641385a');
INSERT INTO `RoleMenu` VALUES ('08d8404e-8453-4ed3-85c7-7a1a01c3ea04', '08d8404e-6f15-4c8a-87a6-9d9cf5ab487b', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d8404e-8453-4f6c-8a21-80f628f3bdb0', '08d8404e-6f15-4c8a-87a6-9d9cf5ab487b', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d8404e-8455-479d-8871-3f8b2cf3cf4b', '08d8404e-6f15-4c8a-87a6-9d9cf5ab487b', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d8404e-8455-4898-8669-ca06e3e1eac0', '08d8404e-6f15-4c8a-87a6-9d9cf5ab487b', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9');
INSERT INTO `RoleMenu` VALUES ('08d8404e-8455-4976-813a-cf89006cc717', '08d8404e-6f15-4c8a-87a6-9d9cf5ab487b', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d8404e-8455-4a3d-853c-12e6f8821e71', '08d8404e-6f15-4c8a-87a6-9d9cf5ab487b', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d84051-8907-45bd-8e22-5543b0236404', '08d84051-84da-4677-84f5-8caca636c052', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d84051-8908-4169-83f6-2e5cfb0c9496', '08d84051-84da-4677-84f5-8caca636c052', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d84051-8908-419a-8cc5-73dee23cc73b', '08d84051-84da-4677-84f5-8caca636c052', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9');
INSERT INTO `RoleMenu` VALUES ('08d84051-8908-41a9-8f45-39c24dc05267', '08d84051-84da-4677-84f5-8caca636c052', '08d815d9-93f2-4f7c-8fce-8fa321933eb3');
INSERT INTO `RoleMenu` VALUES ('08d84051-8908-41dc-87bd-b91e9602987c', '08d84051-84da-4677-84f5-8caca636c052', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d84051-8908-41ec-8391-b0bf058138f0', '08d84051-84da-4677-84f5-8caca636c052', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d84051-8908-4208-8de8-473deee3eeb2', '08d84051-84da-4677-84f5-8caca636c052', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d84051-8908-4215-8b44-909d4b8db14e', '08d84051-84da-4677-84f5-8caca636c052', '08d812bb-e756-4c73-8106-3b70a641385a');
INSERT INTO `RoleMenu` VALUES ('08d847d1-7a66-4b35-8523-98342ec632f0', '08d84051-cfdb-441d-8481-2d83a8f1a412', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d847d1-7a66-4b8f-8452-a0f71e00b4c7', '08d84051-cfdb-441d-8481-2d83a8f1a412', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d847d1-7a66-4b9f-89ea-7256d0a5d1cd', '08d84051-cfdb-441d-8481-2d83a8f1a412', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d847d1-7a66-4ba8-84fc-8b4f10063c63', '08d84051-cfdb-441d-8481-2d83a8f1a412', '08d84375-234a-48c6-83e8-36b6134f4439');
INSERT INTO `RoleMenu` VALUES ('08d850e1-c196-42e4-8b84-afb031f7be12', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d850e1-c198-4572-84c9-926f31f37d7e', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', 'fd8a36d4-d6d8-a6bb-2924-77455100a305');
INSERT INTO `RoleMenu` VALUES ('08d850e1-c198-4625-821a-6dedb8f951d3', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d850e1-c198-4655-8170-af4c7863d8ca', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d850e1-c198-468f-8ca9-7b11c2c6606e', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f99-4df7-8b7e-f40740ec879a', '08d879c4-b17e-48c7-8457-83a57a10eedb', 'fd8a36d4-d6d8-a6bb-2924-77455100a305');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-45d2-89fd-8d142f01109f', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-462f-8521-a059f929a858', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-463e-83d1-e74564db83cc', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-466b-88d9-089c8a2b4f78', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-4677-8d4f-6856d70a5f6a', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d84375-234a-48c6-83e8-36b6134f4439');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-4685-8261-ec81b79b2494', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d84376-acc6-4924-8116-9d7af9ea87ce');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-4690-84c5-cb15a25e262b', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-469f-89b6-f3cf3ea05ab1', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d84379-988d-4ff9-8f47-db14075addc2');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-46ad-87d5-6bd2df6d91ae', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-46b9-820b-2761d0787362', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d8444f-875e-4a45-861d-f12dbb72c463');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-46c6-852c-707637b77e7e', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d84450-4c1f-4f06-8652-ab6a2c1c888f');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-46d1-87fe-f47d5ca6a78f', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d84450-78cf-499b-897c-56a4304f139f');
INSERT INTO `RoleMenu` VALUES ('08d87e4f-8f9c-46db-8f01-7e598ba3e965', '08d879c4-b17e-48c7-8457-83a57a10eedb', '08d86484-8c20-4aa8-8a80-1ecb288beabc');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f05-4513-8ed0-5606424a0e64', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-413c-8630-455414d608da', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d81dd2-dc25-4ffa-8518-4b28558ba714');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-416d-8ff6-f471c3987fec', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4178-811b-b1f10679fec4', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-41a3-8446-77252976f1f8', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d83c69-a522-4175-8e0c-5efc57fd6456');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-41ac-818d-172cc95d8ffe', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d84375-234a-48c6-83e8-36b6134f4439');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-41b7-8ee1-f2b0b8d284de', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d84376-acc6-4924-8116-9d7af9ea87ce');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-41c0-804b-e5b57be6180b', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d84378-a754-4829-8ab2-83d25ab2a125');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-41c8-85b9-391f7ece61e9', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d8437d-752a-4633-8ad9-f1e44f005b8d');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-41d2-8a6e-dd55e5b6c91c', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d84379-988d-4ff9-8f47-db14075addc2');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-41da-850b-ac659f170971', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-41e1-8f0d-2bc49b0c820f', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d8444f-875e-4a45-861d-f12dbb72c463');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-41f3-8bec-382c7eb99a17', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d84450-4c1f-4f06-8652-ab6a2c1c888f');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-41fc-829d-25f614e55944', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d84450-78cf-499b-897c-56a4304f139f');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4206-8587-5884b412647b', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', 'fd8a36d4-d6d8-a6bb-2924-77455100a305');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-420e-83ce-5741b4c1d407', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88596-cb6b-43e1-84fb-b5a0a194e545');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4215-8cc0-ec2efa712dfe', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88597-6b34-4f44-8261-dcfa2736e8fe');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4220-809d-cecd1545d786', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88598-b792-4bba-850e-0a15a2644a1c');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4228-8aeb-bf1b0220f36e', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88973-3848-4139-8979-50ba65aa6985');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4233-810a-0f4c16fbb9fa', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88973-4ebe-43b6-83fd-d1343e3c3db3');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-423a-8bed-256b26cc7009', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88973-93b1-4093-889d-97bedabc2233');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4242-826c-7c3204c1555b', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88973-9a33-4a25-8252-e8bff2507cfb');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-424e-8ff5-11817fbae63a', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88973-a35e-4936-84cf-7d8a715f12d2');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4256-89c2-a9b479aacb7c', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88597-a9d2-467d-84cf-73ed0f9c04d3');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4260-8ea5-3a2705b125b7', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88597-eb63-428c-8422-9480fc807c31');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4268-8ccb-962623694134', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88594-14ae-4de2-8e55-dfdf1e41e40d');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4270-868e-deb7edd8634a', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88595-506f-4b2b-8583-fe22dddb3fed');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-427a-8a4c-f85d03d691c7', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88598-3180-446c-8a9f-79af05025956');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4282-84c0-df930227545f', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88598-8230-4d89-892b-e8d34ea95e9a');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4289-8cd4-a99a63a00cbb', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88645-31bd-42e5-8211-753786aaf90b');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4293-8ffa-87c83b2019b9', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d86484-8c20-4aa8-8a80-1ecb288beabc');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-429b-8fcf-94994c3b2b54', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d87ffe-50db-4b11-8ffa-55602e216862');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-42a7-880e-b850eb0c2f68', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88598-4b78-42f3-86e2-a6602135964b');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-42b4-83c1-0f946f1b9626', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d87ffe-c251-4779-8054-15c04038a8f1');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-42bc-86bc-9e12d1be39f5', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88598-7120-46ab-85b4-a7f40af04d3a');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-42cf-8071-0a356e8b5ac1', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d8896e-5fb8-447e-86ce-d3e1548f65f0');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-42d6-89ae-2a8953c66031', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88bd8-177c-40fe-82b6-e4e6484f7c95');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-42dd-8f4f-01173e7e0304', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88bd8-4bc8-4952-8603-1c232987ce0b');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-42e8-8bff-6cd6448f2b11', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88bd8-87b6-4737-8f8b-2778c807fe43');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-42f5-8a2b-dad9276c53d6', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88bd8-a84f-434e-8e97-255bab78ccf2');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-42fd-819e-72607985c38c', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88bd7-2037-4b83-8204-31e2cf867fc3');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4306-8c90-bcf64195ab26', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88bd9-5550-4db7-8ee9-0fc027e5b289');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-430e-842a-bf82d85c3294', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88bd9-66e3-4001-8b57-bd83187c2bfc');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4315-8881-030933dd69e9', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88bd9-8bb4-45ae-83a3-79c4c7949a22');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-431f-84cd-65d2b5406ae6', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88bd9-ac4f-4261-8fd2-743db9af6739');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-4326-8b25-3cdb5f94fa60', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88bd9-bb50-4e9c-8669-3393abe8d475');
INSERT INTO `RoleMenu` VALUES ('08d88bda-1f06-432d-8fe8-aaa8e3b09c10', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', '08d88bd9-cdfc-48a6-8958-bef859429e8e');
INSERT INTO `RoleMenu` VALUES ('08d88d5b-cdf8-48fc-88d6-1a50584cf9ea', '08d88d5b-c231-4790-862d-7ff71eea370d', 'fd8a36d4-d6d8-a6bb-2924-77455100a305');
INSERT INTO `RoleMenu` VALUES ('08d88d5b-cdf9-48e3-8fbe-eb96ad778e51', '08d88d5b-c231-4790-862d-7ff71eea370d', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d88df6-4726-489c-8fb7-369fd2bb4b22', '08d879c4-b899-4cde-8a7e-f9e0c929ab9c', '08d84375-234a-48c6-83e8-36b6134f4439');
INSERT INTO `RoleMenu` VALUES ('08d88df6-4728-4f56-84f6-d2173df75e12', '08d879c4-b899-4cde-8a7e-f9e0c929ab9c', '08d84376-acc6-4924-8116-9d7af9ea87ce');
INSERT INTO `RoleMenu` VALUES ('08d88df6-4728-4fc4-83e4-0a4f651026c7', '08d879c4-b899-4cde-8a7e-f9e0c929ab9c', '08d84378-a754-4829-8ab2-83d25ab2a125');
INSERT INTO `RoleMenu` VALUES ('08d88df6-4728-4fd5-8714-58abc77f141e', '08d879c4-b899-4cde-8a7e-f9e0c929ab9c', '08d8437d-752a-4633-8ad9-f1e44f005b8d');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95a-45aa-808f-c9280a2e0123', '08d88001-7f99-4dac-8283-63ee7048010b', 'fd8a36d4-d6d8-a6bb-2924-77455100a305');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4d07-8907-2edc9c852b87', '08d88001-7f99-4dac-8283-63ee7048010b', '08d815d8-868f-45cc-8fdf-0dff5acac7fc');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4e60-850c-bde28830c739', '08d88001-7f99-4dac-8283-63ee7048010b', '08d87ffe-50db-4b11-8ffa-55602e216862');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4e75-8a98-a69a8de06b1f', '08d88001-7f99-4dac-8283-63ee7048010b', '08d88598-4b78-42f3-86e2-a6602135964b');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4eb3-805d-42823bcc75e7', '08d88001-7f99-4dac-8283-63ee7048010b', '08d87ffe-c251-4779-8054-15c04038a8f1');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4ec4-8388-4ab20086badf', '08d88001-7f99-4dac-8283-63ee7048010b', '08d88598-7120-46ab-85b4-a7f40af04d3a');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4ed0-8b02-fcd3c38717a5', '08d88001-7f99-4dac-8283-63ee7048010b', '08d815d8-dae5-4891-83d3-38a134d63506');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4edf-8201-57cc0960f2f3', '08d88001-7f99-4dac-8283-63ee7048010b', '08d815d8-f67c-4299-8d3a-c3243fcb5bc7');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4ef0-8a31-ad8c12f3cf3f', '08d88001-7f99-4dac-8283-63ee7048010b', '08d88597-eb63-428c-8422-9480fc807c31');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4efc-8ddd-c37b3d2a87fc', '08d88001-7f99-4dac-8283-63ee7048010b', '08d83d35-9456-4c13-8004-ff7f8e3fe2e9');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4f0b-8ab7-18bcda576065', '08d88001-7f99-4dac-8283-63ee7048010b', '08d88595-506f-4b2b-8583-fe22dddb3fed');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4f18-85d8-9ad20f7df486', '08d88001-7f99-4dac-8283-63ee7048010b', '08d88973-3848-4139-8979-50ba65aa6985');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4f26-8923-f7349220ebf8', '08d88001-7f99-4dac-8283-63ee7048010b', '08d88973-4ebe-43b6-83fd-d1343e3c3db3');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4f32-8efd-65121f67dd4c', '08d88001-7f99-4dac-8283-63ee7048010b', '08d88598-8230-4d89-892b-e8d34ea95e9a');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4f3e-8ae5-9d21dad3c552', '08d88001-7f99-4dac-8283-63ee7048010b', '08d88bda-a94d-40e5-82ae-dd6f5f728265');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4f58-8e06-f8acbd4e67cd', '08d88001-7f99-4dac-8283-63ee7048010b', '08d88bda-b12e-4ad2-8c19-1ba86e696050');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4f66-887c-e6fd3b39600f', '08d88001-7f99-4dac-8283-63ee7048010b', '08d88645-31bd-42e5-8211-753786aaf90b');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4f72-8b11-4eb4800b5040', '08d88001-7f99-4dac-8283-63ee7048010b', '08d88bda-448c-42e7-8f54-2cf879cd1ad5');
INSERT INTO `RoleMenu` VALUES ('08d88e18-a95c-4f85-895f-2c0177a26a20', '08d88001-7f99-4dac-8283-63ee7048010b', '08d88597-6b34-4f44-8261-dcfa2736e8fe');

-- ----------------------------
-- Table structure for User
-- ----------------------------
DROP TABLE IF EXISTS `User`;
CREATE TABLE `User`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserName` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `NormalizedUserName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `NickName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `NormalizeEmail` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `HeadImg` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL DEFAULT 0,
  `AccessFailedCount` int(0) NOT NULL DEFAULT 0,
  `IsSystem` tinyint(1) NOT NULL,
  `Sex` int(0) NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of User
-- ----------------------------
INSERT INTO `User` VALUES ('08d82b86-abb8-4276-8159-b7d7508b61a0', 'Test002', 'TEST002', 'Test002', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEKb9X4psRNVe1Nka28ta/JITPAxwMePVyt9H1WUCRLzzf+bZEllY8kG57NyF0SgrOQ==', NULL, 'KBZ6UMAFLYDFX5DYYT64C5TAY7YX35KU', 'dbbb56fc-b3ba-4e41-b235-f40c4e8c0676', NULL, 0, 0, NULL, 1, 0, 0, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-19 09:54:27.921117', 'asdsadsadsaasdsadasdasdasdasdas da sa dasd asd as dasda sd a', '2020-11-14 14:21:52.709784');
INSERT INTO `User` VALUES ('08d8476b-a962-4e7d-84cc-0344b552ae40', 'Test001', 'TEST001', '1212', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEKBZYO2xoCSVSSKmQyEgPmuV8mVMQt/yLnqaAdcqPiiZ3XBkKMj7sY9wL8bn/Yd8Jw==', NULL, 'B645HJXOQYBCTN37BAXO2GVUT6NVHUXU', '1e4ff377-54f0-489e-bf46-fb483aba0354', NULL, 0, 0, NULL, 1, 2, 1, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-23 21:51:40.155256', '', '2020-10-26 15:00:57.247934');
INSERT INTO `User` VALUES ('08d874cd-7d18-4427-83a7-135c5cae2941', 'ASS122', 'ASS122', 'ASS122', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEIqvYsQ++aC9+hnk2ZvMerHaw33K7ijjkkTIV3ShXh7Ve7SxwpFv9zwFsdq6J6WE1g==', NULL, '4LXXYGKXVR7PEBZY4LGSBBKMWGJPOCVT', '958f9f10-69a9-469f-b7e9-da468ed8a345', NULL, 0, 0, NULL, 1, 0, 0, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-20 15:55:18.848298', '', '2020-10-21 13:54:22.428716');
INSERT INTO `User` VALUES ('08d879b9-3bcf-459b-8f66-d68102fa8e2a', 'admindd_12', 'ADMINDD_12', '12', NULL, NULL, 0, '', NULL, '6YY7EMPZQM2S6DWNXY6RVJFL3VX32HQG', 'a39dbe92-3663-4a3d-bfde-ead944d17339', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 22:12:55.198302', '', NULL);
INSERT INTO `User` VALUES ('08d8819d-c546-44de-80c5-7fb55fd06a82', 'wzwzwzwzw', 'WZWZWZWZW', 'wzwzwzwzw', NULL, NULL, 0, 'AQAAAAEAACcQAAAAELHgDpf826D9z0+2yuVOof7DffM+DAg5XMCK79mJKCXVyjr7Wket3hSvQ6hETkKy4w==', NULL, 'WSMR4ATZVNEXS7QGDVWJJ2HSYW2M4FX7', '874e5268-2788-443b-9634-22474c086548', NULL, 0, 0, NULL, 1, 0, 1, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-05 23:16:29.210322', 'string', NULL);
INSERT INTO `User` VALUES ('08d888be-adc9-4887-8001-661ca4f45aa6', 'test00001', 'TEST00001', '测试', NULL, NULL, 0, NULL, NULL, '5IW34S77HLWVUBZTHYDMWP2732KDN2MR', '8639d8b2-a0ba-4fec-a7a1-4ae59757562a', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 00:59:41.344716', NULL, NULL);
INSERT INTO `User` VALUES ('08d888bf-3d6f-4a61-8fad-6786021119e3', 'test000011', 'TEST000011', '测试1', NULL, NULL, 0, NULL, NULL, 'AO7GULXE5ZV3NWRL4LVL56FDM27BSUPL', 'e2559a87-1ac9-42f6-9b4e-24982f07b3ba', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 01:03:42.377239', NULL, NULL);
INSERT INTO `User` VALUES ('08d888c0-d502-4a27-8510-68e61c637dc7', 'test0000122', 'TEST0000122', '测试12', NULL, NULL, 0, NULL, NULL, '4PXOB5KADVEC2DMFHLTANNKEJYWZXVLO', '209fc125-7c2a-40f4-88da-f201bb98aad9', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 01:15:06.140866', NULL, NULL);
INSERT INTO `User` VALUES ('08d888c2-685f-4288-8844-8458298d8914', 'test0000122222', 'TEST0000122222', '测试1211', NULL, NULL, 0, NULL, NULL, 'FI4TKE4EUOAWYD4MKPRHOGGP5KQTRVL4', '7d4f9f50-620e-4357-b6fc-67b77ff9a872', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 01:26:19.798878', NULL, NULL);
INSERT INTO `User` VALUES ('08d888c3-0b2c-4c87-8329-64b4506ec2f2', 'test000012222211', 'TEST000012222211', '测试12111', NULL, NULL, 0, NULL, NULL, '5J4GHJ4HES5SPNKNWAQNBTFR5LANIHVG', '45fa5f39-5dfa-49c9-9df1-e5dc6c019e42', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 01:30:50.898293', NULL, NULL);
INSERT INTO `User` VALUES ('08d888cb-8de4-43eb-840f-0f13d0a8874b', 'FSDFSF', 'FSDFSF', 'sdfsfsf', NULL, NULL, 0, NULL, NULL, 'TE6GL5CNESVFUEPHTOHRC57I4BHC5H5C', '33d12389-e5b7-40dd-9193-181c2e1a83b5', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 02:31:51.289592', NULL, NULL);
INSERT INTO `User` VALUES ('08d888cd-2f45-43c3-81e4-dabbc79bc8dc', 'zzzzz', 'ZZZZZ', 'sdfszzzzfsf', NULL, NULL, 0, NULL, NULL, 'IHECUJDFENZ2NVZW7KQLEKVOJXITWT76', '01065dde-35c0-4a98-8d98-7060ab360f1c', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 02:43:31.565776', NULL, NULL);
INSERT INTO `User` VALUES ('08d888cd-e0a1-40a2-81cc-c28d9597f29a', '1212', '1212', 'dssdfsdfsf', NULL, NULL, 0, NULL, NULL, '2FHAQCJB7LP6DK2YEKTYQBGXC5JZMBOJ', '0dd1875e-c59d-47ff-8f00-bad5587f21c1', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 02:48:29.093283', NULL, NULL);
INSERT INTO `User` VALUES ('08d888ce-c53d-49c5-84ae-c424afa6dd01', '222232323', '222232323', '222222222222222', NULL, NULL, 0, NULL, NULL, 'QXGLS7VDUK6A7DC4Y465M2QMYBJHXDKF', '749e8202-cb57-4d9c-b285-7482113930ee', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 02:54:52.670868', NULL, NULL);
INSERT INTO `User` VALUES ('08d88933-befc-4a48-845a-4133a61c8214', 'TestAuit111', 'TESTAUIT111', 'asfa', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEO4cPsCSwOyY1SPaD7kB6R3/6ImTkbAolC7uyNiG/M3FpI9UF1wWglWLMbQ4OLWWMw==', NULL, '5BJV5XYNN5NCLH5ZTTRNTJU2W36XCYM5', 'fa863095-e832-4ace-8f45-2832ab55d1c0', NULL, 0, 0, NULL, 1, 0, 0, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-15 14:57:41.320005', '1', '2020-11-15 16:52:57.105031');
INSERT INTO `User` VALUES ('08d88a2c-d58d-4502-8115-c1b9ac1bb76f', 'Test1000', 'TEST1000', 'Test1000', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEGolnkmZ1/zGPu+Kby688VKEsr6jglPF25EGTyjm99XlXbk1Dig2DNEN+FKxjvwHsA==', NULL, 'CSQWTU33BUKDTFYWLTJLXKHWBA2BBGX5', 'b8abb8a3-0813-4724-b1f8-518fd5fde535', NULL, 0, 0, NULL, 1, 0, 0, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-16 20:40:43.862804', '测试专用', '2020-11-21 00:40:22.841141');
INSERT INTO `User` VALUES ('08d88d56-9598-42c4-84df-d9b341f2ad76', 'TEST003', 'TEST003', 'TEST003', NULL, NULL, 0, 'AQAAAAEAACcQAAAAECA5uZ0iQWg4S+sJPDhDh2wzpMdH52Kl+427OVPxlfyOEPfRwTyaj8a0RrkYaCjyHQ==', NULL, '2FXY3D3W57GT2ROOEONOCDDSLNMX4EI7', 'c99b4949-9ba4-4eba-9688-49ff6cb9c825', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-20 21:17:08.924426', '132456', NULL);
INSERT INTO `User` VALUES ('08d88d5b-b5ec-4a96-8cf1-e0edaee1423a', 'Test2000', 'TEST2000', 'Test2000', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEBF/HlmbR9F4fQ7RSpQ42zSKUBMWFlxy9dFrT1nwv6XzmNeU+TOXAxK5/ozqjEGb3g==', NULL, 'XI2RXKKV32UMF2EFTGCKN5DXVZHJ2JK3', 'f77faab3-74c3-4a36-b90f-dd1970c7a9b4', NULL, 0, 0, NULL, 1, 0, 0, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-20 21:53:50.622636', '', '2020-11-20 21:55:40.561538');
INSERT INTO `User` VALUES ('08d88de7-ca60-4916-8ed4-0f9b08543569', '1111', '1111', '111111', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEIPN+qrZAtVkv+ZVDsELkErsAC4pac8T7cCjLyHbrxezVs9gkVJ6lj91L5lln42XxQ==', NULL, '5PVZ6HO6NVOHMICFPHH4RZUIQREHDUIR', '5a0934e6-ced1-4d40-85db-a9bfc548e680', NULL, 0, 0, NULL, 1, 0, 0, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-21 14:36:34.491315', '', '2020-11-21 14:48:25.934080');
INSERT INTO `User` VALUES ('08d88de9-8c72-45ed-889f-8b978e8aacac', 'DHGTEST', 'DHGTEST', 'DHGTEST', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEAjE+oF7Q1IdRanlVuiqNjG7pxuJsMq9CPpozOfbUNAW2w2bU+vvv0Do/CcyM8443Q==', NULL, 'GYTYLX3KF5UM5I7TJKZZ27NI2KOOIASS', '2f4b9fa9-a778-446b-a871-651a3e9fc8ba', NULL, 0, 0, NULL, 1, 0, 0, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-21 14:49:09.590955', '大黄瓜测试专用', '2020-11-21 14:54:19.301606');
INSERT INTO `User` VALUES ('08d8915c-4688-4235-8834-9b828ac7b445', 'Test100000', 'TEST100000', '测试100000', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEILGIj6z/swMzCwuePRSlf9Ou7QHqgwIU0X6i4g8TJLfJjU/DBNrEZ+AEwujRsp8wQ==', NULL, 'IAPE7ZTIZ4FZMJH3VWXHNZL7IVU2MEF7', '44f0c1c9-5113-4602-97ee-5d2cf506f179', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-26 00:07:57.890838', '', NULL);
INSERT INTO `User` VALUES ('08d89211-7ff6-4aff-8b74-dbbc82bf6d9d', 'Test20000', 'TEST20000', 'Test20000', NULL, NULL, 0, 'AQAAAAEAACcQAAAAECmE8gxgAglYg9Ncxc4VjV2KmS48MbMbMR+v17ED4iU45GWzopOjVqN8u7r2CcCpgw==', NULL, '5SP5GWW23HSQSXDF6MLK2E5TDSIQYBS6', '301fbec6-402a-4803-9393-d9027f5e3d8d', NULL, 0, 0, NULL, 1, 0, 0, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-26 21:45:13.152901', '', '2020-11-26 21:45:23.136605');
INSERT INTO `User` VALUES ('08d89926-0367-4abe-8dac-b5cc881f0cc5', 'Test8888', 'TEST8888', 'Test8888', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEJQMNngsGWOH63MHY5vhnYsZAjGQbn/hvsghjQmUfimsnt4QSo35BOdMtRi48HZR5A==', NULL, '5AL2GK6Z5OFLNWVNKCS2E6KORV7WVJME', 'a4251836-9e3a-46fe-ac30-c50c2eae69be', NULL, 0, 0, NULL, 1, 0, 0, 0, NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-12-05 21:59:41.745583', '', NULL);
INSERT INTO `User` VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6', 'string748687789', 'STRING748687789', 'string45455445544554', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEMS6tmv/L4i6uiXQfIKTLP3Q6IkA6nxWW1LsRfBR9YLWP0Ul6U1nwE1OpwQbmXhsmw==', NULL, 'JQMDXWWAM6ORVVK6X6ECCOV7OSYGDSIA', 'd4a6b747-99a3-4a1b-8863-c6fa380d337a', NULL, 0, 0, NULL, 1, 0, 0, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-15 20:36:12.850051', 'string', '2020-10-26 14:58:31.876072');
INSERT INTO `User` VALUES ('a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 'Admin', 'ADMIN', '管理员', NULL, NULL, 0, 'AQAAAAEAACcQAAAAEEPWhHPCHU1i6Z0ayoApKGbPlZUb38RUdJg4QjUcccVhUSto0sRZtLOXfwWUJ+P2Xw==', NULL, '3OWMGQAK5ZTXMSV6OFSGIWWWNIWJ2SX6', '0286cab6-8a4a-44ed-9a97-86b0506c65c3', NULL, 0, 0, '2020-10-09 08:53:58.931179', 0, 0, 1, 0, '00000000-0000-0000-0000-000000000000', 0, NULL, '2020-06-16 22:38:12.095039', '系统管理员拥有所有权限', '2020-12-02 22:51:37.253405');

-- ----------------------------
-- Table structure for UserClaim
-- ----------------------------
DROP TABLE IF EXISTS `UserClaim`;
CREATE TABLE `UserClaim`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of UserClaim
-- ----------------------------

-- ----------------------------
-- Table structure for UserRole
-- ----------------------------
DROP TABLE IF EXISTS `UserRole`;
CREATE TABLE `UserRole`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of UserRole
-- ----------------------------
INSERT INTO `UserRole` VALUES ('08d7e920-8bd6-4be2-8b2b-751408ef20e2', '08d7e605-abb6-4bb0-8dcf-650872ad9e4a', '08d7e440-c641-4b91-87d8-9a80bb083415', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-04-25 21:57:09.036031', NULL);
INSERT INTO `UserRole` VALUES ('08d7e920-8bfa-4c73-847f-ff5f0d41667e', '08d7e605-abb6-4bb0-8dcf-650872ad9e4a', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-04-25 21:57:09.290217', NULL);
INSERT INTO `UserRole` VALUES ('08d7e921-50f5-4605-8702-d18ae8ea90d8', '08d7e921-5092-4d2b-8386-2baa014c2b1c', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-25 22:02:39.765817', NULL);
INSERT INTO `UserRole` VALUES ('08d7e921-5114-488c-8aec-f759aa1ac906', '08d7e921-5092-4d2b-8386-2baa014c2b1c', '08d7e43f-4ef1-4349-8fb0-cf493929d335', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-25 22:02:39.970300', NULL);
INSERT INTO `UserRole` VALUES ('08d7e921-5132-49a6-8451-23d2224f8d28', '08d7e921-5092-4d2b-8386-2baa014c2b1c', '08d7e43f-8187-4124-879d-c80d973ca626', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-25 22:02:40.167432', NULL);
INSERT INTO `UserRole` VALUES ('08d7e921-5150-445d-8ea6-dfb3621efc2c', '08d7e921-5092-4d2b-8386-2baa014c2b1c', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-25 22:02:40.362060', NULL);
INSERT INTO `UserRole` VALUES ('08d7e921-516f-4279-8282-479530b9250b', '08d7e921-5092-4d2b-8386-2baa014c2b1c', '08d7e440-c641-4b91-87d8-9a80bb083415', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-25 22:02:40.564537', NULL);
INSERT INTO `UserRole` VALUES ('08d7e921-7628-4a00-88e2-ca40529081c6', '08d7e921-75ec-41ae-8729-5223be30a75b', '08d7e43f-4ef1-4349-8fb0-cf493929d335', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-25 22:03:42.178058', NULL);
INSERT INTO `UserRole` VALUES ('08d7e921-7646-44c0-84fe-48d6d102c907', '08d7e921-75ec-41ae-8729-5223be30a75b', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-25 22:03:42.372342', NULL);
INSERT INTO `UserRole` VALUES ('08d7e921-7665-4035-81bb-2139d66b61c4', '08d7e921-75ec-41ae-8729-5223be30a75b', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-04-25 22:03:42.573705', NULL);
INSERT INTO `UserRole` VALUES ('08d7f005-49fe-40e3-8699-7bc7ee7ef670', '08d7f005-49d3-4031-8ad9-48a05173ab98', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-05-04 16:29:40.309710', NULL);
INSERT INTO `UserRole` VALUES ('08d7f005-4a08-4cdd-81d3-07f8f80fb300', '08d7f005-49d3-4031-8ad9-48a05173ab98', '08d7e43f-4ef1-4349-8fb0-cf493929d335', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-05-04 16:29:40.380508', NULL);
INSERT INTO `UserRole` VALUES ('08d7f005-631f-4ff1-860c-eba1872faf36', '08d7f005-630a-4890-8ca6-acbba9f2f780', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-05-04 16:30:22.475760', NULL);
INSERT INTO `UserRole` VALUES ('08d7f005-6328-4e2f-8612-0c6edf0a4ed0', '08d7f005-630a-4890-8ca6-acbba9f2f780', '08d7e43f-4ef1-4349-8fb0-cf493929d335', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-05-04 16:30:22.534079', NULL);
INSERT INTO `UserRole` VALUES ('08d7f005-6331-4d26-88e7-e1c9302f6626', '08d7f005-630a-4890-8ca6-acbba9f2f780', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-05-04 16:30:22.592628', NULL);
INSERT INTO `UserRole` VALUES ('08d7f018-31e3-4c1f-82e1-eced9a3bc2f9', '08d7e605-abb6-4bb0-8dcf-650872ad9e4a', '08d7e440-c641-4b91-87d8-9a80bb083415', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 18:45:00.274336', NULL);
INSERT INTO `UserRole` VALUES ('08d7f018-3205-42b7-83ce-8b4cbfd2afdb', '08d7e605-abb6-4bb0-8dcf-650872ad9e4a', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 18:45:00.529014', NULL);
INSERT INTO `UserRole` VALUES ('08d7f018-3ef8-4099-8e0c-d599519e317a', '08d7e605-abb6-4bb0-8dcf-650872ad9e4a', '08d7e440-c641-4b91-87d8-9a80bb083415', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 18:45:22.253404', NULL);
INSERT INTO `UserRole` VALUES ('08d7f018-3f17-4f79-8384-cde06fdb9abb', '08d7e605-abb6-4bb0-8dcf-650872ad9e4a', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 18:45:22.463022', NULL);
INSERT INTO `UserRole` VALUES ('08d7f018-4853-47f9-8319-e4947fc2c0b7', '08d7e605-abb6-4bb0-8dcf-650872ad9e4a', '08d7e440-c641-4b91-87d8-9a80bb083415', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 18:45:37.952435', NULL);
INSERT INTO `UserRole` VALUES ('08d7f018-486f-48c5-866f-25592f374c5e', '08d7e605-abb6-4bb0-8dcf-650872ad9e4a', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-04 18:45:38.136532', NULL);
INSERT INTO `UserRole` VALUES ('08d7f018-a0aa-496e-8f61-2ed405675083', '08d7f018-a070-4f95-864d-53a14f37fa67', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-05-04 18:48:06.162970', NULL);
INSERT INTO `UserRole` VALUES ('08d7f0d5-01fb-45aa-886d-5d5d2b8b6292', '08d7f0d5-0191-4dd8-8a85-49f06aa28f6b', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-05 17:16:34.815448', NULL);
INSERT INTO `UserRole` VALUES ('08d7f0d5-021c-43a8-8fd5-fac286abeaa3', '08d7f0d5-0191-4dd8-8a85-49f06aa28f6b', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-05 17:16:35.031507', NULL);
INSERT INTO `UserRole` VALUES ('08d7f0d5-023a-4084-8965-91864bd2d05d', '08d7f0d5-0191-4dd8-8a85-49f06aa28f6b', '08d7e440-c641-4b91-87d8-9a80bb083415', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-05 17:16:35.226862', NULL);
INSERT INTO `UserRole` VALUES ('08d7f0d5-0258-4aba-832a-466710afee9e', '08d7f0d5-0191-4dd8-8a85-49f06aa28f6b', '08d7efe7-97f8-4262-877d-6f72b76c333b', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-05 17:16:35.427842', NULL);
INSERT INTO `UserRole` VALUES ('08d7f0d5-18f4-4c70-815d-2868fe06d36e', '08d7f0d5-0191-4dd8-8a85-49f06aa28f6b', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-05-05 17:17:13.360836', NULL);
INSERT INTO `UserRole` VALUES ('08d7f0d5-1911-4492-88cf-aa1f837e010e', '08d7f0d5-0191-4dd8-8a85-49f06aa28f6b', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-05-05 17:17:13.547692', NULL);
INSERT INTO `UserRole` VALUES ('08d7f0d5-1938-4980-8a4f-5c4730f38ab9', '08d7f0d5-0191-4dd8-8a85-49f06aa28f6b', '08d7e440-c641-4b91-87d8-9a80bb083415', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-05-05 17:17:13.805290', NULL);
INSERT INTO `UserRole` VALUES ('08d7f0d5-1955-4654-8fcb-a9fd6d075c09', '08d7f0d5-0191-4dd8-8a85-49f06aa28f6b', '08d7efe7-97f8-4262-877d-6f72b76c333b', NULL, 0, '00000000-0000-0000-0000-000000000000', '2020-05-05 17:17:13.994006', NULL);
INSERT INTO `UserRole` VALUES ('08d80538-4194-4218-84a6-c6677fb4b9b7', '08d80538-412d-4c37-8338-e5885f8bcdae', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL, 1, '00000000-0000-0000-0000-000000000000', '2020-05-31 15:57:24.945299', NULL);
INSERT INTO `UserRole` VALUES ('08d8053a-6661-44c4-8766-b1769539bfc9', '08d80538-412d-4c37-8338-e5885f8bcdae', '08d7eff8-d254-4848-80da-d4693602966c', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-05-31 16:12:45.681522', NULL);
INSERT INTO `UserRole` VALUES ('08d80557-0bdd-4311-81fa-0dccf1d75bc1', '08d80557-0bb3-4453-8f6f-05db14d9b68b', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-05-31 11:37:49.223991', NULL);
INSERT INTO `UserRole` VALUES ('08d80557-154a-4235-86c8-0a8eeb174bff', '08d80557-1534-4c1f-8a7e-e129b8f27a91', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-05-31 11:38:05.039422', NULL);
INSERT INTO `UserRole` VALUES ('08d80557-e198-4bf9-8413-536d3c349600', '08d80557-e180-44f4-82ed-15b15797fac1', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-05-31 11:43:47.810098', NULL);
INSERT INTO `UserRole` VALUES ('08d80600-a9b6-4c5b-8fcd-7081ab8569e1', '08d80600-a9a1-4b1b-848a-915218c2c9f0', '08d7efe7-b536-4bd0-8d7e-47e081abc01f', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-01 07:51:59.001652', NULL);
INSERT INTO `UserRole` VALUES ('08d80794-684a-433e-82e3-ffa5bab2d6ba', '08d80794-6833-47ca-8add-ecbd9a3d9a30', '08d7efe7-b536-4bd0-8d7e-47e081abc01f', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-03 08:02:05.917111', NULL);
INSERT INTO `UserRole` VALUES ('08d80796-5ba3-4a80-86b2-4c64259878b4', '08d80796-5b8d-4821-8310-6ff589abd11d', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-03 08:16:03.686268', NULL);
INSERT INTO `UserRole` VALUES ('08d80e1d-7807-4dfc-8dd3-e4bf2f60f092', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-11 23:38:20.331360', NULL);
INSERT INTO `UserRole` VALUES ('08d80e1d-e406-4d43-842d-e057143def00', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-11 23:41:21.541161', NULL);
INSERT INTO `UserRole` VALUES ('08d80e1d-ee26-4fec-8ae7-939cb3d294f0', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-11 23:41:38.529715', NULL);
INSERT INTO `UserRole` VALUES ('08d80e1e-17eb-4c35-8d44-0cd0acfbba81', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-11 23:42:48.605837', NULL);
INSERT INTO `UserRole` VALUES ('08d80e1e-1bbb-4ad4-8e3d-21c5d19e73b1', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-11 23:42:55.001588', NULL);
INSERT INTO `UserRole` VALUES ('08d80e1e-c80a-4090-8e16-6395df943917', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-11 23:47:44.083220', NULL);
INSERT INTO `UserRole` VALUES ('08d80e1f-21ca-4012-8871-d5d51d069ad9', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-11 23:50:14.658061', NULL);
INSERT INTO `UserRole` VALUES ('08d80e1f-45df-477c-86d0-1c1928ef9457', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-11 23:51:15.197165', NULL);
INSERT INTO `UserRole` VALUES ('08d80e20-e492-4f5b-88f6-ffd310622abd', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-12 00:02:50.928770', NULL);
INSERT INTO `UserRole` VALUES ('08d80e22-9b06-4f72-8fd1-6efee14f1ff9', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-12 00:15:06.529554', NULL);
INSERT INTO `UserRole` VALUES ('08d80e22-a2e2-472b-8489-e44313560f80', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-12 00:15:19.734573', NULL);
INSERT INTO `UserRole` VALUES ('08d80e22-cd64-42d5-809a-c1687d25403f', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-12 00:16:31.048634', NULL);
INSERT INTO `UserRole` VALUES ('08d80e23-0214-4a1e-8a6c-1f080dd06df8', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-06-12 00:17:59.447205', NULL);
INSERT INTO `UserRole` VALUES ('08d80ed0-6d83-43c9-8291-6356be88fd9a', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, '08d80e1e-12d6-461f-8a94-e9c864de6a14', '2020-06-12 20:59:22.599823', NULL);
INSERT INTO `UserRole` VALUES ('08d80ed1-0793-48c8-8d87-547acbda2342', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, '08d80e1e-12d6-461f-8a94-e9c864de6a14', '2020-06-12 21:03:41.098312', NULL);
INSERT INTO `UserRole` VALUES ('08d80ed1-afa6-4d42-8f39-15ed873c98ce', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, '08d80e1e-12d6-461f-8a94-e9c864de6a14', '2020-06-12 21:08:23.082260', NULL);
INSERT INTO `UserRole` VALUES ('08d80ed1-efae-4755-85c0-ab23d1ef24f4', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, '08d80e1e-12d6-461f-8a94-e9c864de6a14', '2020-06-12 21:10:10.505974', NULL);
INSERT INTO `UserRole` VALUES ('08d80ed1-f375-489a-8732-5c7061cab0ca', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 1, '08d80e1e-12d6-461f-8a94-e9c864de6a14', '2020-06-12 21:10:16.844342', NULL);
INSERT INTO `UserRole` VALUES ('08d820ba-b781-4c75-8624-329f7e2b6927', 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '08d7e440-c641-4b91-87d8-9a80bb083415', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-05 16:09:18.752034', NULL);
INSERT INTO `UserRole` VALUES ('08d820bb-1668-4ae8-8a60-14773b1e64d4', 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '08d7e440-c641-4b91-87d8-9a80bb083415', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-05 16:11:57.985127', NULL);
INSERT INTO `UserRole` VALUES ('08d820c4-e404-4346-8b14-6c20dbf62abb', 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', 'b8551e97-0723-47fc-bd7e-aff35bb1b1e7', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-05 17:22:08.406783', NULL);
INSERT INTO `UserRole` VALUES ('08d820c8-ad31-4f56-83ea-1b66daeaf166', '08d7e605-abb6-4bb0-8dcf-650872ad9e4a', '08d7e440-c641-4b91-87d8-9a80bb083415', NULL, 0, '08d7e60c-fb44-4122-894b-1171470d9248', '2020-07-05 17:49:14.406847', NULL);
INSERT INTO `UserRole` VALUES ('08d820c8-ad40-41f5-8e20-2cb295bd109b', '08d7e605-abb6-4bb0-8dcf-650872ad9e4a', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL, 0, '08d7e60c-fb44-4122-894b-1171470d9248', '2020-07-05 17:49:14.512887', NULL);
INSERT INTO `UserRole` VALUES ('08d820c8-c202-45e1-8f24-e110fb2bd758', '08d820c8-c1e9-4356-8d0b-74d3e6a796b2', '08d7e43f-1991-496a-8bfc-bda023fd6a1b', NULL, 1, '08d7e60c-fb44-4122-894b-1171470d9248', '2020-07-05 17:49:49.340762', NULL);
INSERT INTO `UserRole` VALUES ('08d8273a-84d0-4419-85f9-c25b7e3844ad', '08d7e60d-385b-4015-8cd2-22394b43f428', '08d80a10-221f-48f3-83ea-81e35ca1cf6b', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-13 22:39:16.273798', NULL);
INSERT INTO `UserRole` VALUES ('08d8273a-e58c-47ad-8cb1-10dde1fc8e70', '08d820c8-c1e9-4356-8d0b-74d3e6a796b2', '08d80a10-221f-48f3-83ea-81e35ca1cf6b', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-13 22:41:58.569939', NULL);
INSERT INTO `UserRole` VALUES ('08d8273c-7867-4aad-8cf8-17ab4bbb0f7d', '08d8273c-7823-430c-8ba7-a85c1494afbd', '08d80a10-221f-48f3-83ea-81e35ca1cf6b', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-13 14:53:14.448813', NULL);
INSERT INTO `UserRole` VALUES ('08d8273c-9ac6-4823-8aad-4a33c5844413', '08d8273c-9aad-4190-8484-9ab01953ccec', '08d80a10-221f-48f3-83ea-81e35ca1cf6b', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-13 14:54:12.114330', NULL);
INSERT INTO `UserRole` VALUES ('08d82b86-abdd-4f86-8576-351f232661a3', '08d82b86-abb8-4276-8159-b7d7508b61a0', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-19 09:54:28.198253', NULL);
INSERT INTO `UserRole` VALUES ('08d82b86-da51-4920-8c6c-dc5efe9780b9', '08d82b86-abb8-4276-8159-b7d7508b61a0', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-19 09:55:46.131138', NULL);
INSERT INTO `UserRole` VALUES ('08d82b88-88cd-4514-898f-448db8c6e4bd', '08d82b86-abb8-4276-8159-b7d7508b61a0', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-19 10:07:48.362756', NULL);
INSERT INTO `UserRole` VALUES ('08d82bad-60f3-495d-8d77-938f6630762c', '08d82b86-abb8-4276-8159-b7d7508b61a0', '08d7e43f-c369-4631-8f72-160649a6dc9e', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-07-19 14:31:32.870749', NULL);
INSERT INTO `UserRole` VALUES ('08d83d37-ab24-43ec-86b8-0c859a25c89a', '08d83d37-a51a-4fd2-86de-b41ec38fd244', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-10 22:14:17.666393', NULL);
INSERT INTO `UserRole` VALUES ('08d83d3f-e55b-4089-8302-859a9701fa22', '08d82b86-abb8-4276-8159-b7d7508b61a0', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-10 23:13:11.295599', NULL);
INSERT INTO `UserRole` VALUES ('08d83dfb-8096-4c86-8835-168cb5f6b162', '08d83dfb-804a-406f-8702-32103eb32506', '08d83c76-2b1e-4794-8b2f-3a2aff1edae2', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-11 21:36:07.636911', NULL);
INSERT INTO `UserRole` VALUES ('08d83dfc-89e0-40ab-8f80-a803a0811fe4', '08d83dfb-804a-406f-8702-32103eb32506', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-11 21:43:32.690989', NULL);
INSERT INTO `UserRole` VALUES ('08d83dfd-b2d2-48f9-82e9-017e376f2e79', '08d83dfd-b27e-47d1-8991-9747ef675a1d', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-11 21:51:50.907918', NULL);
INSERT INTO `UserRole` VALUES ('08d83dfe-ec78-4abd-80d8-b09ca724a3da', '08d83dfe-ec17-4390-8ec5-2782d375a606', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-11 22:00:37.123715', NULL);
INSERT INTO `UserRole` VALUES ('08d83dfe-fa1b-4bf1-870a-0d0da8e995cd', '08d83dfe-ec17-4390-8ec5-2782d375a606', '08d83c76-2b1e-4794-8b2f-3a2aff1edae2', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-11 22:01:00.002978', NULL);
INSERT INTO `UserRole` VALUES ('08d84451-c1c8-4550-8cb5-d4717fa9550f', '08d84451-c188-4131-88f3-832dd407b123', '08d83c76-2b1e-4794-8b2f-3a2aff1edae2', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-19 23:08:40.708526', NULL);
INSERT INTO `UserRole` VALUES ('08d84451-c973-4470-8e88-d59799f04a05', '08d84451-c188-4131-88f3-832dd407b123', '08d83c76-2b1e-4794-8b2f-3a2aff1edae2', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-19 23:08:53.573838', NULL);
INSERT INTO `UserRole` VALUES ('08d8451d-a8c6-437a-8a94-2e771e31748a', '08d8451d-a86b-4720-8af9-ae955acfc5eb', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 23:28:16.084907', NULL);
INSERT INTO `UserRole` VALUES ('08d8451d-a8e3-4d18-873f-251d163be129', '08d8451d-a86b-4720-8af9-ae955acfc5eb', '08d83c76-2b1e-4794-8b2f-3a2aff1edae2', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 23:28:16.279105', NULL);
INSERT INTO `UserRole` VALUES ('08d8451d-a902-43e0-8bcd-73224c63b232', '08d8451d-a86b-4720-8af9-ae955acfc5eb', '08d84051-cfdb-441d-8481-2d83a8f1a412', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 23:28:16.478834', NULL);
INSERT INTO `UserRole` VALUES ('08d8451d-e3f7-4cb5-8408-adf60072e789', '08d8451d-a86b-4720-8af9-ae955acfc5eb', '08d83c76-2b1e-4794-8b2f-3a2aff1edae2', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 23:29:55.395949', NULL);
INSERT INTO `UserRole` VALUES ('08d8451d-e415-46a9-8b50-0db6332c1fc3', '08d8451d-a86b-4720-8af9-ae955acfc5eb', '08d84051-cfdb-441d-8481-2d83a8f1a412', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 23:29:55.590100', NULL);
INSERT INTO `UserRole` VALUES ('08d8451e-9ca1-4ba5-8e2c-f623a4594547', '08d8451d-a86b-4720-8af9-ae955acfc5eb', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 23:35:05.210409', NULL);
INSERT INTO `UserRole` VALUES ('08d8451e-9cbe-4139-8a4c-5d9493a547f0', '08d8451d-a86b-4720-8af9-ae955acfc5eb', '08d83c76-2b1e-4794-8b2f-3a2aff1edae2', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 23:35:05.396203', NULL);
INSERT INTO `UserRole` VALUES ('08d8451e-9cdd-4a43-8ef9-34b95b12db2c', '08d8451d-a86b-4720-8af9-ae955acfc5eb', '08d84051-cfdb-441d-8481-2d83a8f1a412', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-20 23:35:05.603077', NULL);
INSERT INTO `UserRole` VALUES ('08d8476b-a9c3-44c8-8028-4a77a692e1ab', '08d8476b-a962-4e7d-84cc-0344b552ae40', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-08-23 21:51:40.813991', NULL);
INSERT INTO `UserRole` VALUES ('08d850d4-599e-4028-87fb-1006e0f8e0ff', '08d82b86-abb8-4276-8159-b7d7508b61a0', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 21:13:43.959075', NULL);
INSERT INTO `UserRole` VALUES ('08d850e1-cef8-4d4c-800c-fb540c74092d', '08d82b86-abb8-4276-8159-b7d7508b61a0', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:50:04.315446', NULL);
INSERT INTO `UserRole` VALUES ('08d850e1-de02-43ec-869e-2cff7369524a', '08d8476b-a962-4e7d-84cc-0344b552ae40', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-09-04 22:50:29.547515', NULL);
INSERT INTO `UserRole` VALUES ('08d8797b-b730-4968-8344-00297c4ab938', '08d8476b-a962-4e7d-84cc-0344b552ae40', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 14:52:33.409906', NULL);
INSERT INTO `UserRole` VALUES ('08d8797c-2028-4d77-8623-eb59329a2973', '08d8476b-a962-4e7d-84cc-0344b552ae40', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 1, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 14:55:29.537217', NULL);
INSERT INTO `UserRole` VALUES ('08d8797c-8cc9-4708-8a97-64e2d56faeb2', '3fa85f64-5717-4562-b3fc-2c963f66afa6', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 14:58:31.784102', NULL);
INSERT INTO `UserRole` VALUES ('08d8797c-e368-4375-87b0-0590968572db', '08d8476b-a962-4e7d-84cc-0344b552ae40', '08d83c6e-4cc0-41a0-865a-9ee5b50c971c', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-10-26 15:00:57.108614', NULL);
INSERT INTO `UserRole` VALUES ('08d88865-93cd-4715-8e57-06db7caa342e', '08d82b86-abb8-4276-8159-b7d7508b61a0', '08d88001-7f99-4dac-8283-63ee7048010b', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-14 14:21:52.540570', NULL);
INSERT INTO `UserRole` VALUES ('08d88a31-b780-415c-89fa-a250263380c2', '08d88a2c-d58d-4502-8115-c1b9ac1bb76f', '08d88001-7f99-4dac-8283-63ee7048010b', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-16 21:15:40.935176', NULL);
INSERT INTO `UserRole` VALUES ('08d88d5b-f741-4cab-824d-f56c57e68e49', '08d88d5b-b5ec-4a96-8cf1-e0edaee1423a', '08d88d5b-c231-4790-862d-7ff71eea370d', NULL, 0, 'a1e89f45-4fa8-4751-9df9-dec86f7e6c14', '2020-11-20 21:55:40.273910', NULL);

-- ----------------------------
-- Table structure for UserToken
-- ----------------------------
DROP TABLE IF EXISTS `UserToken`;
CREATE TABLE `UserToken`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LoginProvider` varchar(450) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Name` varchar(450) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `LastModifierUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `CreatorUserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreatedTime` datetime(6) NOT NULL,
  `LastModifionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of UserToken
-- ----------------------------

-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
DROP TABLE IF EXISTS `__EFMigrationsHistory`;
CREATE TABLE `__EFMigrationsHistory`  (
  `MigrationId` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO `__EFMigrationsHistory` VALUES ('20200616141818_dhg20200616', '3.1.4');
INSERT INTO `__EFMigrationsHistory` VALUES ('20200616142105_wzw20200616_v2', '3.1.4');
INSERT INTO `__EFMigrationsHistory` VALUES ('20200616143812_dhg20200616_v2', '3.1.4');
INSERT INTO `__EFMigrationsHistory` VALUES ('20200622141936_20200622', '3.1.4');
INSERT INTO `__EFMigrationsHistory` VALUES ('20200624134302_wzw20200624_v1', '3.1.4');
INSERT INTO `__EFMigrationsHistory` VALUES ('20200627123301_20200627', '3.1.4');
INSERT INTO `__EFMigrationsHistory` VALUES ('20200630145002_wzw20200630_v1', '3.1.4');
INSERT INTO `__EFMigrationsHistory` VALUES ('20200720131959_wzw20200720', '3.1.5');
INSERT INTO `__EFMigrationsHistory` VALUES ('20200720132335_wzw20200720_v1', '3.1.5');
INSERT INTO `__EFMigrationsHistory` VALUES ('20200720132426_wzw20200720_v2', '3.1.5');
INSERT INTO `__EFMigrationsHistory` VALUES ('20200811133307_Destiny20200811_v1', '3.1.6');
INSERT INTO `__EFMigrationsHistory` VALUES ('20200921131442_wzwIdentityServer4_20200921_v1', '3.1.8');
INSERT INTO `__EFMigrationsHistory` VALUES ('20200921131720_wzwIdentityServer4_20200921_v2', '3.1.8');
INSERT INTO `__EFMigrationsHistory` VALUES ('20201107142235_wzw20201107_v1', '3.1.8');
INSERT INTO `__EFMigrationsHistory` VALUES ('20201111143327_20201111', '3.1.8');

SET FOREIGN_KEY_CHECKS = 1;
