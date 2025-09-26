using Isotop2.Data;
using System.Windows;

namespace Isotop2
{
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
            try
            {
                MainWindow.Show();
                base.OnStartup(e);
            }
            catch(Exception ex)
            {
                new Logger($"App:Не удалось запустить приложение. {ex.Message}" + DateTime.Now.ToString());
                App.Current.Shutdown(); 
            }
        }
    }
}