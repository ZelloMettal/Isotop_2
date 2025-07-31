using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Isotop2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoefficientsForChildrens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AgeRange = table.Column<string>(type: "TEXT", nullable: false),
                    Coefficient = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoefficientsForChildrens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iodine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Day = table.Column<double>(type: "REAL", nullable: false),
                    DecayPrecent = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iodine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManufacturerName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Markers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MarkerName = table.Column<string>(type: "TEXT", nullable: false),
                    MaxActivity = table.Column<int>(type: "INTEGER", nullable: false),
                    MinActivity = table.Column<int>(type: "INTEGER", nullable: false),
                    NewGenerator = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Molybdenum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Day = table.Column<int>(type: "INTEGER", nullable: false),
                    DecayPrecent = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Molybdenum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrganName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PackageName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "RadionuclideCompound",
                columns: table => new
                {
                    RadionuclideCompoundId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Compound = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadionuclideCompound", x => x.RadionuclideCompoundId);
                });

            migrationBuilder.CreateTable(
                name: "Radionuclides",
                columns: table => new
                {
                    RadionuclideId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RadionuclideName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radionuclides", x => x.RadionuclideId);
                });

            migrationBuilder.CreateTable(
                name: "Radium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Day = table.Column<int>(type: "INTEGER", nullable: false),
                    DecayCoefficent = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radium", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    RecipientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipientName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.RecipientId);
                });

            migrationBuilder.CreateTable(
                name: "StoragePoints",
                columns: table => new
                {
                    StoragePointId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoragePointName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoragePoints", x => x.StoragePointId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SupplierName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Technetium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hour = table.Column<double>(type: "REAL", nullable: false),
                    DecayPrecent = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technetium", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    HashPassword = table.Column<string>(type: "TEXT", nullable: false),
                    Administrator = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Volumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RadiationExposureToOrgans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Coefficient = table.Column<double>(type: "REAL", nullable: false),
                    MarkerId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrganId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadiationExposureToOrgans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadiationExposureToOrgans_Markers_MarkerId",
                        column: x => x.MarkerId,
                        principalTable: "Markers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RadiationExposureToOrgans_Organs_OrganId",
                        column: x => x.OrganId,
                        principalTable: "Organs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RAOs",
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
                table: "CoefficientsForChildrens",
                columns: new[] { "Id", "AgeRange", "Coefficient" },
                values: new object[,]
                {
                    { 1, "13-17", 0.5 },
                    { 2, "8-12", 0.40000000000000002 },
                    { 3, "3-7", 0.29999999999999999 },
                    { 4, "1-2", 0.10000000000000001 },
                    { 5, "<1", 0.029999999999999999 }
                });

            migrationBuilder.InsertData(
                table: "Iodine",
                columns: new[] { "Id", "Day", "DecayPrecent" },
                values: new object[,]
                {
                    { 1, 0.0, 100.0 },
                    { 2, 1.0, 91.799999999999997 },
                    { 3, 2.0, 84.299999999999997 },
                    { 4, 3.0, 77.400000000000006 },
                    { 5, 4.0, 71.0 },
                    { 6, 5.0, 65.200000000000003 },
                    { 7, 6.0, 59.899999999999999 },
                    { 8, 7.0, 54.899999999999999 },
                    { 9, 8.0, 50.700000000000003 },
                    { 10, 9.0, 46.299999999999997 },
                    { 11, 10.0, 42.5 },
                    { 12, 11.0, 39.0 },
                    { 13, 12.0, 35.799999999999997 },
                    { 14, 13.0, 32.899999999999999 },
                    { 15, 14.0, 30.199999999999999 },
                    { 16, 15.0, 27.199999999999999 },
                    { 17, 16.0, 25.399999999999999 },
                    { 18, 17.0, 23.399999999999999 },
                    { 19, 18.0, 21.399999999999999 },
                    { 20, 19.0, 19.699999999999999 },
                    { 21, 20.0, 18.100000000000001 },
                    { 22, 21.0, 16.600000000000001 },
                    { 23, 22.0, 15.199999999999999 },
                    { 24, 23.0, 14.0 },
                    { 25, 24.0, 12.800000000000001 },
                    { 26, 25.0, 11.800000000000001 },
                    { 27, 26.0, 10.800000000000001 },
                    { 28, 27.0, 9.6999999999999993 }
                });

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
                table: "Molybdenum",
                columns: new[] { "Id", "Day", "DecayPrecent" },
                values: new object[,]
                {
                    { 1, 0, 100.0 },
                    { 2, 1, 77.329999999999998 },
                    { 3, 2, 60.409999999999997 },
                    { 4, 3, 46.960000000000001 },
                    { 5, 4, 36.5 },
                    { 6, 5, 28.370000000000001 },
                    { 7, 6, 22.050000000000001 },
                    { 8, 7, 17.140000000000001 },
                    { 9, 8, 13.32 },
                    { 10, 9, 10.35 },
                    { 11, 10, 8.0500000000000007 },
                    { 12, 11, 6.2599999999999998 },
                    { 13, 12, 4.8600000000000003 },
                    { 14, 13, 3.7799999999999998 },
                    { 15, 14, 2.9399999999999999 },
                    { 16, 15, 2.2799999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Organs",
                columns: new[] { "Id", "OrganName" },
                values: new object[,]
                {
                    { 1, "Желудок" },
                    { 2, "Лёгкие" },
                    { 3, "Красный костный мозг" },
                    { 4, "Яичники" },
                    { 5, "Семенники" },
                    { 6, "Верхний отдел толстой кишки" },
                    { 7, "Нижний отдел толстой кишки" },
                    { 8, "Мочевой пузырь" },
                    { 9, "Кости" },
                    { 10, "Кожа" },
                    { 11, "Тонка кишка" },
                    { 12, "Почки" },
                    { 13, "Скелетные мышцы" },
                    { 14, "Поджелудочная железа" },
                    { 15, "Селезёнка" },
                    { 16, "Всё тело" },
                    { 17, "Сердце" },
                    { 18, "Надпочечники" },
                    { 19, "Головной мозг" },
                    { 20, "Желчный пузырь" },
                    { 21, "Вилочковая железа" },
                    { 22, "Матка" },
                    { 23, "Печень" },
                    { 24, "Щитовидная железа" },
                    { 25, "Молочные железы" }
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
                table: "Radium",
                columns: new[] { "Id", "Day", "DecayCoefficent" },
                values: new object[,]
                {
                    { 1, 0, 1.54 },
                    { 2, 1, 1.45 },
                    { 3, 2, 1.3600000000000001 },
                    { 4, 3, 1.28 },
                    { 5, 4, 1.21 },
                    { 6, 5, 1.1399999999999999 },
                    { 7, 6, 1.0700000000000001 },
                    { 8, 7, 1.01 },
                    { 9, 8, 0.94999999999999996 },
                    { 10, 9, 0.89000000000000001 },
                    { 11, 10, 0.83999999999999997 },
                    { 12, 11, 0.79000000000000004 },
                    { 13, 12, 0.73999999999999999 },
                    { 14, 13, 0.69999999999999996 },
                    { 15, 14, 0.66000000000000003 },
                    { 16, 15, 0.62 },
                    { 17, 16, 0.57999999999999996 },
                    { 18, 17, 0.55000000000000004 },
                    { 19, 18, 0.52000000000000002 },
                    { 20, 19, 0.48999999999999999 },
                    { 21, 20, 0.46000000000000002 },
                    { 22, 21, 0.42999999999999999 }
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
                    { 2, "Цистех" }
                });

            migrationBuilder.InsertData(
                table: "Technetium",
                columns: new[] { "Id", "DecayPrecent", "Hour" },
                values: new object[,]
                {
                    { 1, 100.0, 0.0 },
                    { 2, 94.390000000000001, 0.5 },
                    { 3, 89.090000000000003, 1.0 },
                    { 4, 84.090000000000003, 1.5 },
                    { 5, 79.370000000000005, 2.0 },
                    { 6, 74.920000000000002, 2.5 },
                    { 7, 70.709999999999994, 3.0 },
                    { 8, 66.739999999999995, 3.5 },
                    { 9, 63.0, 4.0 },
                    { 10, 59.460000000000001, 4.5 },
                    { 11, 56.119999999999997, 5.0 },
                    { 12, 52.969999999999999, 5.5 },
                    { 13, 50.0, 6.0 },
                    { 14, 47.189999999999998, 6.5 },
                    { 15, 44.539999999999999, 7.0 },
                    { 16, 42.039999999999999, 7.5 },
                    { 17, 36.689999999999998, 8.0 },
                    { 18, 37.460000000000001, 8.5 },
                    { 19, 35.359999999999999, 9.0 },
                    { 20, 33.369999999999997, 9.5 },
                    { 21, 31.5, 10.0 },
                    { 22, 29.73, 10.5 },
                    { 23, 28.059999999999999, 11.0 },
                    { 24, 26.489999999999998, 11.5 },
                    { 25, 25.0, 12.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Administrator", "HashPassword", "UserName" },
                values: new object[,]
                {
                    { 1, true, "auPAL1Sso5X9X7sdacYQTgDN8z4gpd3hGLCpp/Et/G6J/2LDxKz9O7RKK8FQ9BcfMQ==", "Admin" },
                    { 2, false, "H0yEASs4ezLMMi3DIgBd0QCdIV5qTL+q8uyGa3MGvdVvse3aurncEvNh/yd4sVxM+g==", "User" }
                });

            migrationBuilder.InsertData(
                table: "Volumes",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, 10.0 },
                    { 2, 8.0 },
                    { 3, 5.0 },
                    { 4, 4.0 },
                    { 5, 3.0 },
                    { 6, 2.0 },
                    { 7, 1.5 },
                    { 8, 1.3999999999999999 },
                    { 9, 1.3 },
                    { 10, 1.2 },
                    { 11, 1.1000000000000001 },
                    { 12, 1.0 },
                    { 13, 0.90000000000000002 },
                    { 14, 0.80000000000000004 },
                    { 15, 0.69999999999999996 },
                    { 16, 0.59999999999999998 },
                    { 17, 0.5 },
                    { 18, 0.40000000000000002 },
                    { 19, 0.29999999999999999 },
                    { 20, 0.20000000000000001 },
                    { 21, 0.10000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "RAOs",
                columns: new[] { "Id", "AccompanyingDocument", "Activity", "CreateDate", "GeneratorNumber", "ManufacturerId", "Operation", "OperationDate", "PackageId", "PassportNumber", "RadionuclideCompoundId", "RadionuclideId", "RecipientId", "Sent", "StoragePointId", "SupplierId", "Volume", "Weight" },
                values: new object[] { 1, "Т-Т Накладная", 19000.0, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "4554", 1, "В/В Введение", new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "904", 1, 1, 1, true, 1, 1, 200.0, 15.0 });

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

            migrationBuilder.CreateIndex(
                name: "IX_RadiationExposureToOrgans_MarkerId",
                table: "RadiationExposureToOrgans",
                column: "MarkerId");

            migrationBuilder.CreateIndex(
                name: "IX_RadiationExposureToOrgans_OrganId",
                table: "RadiationExposureToOrgans",
                column: "OrganId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoefficientsForChildrens");

            migrationBuilder.DropTable(
                name: "Iodine");

            migrationBuilder.DropTable(
                name: "Molybdenum");

            migrationBuilder.DropTable(
                name: "RadiationExposureToOrgans");

            migrationBuilder.DropTable(
                name: "Radium");

            migrationBuilder.DropTable(
                name: "RAOs");

            migrationBuilder.DropTable(
                name: "Technetium");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Volumes");

            migrationBuilder.DropTable(
                name: "Markers");

            migrationBuilder.DropTable(
                name: "Organs");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "RadionuclideCompound");

            migrationBuilder.DropTable(
                name: "Radionuclides");

            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropTable(
                name: "StoragePoints");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
