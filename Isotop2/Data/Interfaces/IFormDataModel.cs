using System.Security;

namespace Isotop2.Data.Interfaces
{
    internal interface IFormDataModel
    {
        void SetUserRole(bool value);
        bool GetUserRole();
        List<string> GetTableNames();
        Dictionary<string, string[]> GetHeaderList();
        string GetCurrentTable();
        int GetCurrentItemTable();
        string[] GetConstTables();
        void SetCurrentTable(string nameTable);
        void SetCurrentItemTable(int id);
        public List<object> GetDataFromTable();
        bool Add(params string[] entityProps);
        bool AddUser(string userName, SecureString password, bool isAdmin);
        bool Delete();
    }
}
