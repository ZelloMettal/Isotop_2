using Isotop2.Data.Entities;
using Isotop2.Data.Interfaces;
using System.Linq.Expressions;

namespace Isotop2.Data.Models
{
    internal class RIModel : IRIModel
    {
        Expression<Func<RI, object>>[] _RIPredicate = { r => r.Radionuclide, c => c.RadionuclideCompound, m => m.Manufacturer, p => p.Package, s => s.StoragePoint, s => s.Supplier, r => r.Recipient };
        List<Radionuclide>? _radionuclideList;
        List<RadionuclideCompound>? _radionuclideCompoundList;
        List<Manufacturer>? _manufacturerList;
        List<Package>? _packageList;
        List<StoragePoint>? _storagePointList;
        List<Supplier>? _supplierList;
        List<Recipient>? _recipientList;

        readonly IDataStorage<RI> _dataStorage;

        int _currentRI = -1;
        bool _isCreated = false;

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

        public RIModel(IDataStorage<RI> dataStorage)
        {
            _dataStorage = dataStorage;
            RefrashData();
        }
        public void RefrashData()
        {
            _radionuclideList = new DataStorage<Radionuclide>().GetAll();
            _radionuclideCompoundList = new DataStorage<RadionuclideCompound>().GetAll();
            _manufacturerList = new DataStorage<Manufacturer>().GetAll();
            _packageList = new DataStorage<Package>().GetAll();
            _storagePointList = new DataStorage<StoragePoint>().GetAll();
            _supplierList = new DataStorage<Supplier>().GetAll();
            _recipientList = new DataStorage<Recipient>().GetAll();
        }

        private RI? CreateRI(int id, string radionuclide, string passportNumber, DateTime createDate, string weight, string volume, string generatorNumber, string activity,
                             string compound, string manufacturer, string operation, DateTime operationDate, string package, string storagePoint, string supplier,
                             string recipient, string document, bool sent)
        {
  
            Radionuclide? rad = _radionuclideList.FirstOrDefault(r => r.RadionuclideName == radionuclide);
            RadionuclideCompound? comp = _radionuclideCompoundList.FirstOrDefault(c => c.Compound == compound);
            Manufacturer? manuf = _manufacturerList.FirstOrDefault(m => m.ManufacturerName == manufacturer);
            Package? pack = _packageList.FirstOrDefault(p => p.PackageName == package);
            StoragePoint? store = _storagePointList.FirstOrDefault(s => s.StoragePointName == storagePoint);
            Supplier? supp = _supplierList.FirstOrDefault(s => s.SupplierName == supplier);
            Recipient? rec = _recipientList.FirstOrDefault(r => r.RecipientName == recipient);

            RI ri;
            try
            {
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
            }
            catch (Exception ex)
            {
                ri = null;
                _isCreated = false;
            }
            return ri;
        }
        
        private void CreateCSV(List<RIView> dataList)
        {
            CSVDocCreater csv = new CSVDocCreater();
            csv.CreateFile(dataList);
            csv.RunDocument();
        }
      
        public bool IsRICreated()
        {
            return _isCreated;
        }
     
        public int GetCurrentRI()
        {
            return _currentRI;
        }
    
        public void SetCurrenRI(int id)
        {
            _currentRI = id;
        }
    
        public List<RIView> GetAllRI()
        {
            List<RI>? list = _dataStorage.GetAllIcluded(_RIPredicate);
            List<RIView> RIVList = AuxiliaryFuntions.ConvertRIToRIView(list);
            return RIVList;
        }
   
        public List<RIView>? GetFilterRI(string filter, string search, string addionalSearch = "")
        {
            List<RI>? RIList = null;
            switch (filter)
            {
                case "Наименование РИ":
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.Radionuclide.RadionuclideName == search, _RIPredicate);
                break;
                case "Номер паспорта":
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.PassportNumber == search, _RIPredicate);
                break;
                case "Дата изготовления":                    
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.CreateDate >= Convert.ToDateTime(search) && x.CreateDate <= Convert.ToDateTime(addionalSearch), _RIPredicate);
                break;
                case "Номер генератора":
                    if (search == "") search = null;
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.GeneratorNumber == search, _RIPredicate);
                break;
                case "Производитель":
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.Manufacturer.ManufacturerName == search, _RIPredicate);
                break;
                case "Поставщик":
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.Supplier.SupplierName == search, _RIPredicate);
                break;
                case "Получатель":
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.Recipient.RecipientName == search, _RIPredicate);
                break;
                case "Отправлен":
                    RIList = _dataStorage.GetAllIcludedAndWhere(x => x.Sent == Convert.ToBoolean(search), _RIPredicate);
                break;
            }
            if (RIList == null)
            { 
                new Logger($"При попытки получения данных вернулся Null; {DateTime.Now.ToString()}");
                return null;
            }
            List<RIView> RIVList = AuxiliaryFuntions.ConvertRIToRIView(RIList);
            return RIVList;
        }
      
        public List<Radionuclide> GetRadionuclideList()
        {
            return _radionuclideList;
        }
    
        public List<RadionuclideCompound> GetRadionuclideCompoundList()
        {
            return _radionuclideCompoundList;
        }
    
        public List<Manufacturer> GetManufacturerList()
        {
            return _manufacturerList;
        }
      
        public List<Package> GetPackageList()
        {
            return _packageList;
        }
   
        public List<StoragePoint> GetStoragePointList()
        {
            return _storagePointList;
        }
   
        public List<Supplier> GetSupplierList()
        {
            return _supplierList;
        }
    
        public List<Recipient> GetRecipientList()
        {
            return _recipientList;
        }
 
        public RI? GetRIbyId(int id)
        {
            RI? ri = _dataStorage.GetOneEntityIcludedAndWhere(x => x.Id == id, _RIPredicate);
            return ri;
        }        
    
        public bool AddRI(string radionuclide, string passportNumber, string createDate, string weight, string volume, string generatorNumber,
                          string activity, string compound, string manufacturer, string operation, string operationDate, string package,
                          string storage, string supplier, string recipient, string document, bool sent)
        {
            RI? ri = CreateRI
                (
                    _currentRI,
                    radionuclide,
                    passportNumber,
                    Convert.ToDateTime(createDate),
                    weight,
                    volume,
                    generatorNumber,
                    activity,
                    compound,
                    manufacturer,
                    operation,
                    Convert.ToDateTime(operationDate),
                    package,
                    storage,
                    supplier,
                    recipient,
                    document,
                    sent
                );
            if(_isCreated)
                return _dataStorage.Add(ri);
            return _isCreated;
        }
   
        public bool EditRI(string radionuclide, string passportNumber, string createDate, string weight, string volume, string generatorNumber,
                          string activity, string compound, string manufacturer, string operation, string operationDate, string package,
                          string storage, string supplier, string recipient, string document, bool sent)
        {
            RI? ri = CreateRI
                (
                    _currentRI,
                    radionuclide,
                    passportNumber,
                    Convert.ToDateTime(createDate),
                    weight,
                    volume,
                    generatorNumber,
                    activity,
                    compound,
                    manufacturer,
                    operation,
                    Convert.ToDateTime(operationDate),
                    package,
                    storage,
                    supplier,
                    recipient,
                    document,
                    sent
                );
            if (_isCreated)
                return _dataStorage.Update(ri);
            return _isCreated;
        }
   
        public bool DeleteRI(int id)
        {     
            RI? ri = _dataStorage.GetOneEntityIcludedAndWhere(x => x.Id == id, _RIPredicate);
            if (ri == null)
                return false;
            _dataStorage.Delete(ri);
            return true;
        }
    
        public string[] GetHeaderList()
        {
            return _headerList;
        }
    
        public string[] GetColumnNameToSearch()
        { 
            return _columnNameToSearch; 
        }
     
        public async Task ExportToCSVAsync(List<RIView> dataList)
        {
            await Task.Run(()=> CreateCSV(dataList));
        }
    }
}