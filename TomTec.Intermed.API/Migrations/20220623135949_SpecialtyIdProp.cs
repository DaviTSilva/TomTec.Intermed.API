using Microsoft.EntityFrameworkCore.Migrations;

namespace TomTec.Intermed.API.Migrations
{
    public partial class SpecialtyIdProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "HealthProfessionals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FourLastNumbers",
                table: "CreditCardInfos",
                type: "varchar(4)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HealthProfessionals_SpecialtyId",
                table: "HealthProfessionals",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthProfessionals_Specialties_SpecialtyId",
                table: "HealthProfessionals",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthProfessionals_Specialties_SpecialtyId",
                table: "HealthProfessionals");

            migrationBuilder.DropIndex(
                name: "IX_HealthProfessionals_SpecialtyId",
                table: "HealthProfessionals");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "HealthProfessionals");

            migrationBuilder.DropColumn(
                name: "FourLastNumbers",
                table: "CreditCardInfos");
        }
    }
}
