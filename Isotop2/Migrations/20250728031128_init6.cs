using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Isotop2.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Day",
                table: "Iodine",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 1,
                column: "Day",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 2,
                column: "Day",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 3,
                column: "Day",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 4,
                column: "Day",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 5,
                column: "Day",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 6,
                column: "Day",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 7,
                column: "Day",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 8,
                column: "Day",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 9,
                column: "Day",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 10,
                column: "Day",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 11,
                column: "Day",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 12,
                column: "Day",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 13,
                column: "Day",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 14,
                column: "Day",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 15,
                column: "Day",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 16,
                column: "Day",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 17,
                column: "Day",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 18,
                column: "Day",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 19,
                column: "Day",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 20,
                column: "Day",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 21,
                column: "Day",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 22,
                column: "Day",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 23,
                column: "Day",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 24,
                column: "Day",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 25,
                column: "Day",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 26,
                column: "Day",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 27,
                column: "Day",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 28,
                column: "Day",
                value: 27);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Day",
                table: "Iodine",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 1,
                column: "Day",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 2,
                column: "Day",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 3,
                column: "Day",
                value: 2.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 4,
                column: "Day",
                value: 3.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 5,
                column: "Day",
                value: 4.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 6,
                column: "Day",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 7,
                column: "Day",
                value: 6.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 8,
                column: "Day",
                value: 7.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 9,
                column: "Day",
                value: 8.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 10,
                column: "Day",
                value: 9.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 11,
                column: "Day",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 12,
                column: "Day",
                value: 11.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 13,
                column: "Day",
                value: 12.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 14,
                column: "Day",
                value: 13.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 15,
                column: "Day",
                value: 14.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 16,
                column: "Day",
                value: 15.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 17,
                column: "Day",
                value: 16.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 18,
                column: "Day",
                value: 17.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 19,
                column: "Day",
                value: 18.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 20,
                column: "Day",
                value: 19.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 21,
                column: "Day",
                value: 20.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 22,
                column: "Day",
                value: 21.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 23,
                column: "Day",
                value: 22.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 24,
                column: "Day",
                value: 23.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 25,
                column: "Day",
                value: 24.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 26,
                column: "Day",
                value: 25.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 27,
                column: "Day",
                value: 26.0);

            migrationBuilder.UpdateData(
                table: "Iodine",
                keyColumn: "Id",
                keyValue: 28,
                column: "Day",
                value: 27.0);
        }
    }
}
