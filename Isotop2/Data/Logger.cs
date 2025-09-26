using System.IO;

namespace Isotop2.Data
{

    internal class Logger
    {
        string _filePath = String.Empty;
        string _fileName = "log.txt";
  
        public Logger()
        {
            CreateLogFile();
        }
    
        public Logger(string text)
        { 
            CreateLogFile();
            WrittingLogs(text);             
        }
  
        private void CreateLogFile()
        {
            _filePath = $"{Directory.GetCurrentDirectory()}\\Logs\\{_fileName}";
        }
  
        public async void WrittingLogs(string text)
        {
            using (StreamWriter stream = new StreamWriter(_filePath, true))
            { 
                await stream.WriteLineAsync(text);
            }
        }
    }
}
