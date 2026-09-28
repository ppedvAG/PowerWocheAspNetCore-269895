using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPages_with_EFCore_Relationships.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_Continent_ContinentRefId",
                table: "Country");

            migrationBuilder.RenameColumn(
                name: "ContinentRefId",
                table: "Country",
                newName: "ContinentId");

            migrationBuilder.RenameIndex(
                name: "IX_Country_ContinentRefId",
                table: "Country",
                newName: "IX_Country_ContinentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_Continent_ContinentId",
                table: "Country",
                column: "ContinentId",
                principalTable: "Continent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_Continent_ContinentId",
                table: "Country");

            migrationBuilder.RenameColumn(
                name: "ContinentId",
                table: "Country",
                newName: "ContinentRefId");

            migrationBuilder.RenameIndex(
                name: "IX_Country_ContinentId",
                table: "Country",
                newName: "IX_Country_ContinentRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_Continent_ContinentRefId",
                table: "Country",
                column: "ContinentRefId",
                principalTable: "Continent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
