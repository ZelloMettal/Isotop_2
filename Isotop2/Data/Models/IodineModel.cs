using Isotop2.Data.Entities;
using Isotop2.Data.Interfaces;

namespace Isotop2.Data.Models
{
    internal class IodineModel : IIodineModel
    {
        private List<Iodine> _iodineList;

        private readonly IDataStorage<Iodine> _dataStorage;

        public IodineModel(IDataStorage<Iodine> dataStorage)
        {
            _dataStorage = dataStorage;
            _iodineList = _dataStorage.GetAll();
        }

        private ActivityByVolume CalculationActivityAndVolume(double decayPrecent, double startActivity)
        {
            int activity = (int)Math.Round(startActivity * decayPrecent / 100, 0);
            double volume = Math.Round((double)10 * 3 / activity, 1);
            ActivityByVolume activityByVolume = new ActivityByVolume() { Activity = activity, Volume = volume };
            return activityByVolume;
        }
     
        public Dictionary<Iodine, ActivityByVolume> CreateListActivityIodine(double activity)
        {
            Dictionary<Iodine, ActivityByVolume> dict = new Dictionary<Iodine, ActivityByVolume>();
            foreach (Iodine item in _iodineList)
            {
                ActivityByVolume activity_by_volume = CalculationActivityAndVolume(item.DecayPrecent, activity);
                dict.Add(item, activity_by_volume);
            }
            return dict;
        }        
    }
}