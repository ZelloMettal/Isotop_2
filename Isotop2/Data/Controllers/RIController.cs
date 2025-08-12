using System.Windows.Controls;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Isotop2.Services;
using Isotop2.Forms;
using Isotop2.Data.Models;
using Isotop2.Data.Entities;

namespace Isotop2.Data.Controllers
{
    internal class RIController
    {
        static private RIModel _model = new RIModel(ServiceProviderHolder.ServiceProvider.GetRequiredService<DataStorage<RI>>()); //Объект РАО

        //Метод установки заголовков DataGridView
        static private void SetColumnNameForDataGrid(DataGrid dgv)
        {
            string[] headerList = _model.GetHeaderList();
            AuxiliaryFuntions.SetHeaderDataGrid(dgv, headerList);
            dgv.Columns[0].MaxWidth = 0;
        }
        //Метод заполенения DataGridView списком РИ
        static public async Task FillRIAsync(DataGrid dgv)
        {
            dgv.ItemsSource = await Task.Run(()=>_model.GetAllRI());
            SetColumnNameForDataGrid(dgv);
        }
        //Метод вызова формы для добавления РИ
        static public void AddRI()
        {
            RIAddEditForm RIAE = new RIAddEditForm();
            RIAE.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "RIFormName").First();
            RIAE.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            RIAE.ShowDialog();
            _model.SetCurrenRI(-1);
        }
        //Метод вызова формы для редактирования РИ
        static public void EditRI()
        {
            if (_model.GetCurrentRI() < 0)
            {
                MessageBox.Show("Выберите строку", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            RIAddEditForm RIAE = new RIAddEditForm(_model.GetCurrentRI());
            RIAE.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            RIAE.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "RIFormName").First();
            RIAE.ShowDialog();
            _model.SetCurrenRI(-1);
        }
        //Метод вызова формы поиска
        static public bool SearchRI(DataGrid dgv)
        {
            SearchForm SF = new SearchForm();
            SF.Owner = App.Current.Windows.Cast<Window>().Where(w => w.Name == "RIFormName").First();
            SF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            SF.ShowDialog();
            if (SF.DialogResult == true)
            {
                (string searchItem1, string searchItem2, string searchItem3) _dataSearch = SF.GetEnteredData();
                if (_dataSearch.searchItem1 == "")                 
                    return false;                
                dgv.ItemsSource = _model.GetFilterRI(_dataSearch.searchItem1, _dataSearch.searchItem2, _dataSearch.searchItem3);
                SetColumnNameForDataGrid(dgv);
            }
            else            
                return false;           
            SF.Close();           
            return true;
        }
        //Метод удаления РИ
        static public void DeleteRI()
        {
            //Если ни одной строки не выбрано
            if (_model.GetCurrentRI() < 0)
            {
                MessageBox.Show("Выберите строку", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _model.DeleteRI(_model.GetCurrentRI());
            _model.SetCurrenRI(-1);
        }
        //Метод установки выбранного РИ в DataGrid
        static public void SetCurrenRI(int id)
        {
            _model.SetCurrenRI(id);
        }
        //Метод экспорта данных из DataGrid в Excel
        static public void ExportExcel(DataGrid dataGrid)
        {
            List<string[]> dataList = new List<string[]>();
            dataList.Add(_model.GetHeaderList().Skip(1).ToArray()); //Список заголовков         
            dataList.AddRange(AuxiliaryFuntions.RIViewToStringList((List<RIView>)dataGrid.ItemsSource, true));  //Список данных
            _model.ExportToExcelAsync(dataList);
        }
    }
}
