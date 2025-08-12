using Isotop2.Data.Models;
using Isotop2.Data.Entities;
using Isotop2.Forms;
using System.Windows.Controls;
using System.Windows;

namespace Isotop2.Data.Controllers
{
    internal class MainFormController
    {
        //Свойства контроллера
        static private MainModel _model = new MainModel();  //Модель данных

        ///////// Часть для Технеция /////////

        //Метод становку текущего распада для Технеция
        static public void SetTechnetiumCurrentDecay(double hour)
        {
            _model.SetTechnetiumCurrentDecay(hour);
        }
        //Метод получения списка коэффицентов детей
        static public void FillTechnetiumCoefficientChildren(ComboBox cb)
        {
            cb.Items.Clear();
            List<CoefficientsForChildren> childrenCoeff = _model.GetСoefficentСhildrenList().OrderByDescending(x => x.Coefficient).ToList();
            foreach (var item in childrenCoeff)
                cb.Items.Add(item.AgeRange);
            cb.SelectedIndex = 0;
        }
        //Метод установки текущего детского коэффицента
        static public void SetChildrenCoefficent(string range)
        {
            _model.SetChildrenCoefficent(range);
        }
        //Метод заполнения ListView генератора
        static public void FillListViewGeneration(ListView lv, decimal activity)
        {
            List<ActivityByVolume> volumeActivity = _model.GetListActivityByVolume(activity);
            lv.ItemsSource = volumeActivity;
        }
        //Метод заполнения ListView по маркера для взрослых
        static public void GetListTechnetiumPatient(ListView lv, decimal newActivity, decimal oldActivity, bool isAdults)
        {
            List<string[]> markerList;
            //Получаем соотвестввующий список данных для пациентов
            if (isAdults)
                markerList = _model.GetListTechnetiumAdultPatient(newActivity, oldActivity);
            else
                markerList = _model.GetListTechnetiumChildPatient(newActivity, oldActivity);
            lv.ItemsSource = markerList;
        }
        //Метод вызова формы печати технеция
        static public void PrintTechnetiumForm(decimal newActivity, decimal oldActivity, string childrenAge)
        {
            Dictionary<Marker, ActivityByVolume> adultPrint = _model.GetAdultPrintList();
            Dictionary<Marker, ActivityByVolume> childrenPrint = _model.GetChildrenPrintList();
            TechnetiumPrintForm TPF = new TechnetiumPrintForm(adultPrint, childrenPrint, newActivity, oldActivity, childrenAge);
            TPF.Owner = App.Current.MainWindow;
            TPF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            TPF.ShowDialog();
        }

        ///////// ******************** /////////

        ///////// Часть для Йода /////////

        //Метод заполнения ListView Йодна
        static public void FillListViewIodine(ListView lv, decimal activity, DateTime startDate)
        {
            List<string[]> dataList = _model.GetListDataIodine(activity, startDate);
            lv.ItemsSource = dataList;
        }
        //Метод печати Йода
        static public void PrintIodine(ListView lv, decimal activity)
        {
            List<string> dataList = AuxiliaryFuntions.ConvertListItemsToList((List<string[]>)lv.ItemsSource);
            int countRow = ((List<string[]>)lv.ItemsSource).Count();
            IodinePrintController.SetPrintData(dataList, countRow, activity);
            IodinePrintController.ExpotrToPDF();
        }

        ///////// ******************** /////////

        ///////// Часть для Радия /////////

        //Проверка на срок годность
        static public bool IsExpiredRadium()
        {
            return _model.IsExpiredRadium();
        }
        static public int GetDefferenceDayRadiun()
        {
            return _model.GetDefferenceDay();
        }
        //Установка нового значения разности дней Радия
        static public void SetDifferenceDayRadium(DateTime createDate, DateTime currentDate)
        {
            _model.SetDifferenceDayRadium(createDate, currentDate);
        }
        //Метод заполнения списка распада Радия
        static public void FillListViewRadium(ListView lv, double activity)
        {
            List<string[]> dataList = _model.GetListDataRadium(activity);
            lv.ItemsSource = dataList;
        }
        //Метод заполнения ListView Радия для пациента
        static public void FillListViewRadiumForPatient(ListView lv, decimal weightPatient, double activity)
        {
            List<string[]> dataList = _model.GetRadiumForPatient(weightPatient, activity);
            lv.ItemsSource = dataList;
        }
        //Метод добавления пациентов в список Радия
        static public void AddRadiumPatientList(ListView lv, decimal weightPatient, double activity)
        {
            List<string[]> dataList = _model.GetRadiumForPatient(weightPatient, activity);
            AddNameRadiumPatient ANRP = new AddNameRadiumPatient();
            ANRP.Owner = App.Current.MainWindow;
            ANRP.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (ANRP.ShowDialog() == true)
            {
                string patientName = ANRP.GetEnteredData();
                ANRP.Close();                
                lv.Items.Add(new string[] { patientName, weightPatient.ToString(), dataList.First()[3], dataList.First()[4] });
            }
        }
        //Метод удаления пациента из списка радия
        static public void DeleteRadiumPatientList(ListView lv)
        {
            if (lv.SelectedIndex >= 0)
            { 
                if (MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    lv.Items.RemoveAt(lv.SelectedIndex);
            }
            else
                MessageBox.Show("Выберите строку", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        //Метод печати Радия
        static public void PrintRadium(ListView patientList, DateTime currentDate, decimal weightPatient, double activity)
        {
            List<string[]> dataList = _model.GetRadiumForPatient(weightPatient, activity);
            RadiumPrintController.SetPrintData(patientList, currentDate, dataList.First()[0], dataList.First()[1], dataList.First()[2]);
            RadiumPrintController.ExportToPDF();
        }

        ///////// ******************** /////////

        //Метод сохранения настроек
        static public void SaveSettings(decimal activityNewGenerator, decimal activityOldGenerator, int timeDecay, DateTime dateZeroDay, decimal activityIodine, decimal activityRadium, DateTime createDate, decimal weihget)
        {
            ProgramSettings settings = new ProgramSettings
            {
                NewGenerationActivity = activityNewGenerator,
                OldGenerationActivity = activityOldGenerator,
                TimeDecay = timeDecay,
                DateOnZeroDay = dateZeroDay,
                IodineActivity = activityIodine,
                RadiumActivity = activityRadium,
                CreateDateRadium = createDate,
                PatientWeighet = weihget
            };

            SaveLoadSettings newSettings = new SaveLoadSettings(settings);
            newSettings.SaveToXML();
        }
        //Метод загрузки настроек
        static public void LoadSettings(TextBox activityNewGenerator, TextBox activityOldGenerator, Slider timeDecay, DatePicker dateZeroDay, TextBox activityIodine, TextBox acativityRadium, DatePicker createDate, TextBox weihget)
        {
            SaveLoadSettings settings = new SaveLoadSettings();
            settings.LoadFromXML();
            ProgramSettings loadSettings = settings.GetSettings();
            activityNewGenerator.Text = loadSettings.NewGenerationActivity.ToString();
            activityOldGenerator.Text = loadSettings.OldGenerationActivity.ToString();
            timeDecay.Value = loadSettings.TimeDecay;
            dateZeroDay.Text = loadSettings.DateOnZeroDay.ToString();
            activityIodine.Text = loadSettings.IodineActivity.ToString();
            acativityRadium.Text = loadSettings.RadiumActivity.ToString();
            createDate.Text = loadSettings.CreateDateRadium.ToString();
            weihget.Text = loadSettings.PatientWeighet.ToString();
        }
        //Метод откртия формы FormData
        static public void OpenFormData()
        {
            FormData FD = new FormData(_model.GetUserRole());
            FD.Owner = App.Current.MainWindow;
            FD.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            FD.ShowDialog();
            _model.RefrashDataTechnetium();
        }
        //Метод открытия формы RAOForm
        static public void OpenRIForm()
        {
            RIForm RF = new RIForm();
            RF.Owner = App.Current.MainWindow;
            RF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            RF.ShowDialog();
        }
        //Метод открытия формы авторизации
        static public bool Authorization()
        {
            AuthorizationForm AF = new AuthorizationForm();
            AF.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AF.ShowDialog();
            if (AF.DialogResult != true)
                return false;
            _model.SetUserRole(AF.GetUserRole());
            _model.SetUserName(AF.GetUserName());
            AF.Close();
            return true;
        }
        //Метод установки текущего пользователя в форме
        static public void SetUserName()
        { 
            App.Current.MainWindow.Title = "Изотоп 2.0. Пользователь: " + _model.GetUserName();
        }
    }
}

