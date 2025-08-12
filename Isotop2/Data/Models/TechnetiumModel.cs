using Isotop2.Data.Entities;

namespace Isotop2.Data.Models
{
    internal class TechnetiumModel
    {
        private List<Technetium> _technetiumList; //Список технеция
        private List<CoefficientsForChildren> _coefficentForChildrenList; //Список коэффицентов для детей
        private List<Volume> _volumeList; //Список объёмов
        private List<Marker> _markerList; //Список маркеров
        private double _currentDecay; //Текущий процент распада
        private double _currentChildrenCoefficent; //Текущий коеффицент для детей

        private readonly DataStorage<Technetium> _dataStorage;
        public TechnetiumModel(DataStorage<Technetium> dataStorage)
        {
            _dataStorage = dataStorage;

            _technetiumList = _dataStorage.GetAll(); //Получаем список объектов Технеция
            _coefficentForChildrenList = new DataStorage<CoefficientsForChildren>().GetAll(); //Получаем список коэффицентов детей
            LoadVolumeList();
            LoadMarkerList();
            _currentDecay = _technetiumList.FirstOrDefault().DecayPrecent; //Получаем текущий процент распада
            _currentChildrenCoefficent = _coefficentForChildrenList.FirstOrDefault().Coefficient; //Получаем текущий коэффицент для детей
        }
        //Метод расчёта генераторов
        private int CalculationActivityGeneration(double volume, decimal activity, double firstVolume, double currentDecay)
        {
            double result = Math.Round((double)activity * volume / firstVolume * currentDecay / 100, 0);
            return (int)result;
        }
        //Метод получения текущего распада
        public double GetCurrentDecay()
        {
            return _currentDecay;
        }
        //Метод установки текущего распада
        public void SetCurrentDecay(double hour)
        {
            double current_decay = _technetiumList.Where(h => h.Hour == hour).First().DecayPrecent;
            _currentDecay = current_decay;
        }
        //Метод получения списка коэффицентов детей
        public List<CoefficientsForChildren> GetСoefficentСhildrenList()
        {
            return _coefficentForChildrenList;
        }
        //Метод установки текущего коэффицента для детей
        public void SetCurrentChildrenCoefficent(string range)
        {
            double coefficent = _coefficentForChildrenList.Where(c => c.AgeRange == range).First().Coefficient;
            _currentChildrenCoefficent = coefficent;
        }
        //Метод расчёта активности генераторов по объёмам
        public List<ActivityByVolume> CreateListActivityByVolume(decimal activity)
        {
            List<ActivityByVolume> list = new List<ActivityByVolume>();
            foreach (var volume in _volumeList)
            {
                //Получаем данные для генератора
                int newActivity = CalculationActivityGeneration(volume.Value, activity, _volumeList[0].Value, _currentDecay);
                ActivityByVolume activityByVolume = new ActivityByVolume { Activity = newActivity, Volume = volume.Value };
                list.Add(activityByVolume);
            }
            return list;
        }        
        //Расчёт активности по маркерам для взрослых
        public Dictionary<Marker, ActivityByVolume> CreateListActivityForAdults(decimal activity)
        {
            Dictionary<Marker, ActivityByVolume> dict = new Dictionary<Marker, ActivityByVolume>();
            List<ActivityByVolume> list = CreateListActivityByVolume(activity);
            foreach (Marker marker in _markerList)
            {
                ActivityByVolume newActivity = list.Where(a => a.Activity >= marker.MinActivity && a.Activity <= marker.MaxActivity).LastOrDefault();
                if (newActivity == null)
                    newActivity = list.LastOrDefault(a => marker.MaxActivity < a.Activity);
                if (newActivity == null)
                    newActivity = list.First();
                dict.Add(marker, newActivity);
            }
            return dict;
        }
        //Расчёт активности по маркерам для детей
        public Dictionary<Marker, ActivityByVolume> CreateListActivityForChildren(decimal activity)
        {
            Dictionary<Marker, ActivityByVolume> activityForAdult = CreateListActivityForAdults(activity);
            Dictionary<Marker, ActivityByVolume> activityForChildren = new Dictionary<Marker, ActivityByVolume>();

            foreach (var item in activityForAdult)
            {
                int newActivity = (int)Math.Round(item.Value.Activity * _currentChildrenCoefficent, 0);
                double newVolume = Math.Round(item.Value.Volume * _currentChildrenCoefficent, 2);
                ActivityByVolume activityByVolume = new ActivityByVolume() { Activity = newActivity, Volume = newVolume };
                activityForChildren.Add(item.Key, activityByVolume);
            }
            return activityForChildren;
        }
        //Метод загрузки списка Объёмов
        public void LoadVolumeList()
        {
            _volumeList = new DataStorage<Volume>().GetAll();
        }
        //Метод загрузки списка Маркеров
        public void LoadMarkerList()
        {
            _markerList = new DataStorage<Marker>().GetAll();
        }
        //Метод загрузки списка Коэффицентов детей
        public void LoadChildrenAgeList()
        {
            _coefficentForChildrenList = new DataStorage<CoefficientsForChildren>().GetAll();
        }
    }
}
