using Isotop2.Data.Entities;

namespace Isotop2.Data.Interfaces
{
    internal interface IRIModel
    {
        void RefrashData();
        bool IsRICreated();
        int GetCurrentRI();
        void SetCurrenRI(int id);
        List<RIView> GetAllRI();
        List<RIView>? GetFilterRI(string filter, string search, string addionalSearch = "");
        List<Radionuclide> GetRadionuclideList();
        List<RadionuclideCompound> GetRadionuclideCompoundList();
        List<Manufacturer> GetManufacturerList();
        List<Package> GetPackageList();
        List<StoragePoint> GetStoragePointList();
        List<Supplier> GetSupplierList();
        List<Recipient> GetRecipientList();
        RI? GetRIbyId(int id);
        bool AddRI(string radionuclide, string passportNumber, string createDate, string weight, string volume, string generatorNumber,
                          string activity, string compound, string manufacturer, string operation, string operationDate, string package,
                          string storage, string supplier, string recipient, string document, bool sent);
        bool EditRI(string radionuclide, string passportNumber, string createDate, string weight, string volume, string generatorNumber,
                          string activity, string compound, string manufacturer, string operation, string operationDate, string package,
                          string storage, string supplier, string recipient, string document, bool sent);
        bool DeleteRI(int id);
        string[] GetHeaderList();
        string[] GetColumnNameToSearch();
        Task ExportToCSVAsync(List<RIView> dataList);
    }
}
