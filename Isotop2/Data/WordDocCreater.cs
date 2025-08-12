using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;

namespace Isotop2.Data
{
    internal class WordDocCreater
    {
        Word.Application _application = null; //Объект Word-приложения
        Word.Document _document = null; //Объект документа
        TableConstructor _table = new TableConstructor(); //Объект таблицы

        public WordDocCreater()
        {
            //Инициальзация Word-документа
            _application = new Word.Application();
            _document = _application.Documents.Add();
        }
        //Метод создание строк таблицы
        public void AddRow(int rows, int columns, bool centerText, double marginTop = 56.7, double marginBottom = 56.7, double marginLeft = 85.05, double marginRight = 42.55)
        {
            Word.Paragraph paragraph = _document.Paragraphs.Add(); //Создание параграфа
            Word.Range range = paragraph.Range; //Создание текстового диапозона
            //Настройка отступов
            range.PageSetup.TopMargin = (float)marginTop;
            range.PageSetup.LeftMargin = (float)marginLeft;
            range.PageSetup.RightMargin = (float)marginRight;
            range.PageSetup.BottomMargin = (float)marginBottom;
            Word.Table table = _document.Tables.Add(range, rows, columns); //Создание таблицы
            table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle; //Задание толщины рамки
            //Выравнивание по середине
            if (centerText)
            {
                table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                table.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
            _table.AddRow(table, new TableRows(rows, columns)); //Добавление таблици в структуру таблицы
        }
        //Метод отображения Word-документа
        public void VisibleDocument()
        {
            _application.Visible = true;
            _document.Activate();
        }
        //Метод заполнения созданной таблицы данными
        public void FillTable(string[] dataCells)
        {
            int indexText = 0;
            int countRow = 1;
            foreach (var row in _table.GetRowList())
            {
                for (int i = 1; i <= row.Value.Rows; i++)
                {
                    for (int j = 1; j <= row.Value.Columns; j++)
                    {
                        Word.Range cellRange;
                        cellRange = row.Key.Cell(countRow, j).Range;
                        cellRange.Text = dataCells[indexText];
                        indexText++;
                    }
                    countRow++;
                }
            }
        }
        //Метод конвертации Word-документа в PDF и очищение ресурсов
        public void PreviewDocument()
        {
            string tempDocument = $"Temp document {DateTime.Now.ToString().Replace(":", "-")}.pdf";
            _application.ActiveDocument.ExportAsFixedFormat
                (
                    tempDocument,
                    WdExportFormat.wdExportFormatPDF,
                    true,
                    WdExportOptimizeFor.wdExportOptimizeForOnScreen,
                    WdExportRange.wdExportAllDocument,
                    1,
                    1,
                    WdExportItem.wdExportDocumentContent,
                    true,
                    true,
                    WdExportCreateBookmarks.wdExportCreateHeadingBookmarks,
                    true,
                    true,
                    false
                );
            object save = Word.WdSaveOptions.wdDoNotSaveChanges;
            object format = Word.WdOriginalFormat.wdOriginalDocumentFormat;
            object route = false;
            _document.Close(ref save, ref format, ref route);
            _application.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            _application.Quit();
            _document = null;
            _application = null;
            GC.Collect();
        }
    }
}
