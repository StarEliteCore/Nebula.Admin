using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class wzwIdentityServer4_20200921_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiResource",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    AllowedAccessTokenSigningAlgorithms = table.Column<string>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiScope",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScope", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceFlowCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DeviceCode = table.Column<string>(nullable: true),
                    UserCode = table.Column<string>(nullable: true),
                    SubjectId = table.Column<string>(nullable: true),
                    SessionId = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true),
                    ConsumedTime = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceFlowCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResource",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    NonEditable = table.Column<bool>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrant",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    SubjectId = table.Column<string>(nullable: true),
                    SessionId = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true),
                    ConsumedTime = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    ApiResourceId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceClaim_ApiResource_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ApiResourceId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceProperty_ApiResource_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceScope",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Scope = table.Column<string>(nullable: true),
                    ApiResourceId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceScope", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceScope_ApiResource_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceSecret",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ApiResourceId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceSecret", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceSecret_ApiResource_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiScopeClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    ScopeId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopeClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiScopeClaim_ApiScope_ScopeId",
                        column: x => x.ScopeId,
                        principalTable: "ApiScope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiScopeProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ScopeId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopeProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiScopeProperty_ApiScope_ScopeId",
                        column: x => x.ScopeId,
                        principalTable: "ApiScope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResourceClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    IdentityResourceId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResourceClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityResourceClaim_IdentityResource_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalTable: "IdentityResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResourceProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IdentityResourceId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResourceProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityResourceProperty_IdentityResource_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalTable: "IdentityResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceClaim_ApiResourceId",
                table: "ApiResourceClaim",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceProperty_ApiResourceId",
                table: "ApiResourceProperty",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceScope_ApiResourceId",
                table: "ApiResourceScope",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceSecret_ApiResourceId",
                table: "ApiResourceSecret",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeClaim_ScopeId",
                table: "ApiScopeClaim",
                column: "ScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeProperty_ScopeId",
                table: "ApiScopeProperty",
                column: "ScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceClaim_IdentityResourceId",
                table: "IdentityResourceClaim",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceProperty_IdentityResourceId",
                table: "IdentityResourceProperty",
                column: "IdentityResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiResourceClaim");

            migrationBuilder.DropTable(
                name: "ApiResourceProperty");

            migrationBuilder.DropTable(
                name: "ApiResourceScope");

            migrationBuilder.DropTable(
                name: "ApiResourceSecret");

            migrationBuilder.DropTable(
                name: "ApiScopeClaim");

            migrationBuilder.DropTable(
                name: "ApiScopeProperty");

            migrationBuilder.DropTable(
                name: "DeviceFlowCodes");

            migrationBuilder.DropTable(
                name: "IdentityResourceClaim");

            migrationBuilder.DropTable(
                name: "IdentityResourceProperty");

            migrationBuilder.DropTable(
                name: "PersistedGrant");

            migrationBuilder.DropTable(
                name: "ApiResource");

            migrationBuilder.DropTable(
                name: "ApiScope");

            migrationBuilder.DropTable(
                name: "IdentityResource");
        }
    }
}
