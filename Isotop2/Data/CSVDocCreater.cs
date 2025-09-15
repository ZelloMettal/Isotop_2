using CsvHelper;
using Isotop2.Data.Entities;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace Isotop2.Data
{
    //Класс импорат данных в CSV-файл
    internal class CSVDocCreater
    {
        string _pathFile = string.Empty; //Путь к созданному файлу

        public CSVDocCreater()
        {
            _pathFile = $"{Directory.GetCurrentDirectory()}\\Temp\\CSV\\TempCSV_{DateTime.Now.ToShortDateString()}_{DateTime.Now.Hour.ToString()}-{DateTime.Now.Minute.ToString()}-{DateTime.Now.Second.ToString()}.csv";
        }
        //Метод записи данных в файл
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
        //Метод запуска записанного файла
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
                new Logger($"С:Не удалось открыть PDF-файл. {ex.Message}; {DateTime.Now.ToString()}");
            }
        }
    }
}
