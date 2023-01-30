using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataEkobit.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataForGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "GroupId", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, "Grupa1", "G1" },
                    { 2L, "Grupa2", "G2" },
                    { 3L, "Grupa3", "G3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "GroupId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "GroupId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "GroupId",
                keyValue: 3L);
        }
    }
}
