using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace DataEkobit.Migrations
{
    /// <inheritdoc />
    public partial class AddedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "UserId", "Address", "Birthday", "City", "Email", "LastName", "Name", "Nickname", "Password", "ZipCode" },
                values: new object[,]
                {
                    { 2L, "Ulica 11", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Varaždin1", "dvuljak1@ekobit.hr", "Vuljak1", "Dominik1", "Dodo1", "lozinka1", 42000 },
                    { 3L, "Ulica 11", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Varaždin1", "dvuljak1@ekobit.hr", "Vuljak1", "Dominik1", "Dodo1", "lozinka1", 42000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "UserId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "UserId",
                keyValue: 3L);
        }
    }
}
