using Excel = Microsoft.Office.Interop.Excel;

namespace Isotop2.Data
{
    internal class ExcelDocCreater
    {
        Excel.Application _excelApplication = null;
        Excel.Workbook _excelBook = null;
        Excel.Worksheet _excelSheet = null;
        Excel.Range _range = null;

        public ExcelDocCreater()
        { 
            //Инициализация Excel-документа
            _excelApplication = new Excel.Application();
            _excelBook = _excelApplication.Workbooks.Add();
            _excelSheet = (Excel.Worksheet)_excelBook.ActiveSheet;
            _excelSheet.Columns.AutoFit();
        }
        //Метод заполнения докуммента данными
        public bool CreateDocument(List<string[]> dataList, int columnWidth = 20)
        {
            //Проверяем существование данных
            if(dataList == null)
                return false;

            //Заполняем данными таблицу Excel
            for (int i = 0; i < dataList.Count; i++)            
                _excelSheet.Range["A1"].Offset[i].Resize[1, dataList[0].Length].Value = dataList[i];            

            _excelSheet.Columns.EntireColumn.ColumnWidth = columnWidth; //Устанавливаем ширину столбца
            return true;
        }

        // Метод отображаем документ            
        public void VisibleDocument()
        {
            _excelApplication.Visible = true;
            _excelBook.Activate();
        }
    }
}
