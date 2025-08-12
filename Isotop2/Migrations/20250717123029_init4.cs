using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Isotop2.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "HashPassword",
                value: "f8EKu7SwpqildWZB1vPfjADyYop71xwTWF+4FVSBfv5YTW5gtIqKAvz8aY26TFXL3w==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "HashPassword",
                value: "SAGSo68FqZ+Cr6EIn7eHqgC61MU7NCYMa3UhPw2R3iwvrKpgC23h7m/B9qgyRP/wRA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "HashPassword",
                value: "Da/qC3uIOU9o7A9XVOtc+gCk2TOgkhXHUaiM3f8rtPkFcsATN0DR5wGZd8X3zv8+RQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "HashPassword",
                value: "UCGiegHU7YT9SOj7o1bwdgBqmrGp4UL80ln2LEYHa93FfJoYPE7hB/rRmfevh/wWCQ==");
        }
    }
}
