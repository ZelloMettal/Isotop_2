using Isotop2.Data;
using System.Windows;

namespace Isotop2
{
    //Класс запуская приложения
    public partial class App : Application
    {
        readonly MainForm _mainForm = new MainForm();
        public App()
        {
            MainWindow = _mainForm;
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            //Пытаемся отобрать главное окно
            try
            {
                MainWindow.Show();
                base.OnStartup(e);
            }
            catch(Exception ex)
            {
                //Завершаем приложение при неудачи
                new Logger($"App:Не удалось отобразить окно. {ex.Message}" + DateTime.Now.ToString());
                App.Current.Shutdown(); 
            }
        }
    }
}