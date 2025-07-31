using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Isotop2.Data.Entities;

namespace Isotop2.Data.Models
{
    internal class SaveLoadSettings
    {
        public SaveLoadSettings()
        {
            this.ProgramSettings = new ProgramSettings();
        }
        ProgramSettings ProgramSettings;
        public SaveLoadSettings(ProgramSettings settings)
        {
            this.ProgramSettings = settings;
        }        
        //Сохранение
        public void SaveToXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProgramSettings));
            TextWriter writer = new StreamWriter(ProgramSettings.FileName);
            serializer.Serialize(writer, ProgramSettings);
            writer.Close();
        }
        //Загрузка
        public void LoadFromXML()
        {
            if (File.Exists(ProgramSettings.FileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ProgramSettings));
                TextReader reader = new StreamReader(ProgramSettings.FileName);
                ProgramSettings = serializer.Deserialize(reader) as ProgramSettings;
                reader.Close();
            }
            else
            {
                MessageBox.Show("Файл с настройками не найден! Установлены настройки по умолчанию!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Получение сущности настроек
        public ProgramSettings GetSettings()
        {
            return this.ProgramSettings;
        }
    }
}
