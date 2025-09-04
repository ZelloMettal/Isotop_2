//#pragma checksum "..\..\..\App.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9DF010FCDFFCCFBAC91C795AD0CA71C702212291"
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
            _mainForm.Show();
            base.OnStartup(e);
        }
    }
}
