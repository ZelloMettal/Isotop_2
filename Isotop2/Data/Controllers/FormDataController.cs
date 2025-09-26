using System.Windows.Controls;
using System.Windows;
using Isotop2.Data.Interfaces;
using Isotop2.Forms;
using Isotop2.Data.Entities;
using System.Security;
using Microsoft.Extensions.DependencyInjection;
using Isotop2.Services;

namespace Isotop2.Data.Controllers
{
    public static class FormDataController
    {
        private static readonly IFormDataModel _model = ServiceProviderHolder.ServiceProvider.GetRequiredService<IFormDataModel>();

        private static bool AddVolume()
        {
            bool isAdd = true;
            AddVolumeForm AV = new AddVolumeForm();
            AV.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            AV.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AV.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            AV.ShowDialog();
            if (AV.DialogResult == true)
            {
                string value = AV.GetEnteredData();
                isAdd = _model.Add(value);
            }
            AV.Close();
            return isAdd;
        }

        private static bool AddMarker()
        {
            bool isAdd = true;
            (string name, string max, string min, bool isNew) data;
            AddMarkerForm AMF = new AddMarkerForm();
            AMF.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            AMF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AMF.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            AMF.ShowDialog();
            if (AMF.DialogResult == true)
            {
                data = AMF.GetEnteredData();
                isAdd = _model.Add(data.name, data.max, data.min, data.isNew.ToString());
            }            
            AMF.Close();
            return isAdd;
        }
 
        private static bool AddExposureToOrgan()
        {
            bool isAdd = true;
            (string marker, string organ, string coeff) data;
            AddRadiationExposureToOrganForm AREO = new AddRadiationExposureToOrganForm();
            AREO.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            AREO.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AREO.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            AREO.ShowDialog();
            if (AREO.DialogResult == true)
            {
                data = AREO.GetEnteredData();
                isAdd = _model.Add(data.marker, data.organ, data.coeff);
            }
            AREO.Close();
            return isAdd;
        }

        private static bool AddUser()
        {
            bool isAdd = true;
            (string name, SecureString pass, bool isAdmin) data;
            List<User> users = new DataStorage<User>().GetAll();
            AddUserForm AU = new AddUserForm();
            AU.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            AU.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AU.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            AU.ShowDialog();
            if (AU.DialogResult == true)
            {
                data = AU.GetEnteredData();
                User find_user = users.Find(x => x.UserName.Contains(data.name));
                if (find_user == null)
                    isAdd = _model.AddUser(data.name, data.pass, Convert.ToBoolean(data.isAdmin));
                else
                    MessageBox.Show("Такой пользователь уже существует", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            AU.Close();
            return isAdd;
        }

        private static bool AddIsotop()
        {
            bool isAdd = true;
            (string day, string dacay) data;
            AddIsotopForm AIF = new AddIsotopForm();
            AIF.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            AIF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AIF.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            AIF.ShowDialog();
            if (AIF.DialogResult == true)
            {
                data = AIF.GetEnteredData();
                isAdd = _model.Add(data.day, data.dacay);
            }
            AIF.Close();
            return isAdd;
        }

        private static bool AddChildrenAge()
        {
            bool isAdd = true;
            (string age, string coeff) data;
            AddChildrenAgeForm ACAF = new AddChildrenAgeForm();
            ACAF.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            ACAF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ACAF.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            ACAF.ShowDialog();
            if (ACAF.DialogResult == true)
            {
                data = ACAF.GetEnteredData();
                isAdd = _model.Add(data.age, data.coeff);
            }
            ACAF.Close();
            return isAdd;
        }

        private static bool AddRemain()
        {
            bool isAdd = true;
            string value = string.Empty;
            AddForm AF = new AddForm();
            AF.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            AF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AF.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            AF.ShowDialog();
            if (AF.DialogResult == true)
            {
                value = AF.GetEnteredData();
                isAdd = _model.Add(value);
            }
            AF.Close();
            return isAdd;
        }

        static public void SetUserRole(bool value)
        {
            _model.SetUserRole(value);
        }

        static public void FillListView(ListView lv)
        {
            List<string> tableNames = _model.GetTableNames();
            bool userRole = _model.GetUserRole();
            if (!userRole)
                lv.ItemsSource = tableNames.Where(n => n != "Пользователи");
            else
                lv.ItemsSource = tableNames;
        }

        static public void FillDataGridView(DataGrid dataGrid)
        {
            Dictionary<string, string[]> headerList = _model.GetHeaderList();
            dataGrid.ItemsSource = _model.GetDataFromTable();
            AuxiliaryFuntions.SetHeaderDataGrid(dataGrid, headerList[GetCurrentTable()]);
            if (dataGrid.ItemsSource == null)
            {
                MessageBox.Show("Не удалось загрузить данные", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }    
            if(GetCurrentTable() == "Пользователи")
                dataGrid.Columns[2].MaxWidth = 0; //Скрываем столбец с хешем пароля
            dataGrid.Columns[0].MaxWidth = 0;    //Скрываем столбец с id
        }

        static public string GetCurrentTable()
        {
            return _model.GetCurrentTable();
        }

        static public void SetCurrentTable(string currentTable, params Button[] buttons)
        {
            _model.SetCurrentTable(currentTable);
            string[] constsTable = _model.GetConstTables();
            if (constsTable.Contains(currentTable) && !_model.GetUserRole())
            {
                foreach (Button button in buttons)
                    button.IsEnabled = false;
            }
            else
            {
                foreach (Button button in buttons)
                    button.IsEnabled = true;
            }
        }

        static public void SetCurrentItemTable(DataGrid dataGrid)
        {
            int id = -1;

            var dataItem = dataGrid.SelectedItem;
            if (dataItem != null)
            { 
                id = Convert.ToInt32(((TextBlock)dataGrid.SelectedCells[0].Column.GetCellContent(dataItem)).Text);
                if (id > 0)
                    _model.SetCurrentItemTable(id);
                else
                { 
                    id = -1;                    
                    _model.SetCurrentItemTable(id);
                }
            }
            _model.SetCurrentItemTable(id);
        }

        static public void SetCurrentItemTable(int id)
        {            
            _model.SetCurrentItemTable(id);
        }

        static public void Add()
        {
            string currentTable = _model.GetCurrentTable();
            bool isAdd = false;
            switch (currentTable)
            {
                case "Рабочие объёмы":
                    isAdd = AddVolume();
                break;
                case "Маркер":
                    isAdd = AddMarker();
                break;
                case "Нагрузка на органы":
                    isAdd = AddExposureToOrgan();
                break;
                case "Пользователи":
                    isAdd = AddUser();
                break;
                case "Детский коэффицент":
                    isAdd = AddChildrenAge();
                break;
                case "Технеций":
                case "Молибден":
                case "Йод":
                case "Радий":
                    isAdd = AddIsotop();
                break;
                default:
                    isAdd = AddRemain();
                break;
            }

            if(!isAdd)
                MessageBox.Show("Не удалось добавить", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void Delete()
        {
            if (_model.GetCurrentItemTable() > 0)
            {
                if (MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                { 
                    if(!_model.Delete())
                        MessageBox.Show("Не удалось удалить", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Выберите строку", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

