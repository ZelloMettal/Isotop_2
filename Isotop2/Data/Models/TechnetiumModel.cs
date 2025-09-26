using Isotop2.Data.Entities;
using Isotop2.Data.Interfaces;

namespace Isotop2.Data.Models
{
    internal class TechnetiumModel : ITechnetiumModel
    {
        private List<Technetium> _technetiumList;
        private List<CoefficientsForChildren> _coefficentForChildrenList;
        private List<Volume> _volumeList;
        private List<Marker> _markerList;
        private double _currentDecay;
        private double _currentChildrenCoefficent;

        private readonly IDataStorage<Technetium> _dataStorage;
        public TechnetiumModel(IDataStorage<Technetium> dataStorage)
        {
            _dataStorage = dataStorage;

            _technetiumList = _dataStorage.GetAll();
            _coefficentForChildrenList = new DataStorage<CoefficientsForChildren>().GetAll();
            _currentDecay = _technetiumList.First().DecayPrecent;
            _currentChildrenCoefficent = _coefficentForChildrenList.First().Coefficient;
            LoadMarkerList();
            LoadVolumeList();
        }
      
        private int CalculationActivityGeneration(double volume, double activity, double firstVolume, double currentDecay)
        {
            double result = Math.Round(activity * volume / firstVolume * currentDecay / 100, 0);
            return (int)result;
        }
     
        public double GetCurrentDecay()
        {
            return _currentDecay;
        }
      
        public void SetCurrentDecay(double hour)
        {
            double current_decay = _technetiumList.Where(h => h.Hour == hour).First().DecayPrecent;
            _currentDecay = current_decay;
        }
   
        public List<CoefficientsForChildren> GetСoefficentСhildrenList()
        {
            return _coefficentForChildrenList;
        }
     
        public void SetCurrentChildrenCoefficent(string range)
        {
            double coefficent = _coefficentForChildrenList.Where(c => c.AgeRange == range).First().Coefficient;
            _currentChildrenCoefficent = coefficent;
        }
      
        public List<ActivityByVolume> CreateListActivityByVolume(double activity)
        {
            List<ActivityByVolume> list = new List<ActivityByVolume>();
            foreach (var volume in _volumeList)
            {
                int newActivity = CalculationActivityGeneration(volume.Value, activity, _volumeList[0].Value, _currentDecay);
                ActivityByVolume activityByVolume = new ActivityByVolume { Activity = newActivity, Volume = volume.Value };
                list.Add(activityByVolume);
            }
            return list;
        }        

        public Dictionary<Marker, ActivityByVolume> CreateListActivityForAdults(double activity)
        {
            Dictionary<Marker, ActivityByVolume> dict = new Dictionary<Marker, ActivityByVolume>();
            List<ActivityByVolume> list = CreateListActivityByVolume(activity);
            foreach (Marker marker in _markerList)
            {
                ActivityByVolume? newActivity = list.Where(a => a.Activity >= marker.MinActivity && a.Activity <= marker.MaxActivity).LastOrDefault();
                if (newActivity == null)
                    newActivity = list.Where(a => marker.MaxActivity >= a.Activity).FirstOrDefault();
                if (newActivity == null)
                    newActivity = list.Last();
                dict.Add(marker, newActivity);
            }
            return dict;
        }
    
        public Dictionary<Marker, ActivityByVolume> CreateListActivityForChildren(double activity)
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
      
        public void LoadVolumeList()
        {
            _volumeList = new DataStorage<Volume>().GetAll().OrderByDescending(v => v.Value).ToList();
        }
     
        public void LoadMarkerList()
        {
            _markerList = new DataStorage<Marker>().GetAll().OrderByDescending(g => g.NewGenerator).ToList();
        }
     
        public void LoadChildrenAgeList()
        {
            _coefficentForChildrenList = new DataStorage<CoefficientsForChildren>().GetAll();
        }
    }
}
