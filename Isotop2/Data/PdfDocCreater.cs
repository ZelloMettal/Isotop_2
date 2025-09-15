using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using System.Diagnostics;
using System.IO;

namespace Isotop2.Data
{
    //Класс записи данных в PDF
    internal class PdfDocCreater :IDisposable
    {
        PdfWriter _pdfWriter; //Объект записи в PDF
        PdfDocument _pdf; //Объект для работы с PDF документом
        Document _pdfDocument; //Объект корневого элемента PDF документа
        PdfFont _pdfFont; //Объект шрифтов
        Table? _table; //Объект таблиц
        int _defaultColumns = 1; //Количество столбцов в таблице по умолчанию
        string _pathFile = String.Empty; //Путь к PDF файлу
        string _pathFont = "\\Fonts\\arial.ttf"; //Путь к шрифтам

        public PdfDocCreater()
        {
            //Получаем пути к рабочему файлу PDF
            string currentDirectory = Directory.GetCurrentDirectory();
            _pathFile = $"{currentDirectory}\\Temp\\PDF\\TempPDF_{DateTime.Now.ToShortDateString()}_{DateTime.Now.Hour.ToString()}-{DateTime.Now.Minute.ToString()}-{DateTime.Now.Second.ToString()}.pdf";
            //Инициальзация объектов
            _pdfWriter = new PdfWriter(_pathFile);
            _pdf = new PdfDocument(_pdfWriter);
            _pdfDocument = new Document(_pdf);
            //Настраеваем и подключаем шрифты(для поддержки кириллицы)
            _pdfFont = PdfFontFactory.CreateFont($"{currentDirectory}{_pathFont}", "Identity-H");
            _pdfDocument.SetFont(_pdfFont);
        }
        //Метод создания новой таблицы
        public void CreateTable(int columns)
        {
            _table = null;
            _table = new Table(columns).UseAllAvailableWidth();
        }
        //Метод добавления строк к таблице
        public void AddRow(List<string> dataList)
        {
            if (_table == null) 
                CreateTable(_defaultColumns);
            foreach (string data in dataList)
            {
                _table.AddCell(data).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            }
            _pdfDocument.Add(_table);
        }
        //Запуск PDF файла
        public void RunDocument()
        {
            try
            { 
                using (Process openPdf = new Process())
                {
                    openPdf.StartInfo.UseShellExecute = true;
                    openPdf.StartInfo.FileName = _pathFile;
                    openPdf.Start();
                }
            }
            catch (Exception ex)
            {
                new Logger($"P:Не удалось открыть PDF-файл. {ex.Message}; {DateTime.Now.ToString()}");
            }
        }
        //Очистка ресурсов
        public void Dispose()
        {
            _pdfDocument.Close();
            _pdf.Close();
            _pdfWriter.Close();
        }
    }
}
