using Isotop2.Data.Entities;
using Isotop2.Data.Models;
using System.Windows.Controls;

namespace Isotop2.Data.Controllers
{
    internal class TechnetiumPrintController
    {
        static private TechnetiumPrintModel _model = null;

        //Метод установки данных для печати
        static public void SetPrintData(Dictionary<Marker, ActivityByVolume> adultList, Dictionary<Marker, ActivityByVolume> childList, double newActivity, double oldActivity)
        {
            _model = new TechnetiumPrintModel(adultList, childList, newActivity, oldActivity);
        }
        //Получение списка взрослых
        static public Dictionary<Marker, ActivityByVolume> GetAdultList()
        {
            return _model.GetAdultList();
        }
        //Получение списка детей
        static public Dictionary<Marker, ActivityByVolume> GetChildrenList()
        {
            return _model.GetChildrenList();
        }
        //Получение получение активности нового генератора
        static public double GetNewActivity()
        {
            return _model.GetNewActivity();
        }
        //Получение активности старого генератора
        static public double GetOldActivity()
        {
            return _model.GetOldActivity();
        }
        //Метод заполнения ListView
        static public void FillListView(ListView lv, Dictionary<Marker, ActivityByVolume> list)
        {
            List<CheckedMarkerForPrint> dataPrint = AuxiliaryFuntions.ConvertDictionaryToListChecked(list); 
            lv.ItemsSource = dataPrint;
        }
        //Метод получения дня недели
        static public string GetWeekDay(string weekDay)
        {
            return _model.GetRusNameDayWeek(weekDay);
        }
        //Метод формирования документа на печать
        static public void PrintDocument(bool isPrintAdult, ListView lv_Adult, bool isPrintChildren, ListView lv_Children)
        {
            if (isPrintAdult && !isPrintChildren)
            {
                //Получаем саписок данных для печати
                List<string> data = AuxiliaryFuntions.ConvertListItemsToList((List<CheckedMarkerForPrint>)lv_Adult.ItemsSource);
                _model.ExportToPDFAsync(data, "Взрослые");
            }
            else if (!isPrintAdult && isPrintChildren)
            {
                //Получаем саписок данных для печати
                List<string> data = AuxiliaryFuntions.ConvertListItemsToList((List<CheckedMarkerForPrint>)lv_Children.ItemsSource);
                _model.ExportToPDFAsync(data, "Дети");
            }
            else if (isPrintAdult && isPrintChildren)
            {
                //Получаем саписок данных для печати
                List<string> dataAdult = AuxiliaryFuntions.ConvertListItemsToList((List<CheckedMarkerForPrint>)lv_Adult.ItemsSource);
                List<string> dataChildren = AuxiliaryFuntions.ConvertListItemsToList((List<CheckedMarkerForPrint>)lv_Children.ItemsSource);
                _model.ExportToPDFAsync(dataAdult, dataChildren);
            }
        }
    }
}
