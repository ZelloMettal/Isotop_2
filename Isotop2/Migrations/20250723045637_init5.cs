using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Isotop2.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RAOs");

            migrationBuilder.CreateTable(
                name: "RIs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RadionuclideId = table.Column<int>(type: "INTEGER", nullable: true),
                    PassportNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    GeneratorNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Volume = table.Column<double>(type: "REAL", nullable: false),
                    Activity = table.Column<double>(type: "REAL", nullable: false),
                    RadionuclideCompoundId = table.Column<int>(type: "INTEGER", nullable: true),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: true),
                    Operation = table.Column<string>(type: "TEXT", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PackageId = table.Column<int>(type: "INTEGER", nullable: true),
                    StoragePointId = table.Column<int>(type: "INTEGER", nullable: true),
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: true),
                    RecipientId = table.Column<int>(type: "INTEGER", nullable: true),
                    AccompanyingDocument = table.Column<string>(type: "TEXT", nullable: false),
                    Sent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RIs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RIs_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RIs_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RIs_RadionuclideCompound_RadionuclideCompoundId",
                        column: x => x.RadionuclideCompoundId,
                        principalTable: "RadionuclideCompound",
                        principalColumn: "RadionuclideCompoundId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RIs_Radionuclides_RadionuclideId",
                        column: x => x.RadionuclideId,
                        principalTable: "Radionuclides",
                        principalColumn: "RadionuclideId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RIs_Recipients_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipients",
                        principalColumn: "RecipientId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RIs_StoragePoints_StoragePointId",
                        column: x => x.StoragePointId,
                        principalTable: "StoragePoints",
                        principalColumn: "StoragePointId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RIs_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "RIs",
                columns: new[] { "Id", "AccompanyingDocument", "Activity", "CreateDate", "GeneratorNumber", "ManufacturerId", "Operation", "OperationDate", "PackageId", "PassportNumber", "RadionuclideCompoundId", "RadionuclideId", "RecipientId", "Sent", "StoragePointId", "SupplierId", "Volume", "Weight" },
                values: new object[,]
                {
                    { 1, "Т-Т Накладная", 19000.0, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "4554", 1, "В/В Введение", new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "904", 1, 1, 1, true, 3, 1, 200.0, 15.0 },
                    { 2, "Т-Т Накладная", 200.0, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "PerOs", new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "03186", 2, 2, 1, false, 1, 2, 6.0, 2.0 },
                    { 3, "Т-Т Накладная", 10.199999999999999, new DateTime(2025, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "В/В Введение", new DateTime(2025, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "210225-1/59", 3, 3, 1, false, 1, 1, 6.5999999999999996, 2.0 }
                });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2,
                column: "SupplierName",
                value: "ООО Цистех");

            migrationBuilder.CreateIndex(
                name: "IX_RIs_ManufacturerId",
                table: "RIs",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_RIs_PackageId",
                table: "RIs",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_RIs_RadionuclideCompoundId",
                table: "RIs",
                column: "RadionuclideCompoundId");

            migrationBuilder.CreateIndex(
                name: "IX_RIs_RadionuclideId",
                table: "RIs",
                column: "RadionuclideId");

            migrationBuilder.CreateIndex(
                name: "IX_RIs_RecipientId",
                table: "RIs",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_RIs_StoragePointId",
                table: "RIs",
                column: "StoragePointId");

            migrationBuilder.CreateIndex(
                name: "IX_RIs_SupplierId",
                table: "RIs",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RIs");

            migrationBuilder.CreateTable(
                name: "RAOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: true),
                    PackageId = table.Column<int>(type: "INTEGER", nullable: true),
                    RadionuclideCompoundId = table.Column<int>(type: "INTEGER", nullable: true),
                    RadionuclideId = table.Column<int>(type: "INTEGER", nullable: true),
                    RecipientId = table.Column<int>(type: "INTEGER", nullable: true),
                    StoragePointId = table.Column<int>(type: "INTEGER", nullable: true),
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: true),
                    AccompanyingDocument = table.Column<string>(type: "TEXT", nullable: false),
                    Activity = table.Column<double>(type: "REAL", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GeneratorNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Operation = table.Column<string>(type: "TEXT", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PassportNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Sent = table.Column<bool>(type: "INTEGER", nullable: false),
                    Volume = table.Column<double>(type: "REAL", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RAOs_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RAOs_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RAOs_RadionuclideCompound_RadionuclideCompoundId",
                        column: x => x.RadionuclideCompoundId,
                        principalTable: "RadionuclideCompound",
                        principalColumn: "RadionuclideCompoundId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RAOs_Radionuclides_RadionuclideId",
                        column: x => x.RadionuclideId,
                        principalTable: "Radionuclides",
                        principalColumn: "RadionuclideId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RAOs_Recipients_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipients",
                        principalColumn: "RecipientId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RAOs_StoragePoints_StoragePointId",
                        column: x => x.StoragePointId,
                        principalTable: "StoragePoints",
                        principalColumn: "StoragePointId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RAOs_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "RAOs",
                columns: new[] { "Id", "AccompanyingDocument", "Activity", "CreateDate", "GeneratorNumber", "ManufacturerId", "Operation", "OperationDate", "PackageId", "PassportNumber", "RadionuclideCompoundId", "RadionuclideId", "RecipientId", "Sent", "StoragePointId", "SupplierId", "Volume", "Weight" },
                values: new object[] { 1, "Т-Т Накладная", 19000.0, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "4554", 1, "В/В Введение", new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "904", 1, 1, 1, true, 1, 1, 200.0, 15.0 });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2,
                column: "SupplierName",
                value: "Цистех");

            migrationBuilder.CreateIndex(
                name: "IX_RAOs_ManufacturerId",
                table: "RAOs",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_RAOs_PackageId",
                table: "RAOs",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_RAOs_RadionuclideCompoundId",
                table: "RAOs",
                column: "RadionuclideCompoundId");

            migrationBuilder.CreateIndex(
                name: "IX_RAOs_RadionuclideId",
                table: "RAOs",
                column: "RadionuclideId");

            migrationBuilder.CreateIndex(
                name: "IX_RAOs_RecipientId",
                table: "RAOs",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_RAOs_StoragePointId",
                table: "RAOs",
                column: "StoragePointId");

            migrationBuilder.CreateIndex(
                name: "IX_RAOs_SupplierId",
                table: "RAOs",
                column: "SupplierId");
        }
    }
}
