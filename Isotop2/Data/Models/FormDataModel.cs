using Isotop2.Data.Entities;
using Isotop2.Data.Interfaces;
using System.Collections;
using System.Security;

namespace Isotop2.Data.Models
{
    public class FormDataModel : IFormDataModel
    {
        private string _currentTable = string.Empty; //Выбранная таблица
        private int _currentItemTable = -1; //Выбранный элемент в таблице
        private bool _userRoleAdministrator = false; //Роль пользвателя
        private readonly string[] CONSTS_TABLE = { "Детский коэффицент", "Технеций", "Молибден", "Йод", "Радий" }; //Список неизменяемых таблицы
        private readonly List<string> _tableName = new List<string>//Список таблиц
            {
                "Детский коэффицент",
                "Изотоп",
                "Изотопный состав",
                "Органы",
                "Нагрузка на органы",
                "Молибден",
                "Маркер",
                "Место хранения",
                "Получатель",
                "Пользователи",
                "Поставщик",
                "Производитель",
                "Рабочие объёмы",
                "Радий",
                "Технеций",
                "Тип упаковки",
                "Йод"
        };
        private readonly Dictionary<string, string[]> _headerList = new Dictionary<string, string[]> //Список заголовков таблиц
        {
            { "Маркер", new string[] { "ID", "Имя", "Макс.Активность", "Мин.Активность", "Новый генератор" } },
            { "Рабочие объёмы", new string[] { "ID", "Объём" } },
            { "Молибден", new string[] { "ID", "День", "Процент распада" } },
            { "Технеций", new string[] { "ID", "Час", "Процент распада" } },
            { "Йод", new string[] { "ID", "День", "Процент распада" } },
            { "Радий", new string[] { "ID", "День", "Коэффицент распада" } },
            { "Органы", new string[] { "ID", "Орган" } },
            { "Детский коэффицент", new string[] { "ID", "Возраст", "Коэффицент" } },
            { "Нагрузка на органы", new string[] { "ID", "Коэффицент", "Маркер", "Орган" } },
            { "Изотоп", new string[] { "ID", "Название изотопа" } },
            { "Изотопный состав", new string[] { "ID", "Изотопный состав" } },
            { "Производитель", new string[] { "ID", "Производитель" } },
            { "Тип упаковки", new string[] { "ID", "Упаковка" } },
            { "Место хранения", new string[] { "ID", "Место хранения" } },
            { "Поставщик", new string[] { "ID", "Поставщик" } },
            { "Получатель", new string[] { "ID", "Получатель" } },
            { "Пользователи", new string[] { "ID", "Имя пользователя", "Пароль", "Администратор" } }
        };
        //Метод установки роли пользователя
        public void SetUserRole(bool value)
        {
            _userRoleAdministrator = value;
        }
        //Метод установки роли пользователя
        public bool GetUserRole()
        {
            return _userRoleAdministrator;
        }
        //Метод получения списка названий таблиц
        public List<string> GetTableNames()
        {
            return _tableName;
        }
        //Метод получения списка заголовков таблиц
        public Dictionary<string, string[]> GetHeaderList()
        {
            return _headerList;
        }
        //Метод получения выбранной таблицы
        public string GetCurrentTable()
        {
            return _currentTable;
        }
        //Метод получения выбранного элемента в таблицы
        public int GetCurrentItemTable()
        {
            return _currentItemTable;
        }
        //Метод получения списка неизменяемых таблиц
        public string[] GetConstTables()
        {
            return CONSTS_TABLE;
        }
        //Метод установки выбранной таблицы
        public void SetCurrentTable(string nameTable)
        {
            _currentTable = nameTable;
        }
        //Метод установки выбранного элемента в таблицы
        public void SetCurrentItemTable(int id)
        {
            _currentItemTable = id;
        }
        //Метод получения данных из БД
        public List<object> GetDataFromTable()
        {
            List<object> data = new List<object>();
            try
            { 
                switch (_currentTable)
                {
                    case "Маркер":
                        {
                            List<Marker>? list = new DataStorage<Marker>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Рабочие объёмы":
                        {
                            List<Volume>? list = new DataStorage<Volume>().GetAll();
                            data.AddRange(list.OrderByDescending(x => x.Value).ToList());
                            return data;
                        }
                    case "Молибден":
                        {
                            List<Molybdenum>? list = new DataStorage<Molybdenum>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Технеций":
                        {
                            List<Technetium>? list = new DataStorage<Technetium>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Йод":
                        {
                            List<Iodine>? list = new DataStorage<Iodine>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Радий":
                        {
                            List<Radium>? list = new DataStorage<Radium>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Органы":
                        {
                            List<Organ>? list = new DataStorage<Organ>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Нагрузка на органы":
                        {
                            List<RadiationExposureToOrgan>? list = new DataStorage<RadiationExposureToOrgan>().GetAllIcluded(x => x.Marker, x => x.Organ);
                            List<RadiationExposureView> listView = AuxiliaryFuntions.ConvertRadiationExposureToRadiationExposureView(list);
                            data.AddRange(listView);
                            return data;
                        }
                    case "Детский коэффицент":
                        {
                            List<CoefficientsForChildren>? list = new DataStorage<CoefficientsForChildren>().GetAll();
                            data.AddRange(list.OrderByDescending(x => x.Coefficient).ToList());
                            return data;
                        }
                    case "Изотоп":
                        {
                            List<Radionuclide>? list = new DataStorage<Radionuclide>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Изотопный состав":
                        {
                            List<RadionuclideCompound>? list = new DataStorage<RadionuclideCompound>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Производитель":
                        {
                            List<Manufacturer>? list = new DataStorage<Manufacturer>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Тип упаковки":
                        {
                            List<Package>? list = new DataStorage<Package>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Место хранения":
                        {
                            List<StoragePoint>? list = new DataStorage<StoragePoint>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Поставщик":
                        {
                            List<Supplier>? list = new DataStorage<Supplier>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Получатель":
                        {
                            List<Recipient>? list = new DataStorage<Recipient>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    case "Пользователи":
                        {
                            List<User>? list = new DataStorage<User>().GetAll();
                            data.AddRange(list);
                            return data;
                        }
                    default: return null;
                }            
            }
            catch 
            {
                return null;
            }
        }
        //Метод добавления сущности 
        public bool Add(params string[] entityProps)
        {
            bool isAdd = false;
            switch (_currentTable)
            {
                case "Маркер":
                    {
                        Marker marker = new Marker
                        {
                            MarkerName = entityProps[0],
                            MaxActivity = Convert.ToInt32(entityProps[1]),
                            MinActivity = Convert.ToInt32(entityProps[2]),
                            NewGenerator = Convert.ToBoolean(entityProps[3])
                        };
                        isAdd = new DataStorage<Marker>().Add(marker);
                    }
                    break;
                case "Рабочие объёмы":
                    {
                        Volume newVolume = new Volume { Value = Convert.ToDouble(entityProps[0]) };
                        isAdd = new DataStorage<Volume>().Add(newVolume);
                    }
                    break;
                case "Органы":
                    {
                        Organ organ = new Organ { OrganName = entityProps[0] };
                        isAdd = new DataStorage<Organ>().Add(organ);
                    }
                    break;
                case "Нагрузка на органы":
                    {
                        Marker? marker = new DataStorage<Marker>().GetOneEntityWher(x => x.MarkerName == entityProps[0]);
                        Organ? organ = new DataStorage<Organ>().GetOneEntityWher(x => x.OrganName == entityProps[1]);
                        RadiationExposureToOrgan ERTO = new RadiationExposureToOrgan { MarkerId = marker.Id, OrganId = organ.Id, Coefficient = Convert.ToDouble(entityProps[2]) };
                        isAdd = new DataStorage<RadiationExposureToOrgan>().Add(ERTO);
                    }
                    break;
                case "Изотоп":
                    {
                        Radionuclide radio = new Radionuclide { RadionuclideName = entityProps[0] };
                        isAdd = new DataStorage<Radionuclide>().Add(radio);
                    }
                    break;
                case "Изотопный состав":
                    {
                        RadionuclideCompound compound = new RadionuclideCompound { Compound = entityProps[0] };
                        isAdd = new DataStorage<RadionuclideCompound>().Add(compound);
                    }
                    break;
                case "Производитель":
                    {
                        Manufacturer manufacturer = new Manufacturer { ManufacturerName = entityProps[0] };
                        isAdd = new DataStorage<Manufacturer>().Add(manufacturer);
                    }
                    break;
                case "Тип упаковки":
                    {
                        Package package = new Package { PackageName = entityProps[0] };
                        isAdd = new DataStorage<Package>().Add(package);
                    }
                    break;
                case "Место хранения":
                    {
                        StoragePoint storagePoint = new StoragePoint { StoragePointName = entityProps[0] };
                        isAdd = new DataStorage<StoragePoint>().Add(storagePoint);
                    }
                    break;
                case "Поставщик":
                    {
                        Supplier supplier = new Supplier { SupplierName = entityProps[0] };
                        isAdd = new DataStorage<Supplier>().Add(supplier);
                    }
                    break;
                case "Получатель":
                    {
                        Recipient recipient = new Recipient { RecipientName = entityProps[0] };
                        isAdd = new DataStorage<Recipient>().Add(recipient);
                    }
                    break;
                case "Технеций":
                    {
                        Technetium tehnetium = new Technetium { Hour = Convert.ToDouble(entityProps[0]), DecayPrecent = Convert.ToDouble(entityProps[1])  };
                        isAdd = new DataStorage<Technetium>().Add(tehnetium);
                    }
                    break;
                case "Йод":
                    {
                        Iodine iodine = new Iodine { Day = Convert.ToInt32(entityProps[0]), DecayPrecent = Convert.ToDouble(entityProps[1]) };
                        isAdd = new DataStorage<Iodine>().Add(iodine);
                    }
                    break;
                case "Радий":
                    {
                        Radium radium = new Radium { Day = Convert.ToInt32(entityProps[0]), DecayCoefficent = Convert.ToDouble(entityProps[1]) };
                        isAdd = new DataStorage<Radium>().Add(radium);
                    }
                    break;
                case "Молибден":
                    {
                        Molybdenum molybdenum = new Molybdenum { Day = Convert.ToInt32(entityProps[0]), DecayPrecent = Convert.ToDouble(entityProps[1]) };
                        isAdd = new DataStorage<Molybdenum>().Add(molybdenum);
                    }
                    break;
                case "Детский коэффицент":
                    {
                        CoefficientsForChildren coefficients = new CoefficientsForChildren { AgeRange = entityProps[0], Coefficient = Convert.ToDouble(entityProps[1]) };
                        isAdd = new DataStorage<CoefficientsForChildren>().Add(coefficients);
                    }
                    break;
                default: break;                    
            }

            return isAdd;
        }
        //Метод добавления пользователя
        public bool AddUser(string userName, SecureString password, bool isAdmin)
        {
            bool isAdd = false;
            string hashPassword = PasswordHasher.Hashing(password);
            User user = new User { UserName = userName, HashPassword = hashPassword, Administrator = isAdmin };
            isAdd = new DataStorage<User>().Add(user);

            return isAdd;
        }
        //Метод удаления сущности
        public bool Delete()
        {
            bool isDelete = false;
            switch (_currentTable)
            {
                case "Маркер":
                    {
                        Marker? marker = new DataStorage<Marker>().GetById(_currentItemTable);
                        isDelete = new DataStorage<Marker>().Delete(marker);
                    }
                    break;
                case "Рабочие объёмы":
                    {
                        Volume? volume = new DataStorage<Volume>().GetById(_currentItemTable);
                        isDelete = new DataStorage<Volume>().Delete(volume);
                    }
                    break;
                case "Органы":
                    {
                        Organ? organ = new DataStorage<Organ>().GetById(_currentItemTable);
                        isDelete = new DataStorage<Organ>().Delete(organ);
                    }
                    break;
                case "Нагрузка на органы":
                    {
                        RadiationExposureToOrgan? REO = new DataStorage<RadiationExposureToOrgan>().GetById(_currentItemTable);
                        isDelete = new DataStorage<RadiationExposureToOrgan>().Delete(REO);
                    }
                    break;
                case "Изотоп":
                    {
                        Radionuclide? radio = new DataStorage<Radionuclide>().GetById(_currentItemTable);
                        isDelete = new DataStorage<Radionuclide>().Delete(radio);
                    }
                    break;
                case "Изотопный состав":
                    {
                        RadionuclideCompound? compound = new DataStorage<RadionuclideCompound>().GetById(_currentItemTable);
                        isDelete = new DataStorage<RadionuclideCompound>().Delete(compound);
                    }
                    break;
                case "Производитель":
                    {
                        Manufacturer? manufacturer = new DataStorage<Manufacturer>().GetById(_currentItemTable);
                        isDelete = new DataStorage<Manufacturer>().Delete(manufacturer);
                    }
                    break;
                case "Тип упаковки":
                    {
                        Package? package = new DataStorage<Package>().GetById(_currentItemTable);
                        isDelete = new DataStorage<Package>().Delete(package);
                    }
                    break;
                case "Место хранения":
                    {
                        StoragePoint? storagePoint = new DataStorage<StoragePoint>().GetById(_currentItemTable);
                        isDelete = new DataStorage<StoragePoint>().Delete(storagePoint);
                    }
                    break;
                case "Поставщик":
                    {
                        Supplier? supplier = new DataStorage<Supplier>().GetById(_currentItemTable);
                        isDelete = new DataStorage<Supplier>().Delete(supplier);
                    }
                    break;
                case "Получатель":
                    {
                        Recipient? recipient = new DataStorage<Recipient>().GetById(_currentItemTable);
                        isDelete = new DataStorage<Recipient>().Delete(recipient);
                    }
                    break;
                case "Пользователи":
                    {
                        User? user = new DataStorage<User>().GetById(_currentItemTable);
                        isDelete = new DataStorage<User>().Delete(user);
                    }
                    break;
                case "Детский коэффицент":
                    {
                        CoefficientsForChildren? coefficients = new DataStorage<CoefficientsForChildren>().GetById(_currentItemTable);
                        isDelete = new DataStorage<CoefficientsForChildren>().Delete(coefficients);
                    }
                    break;
                case "Технеций":
                    {
                        Technetium? technetium = new DataStorage<Technetium>().GetById(_currentItemTable);
                        isDelete = new DataStorage<Technetium>().Delete(technetium);
                    }
                    break;
                case "Йод":
                    {
                        Iodine? iodine = new DataStorage<Iodine>().GetById(_currentItemTable);
                        isDelete = new DataStorage<Iodine>().Delete(iodine);
                    }
                    break;
                case "Молибден":
                    {
                        Molybdenum? molybdenum = new DataStorage<Molybdenum>().GetById(_currentItemTable);
                        isDelete = new DataStorage<Molybdenum>().Delete(molybdenum);
                    }
                    break;
                case "Радий":
                    {
                        Radium? radium = new DataStorage<Radium>().GetById(_currentItemTable);
                        isDelete = new DataStorage<Radium>().Delete(radium);
                    }
                    break;
                default: break;
            }
            _currentItemTable = -1;
            return isDelete;
        }
    }
}