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
  
        public FormData(bool userRole)
        {
            InitializeComponent();
            FormDataController.SetUserRole(userRole);
        }
    
        private void FormData_Load(object sender, RoutedEventArgs e)
        {
            FormDataController.FillListView(listView_Tables);
        }
     
        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            FormDataController.Add();
            FormDataController.FillDataGridView(dataGrid_DataTables);
        }
    
        private void dataGrid_DataTables_CellClick(object sender, SelectedCellsChangedEventArgs e)
        {                       
            FormDataController.SetCurrentItemTable(dataGrid_DataTables); 
        }
    
        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            FormDataController.Delete();
            FormDataController.FillDataGridView(dataGrid_DataTables);
        }
  
        private void listView_Tables_ItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FormDataController.SetCurrentTable(listView_Tables.SelectedValue.ToString(), button_Add, button_Delete);
            FormDataController.SetCurrentItemTable(-1);
            FormDataController.FillDataGridView(dataGrid_DataTables);
        }
   
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
     
        private void PressHotKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                button_Cancel_Click(sender, e);
        }
    }
}