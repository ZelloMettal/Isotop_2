namespace Isotop2.Data.Models
{
    internal class IodinePrintModel
    {
        private List<string> _dataListView = new List<string>();
        private double _currentActivity;

        public IodinePrintModel(List<string> data, double currentActivity)
        {
            _currentActivity = currentActivity;
            _dataListView = data;
        }
      
        private void CreateTable()
        {
            using (PdfDocCreater pdf = new PdfDocCreater())
            {
                pdf.CreateTable(1);
                pdf.AddRow(new List<string> { $"Активность {_currentActivity}МБК"});
                pdf.CreateTable(5);
                List<string> headerDataList = new List<string>() { "Дата", "День", "Процент распада", "Активность, МБк", "Объём, Мл"};
                _dataListView.InsertRange(0, headerDataList);
                pdf.AddRow(_dataListView);
                pdf.RunDocument();
            }
        }
    
        public async Task ExpotrToPDFAsync()
        {
            await Task.Run(()=> CreateTable());
        }        
    }
}
