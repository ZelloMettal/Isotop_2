using Isotop2.Data.Entities;

namespace Isotop2.Data.Models
{
    internal class IodineModel
    {
        private List<Iodine> _iodineList; //Список распада Йода

        private readonly DataStorage<Iodine> _dataStorage;

        public IodineModel(DataStorage<Iodine> dataStorage)
        {
            _dataStorage = dataStorage;
            _iodineList = _dataStorage.GetAll();
        }
        //Метод расчёта активности и объёма Йода
        private ActivityByVolume CalculationActivityAndVolume(double decayPrecent, decimal startActivity)
        {
            int activity = (int)Math.Round((double)startActivity * decayPrecent / 100, 0);
            double volume = Math.Round((double)10 * 3 / activity, 1);
            ActivityByVolume activityByVolume = new ActivityByVolume() { Activity = activity, Volume = volume };
            return activityByVolume;
        }
        //Формирование списка активности и объёма Йода
        public Dictionary<Iodine, ActivityByVolume> CreateListActivityIodine(decimal activity)
        {
            Dictionary<Iodine, ActivityByVolume> dict = new Dictionary<Iodine, ActivityByVolume>();
            foreach (var item in _iodineList)
            {
                ActivityByVolume activity_by_volume = CalculationActivityAndVolume(item.DecayPrecent, activity);
                dict.Add(item, activity_by_volume);
            }
            return dict;
        }        
    }
}
