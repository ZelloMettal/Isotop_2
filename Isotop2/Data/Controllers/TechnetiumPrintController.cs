using Isotop2.Data.Entities;
using Isotop2.Data.Models;
using System.Windows.Controls;

namespace Isotop2.Data.Controllers
{
    internal class TechnetiumPrintController
    {
        static private TechnetiumPrintModel _model;

        static public void SetPrintData(Dictionary<Marker, ActivityByVolume> adultList, Dictionary<Marker, ActivityByVolume> childList, double newActivity, double oldActivity)
        {
            _model = new TechnetiumPrintModel(adultList, childList, newActivity, oldActivity);
        }
     
        static public Dictionary<Marker, ActivityByVolume> GetAdultList()
        {
            return _model.GetAdultList();
        }
    
        static public Dictionary<Marker, ActivityByVolume> GetChildrenList()
        {
            return _model.GetChildrenList();
        }

        static public void FillListView(ListView lv, Dictionary<Marker, ActivityByVolume> list)
        {
            List<CheckedMarkerForPrint> dataPrint = AuxiliaryFuntions.ConvertDictionaryToListChecked(list); 
            lv.ItemsSource = dataPrint;
        }
   
        static public string GetWeekDay(string weekDay)
        {
            return _model.GetRusNameDayWeek(weekDay);
        }
   
        static public void PrintDocument(bool isPrintAdult, ListView lv_Adult, bool isPrintChildren, ListView lv_Children)
        {
            if (isPrintAdult && !isPrintChildren)
            {
                List<string> data = AuxiliaryFuntions.ConvertListItemsToList((List<CheckedMarkerForPrint>)lv_Adult.ItemsSource);
                _model.ExportToPDFAsync(data, "Взрослые");
            }
            else if (!isPrintAdult && isPrintChildren)
            {
                List<string> data = AuxiliaryFuntions.ConvertListItemsToList((List<CheckedMarkerForPrint>)lv_Children.ItemsSource);
                _model.ExportToPDFAsync(data, "Дети");
            }
            else if (isPrintAdult && isPrintChildren)
            {
                List<string> dataAdult = AuxiliaryFuntions.ConvertListItemsToList((List<CheckedMarkerForPrint>)lv_Adult.ItemsSource);
                List<string> dataChildren = AuxiliaryFuntions.ConvertListItemsToList((List<CheckedMarkerForPrint>)lv_Children.ItemsSource);
                _model.ExportToPDFAsync(dataAdult, dataChildren);
            }
        }
    }
}
