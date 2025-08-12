using Isotop2.Data.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Isotop2.Data.Models
{
    internal class RIModel
    {
        Expression<Func<RI, object>>[] _RIIncludes = { r => r.Radionuclide, c => c.RadionuclideCompound, m => m.Manufacturer, p => p.Package, s => s.StoragePoint, s => s.Supplier, r => r.Recipient };
        List<Radionuclide> _radionuclideList; //Список радионуклиидов
        List<RadionuclideCompound> _radionuclideCompoundList; //Список соеденений
        List<Manufacturer> _manufacturerList; //Список производителей
        List<Package> _packageList; //Список упаковок
        List<StoragePoint> _storagePointList; //Список хранилищ
        List<Supplier> _supplierList; //Спискок поставщиков
        List<Recipient> _recipientList; //Список получателей

        int _currentRI = -1; //Выбранное РИ
        bool _isCreated = false; //Существование объекта РИ

        string[] _headerList =
        {
                "Id",
                "Наименование РИ",
                "Номер паспорта",
                "Дата изготовления",
                "Масса, Кг",
                "Номер генератора",
                "Объём, Мл",
                "Активность, МБк",
                "Состав РИ",
                "Производитель",
                "Вид операции",
                "Дата операции",
                "Тип упаковки",
                "Место хранения",
                "Поставщик",
                "Получатель",
                "Документ",
                "Отправлен"
        };

        string[] _columnNameToSearch = { "Наименование РИ", "Производитель", "Поставщик", "Получатель" };

        private readonly DataStorage<RI> _dataStorage; //Хранилище
        public RIModel(DataStorage<RI> dataStorage)
        {
            _dataStorage = dataStorage;

            _radionuclideList = new DataStorage<Radionuclide>().GetAll();
            _radionuclideCompoundList = new DataStorage<RadionuclideCompound>().GetAll();
            _manufacturerList = new DataStorage<Manufacturer>().GetAll();
            _packageList = new DataStorage<Package>().GetAll();
            _storagePointList = new DataStorage<StoragePoint>().GetAll();
            _supplierList = new DataStorage<Supplier>().GetAll();
            _recipientList = new DataStorage<Recipient>().GetAll();
        }
        //Метод создания таблицы Excel
        private void CreateExcelTable(List<string[]> dataList)
        {
            ExcelDocCreater excel = new ExcelDocCreater();
            excel.CreateDocument(dataList);
            excel.VisibleDocument();
        }
        //Получаем состояние
        public bool IsRICreated()
        {
            return _isCreated;
        }
        //Получение выбранного РИ
        public int GetCurrentRI()
        {
            return _currentRI;
        }
        //Установка выбранного РИ
        public void SetCurrenRI(int id)
        {
            _currentRI = id;
        }
        //Метод получения всех РИ
        public List<RIView> GetAllRI()
        {
            List<RI> list = _dataStorage.GetAllIcluded(_RIIncludes);
            List<RIView> RIVList = AuxiliaryFuntions.ConvertRIToRIView(list);
            return RIVList;
        }
        //Метод получения отфильтрованных данных
        public List<RIView> GetFilterRI(string filter, string search, string addionalSearch = "")
        {
            List<RI> RIList = null;
            switch (filter)
            {
                case "Наименование РИ":
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.Radionuclide.RadionuclideName == search, _RIIncludes);
                break;
                case "Номер паспорта":
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.PassportNumber == search, _RIIncludes);
                break;
                case "Дата изготовления":                    
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.CreateDate >= Convert.ToDateTime(search) && x.CreateDate <= Convert.ToDateTime(addionalSearch), _RIIncludes);
                break;
                case "Номер генератора":
                    if (search == "") search = null;
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.GeneratorNumber == search, _RIIncludes);
                break;
                case "Производитель":
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.Manufacturer.ManufacturerName == search, _RIIncludes);
                break;
                case "Поставщик":
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.Supplier.SupplierName == search, _RIIncludes);
                break;
                case "Получатель":
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.Recipient.RecipientName == search, _RIIncludes);
                break;
                case "Отправлен":
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.Sent == Convert.ToBoolean(search), _RIIncludes);
                break;
            }
            List<RIView> RIVList = AuxiliaryFuntions.ConvertRIToRIView(RIList);
            return RIVList;
        }
        //Получаем списков радионуклиидов
        public List<Radionuclide> GetRadionuclideList()
        {
            return _radionuclideList;
        }
        //Получаем списков соеденений
        public List<RadionuclideCompound> GetRadionuclideCompoundList()
        {
            return _radionuclideCompoundList;
        }
        //Получаем списков изготовителей
        public List<Manufacturer> GetManufacturerList()
        {
            return _manufacturerList;
        }
        //Получаем списков упаковок
        public List<Package> GetPackageList()
        {
            return _packageList;
        }
        //Получаем списков хранилищ
        public List<StoragePoint> GetStoragePointList()
        {
            return _storagePointList;
        }
        //Получаем списков поставщиков
        public List<Supplier> GetSupplierList()
        {
            return _supplierList;
        }
        //Получаем списков получателей
        public List<Recipient> GetRecipientList()
        {
            return _recipientList;
        }
        //Получение РИ по id
        public RI GetRIbyId(int id)
        {
            RI ri = _dataStorage.GetOneEntityIcludedAndWhere(x => x.Id == id, _RIIncludes);
            return ri;
        }
        //Создаём обекта РИ по введённым данным
        public RI CreateRI(int id, string radionuclide, string passportNumber, DateTime createDate, string weight, string volume, string generatorNumber, string activity,
                             string compound, string manufacturer, string operation, DateTime operationDate, string package, string storagePoint, string supplier,
                             string recipient, string document, bool sent)
        {
            //Проверяем на заполенени необходимых полей
            if (radionuclide == "" || passportNumber == "" || weight == "" || volume == "" || activity == "" || compound == "" ||
                manufacturer == "" || operation == "" | package == "" || storagePoint == "" || supplier == "" || recipient == "" || document == "")
            {
                _isCreated = false;
                return null;
            }

            //Получаем соответствующие объекты для создания сущности РИ
            Radionuclide rad = _radionuclideList.FirstOrDefault(r => r.RadionuclideName == radionuclide);
            RadionuclideCompound comp = _radionuclideCompoundList.FirstOrDefault(c => c.Compound == compound);
            Manufacturer manuf = _manufacturerList.FirstOrDefault(m => m.ManufacturerName == manufacturer);
            Package pack = _packageList.FirstOrDefault(p => p.PackageName == package);
            StoragePoint store = _storagePointList.FirstOrDefault(s => s.StoragePointName == storagePoint);
            Supplier supp = _supplierList.FirstOrDefault(s => s.SupplierName == supplier);
            Recipient rec = _recipientList.FirstOrDefault(r => r.RecipientName == recipient);

            //Создаём сущность для добавления БД
            RI ri;
            //Если сущность добавляется
            if (id < 0)
                ri = new RI
                {
                    RadionuclideId = rad.RadionuclideId,
                    PassportNumber = passportNumber,
                    CreateDate = createDate.Date,
                    Weight = Convert.ToDouble(weight),
                    GeneratorNumber = generatorNumber == "" ? null : generatorNumber,
                    Volume = Convert.ToDouble(volume),
                    Activity = Convert.ToDouble(activity),
                    RadionuclideCompoundId = comp.RadionuclideCompoundId,
                    ManufacturerId = manuf.ManufacturerId,
                    Operation = operation,
                    OperationDate = operationDate.Date,
                    PackageId = pack.PackageId,
                    StoragePointId = store.StoragePointId,
                    SupplierId = supp.SupplierId,
                    RecipientId = rec.RecipientId,
                    AccompanyingDocument = document,
                    Sent = sent
                };
            //Если редактируется
            else
                ri = new RI
                {
                    Id = id,
                    RadionuclideId = rad.RadionuclideId,
                    PassportNumber = passportNumber,
                    CreateDate = createDate.Date,
                    Weight = Convert.ToDouble(weight),
                    GeneratorNumber = generatorNumber == "" ? null : generatorNumber,
                    Volume = Convert.ToDouble(volume),
                    Activity = Convert.ToDouble(activity),
                    RadionuclideCompoundId = comp.RadionuclideCompoundId,
                    ManufacturerId = manuf.ManufacturerId,
                    Operation = operation,
                    OperationDate = operationDate.Date,
                    PackageId = pack.PackageId,
                    StoragePointId = store.StoragePointId,
                    SupplierId = supp.SupplierId,
                    RecipientId = rec.RecipientId,
                    AccompanyingDocument = document,
                    Sent = sent
                };
            _isCreated = true;
            return ri;
        }
        //Добавление РИ
        public void AddRI(RI ri)
        {
            _dataStorage.Add(ri);
        }
        //Редактирование РИ
        public void EditRI(RI ri)
        {
            _dataStorage.Update(ri);
        }
        //Удаляем сущность из БД
        public bool DeleteRI(int id)
        {
            //Получаем сущность из БД
            RI ri = _dataStorage.GetOneEntityIcludedAndWhere(x => x.Id == id, _RIIncludes);
            if (ri == null)
                return false;
            //Если сущность существует, то удаляем
            _dataStorage.Delete(ri);
            return true;
        }
        //Метод получения списка заголовков
        public string[] GetHeaderList()
        {
            return _headerList;
        }
        //Метод получения названий таблиц для поиска
        public string[] GetColumnNameToSearch()
        { 
            return _columnNameToSearch; 
        }
        //Метод экспорта данных в Excel
        public async Task ExportToExcelAsync(List<string[]> dataList)
        {
            await Task.Run(()=>CreateExcelTable(dataList));
        }
    }
}
