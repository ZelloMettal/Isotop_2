using System.Windows.Controls;
using Isotop2.Data.Models;

namespace Isotop2.Data.Controllers
{
    internal class RadiumPrintController
    {
        static private RadiumPrintModel _model = null; //Обект формирования данных для печати
        //Метод задания источника данных
        static public void SetPrintData(ListView lv, DateTime currentDate, string currentDay, string currentCoefficent, string currentActivity)
        {
            //Получаем список данных для печати
            List<string> data = AuxiliaryFuntions.ConvertListItemsToList(lv.Items.Cast<string[]>().ToList());
            //Получаем количество строк
            int countRows = lv.Items.Count;
            _model = new RadiumPrintModel(data, countRows, currentDate, currentDay, currentCoefficent, currentActivity);
        }
        //Метод создание таблицы для печати
        static public void ExportToPDF()
        {
            _model.ExportToPDFAsync();
        }
    }
}
