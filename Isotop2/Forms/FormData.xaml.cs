using Isotop2.Data.Controllers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Isotop2.Forms
{
    public partial class FormData : Window
    {
        public FormData()
        {
            InitializeComponent();
        }
        //Конструктор с получение роли
        public FormData(bool userRole)
        {
            InitializeComponent();
            FormDataController.SetUserRole(userRole);
        }
        // Событие получения таблиц из БД и заполнение ListView
        private void FormData_Load(object sender, RoutedEventArgs e)
        {
            FormDataController.FillListView(listView_Tables);
        }
        // Событие добаления записи в выбранную таблицу
        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            FormDataController.Add();
            FormDataController.FillDataGridView(dataGrid_DataTables);
        }
        // Событие получения выбранной ячейки в таблице
        private void dataGrid_DataTables_CellClick(object sender, SelectedCellsChangedEventArgs e)
        {                       
            FormDataController.SetCurrentItemTable(dataGrid_DataTables); 
        }
        //Событие удаления выбранной записи в таблице
        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            FormDataController.Delete();
            FormDataController.FillDataGridView(dataGrid_DataTables);
        }
        // Событие выбора таблицы
        private void listView_Tables_ItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FormDataController.SetCurrentTable(listView_Tables.SelectedValue.ToString(), button_Add, button_Delete);
            FormDataController.SetCurrentItemTable(-1);
            FormDataController.FillDataGridView(dataGrid_DataTables);
        }
        // Событие выхода из формы
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Событие нажатие Esc
        private void PressHotKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                button_Cancel_Click(sender, e);
        }
    }
}