using Isotop2.Data.Entities;
using Isotop2.Data.Interfaces;
using System.Security;

namespace Isotop2.Data.Models
{
    public class FormDataModel : IFormDataModel
    {
        private string _currentTable = string.Empty;
        private int _currentItemTable = -1;
        private bool _userRoleAdministrator = false;
        private readonly string[] CONSTS_TABLE = { "Детский коэффицент", "Технеций", "Молибден", "Йод", "Радий" };
        private readonly List<string> _tableName = new List<string>
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
        private readonly Dictionary<string, string[]> _headerList = new Dictionary<string, string[]>
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
     
        public void SetUserRole(bool value)
        {
            _userRoleAdministrator = value;
        }
      
        public bool GetUserRole()
        {
            return _userRoleAdministrator;
        }
    
        public List<string> GetTableNames()
        {
            return _tableName;
        }
     
        public Dictionary<string, string[]> GetHeaderList()
        {
            return _headerList;
        }
   
        public string GetCurrentTable()
        {
            return _currentTable;
        }
     
        public int GetCurrentItemTable()
        {
            return _currentItemTable;
        }
   
        public string[] GetConstTables()
        {
            return CONSTS_TABLE;
        }
    
        public void SetCurrentTable(string nameTable)
        {
            _currentTable = nameTable;
        }
    
        public void SetCurrentItemTable(int id)
        {
            _currentItemTable = id;
        }
   
        public List<object>? GetDataFromTable()
        {
            List<object> data = new List<object>();
            try
            { 
                switch (_currentTable)
                {
                    case "Маркер": data.AddRange(new DataStorage<Marker>().GetAll()); break;
                    case "Рабочие объёмы": data.AddRange(new DataStorage<Volume>().GetAll().OrderByDescending(x => x.Value).ToList()); break;
                    case "Молибден": data.AddRange(new DataStorage<Molybdenum>().GetAll()); break;
                    case "Технеций": data.AddRange(new DataStorage<Technetium>().GetAll()); break;
                    case "Йод": data.AddRange(new DataStorage<Iodine>().GetAll()); break;
                    case "Радий": data.AddRange(new DataStorage<Radium>().GetAll()); break;
                    case "Органы": data.AddRange(new DataStorage<Organ>().GetAll()); break;                    
                    case "Детский коэффицент": data.AddRange(new DataStorage<CoefficientsForChildren>().GetAll().OrderByDescending(x => x.Coefficient).ToList()); break;
                    case "Изотоп": data.AddRange(new DataStorage<Radionuclide>().GetAll()); break;
                    case "Изотопный состав": data.AddRange(new DataStorage<RadionuclideCompound>().GetAll()); break;
                    case "Производитель": data.AddRange(new DataStorage<Manufacturer>().GetAll()); break;
                    case "Тип упаковки": data.AddRange(new DataStorage<Package>().GetAll()); break;
                    case "Место хранения": data.AddRange(new DataStorage<StoragePoint>().GetAll()); break;
                    case "Поставщик": data.AddRange(new DataStorage<Supplier>().GetAll()); break;
                    case "Получатель": data.AddRange(new DataStorage<Recipient>().GetAll()); break;
                    case "Пользователи": data.AddRange(new DataStorage<User>().GetAll()); break;
                    case "Нагрузка на органы":
                        {
                            List<RadiationExposureView> listView = AuxiliaryFuntions.ConvertRadiationExposureToRadiationExposureView(new DataStorage<RadiationExposureToOrgan>().GetAllIcluded(x => x.Marker, x => x.Organ));
                            data.AddRange(listView);
                        }
                    break;
                    default: return null;
                }            
            }
            catch 
            {
                return null;
            }
            return data;
        }
     
        public bool Add(params string[] entityProps)
        {
            bool isAdded = false;
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
                        isAdded = new DataStorage<Marker>().Add(marker);
                    }
                break;
                case "Рабочие объёмы":
                    {
                        Volume newVolume = new Volume { Value = Convert.ToDouble(entityProps[0]) };
                        isAdded = new DataStorage<Volume>().Add(newVolume);
                    }
                break;
                case "Органы":
                    {
                        Organ organ = new Organ { OrganName = entityProps[0] };
                        isAdded = new DataStorage<Organ>().Add(organ);
                    }
                break;
                case "Нагрузка на органы":
                    {
                        Marker? marker = new DataStorage<Marker>().GetOneEntityWher(x => x.MarkerName == entityProps[0]);
                        Organ? organ = new DataStorage<Organ>().GetOneEntityWher(x => x.OrganName == entityProps[1]);
                        RadiationExposureToOrgan ERTO = new RadiationExposureToOrgan { MarkerId = marker.Id, OrganId = organ.Id, Coefficient = Convert.ToDouble(entityProps[2]) };
                        isAdded = new DataStorage<RadiationExposureToOrgan>().Add(ERTO);
                    }
                break;
                case "Изотоп":
                    {
                        Radionuclide radio = new Radionuclide { RadionuclideName = entityProps[0] };
                        isAdded = new DataStorage<Radionuclide>().Add(radio);
                    }
                break;
                case "Изотопный состав":
                    {
                        RadionuclideCompound compound = new RadionuclideCompound { Compound = entityProps[0] };
                        isAdded = new DataStorage<RadionuclideCompound>().Add(compound);
                    }
                break;
                case "Производитель":
                    {
                        Manufacturer manufacturer = new Manufacturer { ManufacturerName = entityProps[0] };
                        isAdded = new DataStorage<Manufacturer>().Add(manufacturer);
                    }
                break;
                case "Тип упаковки":
                    {
                        Package package = new Package { PackageName = entityProps[0] };
                        isAdded = new DataStorage<Package>().Add(package);
                    }
                break;
                case "Место хранения":
                    {
                        StoragePoint storagePoint = new StoragePoint { StoragePointName = entityProps[0] };
                        isAdded = new DataStorage<StoragePoint>().Add(storagePoint);
                    }
                break;
                case "Поставщик":
                    {
                        Supplier supplier = new Supplier { SupplierName = entityProps[0] };
                        isAdded = new DataStorage<Supplier>().Add(supplier);
                    }
                break;
                case "Получатель":
                    {
                        Recipient recipient = new Recipient { RecipientName = entityProps[0] };
                        isAdded = new DataStorage<Recipient>().Add(recipient);
                    }
                break;
                case "Технеций":
                    {
                        Technetium tehnetium = new Technetium { Hour = Convert.ToDouble(entityProps[0]), DecayPrecent = Convert.ToDouble(entityProps[1])  };
                        isAdded = new DataStorage<Technetium>().Add(tehnetium);
                    }
                break;
                case "Йод":
                    {
                        Iodine iodine = new Iodine { Day = Convert.ToInt32(entityProps[0]), DecayPrecent = Convert.ToDouble(entityProps[1]) };
                        isAdded = new DataStorage<Iodine>().Add(iodine);
                    }
                break;
                case "Радий":
                    {
                        Radium radium = new Radium { Day = Convert.ToInt32(entityProps[0]), DecayCoefficent = Convert.ToDouble(entityProps[1]) };
                        isAdded = new DataStorage<Radium>().Add(radium);
                    }
                break;
                case "Молибден":
                    {
                        Molybdenum molybdenum = new Molybdenum { Day = Convert.ToInt32(entityProps[0]), DecayPrecent = Convert.ToDouble(entityProps[1]) };
                        isAdded = new DataStorage<Molybdenum>().Add(molybdenum);
                    }
                break;
                case "Детский коэффицент":
                    {
                        CoefficientsForChildren coefficients = new CoefficientsForChildren { AgeRange = entityProps[0], Coefficient = Convert.ToDouble(entityProps[1]) };
                        isAdded = new DataStorage<CoefficientsForChildren>().Add(coefficients);
                    }
                break;
                default: break;                    
            }

            return isAdded;
        }

        public bool AddUser(string userName, SecureString password, bool isAdmin)
        {
            bool isAdd = false;
            string hashPassword = PasswordHasher.Hashing(password);
            User user = new User { UserName = userName, HashPassword = hashPassword, Administrator = isAdmin };
            isAdd = new DataStorage<User>().Add(user);
            return isAdd;
        }

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