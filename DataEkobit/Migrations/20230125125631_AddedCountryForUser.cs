using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEkobit.Migrations
{
    /// <inheritdoc />
    public partial class AddedCountryForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "user",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CountryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: 2L,
                column: "CountryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: 3L,
                column: "CountryId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_user_CountryId",
                table: "user",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_country_CountryId",
                table: "user",
                column: "CountryId",
                principalTable: "country",
                principalColumn: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_country_CountryId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_CountryId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "user");
        }
    }
}
