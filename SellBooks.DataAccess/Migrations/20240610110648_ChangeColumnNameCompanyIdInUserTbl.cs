using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellBooks.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnNameCompanyIdInUserTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CountryId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "AspNetUsers",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "AspNetUsers",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CountryId",
                table: "AspNetUsers",
                column: "CountryId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
