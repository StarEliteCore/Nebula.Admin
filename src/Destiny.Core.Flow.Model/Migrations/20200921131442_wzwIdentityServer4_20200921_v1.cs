using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class wzwIdentityServer4_20200921_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifierTime",
                table: "UserToken");

            migrationBuilder.DropColumn(
                name: "LastModifierTime",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "LastModifierTime",
                table: "UserClaim");

            migrationBuilder.DropColumn(
                name: "LastModifierTime",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastModifierTime",
                table: "RoleClaim");

            migrationBuilder.DropColumn(
                name: "LastModifierTime",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "LastModifierTime",
                table: "Organizated");

            migrationBuilder.DropColumn(
                name: "LastModifierTime",
                table: "MenuFunction");

            migrationBuilder.DropColumn(
                name: "LastModifierTime",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "LastModifierTime",
                table: "Function");

            migrationBuilder.DropColumn(
                name: "LastModifierTime",
                table: "DataDictionary");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifionTime",
                table: "UserToken",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifionTime",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifionTime",
                table: "UserClaim",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifionTime",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifionTime",
                table: "RoleClaim",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifionTime",
                table: "Role",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifionTime",
                table: "Organizated",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifionTime",
                table: "MenuFunction",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifionTime",
                table: "Menu",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifionTime",
                table: "Function",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifionTime",
                table: "DataDictionary",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false, defaultValue: true),
                    ClientId = table.Column<string>(nullable: true),
                    ProtocolType = table.Column<string>(nullable: true, defaultValue: "oidc"),
                    RequireClientSecret = table.Column<bool>(nullable: false, defaultValue: true),
                    ClientName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ClientUri = table.Column<string>(nullable: true),
                    LogoUri = table.Column<string>(nullable: true),
                    RequireConsent = table.Column<bool>(nullable: false),
                    AllowRememberConsent = table.Column<bool>(nullable: false, defaultValue: true),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(nullable: false),
                    RequirePkce = table.Column<bool>(nullable: false, defaultValue: true),
                    AllowPlainTextPkce = table.Column<bool>(nullable: false),
                    RequireRequestObject = table.Column<bool>(nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(nullable: false),
                    FrontChannelLogoutUri = table.Column<string>(nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(nullable: false, defaultValue: true),
                    BackChannelLogoutUri = table.Column<string>(nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(nullable: false, defaultValue: true),
                    AllowOfflineAccess = table.Column<bool>(nullable: false),
                    IdentityTokenLifetime = table.Column<int>(nullable: false, defaultValue: 300),
                    AllowedIdentityTokenSigningAlgorithms = table.Column<string>(nullable: true),
                    AccessTokenLifetime = table.Column<int>(nullable: false, defaultValue: 3600),
                    AuthorizationCodeLifetime = table.Column<int>(nullable: false, defaultValue: 300),
                    ConsentLifetime = table.Column<int>(nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(nullable: false, defaultValue: 2592000),
                    SlidingRefreshTokenLifetime = table.Column<int>(nullable: false, defaultValue: 2592000),
                    RefreshTokenUsage = table.Column<int>(nullable: false, defaultValue: -1),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(nullable: false),
                    RefreshTokenExpiration = table.Column<int>(nullable: false, defaultValue: -1),
                    AccessTokenType = table.Column<int>(nullable: false),
                    EnableLocalLogin = table.Column<bool>(nullable: false, defaultValue: true),
                    IncludeJwtId = table.Column<bool>(nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>(nullable: false),
                    ClientClaimsPrefix = table.Column<string>(nullable: true, defaultValue: "client_"),
                    PairWiseSubjectSalt = table.Column<string>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    UserSsoLifetime = table.Column<int>(nullable: true),
                    UserCodeType = table.Column<string>(nullable: true),
                    DeviceCodeLifetime = table.Column<int>(nullable: false, defaultValue: 300),
                    NonEditable = table.Column<bool>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientClaim_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientCorsOrigin",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Origin = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCorsOrigin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCorsOrigin_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientGrantType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GrantType = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGrantType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientGrantType_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientIdPRestriction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Provider = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientIdPRestriction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientIdPRestriction_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientPostLogoutRedirectUri",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PostLogoutRedirectUri = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPostLogoutRedirectUri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientPostLogoutRedirectUri_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientProperty_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientRedirectUri",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RedirectUri = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRedirectUri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientRedirectUri_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientScope",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Scope = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientScope", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientScope_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientSecret",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSecret", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientSecret_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientClaim_ClientId",
                table: "ClientClaim",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCorsOrigin_ClientId",
                table: "ClientCorsOrigin",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGrantType_ClientId",
                table: "ClientGrantType",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdPRestriction_ClientId",
                table: "ClientIdPRestriction",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPostLogoutRedirectUri_ClientId",
                table: "ClientPostLogoutRedirectUri",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProperty_ClientId",
                table: "ClientProperty",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRedirectUri_ClientId",
                table: "ClientRedirectUri",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientScope_ClientId",
                table: "ClientScope",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSecret_ClientId",
                table: "ClientSecret",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientClaim");

            migrationBuilder.DropTable(
                name: "ClientCorsOrigin");

            migrationBuilder.DropTable(
                name: "ClientGrantType");

            migrationBuilder.DropTable(
                name: "ClientIdPRestriction");

            migrationBuilder.DropTable(
                name: "ClientPostLogoutRedirectUri");

            migrationBuilder.DropTable(
                name: "ClientProperty");

            migrationBuilder.DropTable(
                name: "ClientRedirectUri");

            migrationBuilder.DropTable(
                name: "ClientScope");

            migrationBuilder.DropTable(
                name: "ClientSecret");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropColumn(
                name: "LastModifionTime",
                table: "UserToken");

            migrationBuilder.DropColumn(
                name: "LastModifionTime",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "LastModifionTime",
                table: "UserClaim");

            migrationBuilder.DropColumn(
                name: "LastModifionTime",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastModifionTime",
                table: "RoleClaim");

            migrationBuilder.DropColumn(
                name: "LastModifionTime",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "LastModifionTime",
                table: "Organizated");

            migrationBuilder.DropColumn(
                name: "LastModifionTime",
                table: "MenuFunction");

            migrationBuilder.DropColumn(
                name: "LastModifionTime",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "LastModifionTime",
                table: "Function");

            migrationBuilder.DropColumn(
                name: "LastModifionTime",
                table: "DataDictionary");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifierTime",
                table: "UserToken",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifierTime",
                table: "UserRole",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifierTime",
                table: "UserClaim",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifierTime",
                table: "User",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifierTime",
                table: "RoleClaim",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifierTime",
                table: "Role",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifierTime",
                table: "Organizated",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifierTime",
                table: "MenuFunction",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifierTime",
                table: "Menu",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifierTime",
                table: "Function",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifierTime",
                table: "DataDictionary",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
