using Isotop2.Data.Entities;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.Layout.Properties;
using System.Diagnostics;

namespace Isotop2.Data.Models
{
    internal class TechnetiumPrintModel
    {
        private Dictionary<Marker, ActivityByVolume> _adultList; //Список взрослых
        private Dictionary<Marker, ActivityByVolume> _childrenList; //Список детей
        private double _newActivity = 0; //Активность нового генератора
        private double _oldActivity = 0; //Активность старого генератора
        private Dictionary<string, string> _dayWeekRusName = new Dictionary<string, string>()
        {
            { "Monday", "Понидельник"},
            { "Tuesday", "Вторник"},
            { "Wednesday", "Среда"},
            { "Thursday", "Четверг"},
            { "Friday", "Пятница"},
            { "Saturday", "Суббота"},
            { "Sunday", "Воскресенье"}
        };

        public TechnetiumPrintModel(Dictionary<Marker, ActivityByVolume> adult_list, Dictionary<Marker, ActivityByVolume> Children_list, double new_activity, double old_activity)
        {
            _adultList = adult_list;
            _childrenList = Children_list;
            _newActivity = new_activity;
            _oldActivity = old_activity;
        }
        //Получение списка взрослых
        public Dictionary<Marker, ActivityByVolume> GetAdultList()
        {
            return _adultList;
        }
        //Получение списка детей
        public Dictionary<Marker, ActivityByVolume> GetChildrenList()
        {
            return _childrenList;
        }
        //Получение полуение активности нового генератора
        public double GetNewActivity()
        {
            return _newActivity;
        }
        //Получение получение активности старого генератора
        public double GetOldActivity()
        {
            return _oldActivity;
        }
        //Методы методы отправки данных в PDF
        public async Task ExportToPDFAsync(List<string> dataList, string typePatient = "")
        {            
            await Task.Run(() => CreateOneTable(dataList, typePatient));
        }
        public async Task ExportToPDFAsync(List<string> dataAdult, List<string> dataChildren)
        {
            await Task.Run(() => CreateTwoTable(dataAdult, dataChildren));
        }
        //Метод формирование одной таблицы с данными 
        private void CreateOneTable(List<string> dataList, string typePatient = "")
        {
            using (PdfDocCreater pdf = new PdfDocCreater())
            {
                pdf.CreateTable(2);
                pdf.AddRow(new List<string> { $"Новый генератор {_newActivity}МБК", $"Старый генератор {_oldActivity}МБк" });
                pdf.CreateTable(1);
                pdf.AddRow(new List<string> { typePatient });
                pdf.CreateTable(3);
                List<string> headerDataList = new List<string>() { "Маркер", "Объём, Мл", "Активность, МБк" };
                dataList.InsertRange(0, headerDataList);
                pdf.AddRow(dataList);
                pdf.RunDocument();
            }
        }
        //Метод формирование двух таблиц с данными 
        private void CreateTwoTable(List<string> dataAdult, List<string> dataChildren)
        {
            using (PdfDocCreater pdf = new PdfDocCreater())
            {
                pdf.CreateTable(2);
                pdf.AddRow(new List<string> { $"Новый генератор {_newActivity}МБК", $"Старый генератор {_oldActivity}МБк" });
                pdf.CreateTable(1);
                pdf.AddRow(new List<string> { "Взрослые" });
                List<string> headerDataList = new List<string>() { "Маркер", "Объём, Мл", "Активность, МБк" };
                pdf.CreateTable(3);
                dataAdult.InsertRange(0, headerDataList);
                pdf.AddRow(dataAdult);
                pdf.CreateTable(1);
                pdf.AddRow(new List<string> { "Дети" });
                pdf.CreateTable(3);
                dataChildren.InsertRange(0, headerDataList);
                pdf.AddRow(dataChildren);
                pdf.RunDocument();
            }
        }
        //Метод получения дня недели 
        public string GetRusNameDayWeek(string weekDay)
        {
            return _dayWeekRusName[weekDay];
        }
    }
}