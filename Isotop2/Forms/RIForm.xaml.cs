using Isotop2.Data.Controllers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Isotop2.Forms
{
    public partial class RIForm : Window
    {
        public RIForm()
        {
            InitializeComponent();
        }

        private void RIForm_Load(object sender, RoutedEventArgs e)
        {
            RIController.FillRIAsync(dataGrid_RIList);
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            RIController.AddRI();
            RIController.FillRIAsync(dataGrid_RIList);
        }
    
        private void button_Edit_Click(object sender, RoutedEventArgs e)
        {
            RIController.EditRI();
            RIController.FillRIAsync(dataGrid_RIList);
        }
 
        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            RIController.DeleteRI();
            RIController.FillRIAsync(dataGrid_RIList);            
        }
   
        private void dataGrid_RIList_CellClick(object sender, SelectedCellsChangedEventArgs e)
        {
            object dataItem = dataGrid_RIList.SelectedItem;
            if (dataItem != null)
            { 
                string id = ((TextBlock)dataGrid_RIList.SelectedCells[0].Column.GetCellContent(dataItem)).Text;
                RIController.SetCurrenRI(id);
            }
        }
   
        private void button_Search_Click(object sender, RoutedEventArgs e)
        {
            if(RIController.SearchRI(dataGrid_RIList))
                button_Search.Background = Brushes.LightGreen;
        }

        private void button_DropSearch_Click(object sender, RoutedEventArgs e)
        {
            RIController.FillRIAsync(dataGrid_RIList);
            button_Search.Background = Brushes.White;
        }

        private void button_ExportToCSV_Click(object sender, RoutedEventArgs e)
        {
            RIController.ExportToCSV(dataGrid_RIList);
        }   
    }
}
