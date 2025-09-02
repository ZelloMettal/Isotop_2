using Isotop2.Forms;
using System.ComponentModel;
using System.Windows;

namespace Isotop2
{
    //Класс запуская приложения
    class App : Application
    {
        readonly MainForm _mainForm;
        public App(MainForm mainForm)
        {
            _mainForm = mainForm;
            MainWindow = _mainForm;
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _mainForm.Show();
            base.OnStartup(e);
        }
    }
}
