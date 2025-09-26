using Isotop2.Data.Entities;
using Isotop2.Data.Interfaces;

namespace Isotop2.Data.Models
{
    internal class RadiumModel : IRadiumModel
    {
        private List<Radium> _radiumList;
        private int _differenceDay = 0;

        private readonly IDataStorage<Radium> _dataStorage;
        public RadiumModel(IDataStorage<Radium> dataStorage)
        {
            _dataStorage = dataStorage;
            _radiumList = _dataStorage.GetAll();
        }
   
        private double CalculationRadiumActivity(double coefficent, double activity, double firstCoefficentDecay)
        {
            double result = activity * coefficent / firstCoefficentDecay;
            return Math.Round(result, 2);
        }
    
        public int GetRadiumLastDay()
        {
            return _radiumList.Last().Day;
        }
    
        public int GetDefferenceDay()
        {
            return _differenceDay;
        }
      
        public void SetDefferenceDay(DateTime creatureDate, DateTime currentDate)
        {
            _differenceDay = (currentDate - creatureDate).Days;
        }
    
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
     
        public (Radium, ActivityByVolume, double) CreateRadiumForPatient(double weightPatient, double activity)
        {    
            Radium? radium = _radiumList.FirstOrDefault(r => r.Day == _differenceDay);
            if (radium == null)
                radium = _radiumList.Last();
       
            double currentActivity = Math.Round(activity * radium.DecayCoefficent / _radiumList.First().DecayCoefficent, 2);          
            int activityPatient = (int)weightPatient * 55;
            double volumePatient = Math.Round(activityPatient / (radium.DecayCoefficent * 1100), 2);
            ActivityByVolume activityVolume = new ActivityByVolume() { Activity = activityPatient, Volume = volumePatient };
            return (radium, activityVolume, currentActivity);
        }
    }
}