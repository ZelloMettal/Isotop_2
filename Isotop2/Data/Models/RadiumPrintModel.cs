namespace Isotop2.Data.Models
{
    internal class RadiumPrintModel
    {
        private List<string> _dataListView = new List<string>(); //Список с данными для заполнения ячеек
        private int _rowCount = 0; //Колиество строк

        public RadiumPrintModel(List<string> data, int countRows, DateTime currentDate, string currentDay, string currentCoefficent, string currentActivity)
        {
            _rowCount = countRows;
            _dataListView.AddRange(new string[] { $"Дата: {currentDate.ToShortDateString()}", $"День: {currentDay}", $"Коэффицент: {currentCoefficent}", $"Активность: {currentActivity} МБк" });
            _dataListView.AddRange(new string[] { "Имя пациента", "Вес пациента, Кг", "Объём, Мл", "Активность, КБк" });
            _dataListView.AddRange(data);
        }
        //Метод формирования таблицы и передачи в PDF
        private void CreateTable()
        {
            WordDocCreater WordDocument = new WordDocCreater(); //Объект работы с Word-докумментом

            //Создаём таблицу
            WordDocument.AddRow(1, 4, true, 15, 0, 15, 15);
            WordDocument.AddRow(1, 4, true, 15, 0, 15, 15);
            if (_rowCount > 0)
                WordDocument.AddRow(_rowCount, 4, true, 15, 0, 15, 15);

            //Заполняем таблицу
            WordDocument.FillTable(_dataListView.ToArray());

            //Вывод документа
            WordDocument.PreviewDocument();
        }
        //Метод формирования таблици на печать
        public async Task ExportToPDFAsync()
        {
            await Task.Run(() => CreateTable());
        }
    }
}
