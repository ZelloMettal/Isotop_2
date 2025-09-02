using Isotop2.Data.Entities;

namespace Isotop2.Data.Models
{
    internal class TechnetiumPrintModel
    {
        private Dictionary<Marker, ActivityByVolume> _adultList = null; //Список взрослых
        private Dictionary<Marker, ActivityByVolume> _childrenList = null; //Список детей
        private decimal _newActivity = 0; //Активность нового генератора
        private decimal _oldActivity = 0; //Активность старого генератора
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

        public TechnetiumPrintModel(Dictionary<Marker, ActivityByVolume> adult_list, Dictionary<Marker, ActivityByVolume> Children_list, decimal new_activity, decimal old_activity)
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
        public decimal GetNewActivity()
        {
            return _newActivity;
        }
        //Получение получение активности старого генератора
        public decimal GetOldActivity()
        {
            return _oldActivity;
        }
        //Методы методы отправки данных в PDF
        public async Task ExportToPDFAsync(List<string> data, int countRow, string typePatient = "")
        { 
            await Task.Run(() => CreateOneTable(data, countRow, typePatient));
        }
        public async Task ExportToPDFAsync(List<string> dataAdult, int countRowsAdult, List<string> dataChildren, int countRowsChildren)
        {
            await Task.Run(() => CreateTwoTable(dataAdult, countRowsAdult, dataChildren, countRowsChildren));
        }
        //Метод формирование одной таблицы с данными 
        private void CreateOneTable(List<string> data, int countRow, string typePatient = "")
        {
            WordDocCreater WordDocument = new WordDocCreater(); //Объект работы с Word-докумментом
            List<string> dataCells = new List<string>(); //Создаём список данных  

            //Создаём таблицу
            WordDocument.AddRow(1, 2, true, 15, 0, 15, 15);
            WordDocument.AddRow(1, 1, true, 15, 0, 15, 15);
            WordDocument.AddRow(1, 3, true, 15, 0, 15, 15);
            if (countRow > 0)
                WordDocument.AddRow(countRow, 3, true, 15, 0, 15, 15);

            //Заполняем таблицу
            dataCells.AddRange(new string[] { "Новый генератор - " + _newActivity.ToString() + "МБк", "Старый генератор - " + _oldActivity.ToString() + "МБк" });
            dataCells.AddRange(new string[] { typePatient, "Маркер", "Объём, Мл", "Активность, МБк" });
            if (countRow > 0)
                dataCells.AddRange(data);
            WordDocument.FillTable(dataCells.ToArray());

            //Вывод документа
            WordDocument.PreviewDocument();
        }
        //Метод формирование двух таблиц с данными 
        private void CreateTwoTable(List<string> dataAdult, int countRowsAdult, List<string> dataChildren, int countRowsChildren)
        {
            WordDocCreater WordDocument = new WordDocCreater(); //Объект работы с Word-докумментом
            List<string> dataCells = new List<string>(); //Создаём список данных 

            //Создаём таблицу
            WordDocument.AddRow(1, 2, true, 15, 0, 15, 15);
            WordDocument.AddRow(1, 1, true, 15, 0, 15, 15);
            WordDocument.AddRow(1, 3, true, 15, 0, 15, 15);
            if (countRowsAdult > 0)
                WordDocument.AddRow(countRowsAdult, 3, true, 15, 0, 15, 15);
            WordDocument.AddRow(1, 1, true, 15, 0, 15, 15);
            WordDocument.AddRow(1, 3, true, 15, 0, 15, 15);
            if (countRowsChildren > 0)
                WordDocument.AddRow(countRowsChildren, 3, true, 15, 0, 15, 15);

            //Заполняем таблицу
            //Шапка с активностями
            dataCells.AddRange(new string[] { "Новый генератор - " + _newActivity.ToString() + "МБк", "Старый генератор - " + _oldActivity.ToString() + "МБк" });
            //Шапка для взрослых
            dataCells.AddRange(new string[] { "Взрослые", "Маркер", "Объём, Мл", "Активность, МБк" });
            //Данные взрослых
            if (countRowsAdult > 0)
                dataCells.AddRange(dataAdult);
            //Шапка для детей
            dataCells.AddRange(new string[] { "Дети", "Маркер", "Объём, Мл", "Активность, МБк" });
            //Данные детей
            if (countRowsChildren > 0)
                dataCells.AddRange(dataChildren);

            WordDocument.FillTable(dataCells.ToArray());

            //Вывод документа
            WordDocument.PreviewDocument();
        }
        //Метод получения дня недели 
        public string GetRusNameDayWeek(string weekDay)
        {
            return _dayWeekRusName[weekDay];
        }
    }
}
