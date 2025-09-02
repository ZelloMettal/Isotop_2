using System.IO;

namespace Isotop2.Data
{
    //Класс логирования
    internal class Logger
    {
        string _filePath = String.Empty; //Путь к лог-файлу
        string _fileName = "log.txt"; //Имя лог-файлв
        //Конструктор по умолчанию
        public Logger()
        {
            CreateLogFile();
        }
        //Конструктор с записью
        public Logger(string text)
        { 
            CreateLogFile();
            WrittingLogs(text);             
        }
        //Метод создания лог-файлв
        private void CreateLogFile()
        {
            string current_dir = Directory.GetCurrentDirectory(); //Текущий путь
            if (!Directory.Exists($"{current_dir}//Logs")) //Если нет директории Log
            {
                Directory.CreateDirectory($"{current_dir}//Logs"); //Создаём директорию
                File.Create(_filePath); //Создаём лог-файл
            }
            _filePath = $"{current_dir}\\Logs\\{_fileName}"; //Получаем путь к лог-файлу
        }
        //Метод записи лога
        public async void WrittingLogs(string text)
        {
            using (StreamWriter stream = new StreamWriter(_filePath, true))
            { 
                await stream.WriteLineAsync(text);
            }
        }
    }
}
