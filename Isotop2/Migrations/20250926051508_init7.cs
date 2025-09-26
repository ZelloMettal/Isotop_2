using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Isotop2.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RIs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RIs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RIs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "RadiationExposureToOrgans",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "StoragePoints",
                keyColumn: "StoragePointId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RadionuclideCompound",
                keyColumn: "RadionuclideCompoundId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RadionuclideCompound",
                keyColumn: "RadionuclideCompoundId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RadionuclideCompound",
                keyColumn: "RadionuclideCompoundId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Radionuclides",
                keyColumn: "RadionuclideId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Radionuclides",
                keyColumn: "RadionuclideId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Radionuclides",
                keyColumn: "RadionuclideId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipients",
                keyColumn: "RecipientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StoragePoints",
                keyColumn: "StoragePointId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StoragePoints",
                keyColumn: "StoragePointId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "ManufacturerName" },
                values: new object[,]
                {
                    { 1, "ФГАОУ ВО УФУ" },
                    { 2, "АО НИФХИИ" }
                });

            migrationBuilder.InsertData(
                table: "Markers",
                columns: new[] { "Id", "MarkerName", "MaxActivity", "MinActivity", "NewGenerator" },
                values: new object[,]
                {
                    { 1, "Резоскан", 600, 400, true },
                    { 2, "Нанотоп", 170, 120, true },
                    { 3, "Пентатех", 370, 110, false },
                    { 4, "Технефит", 300, 120, false },
                    { 5, "Технемек", 150, 100, false }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "PackageId", "PackageName" },
                values: new object[,]
                {
                    { 1, "ГТ-4К" },
                    { 2, "КТ-1-10" }
                });

            migrationBuilder.InsertData(
                table: "RadionuclideCompound",
                columns: new[] { "RadionuclideCompoundId", "Compound" },
                values: new object[,]
                {
                    { 1, "Пертехнет Натрия" },
                    { 2, "Натрий Йодит" },
                    { 3, "Радия Хлорид" }
                });

            migrationBuilder.InsertData(
                table: "Radionuclides",
                columns: new[] { "RadionuclideId", "RadionuclideName" },
                values: new object[,]
                {
                    { 1, "Технеций-99m" },
                    { 2, "Йод-131" },
                    { 3, "Радий-223" }
                });

            migrationBuilder.InsertData(
                table: "Recipients",
                columns: new[] { "RecipientId", "RecipientName" },
                values: new object[] { 1, "ГУЗ КОД" });

            migrationBuilder.InsertData(
                table: "StoragePoints",
                columns: new[] { "StoragePointId", "StoragePointName" },
                values: new object[,]
                {
                    { 1, "Сейф" },
                    { 2, "Хранилище" },
                    { 3, "Генераторная" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "SupplierName" },
                values: new object[,]
                {
                    { 1, "ООО Фарматом" },
                    { 2, "ООО Цистех" }
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

            migrationBuilder.InsertData(
                table: "RadiationExposureToOrgans",
                columns: new[] { "Id", "Coefficient", "MarkerId", "OrganId" },
                values: new object[,]
                {
                    { 1, 0.0070000000000000001, 1, 9 },
                    { 2, 0.0040000000000000001, 1, 4 },
                    { 3, 0.0050000000000000001, 1, 5 },
                    { 4, 0.0025000000000000001, 1, 16 },
                    { 5, 0.01, 2, 24 },
                    { 6, 0.0050000000000000001, 2, 3 },
                    { 7, 0.0060000000000000001, 2, 9 },
                    { 8, 0.0030000000000000001, 2, 5 },
                    { 9, 0.017999999999999999, 2, 4 },
                    { 10, 0.0089999999999999993, 2, 16 },
                    { 11, 0.01, 3, 12 },
                    { 12, 0.002, 3, 3 },
                    { 13, 0.0060000000000000001, 3, 4 },
                    { 14, 0.0030000000000000001, 3, 5 },
                    { 15, 0.002, 3, 16 },
                    { 16, 0.059999999999999998, 3, 8 },
                    { 17, 0.0040000000000000001, 4, 16 },
                    { 18, 0.080000000000000002, 4, 23 },
                    { 19, 0.040000000000000001, 4, 15 },
                    { 20, 0.014999999999999999, 4, 3 },
                    { 21, 0.0050000000000000001, 5, 16 },
                    { 22, 0.0018, 5, 5 },
                    { 23, 0.0033999999999999998, 5, 4 },
                    { 34, 0.23000000000000001, 5, 12 }
                });
        }
    }
}
