using Microsoft.EntityFrameworkCore;
using Isotop2.Data.Entities;

namespace Isotop2.Services
{
    internal class DataDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source = DataDB.db");
        }
        public DbSet<Marker> Markers { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Molybdenum> Molybdenum { get; set; }
        public DbSet<Technetium> Technetium { get; set; }
        public DbSet<Iodine> Iodine { get; set; }
        public DbSet<Radium> Radium { get; set; }
        public DbSet<Organ> Organs { get; set; }
        public DbSet<RadiationExposureToOrgan> RadiationExposureToOrgans { get; set; }
        public DbSet<CoefficientsForChildren> CoefficientsForChildrens { get; set; }
        public DbSet<Radionuclide> Radionuclides { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<StoragePoint> StoragePoints { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<RadionuclideCompound> RadionuclideCompound { get; set; }
        public DbSet<RI> RIs { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            //Инициализация БД
            //Настройка удаления зависемой таблицы
            model.Entity<RI>().HasOne(r => r.Radionuclide).WithMany().OnDelete(DeleteBehavior.SetNull);
            model.Entity<RI>().HasOne(r => r.RadionuclideCompound).WithMany().OnDelete(DeleteBehavior.SetNull);
            model.Entity<RI>().HasOne(m => m.Manufacturer).WithMany().OnDelete(DeleteBehavior.SetNull);
            model.Entity<RI>().HasOne(p => p.Package).WithMany().OnDelete(DeleteBehavior.SetNull);
            model.Entity<RI>().HasOne(s => s.StoragePoint).WithMany().OnDelete(DeleteBehavior.SetNull);
            model.Entity<RI>().HasOne(s => s.Supplier).WithMany().OnDelete(DeleteBehavior.SetNull);
            model.Entity<RI>().HasOne(r => r.Recipient).WithMany().OnDelete(DeleteBehavior.SetNull);
            //Маркеры
            model.Entity<Marker>().HasData(
                new Marker[]
                {
                    new Marker{ Id = 1, MarkerName = "Резоскан", MaxActivity = 600, MinActivity = 400, NewGenerator = true},
                    new Marker{ Id = 2, MarkerName = "Нанотоп" , MaxActivity = 170, MinActivity = 120, NewGenerator = true},
                    new Marker{ Id = 3, MarkerName = "Пентатех", MaxActivity = 370, MinActivity = 110, NewGenerator = false},
                    new Marker{ Id = 4, MarkerName = "Технефит", MaxActivity = 300, MinActivity = 120, NewGenerator = false},
                    new Marker{ Id = 5, MarkerName = "Технемек", MaxActivity = 150, MinActivity = 100, NewGenerator = false}
                });
            //Объёмы
            model.Entity<Volume>().HasData(
                new Volume[]
                {
                    new Volume{ Id = 1, Value = 10 },
                    new Volume{ Id = 2, Value = 8 },
                    new Volume{ Id = 3, Value = 5 },
                    new Volume{ Id = 4, Value = 4 },
                    new Volume{ Id = 5, Value = 3 },
                    new Volume{ Id = 6, Value = 2 },
                    new Volume{ Id = 7, Value = 1.5 },
                    new Volume{ Id = 8, Value = 1.4 },
                    new Volume{ Id = 9, Value = 1.3 },
                    new Volume{ Id = 10, Value = 1.2 },
                    new Volume{ Id = 11, Value = 1.1 },
                    new Volume{ Id = 12, Value = 1 },
                    new Volume{ Id = 13, Value = 0.9 },
                    new Volume{ Id = 14, Value = 0.8 },
                    new Volume{ Id = 15, Value = 0.7 },
                    new Volume{ Id = 16, Value = 0.6 },
                    new Volume{ Id = 17, Value = 0.5 },
                    new Volume{ Id = 18, Value = 0.4 },
                    new Volume{ Id = 19, Value = 0.3 },
                    new Volume{ Id = 20, Value = 0.2 },
                    new Volume{ Id = 21, Value = 0.1 }
                });
            //Распад Молибдена
            model.Entity<Molybdenum>().HasData(
                new Molybdenum[]
                {
                    new Molybdenum {Id = 1, Day = 0, DecayPrecent = 100 },
                    new Molybdenum {Id = 2, Day = 1, DecayPrecent = 77.33 },
                    new Molybdenum {Id = 3, Day = 2, DecayPrecent = 60.41 },
                    new Molybdenum {Id = 4, Day = 3, DecayPrecent = 46.96 },
                    new Molybdenum {Id = 5, Day = 4, DecayPrecent = 36.5 },
                    new Molybdenum {Id = 6, Day = 5, DecayPrecent = 28.37 },
                    new Molybdenum {Id = 7, Day = 6, DecayPrecent = 22.05 },
                    new Molybdenum {Id = 8, Day = 7, DecayPrecent = 17.14 },
                    new Molybdenum {Id = 9, Day = 8, DecayPrecent = 13.32 },
                    new Molybdenum {Id = 10, Day = 9, DecayPrecent = 10.35 },
                    new Molybdenum {Id = 11, Day = 10, DecayPrecent = 8.05 },
                    new Molybdenum {Id = 12, Day = 11, DecayPrecent = 6.26 },
                    new Molybdenum {Id = 13, Day = 12, DecayPrecent = 4.86 },
                    new Molybdenum {Id = 14, Day = 13, DecayPrecent = 3.78 },
                    new Molybdenum {Id = 15, Day = 14, DecayPrecent = 2.94 },
                    new Molybdenum {Id = 16, Day = 15, DecayPrecent = 2.28 }
                });
            //Распад Технеция
            model.Entity<Technetium>().HasData(
                new Technetium[]
                {
                    new Technetium {Id = 1, Hour = 0, DecayPrecent = 100 },
                    new Technetium {Id = 2, Hour = 0.5, DecayPrecent = 94.39 },
                    new Technetium {Id = 3, Hour = 1, DecayPrecent = 89.09 },
                    new Technetium {Id = 4, Hour = 1.5, DecayPrecent = 84.09 },
                    new Technetium {Id = 5, Hour = 2, DecayPrecent = 79.37 },
                    new Technetium {Id = 6, Hour = 2.5, DecayPrecent = 74.92 },
                    new Technetium {Id = 7, Hour = 3, DecayPrecent = 70.71 },
                    new Technetium {Id = 8, Hour = 3.5, DecayPrecent = 66.74 },
                    new Technetium {Id = 9, Hour = 4, DecayPrecent = 63 },
                    new Technetium {Id = 10, Hour = 4.5, DecayPrecent = 59.46 },
                    new Technetium {Id = 11, Hour = 5, DecayPrecent = 56.12 },
                    new Technetium {Id = 12, Hour = 5.5, DecayPrecent = 52.97 },
                    new Technetium {Id = 13, Hour = 6, DecayPrecent = 50 },
                    new Technetium {Id = 14, Hour = 6.5, DecayPrecent = 47.19 },
                    new Technetium {Id = 15, Hour = 7, DecayPrecent = 44.54 },
                    new Technetium {Id = 16, Hour = 7.5, DecayPrecent = 42.04 },
                    new Technetium {Id = 17, Hour = 8, DecayPrecent = 36.69 },
                    new Technetium {Id = 18, Hour = 8.5, DecayPrecent = 37.46 },
                    new Technetium {Id = 19, Hour = 9, DecayPrecent = 35.36 },
                    new Technetium {Id = 20, Hour = 9.5, DecayPrecent = 33.37 },
                    new Technetium {Id = 21, Hour = 10, DecayPrecent = 31.50 },
                    new Technetium {Id = 22, Hour = 10.5, DecayPrecent = 29.73 },
                    new Technetium {Id = 23, Hour = 11, DecayPrecent = 28.06 },
                    new Technetium {Id = 24, Hour = 11.5, DecayPrecent = 26.49 },
                    new Technetium {Id = 25, Hour = 12, DecayPrecent = 25 }
                });
            //Распад Йода
            model.Entity<Iodine>().HasData(
                new Iodine[]
                {
                    new Iodine {Id = 1,  Day = 0, DecayPrecent = 100 },
                    new Iodine {Id = 2,  Day = 1, DecayPrecent = 91.8 },
                    new Iodine {Id = 3,  Day = 2, DecayPrecent = 84.3 },
                    new Iodine {Id = 4,  Day = 3, DecayPrecent = 77.4 },
                    new Iodine {Id = 5,  Day = 4, DecayPrecent = 71 },
                    new Iodine {Id = 6,  Day = 5, DecayPrecent = 65.2 },
                    new Iodine {Id = 7,  Day = 6, DecayPrecent = 59.9 },
                    new Iodine {Id = 8,  Day = 7, DecayPrecent = 54.9 },
                    new Iodine {Id = 9,  Day = 8, DecayPrecent = 50.7 },
                    new Iodine {Id = 10, Day = 9, DecayPrecent = 46.3 },
                    new Iodine {Id = 11, Day = 10, DecayPrecent = 42.5 },
                    new Iodine {Id = 12, Day = 11, DecayPrecent = 39 },
                    new Iodine {Id = 13, Day = 12, DecayPrecent = 35.8 },
                    new Iodine {Id = 14, Day = 13, DecayPrecent = 32.9 },
                    new Iodine {Id = 15, Day = 14, DecayPrecent = 30.2 },
                    new Iodine {Id = 16, Day = 15, DecayPrecent = 27.2 },
                    new Iodine {Id = 17, Day = 16, DecayPrecent = 25.4 },
                    new Iodine {Id = 18, Day = 17, DecayPrecent = 23.4 },
                    new Iodine {Id = 19, Day = 18, DecayPrecent = 21.4 },
                    new Iodine {Id = 20, Day = 19, DecayPrecent = 19.7 },
                    new Iodine {Id = 21, Day = 20, DecayPrecent = 18.1 },
                    new Iodine {Id = 22, Day = 21, DecayPrecent = 16.6 },
                    new Iodine {Id = 23, Day = 22, DecayPrecent = 15.2 },
                    new Iodine {Id = 24, Day = 23, DecayPrecent = 14 },
                    new Iodine {Id = 25, Day = 24, DecayPrecent = 12.8 },
                    new Iodine {Id = 26, Day = 25, DecayPrecent = 11.8 },
                    new Iodine {Id = 27, Day = 26, DecayPrecent = 10.8 },
                    new Iodine {Id = 28, Day = 27, DecayPrecent = 9.7 }
                });
            //Распад Радия
            model.Entity<Radium>().HasData(
               new Radium[]
               {
                    new Radium {Id = 1, Day = 0, DecayCoefficent = 1.54 },
                    new Radium {Id = 2, Day = 1, DecayCoefficent = 1.45 },
                    new Radium {Id = 3, Day = 2, DecayCoefficent = 1.36 },
                    new Radium {Id = 4, Day = 3, DecayCoefficent = 1.28 },
                    new Radium {Id = 5, Day = 4, DecayCoefficent = 1.21 },
                    new Radium {Id = 6, Day = 5, DecayCoefficent = 1.14 },
                    new Radium {Id = 7, Day = 6, DecayCoefficent = 1.07 },
                    new Radium {Id = 8, Day = 7, DecayCoefficent = 1.01 },
                    new Radium {Id = 9, Day = 8, DecayCoefficent = 0.95 },
                    new Radium {Id = 10, Day = 9, DecayCoefficent = 0.89 },
                    new Radium {Id = 11, Day = 10, DecayCoefficent = 0.84 },
                    new Radium {Id = 12, Day = 11, DecayCoefficent = 0.79 },
                    new Radium {Id = 13, Day = 12, DecayCoefficent = 0.74 },
                    new Radium {Id = 14, Day = 13, DecayCoefficent = 0.7 },
                    new Radium {Id = 15, Day = 14, DecayCoefficent = 0.66 },
                    new Radium {Id = 16, Day = 15, DecayCoefficent = 0.62 },
                    new Radium {Id = 17, Day = 16, DecayCoefficent = 0.58 },
                    new Radium {Id = 18, Day = 17, DecayCoefficent = 0.55 },
                    new Radium {Id = 19, Day = 18, DecayCoefficent = 0.52 },
                    new Radium {Id = 20, Day = 19, DecayCoefficent = 0.49 },
                    new Radium {Id = 21, Day = 20, DecayCoefficent = 0.46 },
                    new Radium {Id = 22, Day = 21, DecayCoefficent = 0.43 }
               });
            model.Entity<Organ>().HasData(
                new Organ[]
                {
                    new Organ{ Id = 1, OrganName = "Желудок"},
                    new Organ{ Id = 2, OrganName = "Лёгкие"},
                    new Organ{ Id = 3, OrganName = "Красный костный мозг"},
                    new Organ{ Id = 4, OrganName = "Яичники"},
                    new Organ{ Id = 5, OrganName = "Семенники"},
                    new Organ{ Id = 6, OrganName = "Верхний отдел толстой кишки"},
                    new Organ{ Id = 7, OrganName = "Нижний отдел толстой кишки"},
                    new Organ{ Id = 8, OrganName = "Мочевой пузырь"},
                    new Organ{ Id = 9, OrganName = "Кости"},
                    new Organ{ Id = 10, OrganName = "Кожа"},
                    new Organ{ Id = 11, OrganName = "Тонка кишка"},
                    new Organ{ Id = 12, OrganName = "Почки"},
                    new Organ{ Id = 13, OrganName = "Скелетные мышцы"},
                    new Organ{ Id = 14, OrganName = "Поджелудочная железа"},
                    new Organ{ Id = 15, OrganName = "Селезёнка"},
                    new Organ{ Id = 16, OrganName = "Всё тело"},
                    new Organ{ Id = 17, OrganName = "Сердце"},
                    new Organ{ Id = 18, OrganName = "Надпочечники"},
                    new Organ{ Id = 19, OrganName = "Головной мозг"},
                    new Organ{ Id = 20, OrganName = "Желчный пузырь"},
                    new Organ{ Id = 21, OrganName = "Вилочковая железа"},
                    new Organ{ Id = 22, OrganName = "Матка"},
                    new Organ{ Id = 23, OrganName = "Печень"},
                    new Organ{ Id = 24, OrganName = "Щитовидная железа"},
                    new Organ{ Id = 25, OrganName = "Молочные железы"}
                });
            model.Entity<RadiationExposureToOrgan>().HasData(
                new RadiationExposureToOrgan[]
                {
                    new RadiationExposureToOrgan{ Id = 1, MarkerId = 1, OrganId = 9, Coefficient = 0.007},
                    new RadiationExposureToOrgan{ Id = 2, MarkerId = 1, OrganId = 4, Coefficient = 0.004},
                    new RadiationExposureToOrgan{ Id = 3, MarkerId = 1, OrganId = 5, Coefficient = 0.005},
                    new RadiationExposureToOrgan{ Id = 4, MarkerId = 1, OrganId = 16, Coefficient = 0.0025},
                    new RadiationExposureToOrgan{ Id = 5, MarkerId = 2, OrganId = 24, Coefficient = 0.01},
                    new RadiationExposureToOrgan{ Id = 6, MarkerId = 2, OrganId = 3, Coefficient = 0.005},
                    new RadiationExposureToOrgan{ Id = 7, MarkerId = 2, OrganId = 9, Coefficient = 0.006},
                    new RadiationExposureToOrgan{ Id = 8, MarkerId = 2, OrganId = 5, Coefficient = 0.003},
                    new RadiationExposureToOrgan{ Id = 9, MarkerId = 2, OrganId = 4, Coefficient = 0.018},
                    new RadiationExposureToOrgan{ Id = 10, MarkerId = 2, OrganId = 16, Coefficient = 0.009},
                    new RadiationExposureToOrgan{ Id = 11, MarkerId = 3, OrganId = 12, Coefficient = 0.01},
                    new RadiationExposureToOrgan{ Id = 12, MarkerId = 3, OrganId = 3, Coefficient = 0.002},
                    new RadiationExposureToOrgan{ Id = 13, MarkerId = 3, OrganId = 4, Coefficient = 0.006},
                    new RadiationExposureToOrgan{ Id = 14, MarkerId = 3, OrganId = 5, Coefficient = 0.003},
                    new RadiationExposureToOrgan{ Id = 15, MarkerId = 3, OrganId = 16, Coefficient = 0.002},
                    new RadiationExposureToOrgan{ Id = 16, MarkerId = 3, OrganId = 8, Coefficient = 0.06},
                    new RadiationExposureToOrgan{ Id = 17, MarkerId = 4, OrganId = 16, Coefficient = 0.004},
                    new RadiationExposureToOrgan{ Id = 18, MarkerId = 4, OrganId = 23, Coefficient = 0.08},
                    new RadiationExposureToOrgan{ Id = 19, MarkerId = 4, OrganId = 15, Coefficient = 0.04},
                    new RadiationExposureToOrgan{ Id = 20, MarkerId = 4, OrganId = 3, Coefficient = 0.015},
                    new RadiationExposureToOrgan{ Id = 21, MarkerId = 5, OrganId = 16, Coefficient = 0.005},
                    new RadiationExposureToOrgan{ Id = 22, MarkerId = 5, OrganId = 5, Coefficient = 0.0018},
                    new RadiationExposureToOrgan{ Id = 23, MarkerId = 5, OrganId = 4, Coefficient = 0.0034},
                    new RadiationExposureToOrgan{ Id = 34, MarkerId = 5, OrganId = 12, Coefficient = 0.23},
                });
            //Коэффиценты для детей
            model.Entity<CoefficientsForChildren>().HasData(
                new CoefficientsForChildren[]
                {
                    new CoefficientsForChildren{ Id = 1, AgeRange = "13-17", Coefficient = 0.5},
                    new CoefficientsForChildren{ Id = 2, AgeRange = "8-12", Coefficient = 0.4},
                    new CoefficientsForChildren{ Id = 3, AgeRange = "3-7", Coefficient = 0.3},
                    new CoefficientsForChildren{ Id = 4, AgeRange = "1-2", Coefficient = 0.1},
                    new CoefficientsForChildren{ Id = 5, AgeRange = "<1", Coefficient = 0.03}
                });
            //Радионуклиид
            model.Entity<Radionuclide>().HasData(
                new Radionuclide[]
                {
                    new Radionuclide{ RadionuclideId = 1, RadionuclideName = "Технеций-99m"},
                    new Radionuclide{ RadionuclideId = 2, RadionuclideName = "Йод-131"},
                    new Radionuclide{ RadionuclideId = 3, RadionuclideName = "Радий-223"}
                });
            //Радионуклиидный состав
            model.Entity<RadionuclideCompound>().HasData(
                new RadionuclideCompound[]
                {
                    new RadionuclideCompound{ RadionuclideCompoundId = 1, Compound = "Пертехнет Натрия"},
                    new RadionuclideCompound{ RadionuclideCompoundId = 2, Compound = "Натрий Йодит"},
                    new RadionuclideCompound{ RadionuclideCompoundId = 3, Compound = "Радия Хлорид"}
                });
            //Изготовитель
            model.Entity<Manufacturer>().HasData(
                new Manufacturer[]
                {
                    new Manufacturer{ ManufacturerId = 1, ManufacturerName = "ФГАОУ ВО УФУ"},
                    new Manufacturer{ ManufacturerId = 2, ManufacturerName = "АО НИФХИИ"}
                });
            //Поставщик
            model.Entity<Supplier>().HasData(
            new Supplier[]
            {
                    new Supplier{ SupplierId = 1, SupplierName = "ООО Фарматом"},
                    new Supplier{ SupplierId = 2, SupplierName = "ООО Цистех"}
                });
            //Контейнер
            model.Entity<Package>().HasData(
                new Package[]
                {
                    new Package{ PackageId = 1, PackageName = "ГТ-4К"},
                    new Package{ PackageId = 2, PackageName = "КТ-1-10"}
                });
            //Пункт хранения
            model.Entity<StoragePoint>().HasData(
                new StoragePoint[]
                {
                    new StoragePoint{ StoragePointId = 1, StoragePointName = "Сейф"},
                    new StoragePoint{ StoragePointId = 2, StoragePointName = "Хранилище"},
                    new StoragePoint{ StoragePointId = 3, StoragePointName = "Генераторная"}
                });
            //Получатель
            model.Entity<Recipient>().HasData(
                new Recipient[]
                {
                    new Recipient{ RecipientId = 1, RecipientName = "ГУЗ КОД"}
                });
            //РАО
            model.Entity<RI>().HasData(
                new RI[]
                {
                    new RI
                    {
                        Id = 1,
                        RadionuclideId = 1,
                        PassportNumber = "904",
                        CreateDate = new DateTime(2025,02,25),
                        Weight = 15,
                        Volume = 200,
                        GeneratorNumber = "4554",
                        Activity = 19000,
                        RadionuclideCompoundId = 1,
                        ManufacturerId = 1,
                        Operation = "В/В Введение",
                        OperationDate = new DateTime(2025,02,25),
                        PackageId = 1,
                        StoragePointId = 3,
                        SupplierId = 1,
                        RecipientId = 1,
                        AccompanyingDocument = "Т-Т Накладная",
                        Sent = true
                    },
                    new RI
                    {
                        Id = 2,
                        RadionuclideId = 2,
                        PassportNumber = "03186",
                        CreateDate = new DateTime(2024,12,02),
                        Weight = 2,
                        Volume = 6,
                        GeneratorNumber = null,
                        Activity = 200,
                        RadionuclideCompoundId = 2,
                        ManufacturerId = 1,
                        Operation = "PerOs",
                        OperationDate = new DateTime(2024,12,02),
                        PackageId = 2,
                        StoragePointId = 1,
                        SupplierId = 2,
                        RecipientId = 1,
                        AccompanyingDocument = "Т-Т Накладная",
                        Sent = false
                    },
                    new RI
                    {
                        Id = 3,
                        RadionuclideId = 3,
                        PassportNumber = "210225-1/59",
                        CreateDate = new DateTime(2025,02,21),
                        Weight = 2,
                        Volume = 6.6,
                        GeneratorNumber = null,
                        Activity = 10.2,
                        RadionuclideCompoundId = 3,
                        ManufacturerId = 1,
                        Operation = "В/В Введение",
                        OperationDate = new DateTime(2025,02,21),
                        PackageId = 2,
                        StoragePointId = 1,
                        SupplierId = 1,
                        RecipientId = 1,
                        AccompanyingDocument = "Т-Т Накладная",
                        Sent = false
                    }
                });;
            //User
            model.Entity<User>().HasData(
                new User[]
                {
                    new User
                    {
                        UserId = 1,
                        UserName = "Admin",
                        HashPassword = "f8EKu7SwpqildWZB1vPfjADyYop71xwTWF+4FVSBfv5YTW5gtIqKAvz8aY26TFXL3w==",
                        Administrator = true
                    },
                    new User
                    {
                        UserId = 2,
                        UserName = "User",
                        HashPassword = "SAGSo68FqZ+Cr6EIn7eHqgC61MU7NCYMa3UhPw2R3iwvrKpgC23h7m/B9qgyRP/wRA==",
                        Administrator = false
                    }
                });
        }
    }
}
