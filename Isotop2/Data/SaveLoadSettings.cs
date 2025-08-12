using Isotop2.Data.Entities;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace Isotop2.Data
{
    internal class SaveLoadSettings
    {
        //Сущность настроек
        ProgramSettings ProgramSettings;
        public SaveLoadSettings(ProgramSettings settings)
        {
            this.ProgramSettings = settings;
        }
        public SaveLoadSettings()
        {
            this.ProgramSettings = new ProgramSettings();
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
                MessageBox.Show("Файл с настройками не найден. Установлены настройки по умолчанию.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Получение сущности настроек
        public ProgramSettings GetSettings()
        {
            return this.ProgramSettings;
        }
    }
}
