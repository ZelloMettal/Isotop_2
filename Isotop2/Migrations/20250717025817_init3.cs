using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Isotop2.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "HashPassword",
                value: "auPAL1Sso5X9X7sdacYQTgDN8z4gpd3hGLCpp/Et/G6J/2LDxKz9O7RKK8FQ9BcfMQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "HashPassword",
                value: "H0yEASs4ezLMMi3DIgBd0QCdIV5qTL+q8uyGa3MGvdVvse3aurncEvNh/yd4sVxM+g==");
        }
    }
}
