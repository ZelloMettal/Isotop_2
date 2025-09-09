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
            try 
            {
                _excelApplication = new Excel.Application();
                _excelBook = _excelApplication.Workbooks.Add();
                _excelSheet = (Excel.Worksheet)_excelBook.ActiveSheet;
                _excelSheet.Columns.AutoFit();
            }
            catch (Exception ex) 
            {
                new Logger($"E:Не удалось запустить Excel. {ex.Message}; {DateTime.Now.ToString()}");
            }
        }
        //Метод заполнения докуммента данными
        public void CreateDocument(List<string[]> dataList, int columnWidth = 20)
        {
            //Заполняем данными таблицу Excel
            for (int i = 0; i < dataList.Count; i++)            
                _excelSheet.Range["A1"].Offset[i].Resize[1, dataList[0].Length].Value = dataList[i];

            //Устанавливаем ширину столбца
            _excelSheet.Columns.EntireColumn.ColumnWidth = columnWidth;
        }

        // Метод отображаем документ            
        public void VisibleDocument()
        {
            //Отображаем документ
            try
            {
                _excelApplication.Visible = true;
                _excelBook.Activate();
            }
            catch (Exception ex)
            {
                new Logger($"E:Не удалось запустить Excel. {ex.Message}; {DateTime.Now.ToString()}");
            }
            finally
            { 
                //Очищаем память
                _excelApplication = null;
                _excelBook = null;
                _excelSheet = null;
                _range = null;
                GC.Collect();
            }
        }
    }
}
