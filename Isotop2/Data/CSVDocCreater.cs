using CsvHelper;
using Isotop2.Data.Entities;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace Isotop2.Data
{
    internal class CSVDocCreater
    {
        string _pathFile = string.Empty;
        string _currentDirectory = $"{Directory.GetCurrentDirectory()}\\Temp\\CSV";

        public CSVDocCreater()
        {
            _pathFile = $"{_currentDirectory}\\TempCSV_{DateTime.Now.ToShortDateString()}_{DateTime.Now.Hour.ToString()}-{DateTime.Now.Minute.ToString()}-{DateTime.Now.Second.ToString()}.csv";
        }

        private void Open(string path)
        {
            using (Process openPdf = new Process())
            {
                openPdf.StartInfo.UseShellExecute = true;
                openPdf.StartInfo.FileName = path;
                openPdf.Start();
            }
        }

        public void CreateFile(List<RIView> dataList)
        {
            using (StreamWriter streamWriter = new StreamWriter(_pathFile, false, Encoding.UTF8)) 
            { 
                using (CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.CurrentCulture))
                { 
                    csvWriter.WriteRecords(dataList);
                }
            }
        }

        public void RunDocument()
        {
            try
            {
                Open(_pathFile);
            }
            catch (Exception ex)
            {
                new Logger($"С:Не удалось запустить приложение для открытия CSV-файл. {ex.Message}; {DateTime.Now.ToString()}");
                Open(_currentDirectory);
            }
        }
    }
}
