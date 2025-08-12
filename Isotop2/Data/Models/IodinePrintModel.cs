namespace Isotop2.Data.Models
{
    internal class IodinePrintModel
    {
        private List<string> _dataListView = new List<string>(); //Список с данными для заполнения ячеек
        private int _rowCount = 0; //Колиество строк

        public IodinePrintModel(List<string> data, int countRow, decimal currentActivity)
        {
            _rowCount = countRow;
            _dataListView.AddRange(new string[] { $"Активность - {currentActivity} МБк", "Дата", "День", "Процент распада", "Активность, МБк", "Объём, Мл" });
            _dataListView.AddRange(data);
        }
        //Метод формирования таблицы данных и передачи в PDF
        private void CreateTable()
        {
            WordDocCreater WordDocument = new WordDocCreater(); //Объект работы с Word-докумментом

            //Создаём таблицу
            WordDocument.AddRow(1, 1, true, 15, 0, 15, 15);
            WordDocument.AddRow(1, 5, true, 15, 0, 15, 15);
            WordDocument.AddRow(_rowCount, 5, true, 15, 0, 15, 15);

            //Заполняем таблицу
            WordDocument.FillTable(_dataListView.ToArray());

            //Вывод документа
            WordDocument.PreviewDocument();
        }
        //Метод формирования таблици на печать
        public async Task ExpotrToPDFAsync()
        {
            await Task.Run(()=> CreateTable());
        }        
    }
}
