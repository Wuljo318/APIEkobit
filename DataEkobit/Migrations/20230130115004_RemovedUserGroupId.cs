using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEkobit.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserGroupId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "Group");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserGroupId",
                table: "user",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserGroupId",
                table: "Group",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "UserGroupId",
                value: 0L);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: 2L,
                column: "UserGroupId",
                value: 0L);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: 3L,
                column: "UserGroupId",
                value: 0L);
        }
    }
}
