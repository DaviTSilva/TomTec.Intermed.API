using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TomTec.Intermed.API.Migrations
{
    public partial class HealthProfessional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Street = table.Column<string>(type: "varchar(150)", nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "varchar(200)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    City = table.Column<string>(type: "varchar(150)", nullable: false),
                    State = table.Column<string>(type: "varchar(150)", nullable: true),
                    CountryName = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", nullable: true),
                    Link = table.Column<string>(type: "varchar(max)", nullable: true),
                    CelphoneNumber = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    Number = table.Column<string>(type: "varchar(200)", nullable: false),
                    Expire = table.Column<string>(type: "varchar(200)", nullable: false),
                    OwnerName = table.Column<string>(type: "varchar(200)", nullable: false),
                    CVV = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignatureTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignatureTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserName = table.Column<string>(type: "varchar(100)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(120)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProfilePictureURL = table.Column<string>(type: "varchar(max)", nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    UserTypeId = table.Column<int>(nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "varchar(100)", nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    HealthProfessionalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthProfessionals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ServiceTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: false),
                    ContactCardId = table.Column<int>(nullable: false),
                    ConsultingAddressId = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    CreditCardInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthProfessionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthProfessionals_Addresses_ConsultingAddressId",
                        column: x => x.ConsultingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthProfessionals_ContactCards_ContactCardId",
                        column: x => x.ContactCardId,
                        principalTable: "ContactCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthProfessionals_CreditCardInfos_CreditCardInfoId",
                        column: x => x.CreditCardInfoId,
                        principalTable: "CreditCardInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthProfessionals_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthProfessionals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersClaims",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersClaims", x => new { x.UserId, x.ClaimId });
                    table.ForeignKey(
                        name: "FK_UsersClaims_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    HealthProfessionalId = table.Column<int>(nullable: false),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    Expire = table.Column<DateTime>(nullable: false),
                    IsPayed = table.Column<bool>(nullable: false),
                    IsFreeTrial = table.Column<bool>(nullable: false),
                    IsCancelled = table.Column<bool>(nullable: false),
                    IsYearlyPack = table.Column<bool>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    SignatureTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Signatures_HealthProfessionals_HealthProfessionalId",
                        column: x => x.HealthProfessionalId,
                        principalTable: "HealthProfessionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Signatures_SignatureTypes_SignatureTypeId",
                        column: x => x.SignatureTypeId,
                        principalTable: "SignatureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_Name",
                table: "Claims",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HealthProfessionals_ConsultingAddressId",
                table: "HealthProfessionals",
                column: "ConsultingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthProfessionals_ContactCardId",
                table: "HealthProfessionals",
                column: "ContactCardId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthProfessionals_CreditCardInfoId",
                table: "HealthProfessionals",
                column: "CreditCardInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthProfessionals_ServiceTypeId",
                table: "HealthProfessionals",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthProfessionals_UserId",
                table: "HealthProfessionals",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Signatures_HealthProfessionalId",
                table: "Signatures",
                column: "HealthProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Signatures_SignatureTypeId",
                table: "Signatures",
                column: "SignatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_UserName",
                table: "Users",
                columns: new[] { "Email", "UserName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersClaims_ClaimId",
                table: "UsersClaims",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_Name",
                table: "UserTypes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Signatures");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "UsersClaims");

            migrationBuilder.DropTable(
                name: "HealthProfessionals");

            migrationBuilder.DropTable(
                name: "SignatureTypes");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "ContactCards");

            migrationBuilder.DropTable(
                name: "CreditCardInfos");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
