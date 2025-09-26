using Isotop2.Data.Models;

namespace Isotop2.Data.Controllers
{
    internal class IodinePrintController
    {
        static private IodinePrintModel _model;

        static public void SetPrintData(List<string> dataList, double activity)
        {
            _model = new IodinePrintModel(dataList, activity);
        }

        static public void ExpotrToPDF()
        {
            _model.ExpotrToPDFAsync();
        }
    }
}
