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
        //Событие загрузки формы
        private void RIForm_Load(object sender, RoutedEventArgs e)
        {
            RIController.FillRIAsync(dataGrid_RIList);
        }
        //Событие добавления РИ
        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            RIController.AddRI();
            RIController.FillRIAsync(dataGrid_RIList);
        }
        //Событие редактирования РИ
        private void button_Edit_Click(object sender, RoutedEventArgs e)
        {
            RIController.EditRI();
            RIController.FillRIAsync(dataGrid_RIList);
        }
        //Событие удаления РИ
        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                RIController.DeleteRI();
                RIController.FillRIAsync(dataGrid_RIList);
            }
        }
        //Событие выбранной строки в DataGrid
        private void dataGrid_RIList_CellClick(object sender, SelectedCellsChangedEventArgs e)
        {
            int id = -1;
            var dataItem = dataGrid_RIList.SelectedItem;
            if (dataItem != null)
            { 
                id = Convert.ToInt32(((TextBlock)dataGrid_RIList.SelectedCells[0].Column.GetCellContent(dataItem)).Text);
                RIController.SetCurrenRI(id);
            }
        }
        //Событие нажатия кнопки поиска
        private void button_Search_Click(object sender, RoutedEventArgs e)
        {
            if(RIController.SearchRI(dataGrid_RIList))
                button_Search.Background = Brushes.LightGreen;
        }
        //Событие сброса фильтра
        private void button_DropSearch_Click(object sender, RoutedEventArgs e)
        {
            RIController.FillRIAsync(dataGrid_RIList);
            button_Search.Background = Brushes.White;
        }
        //Событие экспорта в Excel
        private void button_ExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            RIController.ExportExcel(dataGrid_RIList);
        }   
    }
}
