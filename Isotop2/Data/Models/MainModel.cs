using Isotop2.Data.Entities;
using Isotop2.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Isotop2.Data.Models
{
    internal class MainModel
    {
        //Свойства модели
        private bool _isCurrentUserRoleAdmin = false;
        private string _currentUserName = "Unknown";
        static private TechnetiumModel _technetium = new TechnetiumModel(ServiceProviderHolder.ServiceProvider.GetRequiredService<DataStorage<Technetium>>());
        static private Dictionary<Marker, ActivityByVolume> _childrenPrintList = new Dictionary<Marker, ActivityByVolume>();
        static private Dictionary<Marker, ActivityByVolume> _adultPrintList = new Dictionary<Marker, ActivityByVolume>();
        static private IodineModel _iodine = new IodineModel(ServiceProviderHolder.ServiceProvider.GetRequiredService<DataStorage<Iodine>>());
        static private RadiumModel _radium = new RadiumModel(ServiceProviderHolder.ServiceProvider.GetRequiredService<DataStorage<Radium>>());

        //Метод получения роли текущего пользователя
        public bool GetUserRole()
        {
            return _isCurrentUserRoleAdmin;
        }
        //Метод установки роли текущего пользователя
        public void SetUserRole(bool isAdmin)
        {
            _isCurrentUserRoleAdmin = isAdmin;
        }
        //Метод получения текущего пользователя
        public string GetUserName() 
        {
            return _currentUserName;
        }
        //Метод установки текущего пользователя
        public void SetUserName(string userName)
        { 
            _currentUserName = userName;
        }
        ///////// Часть для Технеция /////////
        
        //Метод падсчёт данных для пациентов по маркерам
        private List<string[]> DataPatientList(Dictionary<Marker, ActivityByVolume> newGenerator, Dictionary<Marker, ActivityByVolume> oldGenerator, Dictionary<Marker, ActivityByVolume> printList)
        {
            List<string[]> dataListPatient = new List<string[]>();
            for (int i = 0; i < newGenerator.Count; i++)
            {
                if (newGenerator.ElementAt(i).Key.NewGenerator)
                {
                    dataListPatient.Add(new string[]
                    {
                        newGenerator.ElementAt(i).Key.MarkerName,
                        newGenerator.ElementAt(i).Value.Volume.ToString(),
                        newGenerator.ElementAt(i).Value.Activity.ToString()
                    });
                    printList.Add(newGenerator.ElementAt(i).Key, newGenerator.ElementAt(i).Value);
                }
                else
                {
                    dataListPatient.Add(new string[]
                    {
                        oldGenerator.ElementAt(i).Key.MarkerName,
                        oldGenerator.ElementAt(i).Value.Volume.ToString(),
                        oldGenerator.ElementAt(i).Value.Activity.ToString()
                    });
                    printList.Add(oldGenerator.ElementAt(i).Key, oldGenerator.ElementAt(i).Value);
                }
            }
            return dataListPatient;
        }
        //Метод становку текущего распада для Технеция
        public void SetTechnetiumCurrentDecay(double hour)
        {
            _technetium.SetCurrentDecay(hour);
        }
        //Метод получения списка детских коэффицентов
        public List<CoefficientsForChildren> GetСoefficentСhildrenList()
        {
            return _technetium.GetСoefficentСhildrenList();
        }
        //Метод установки текущего детского коэффицента
        public void SetChildrenCoefficent(string range)
        {
            _technetium.SetCurrentChildrenCoefficent(range);
        }
        //Метод получения активности по объёмам
        public List<ActivityByVolume> GetListActivityByVolume(decimal activity)
        {
            return _technetium.CreateListActivityByVolume(activity).OrderByDescending(x => x.Volume).ToList();
        }
        //Метод получения списка печати для взрослых
        public Dictionary<Marker, ActivityByVolume> GetAdultPrintList()
        {
            return _adultPrintList;
        }
        //Метод получения списка печати для детей
        public Dictionary<Marker, ActivityByVolume> GetChildrenPrintList()
        {
            return _childrenPrintList;
        }
        //Метод получения списка расчётных данных для взрослых
        public List<string[]> GetListTechnetiumAdultPatient(decimal newActivity, decimal oldActivity)
        {
            _adultPrintList.Clear();
            Dictionary<Marker, ActivityByVolume> newGenerator = _technetium.CreateListActivityForAdults(newActivity);
            Dictionary<Marker, ActivityByVolume> oldGenerator = _technetium.CreateListActivityForAdults(oldActivity);
            return DataPatientList(newGenerator, oldGenerator, _adultPrintList);
        }
        //Метод получения списка расчётных данных для детей
        public List<string[]> GetListTechnetiumChildPatient(decimal newActivity, decimal old_Activity)
        {
            _childrenPrintList.Clear();
            Dictionary<Marker, ActivityByVolume> newGenerator = _technetium.CreateListActivityForChildren(newActivity);
            Dictionary<Marker, ActivityByVolume> oldGenerator = _technetium.CreateListActivityForChildren(old_Activity);
            return DataPatientList(newGenerator, oldGenerator, _childrenPrintList);
        }       
        //Метод обновления данных Технеция
        public void RefrashDataTechnetium()
        {
            _technetium.LoadMarkerList();
            _technetium.LoadVolumeList();
            _technetium.LoadChildrenAgeList();
        }

        /////////////////////////////////////////////////////

        ///////// Часть для Йода /////////

        //Метод получения расчётных данных для Йода
        public List<string[]> GetListDataIodine(decimal activity, DateTime startDate)
        {
            List<string[]> dataList = new List<string[]>();
            Dictionary<Iodine, ActivityByVolume> iodine = _iodine.CreateListActivityIodine(activity);
            foreach (var item in iodine)
            {
                dataList.Add(new string[]
                {
                    startDate.AddDays(item.Key.Day).ToShortDateString(),
                    item.Key.Day.ToString(),
                    item.Key.DecayPrecent.ToString(),
                    item.Value.Activity.ToString(),
                    item.Value.Volume.ToString()
                });
            }
            return dataList;
        }

        //////////////////////////////////////////////////////

        ///////// Часть для Радия /////////

        //Проверка на срок годности Радия
        public bool IsExpiredRadium()
        {
            return _radium.GetDefferenceDay() <= _radium.GetRadiumLastDay();
        }
        //Метод получпаения разности в днях Радия
        public int GetDefferenceDay()
        { 
            return _radium.GetDefferenceDay();
        }
        //Установка нового значения разности дней Радия
        public void SetDifferenceDayRadium(DateTime createDate, DateTime currentDate)
        {
            _radium.SetDefferenceDay(createDate, currentDate);
        }
        //Метод получения списка данных для Радия
        public List<string[]> GetListDataRadium(double activity)
        {
            List<string[]> dataList = new List<string[]>();
            Dictionary<Radium, double> radium = _radium.CreateRadiumActivityList(activity);

            foreach (var item in radium)
            {
                dataList.Add(new string[]
                {
                    item.Key.Day.ToString(),
                    item.Key.DecayCoefficent.ToString(),
                    item.Value.ToString()
                });
            }
            return dataList;
        }
        //Получение данных для Радия на пациентов
        public List<string[]> GetRadiumForPatient(decimal weightPatient, double activity)
        {
            (Radium radium, ActivityByVolume activity_volume, double current_activity) radium = _radium.CreateRadiumForPatient(weightPatient, activity);
            string[] dataPatient = new string[]
            {
                _radium.GetDefferenceDay().ToString(),
                radium.radium.DecayCoefficent.ToString(),
                radium.current_activity.ToString(),
                radium.activity_volume.Volume.ToString(),
                radium.activity_volume.Activity.ToString()
            };
            return new List<string[]> { dataPatient };
        }

        //////////////////////////////////////////////////////
    }
}

