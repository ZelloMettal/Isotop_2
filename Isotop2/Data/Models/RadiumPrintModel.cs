namespace Isotop2.Data.Models
{
    internal class RadiumPrintModel
    {
        private List<string> _dataListView = new List<string>(); //Список с данными для заполнения ячеек
        private DateTime _currentDate;
        private string _currentDay;
        private string _currentCoefficent;
        private string _currentActivity;

        public RadiumPrintModel(List<string> data, DateTime currentDate, string currentDay, string currentCoefficent, string currentActivity)
        {
            _currentDate = currentDate;
            _currentDay = currentDay;
            _currentCoefficent = currentCoefficent;
            _currentActivity = currentActivity;
            _dataListView = data;
        }
        //Метод формирования таблицы и передачи в PDF
        private void CreateTable()
        {
            using (PdfDocCreater pdf = new PdfDocCreater())
            {
                pdf.CreateTable(4);
                pdf.AddRow(new List<string> { $"Дата: {_currentDate.ToShortDateString()}", $"День: {_currentDay}", $"Коэффицент: {_currentCoefficent}", $"Активность: {_currentActivity} МБк" });
                pdf.CreateTable(1);
                pdf.AddRow(new List<string> { " " });
                pdf.CreateTable(4);
                List<string> headerDataList = new List<string>() { "Имя пациента", "Вес пациента, Кг", "Объём, Мл", "Активность, МБк"};
                _dataListView.InsertRange(0, headerDataList);
                pdf.AddRow(_dataListView);
                pdf.RunDocument();
            }
            //WordDocCreater WordDocument = new WordDocCreater(); //Объект работы с Word-докумментом
            //
            ////Создаём таблицу
            //WordDocument.AddRow(1, 4, true, 15, 0, 15, 15);
            //WordDocument.AddRow(1, 4, true, 15, 0, 15, 15);
            //if (_rowCount > 0)
            //    WordDocument.AddRow(_rowCount, 4, true, 15, 0, 15, 15);
            //
            ////Заполняем таблицу
            //try
            //{ 
            //    WordDocument.FillTable(_dataListView.ToArray());
            //}
            //catch (Exception ex)
            //{
            //    new Logger($"WR:Не удалось добавить данные в таблицу. {ex.Message}; {DateTime.Now.ToString()}");
            //}
            //
            ////Вывод документа
            //WordDocument.PreviewDocument();
        }
        //Метод формирования таблици на печать
        public async Task ExportToPDFAsync()
        {
            await Task.Run(() => CreateTable());
        }
    }
}
