using Isotop2.Data.Models;
using Isotop2.Data.Entities;
using Isotop2.Forms;
using System.Windows.Controls;
using System.Windows;
using Isotop2.Services;
using Microsoft.Extensions.DependencyInjection;
using Isotop2.Data.Interfaces;

namespace Isotop2.Data.Controllers
{
    internal class MainFormController
    {
        static private IMainModel _model = ServiceProviderHolder.ServiceProvider.GetRequiredService<IMainModel>();

        ///////// Часть для Технеция /////////

        static public void SetTechnetiumCurrentDecay(double hour)
        {
            _model.SetTechnetiumCurrentDecay(hour);
        }
      
        static public void FillTechnetiumCoefficientChildren(ComboBox cb)
        {
            cb.Items.Clear();
            List<CoefficientsForChildren> childrenCoeff = _model.GetСoefficentСhildrenList();
            foreach (var item in childrenCoeff)
                cb.Items.Add(item.AgeRange);
            cb.SelectedIndex = 0;
        }
    
        static public void SetChildrenCoefficent(string range)
        {
            _model.SetChildrenCoefficent(range);
        }
   
        static public void FillListViewGeneration(ListView lv, string activity)
        {
            List<ActivityByVolume> volumeActivity = _model.GetListActivityByVolume(Convert.ToDouble(activity));
            lv.ItemsSource = volumeActivity;
        }
      
        static public void GetListTechnetiumPatient(ListView lv, string newActivity, string oldActivity, bool isAdults)
        {
            List<string[]> dataList;
     
            if (isAdults)
                dataList = _model.GetListTechnetiumAdultPatient(Convert.ToDouble(newActivity), Convert.ToDouble(oldActivity));
            else
                dataList = _model.GetListTechnetiumChildPatient(Convert.ToDouble(newActivity), Convert.ToDouble(oldActivity));
            List<MarkerView> markerView = AuxiliaryFuntions.ListArrStringToMarkerView(dataList);
            lv.ItemsSource = markerView;
        }
      
        static public void PrintTechnetiumForm(string newActivity, string oldActivity, string childrenAge)
        {
            Dictionary<Marker, ActivityByVolume> adultPrint = _model.GetAdultPrintList();
            Dictionary<Marker, ActivityByVolume> childrenPrint = _model.GetChildrenPrintList();
            TechnetiumPrintForm TPF = new TechnetiumPrintForm(adultPrint, childrenPrint, Convert.ToDouble(newActivity), Convert.ToDouble(oldActivity), childrenAge);
            TPF.Owner = App.Current.MainWindow;
            TPF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            TPF.ShowDialog();
        }

        ///////// ******************** /////////

        ///////// Часть для Йода /////////

        static public void FillListViewIodine(ListView lv, string activity, string startDate)
        {
            List<string[]> dataList = _model.GetListDataIodine(Convert.ToDouble(activity), Convert.ToDateTime(startDate));
            List<IodineView> iodineViews = AuxiliaryFuntions.ListArrStringToIodineView(dataList);
            lv.ItemsSource = iodineViews;
        }
   
        static public void PrintIodine(ListView lv, string activity)
        {
            List<IodineView> view = lv.ItemsSource.Cast<IodineView>().ToList();
            List<string> dataList = AuxiliaryFuntions.ConvertListObjectToListString(view);
            IodinePrintController.SetPrintData(dataList, Convert.ToDouble(activity));
            IodinePrintController.ExpotrToPDF();
        }

        ///////// ******************** /////////

        ///////// Часть для Радия /////////

        static public bool IsExpiredRadium()
        {
            return _model.IsExpiredRadium();
        }

        static public int GetDefferenceDayRadiun()
        {
            return _model.GetDefferenceDay();
        }

        static public void SetDifferenceDayRadium(string createDate, string currentDate)
        {
            _model.SetDifferenceDayRadium(Convert.ToDateTime(createDate), Convert.ToDateTime(currentDate));
        }
      
        static public void FillListViewRadium(ListView lv, string activity)
        {
            List<string[]> dataList = _model.GetListDataRadium(Convert.ToDouble(activity));
            List<RadiumView> radiumViews = AuxiliaryFuntions.ListArrStringToRadiumView(dataList);
            lv.ItemsSource = radiumViews;
        }
    
        static public void FillListViewRadiumForPatient(ListView lv, string weightPatient, string activity)
        {
            List<string[]> dataList = _model.GetRadiumForPatient(Convert.ToDouble(weightPatient), Convert.ToDouble(activity));
            List<RadiumCalculationView> radiumCalculationViews = AuxiliaryFuntions.ListArrStringToRadiumCalculationView(dataList);
            lv.ItemsSource = radiumCalculationViews;
        }
    
        static public void AddRadiumPatientList(ListView lvPatientList, ListView lvCalculationRadium, string weightPatient, string activity)
        {
            RadiumCalculationView calculationView = lvCalculationRadium.ItemsSource.Cast<RadiumCalculationView>().First();
            AddNameRadiumPatient ANRP = new AddNameRadiumPatient();
            ANRP.Owner = App.Current.MainWindow;
            ANRP.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (ANRP.ShowDialog() == true)
            {
                string patientName = ANRP.GetEnteredData();
                ANRP.Close();
                lvPatientList.Items.Add(new RadiumPatientView 
                    { 
                        PatientName = patientName, 
                        Weight = weightPatient.ToString(), 
                        Volume = calculationView.Volume, 
                        Activity = calculationView.ActivityInVolume
                    });
            }
        }
   
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
   
        static public void PrintRadium(ListView lvPatientList, ListView lvCalculationRadium, string currentDate)
        {
            List<string> dataList = new List<string>();
            RadiumCalculationView calculationView = lvCalculationRadium.ItemsSource.Cast<RadiumCalculationView>().First();
            List<RadiumPatientView> patientView = lvPatientList.Items.Cast<RadiumPatientView>().ToList();
            if(patientView.Count != 0)
                dataList = AuxiliaryFuntions.ConvertListObjectToListString(patientView);
            RadiumPrintController.SetPrintData
                (
                    dataList,
                    Convert.ToDateTime(currentDate),
                    calculationView.DifferenceDays,
                    calculationView.CurrentCoefficent,
                    calculationView.CurrentActivity
                );
            RadiumPrintController.ExportToPDF();
        }

        ///////// ******************** /////////

        static public void SaveSettings(string activityNewGenerator, string activityOldGenerator, double timeDecay, string dateZeroDay, string activityIodine, string activityRadium, string createDate, string weihget)
        {
            if (activityNewGenerator == "" || activityNewGenerator == null)
                return;

            ProgramSettings settings = new ProgramSettings
            {
                NewGenerationActivity = Convert.ToDouble(activityNewGenerator),
                OldGenerationActivity = Convert.ToDouble(activityOldGenerator),
                TimeDecay = (int)timeDecay,
                DateOnZeroDay = Convert.ToDateTime(dateZeroDay),
                IodineActivity = Convert.ToDouble(activityIodine),
                RadiumActivity = Convert.ToDouble(activityRadium),
                CreateDateRadium = Convert.ToDateTime(createDate),
                PatientWeighet = Convert.ToInt32(weihget)
            };

            SaveLoadSettings newSettings = new SaveLoadSettings(settings);
            newSettings.SaveToXML();
        }
 
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
   
        static public void OpenFormData()
        {
            FormData FD = new FormData(_model.GetUserRole());
            FD.Owner = App.Current.MainWindow;
            FD.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            FD.ShowDialog();
            _model.RefrashDataTechnetium();
        }
     
        static public void OpenRIForm()
        {
            RIForm RF = new RIForm();
            RF.Owner = App.Current.MainWindow;
            RF.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            RF.ShowDialog();
        }
   
        static public bool Authorization()
        {
            new Logger($"Попытка авторизации; {DateTime.Now.ToString()}");
            AuthorizationForm AF = new AuthorizationForm();
            AF.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AF.ShowDialog();
            if (AF.DialogResult != true)
            { 
                new Logger($"Не удалось авторизоваться; {DateTime.Now.ToString()}");
                return false;
            }
            _model.SetUserRole(AF.GetUserRole());
            _model.SetUserName(AF.GetUserName());            
            AF.Close();
            return true;
        }
   
        static public void SetUserName()
        { 
            App.Current.MainWindow.Title = "Изотоп 2.0. Пользователь: " + _model.GetUserName();
        }
    }
}

