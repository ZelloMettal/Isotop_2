using System.Windows.Controls;
using System.Windows;
using Isotop2.Data.Models;
using Isotop2.Forms;
using Isotop2.Data.Entities;
using System.Security;

namespace Isotop2.Data.Controllers
{
    //Класс-контроллер FormData
    public static class FormDataController
    {
        private static readonly FormDataModel _model = new FormDataModel(); //Модель данных

        //Метод добавления Рабочих объёмов
        private static void AddVolume()
        {
            AddVolumeForm AV = new AddVolumeForm();
            AV.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            AV.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AV.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            AV.ShowDialog();
            if (AV.DialogResult == true)
            {
                string value = AV.GetEnteredData();
                _model.Add(value);
            }
            AV.Close();
        }
        //Метод добавления Маркеров
        private static void AddMarker()
        {
            (string name, string max, string min, bool isNew) data;
            AddMarkerForm AMF = new AddMarkerForm();
            AMF.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            AMF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AMF.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            AMF.ShowDialog();
            if (AMF.DialogResult == true)
            {
                data = AMF.GetEnteredData();
                _model.Add(data.name, data.max, data.min, data.isNew.ToString());
            }
            AMF.Close();
        }
        //Метод добавления Нагрузок на органы
        private static void AddExposureToOrgan()
        {
            (string marker, string organ, string coeff) data;
            AddRadiationExposureToOrganForm AREO = new AddRadiationExposureToOrganForm();
            AREO.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            AREO.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AREO.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            AREO.ShowDialog();
            if (AREO.DialogResult == true)
            {
                data = AREO.GetEnteredData();
                _model.Add(data.marker, data.organ, data.coeff);
            }
            AREO.Close();
        }
        //Метод добавления Пользователей
        private static void AddUser()
        {
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
                    _model.AddUser(data.name, data.pass, Convert.ToBoolean(data.isAdmin));
                else
                    MessageBox.Show("Такой пользователь уже существует", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            AU.Close();
        }
        //Метод добавления Изотопов
        private static void AddIsotop()
        {
            (string day, string dacay) data;
            AddIsotopForm AIF = new AddIsotopForm();
            AIF.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            AIF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AIF.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            AIF.ShowDialog();
            if (AIF.DialogResult == true)
            {
                data = AIF.GetEnteredData();
                _model.Add(data.day, data.dacay);
            }
            AIF.Close();
        }
        //Метод добавления Детских коэффицентов
        private static void AddChildrenAge()
        {
            (string age, string coeff) data;
            AddChildrenAgeForm ACAF = new AddChildrenAgeForm();
            ACAF.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            ACAF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ACAF.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            ACAF.ShowDialog();
            if (ACAF.DialogResult == true)
            {
                data = ACAF.GetEnteredData();
                _model.Add(data.age, data.coeff);
            }
            ACAF.Close();
        }
        //Метод добавления других остальных данных
        private static void AddRemain()
        {
            string value = string.Empty;
            AddForm AF = new AddForm();
            AF.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "FormDataName").First();
            AF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AF.Title = $"Добавить \"{_model.GetCurrentTable()}\"";
            AF.ShowDialog();
            if (AF.DialogResult == true)
            {
                value = AF.GetEnteredData();
                _model.Add(value);
            }
            AF.Close();
        }
        //Метод установки роли пользователя
        static public void SetUserRole(bool value)
        {
            _model.SetUserRole(value);
        }
        //Метод получение списка неизменяемых таблиц
        static public string[] GetConstTable()
        {
            return _model.GetConstTables();
        }
        //Метод заполнения ListView названиями таблиц
        static public void FillListView(ListView lv)
        {
            List<string> tableNames = _model.GetTableNames();
            bool userRole = _model.GetUserRole();
            if (!userRole)
                lv.ItemsSource = tableNames.Where(n => n != "Пользователи");
            else
                lv.ItemsSource = tableNames;
        }
        //Метод заполнения DataGridView
        static public void FillDataGridView(DataGrid dataGrid, string nameTable)
        {
            Dictionary<string, string[]> headerList = _model.GetHeaderList();
            dataGrid.ItemsSource = _model.GetDataFromTable();
            AuxiliaryFuntions.SetHeaderDataGrid(dataGrid, headerList[nameTable]);
            dataGrid.Columns[0].MaxWidth = 0;    //Скрываем столбец с id
        }
        //Метод получения быбранной таблицы
        static public string GetCurrentTable()
        {
            return _model.GetCurrentTable();
        }
        //Метод установки выбранной таблицы(с отключением кнопок: Добавить/Удалить)
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
        //Метод получения выбранного элемента в таблицы
        static public int GetCurrentItemTable()
        {
            return _model.GetCurrentItemTable();
        }
        //Метод установки выбранного элемента таблицы
        ////////По данным из таблицы
        static public void SetCurrentItemTable(DataGrid dataGrid)
        {
            int id = -1;
            //Получаем объект из DataGrid
            var dataItem = dataGrid.SelectedItem;
            if (dataItem != null)
            { 
                //Если объёкт существует, то получаем его id из таблицы(первый скрытый столбец)
                id = Convert.ToInt32(((TextBlock)dataGrid.SelectedCells[0].Column.GetCellContent(dataItem)).Text);
                if (id > 0)
                    //Если id получен, то сохраняем его
                    _model.SetCurrentItemTable(id);
                else
                { 
                    //Если не получен, то с брасываем
                    id = -1;                    
                    _model.SetCurrentItemTable(id);
                }
            }
            //Если объект не найден, то сбрасываем id
            _model.SetCurrentItemTable(id);
        }
        ////////Непосредственный установка id
        static public void SetCurrentItemTable(int id)
        {            
            _model.SetCurrentItemTable(id);
        }
        //Метод добавления в таблицу
        static public void Add()
        {
            string currentTable = _model.GetCurrentTable(); //Выбранная таблица

            switch (currentTable)
            {
                case "Рабочие объёмы":
                    AddVolume();
                break;
                case "Маркер":
                    AddMarker();
                break;
                case "Нагрузка на органы":
                    AddExposureToOrgan();
                break;
                case "Пользователи":
                    AddUser();
                break;
                case "Детский коэффицент":
                    AddChildrenAge();
                break;
                case "Технеций":
                case "Молибден":
                case "Йод":
                case "Радий":
                    AddIsotop();
                break;
                default:
                    AddRemain();
                break;
            }
        }
        //Метод удаления из таблицы
        public static void Delete()
        {
            if (_model.GetCurrentItemTable() > 0)
            {
                if (MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    _model.Delete();
            }
            else
                MessageBox.Show("Выберите строку", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }        
    }
}

