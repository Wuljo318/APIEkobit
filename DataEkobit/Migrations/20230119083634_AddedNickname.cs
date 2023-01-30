using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEkobit.Migrations
{
    /// <inheritdoc />
    public partial class AddedNickname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "UserId", "Address", "Birthday", "City", "Email", "LastName", "Name", "Nickname", "Password", "ZipCode" },
                values: new object[] { 1L, "Ulica 1", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Varaždin", "dvuljak@ekobit.hr", "Vuljak", "Dominik", "Dodo", "lozinka", 42000 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "UserId",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "user");
        }
    }
}
