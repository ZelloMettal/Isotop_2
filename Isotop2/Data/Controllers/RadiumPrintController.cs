using System.Windows.Controls;
using Isotop2.Data.Models;

namespace Isotop2.Data.Controllers
{
    internal class RadiumPrintController
    {
        static private RadiumPrintModel _model = null; //Обект формирования данных для печати
        //Метод задания источника данных
        static public void SetPrintData(List<string> dataList, DateTime currentDate, string differenceDays, string currentCoefficent, string currentActivity)
        {
            _model = new RadiumPrintModel(dataList, currentDate, differenceDays, currentCoefficent, currentActivity);
        }
        //Метод создание таблицы для печати
        static public void ExportToPDF()
        {
            _model.ExportToPDFAsync();
        }
    }
}
