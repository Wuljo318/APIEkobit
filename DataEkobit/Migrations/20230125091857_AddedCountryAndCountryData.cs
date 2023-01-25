using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataEkobit.Migrations
{
    /// <inheritdoc />
    public partial class AddedCountryAndCountryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capital = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.CountryId);
                });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "CountryId", "Capital", "Continent", "CountryCode", "Name" },
                values: new object[,]
                {
                    { 1, "Zagreb", "Europe", "CRO", "Croatia" },
                    { 2, "Sarajevo", "Europe", "BH", "Bosnia and Herzegovina" },
                    { 3, "Washington D.C.", "North America", "USA", "United States of America" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
