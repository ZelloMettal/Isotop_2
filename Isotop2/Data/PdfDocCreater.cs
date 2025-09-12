using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using System.Diagnostics;
using System.IO;

namespace Isotop2.Data
{
    internal class PdfDocCreater :IDisposable
    {
        PdfWriter _pdfWriter;
        PdfDocument _pdf;
        Document _pdfDocument;
        PdfFont _pdfFont;
        Table? _table;
        int _defaultColumns = 1;
        string _pathFile = String.Empty;
        string _pathFont = "\\Fonts\\arial.ttf";

        public PdfDocCreater()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            _pathFile = $"{currentDirectory}\\Temp\\Temp_{DateTime.Now.ToShortDateString()}_{DateTime.Now.Hour.ToString()}-{DateTime.Now.Minute.ToString()}-{DateTime.Now.Second.ToString()}.pdf";
            _pdfWriter = new PdfWriter(_pathFile);
            _pdf = new PdfDocument(_pdfWriter);
            _pdfDocument = new Document(_pdf);
            _pdfFont = PdfFontFactory.CreateFont($"{currentDirectory}{_pathFont}", "Identity-H");
            _pdfDocument.SetFont(_pdfFont);
        }
        public void CreateTable(int columns)
        {
            _table = null;
            _table = new Table(columns).UseAllAvailableWidth();
        }
        public void AddRow(List<string> dataList, bool bolt = false)
        {
            if (_table == null) 
                CreateTable(_defaultColumns);
            foreach (string data in dataList)
            {
                _table.AddCell(data).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            }
            _pdfDocument.Add(_table);
        }
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
        public void Dispose()
        {
            _pdfDocument.Close();
            _pdf.Close();
            _pdfWriter.Close();
        }
    }
}
