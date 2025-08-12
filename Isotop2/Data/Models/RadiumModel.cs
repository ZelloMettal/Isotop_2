using Isotop2.Data.Entities;

namespace Isotop2.Data.Models
{
    internal class RadiumModel
    {
        private List<Radium> _radiumList; //Список распада Радия
        private int _differenceDay = 0; //Разность дней между датой изготовления и текущей датой

        private readonly DataStorage<Radium> _dataStorage;
        public RadiumModel(DataStorage<Radium> dataStorage)
        {
            _dataStorage = dataStorage;

            _radiumList = _dataStorage.GetAll();
        }
        //Метод расчёта активности распада Радия
        private double CalculationRadiumActivity(double coefficent, double activity, double firstCoefficentDecay)
        {
            double result = activity * coefficent / firstCoefficentDecay;
            return Math.Round(result, 2);
        }
        //Получение последнего дня в списке Радия
        public int GetRadiumLastDay()
        {
            return _radiumList.Last().Day;
        }
        //Получение разносте дней
        public int GetDefferenceDay()
        {
            return _differenceDay;
        }
        //Установка разности дней по датам
        public void SetDefferenceDay(DateTime creatureDate, DateTime currentDate)
        {
            _differenceDay = (currentDate - creatureDate).Days;
        }
        //Формирование списка активностей для Радия
        public Dictionary<Radium, double> CreateRadiumActivityList(double activity)
        {
            Dictionary<Radium, double> dict = new Dictionary<Radium, double>();
            foreach (var item in _radiumList)
            {
                double newActivity = CalculationRadiumActivity(item.DecayCoefficent, activity, _radiumList[0].DecayCoefficent);
                dict.Add(item, newActivity);
            }
            return dict;
        }        
        //Метод расчёта ативности Радия для пациента
        public (Radium, ActivityByVolume, double) CreateRadiumForPatient(decimal weightPatient, double activity)
        {
            //Получаем соответствующий Радий
            Radium radium = _radiumList.FirstOrDefault(r => r.Day == _differenceDay);
            if (radium == null)
                radium = _radiumList.Last();
            //Получаем текущую активность Радия
            double currentActivity = Math.Round(activity * radium.DecayCoefficent / _radiumList.First().DecayCoefficent, 2);
            //Получаем активность для ппациента
            int activityPatient = (int)weightPatient * 55;
            //Получаем объём для пациента
            double volumePatient = Math.Round(activityPatient / (radium.DecayCoefficent * 1100), 2);
            ActivityByVolume activityVolume = new ActivityByVolume() { Activity = activityPatient, Volume = volumePatient };
            return (radium, activityVolume, currentActivity);
        }
    }
}
