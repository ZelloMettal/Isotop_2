using Isotop2.Data.Models;

namespace Isotop2.Data.Controllers
{
    internal class IodinePrintController
    {
        static private IodinePrintModel _model = null; //Обект формирования данных для печати
        //Метод задания источника данных
        static public void SetPrintData(List<string> dataList, double activity)
        {
            _model = new IodinePrintModel(dataList, activity);
        }
        //Метод создание таблицы для печати
        static public void ExpotrToPDF()
        {
            _model.ExpotrToPDFAsync();
        }
    }
}
