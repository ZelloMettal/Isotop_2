using Isotop2.Data.Entities;
using Isotop2.Services;
using Microsoft.Extensions.DependencyInjection;

using Isotop2.Data.Interfaces;

namespace Isotop2.Data.Models
{
    internal class MainModel : IMainModel
    {
        private bool _isCurrentUserRoleAdmin = false;
        private string _currentUserName = "Unknown";
        static private ITechnetiumModel _technetium = ServiceProviderHolder.ServiceProvider.GetRequiredService<ITechnetiumModel>();
        static private IIodineModel _iodine = ServiceProviderHolder.ServiceProvider.GetRequiredService<IIodineModel>();
        static private IRadiumModel _radium = ServiceProviderHolder.ServiceProvider.GetRequiredService<IRadiumModel>();
        static private Dictionary<Marker, ActivityByVolume> _childrenPrintList = new Dictionary<Marker, ActivityByVolume>();
        static private Dictionary<Marker, ActivityByVolume> _adultPrintList = new Dictionary<Marker, ActivityByVolume>();

        public bool GetUserRole()
        {
            return _isCurrentUserRoleAdmin;
        }
     
        public void SetUserRole(bool isAdmin)
        {
            _isCurrentUserRoleAdmin = isAdmin;
        }
    
        public string GetUserName() 
        {
            return _currentUserName;
        }
    
        public void SetUserName(string userName)
        { 
            _currentUserName = userName;
        }

        ///////// Часть для Технеция /////////
        
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
  
        public void SetTechnetiumCurrentDecay(double hour)
        {
            _technetium.SetCurrentDecay(hour);
        }
     
        public List<CoefficientsForChildren> GetСoefficentСhildrenList()
        {
            return _technetium.GetСoefficentСhildrenList().OrderByDescending(x => x.Coefficient).ToList();
        }
   
        public void SetChildrenCoefficent(string range)
        {
            _technetium.SetCurrentChildrenCoefficent(range);
        }
   
        public List<ActivityByVolume> GetListActivityByVolume(double activity)
        {
            return _technetium.CreateListActivityByVolume(activity).OrderByDescending(x => x.Volume).ToList();
        }
     
        public Dictionary<Marker, ActivityByVolume> GetAdultPrintList()
        {
            return _adultPrintList;
        }
     
        public Dictionary<Marker, ActivityByVolume> GetChildrenPrintList()
        {
            return _childrenPrintList;
        }
   
        public List<string[]> GetListTechnetiumAdultPatient(double newActivity, double oldActivity)
        {
            _adultPrintList.Clear();
            Dictionary<Marker, ActivityByVolume> newGenerator = _technetium.CreateListActivityForAdults(newActivity);
            Dictionary<Marker, ActivityByVolume> oldGenerator = _technetium.CreateListActivityForAdults(oldActivity);
            return DataPatientList(newGenerator, oldGenerator, _adultPrintList);
        }
    
        public List<string[]> GetListTechnetiumChildPatient(double newActivity, double old_Activity)
        {
            _childrenPrintList.Clear();
            Dictionary<Marker, ActivityByVolume> newGenerator = _technetium.CreateListActivityForChildren(newActivity);
            Dictionary<Marker, ActivityByVolume> oldGenerator = _technetium.CreateListActivityForChildren(old_Activity);
            return DataPatientList(newGenerator, oldGenerator, _childrenPrintList);
        }       
   
        public void RefrashDataTechnetium()
        {
            _technetium.LoadMarkerList();
            _technetium.LoadVolumeList();
            _technetium.LoadChildrenAgeList();
        }

        /////////////////////////////////////////////////////

        ///////// Часть для Йода /////////

        public List<string[]> GetListDataIodine(double activity, DateTime startDate)
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

        public bool IsExpiredRadium()
        {
            return _radium.GetDefferenceDay() <= _radium.GetRadiumLastDay();
        }
    
        public int GetDefferenceDay()
        { 
            return _radium.GetDefferenceDay();
        }
    
        public void SetDifferenceDayRadium(DateTime createDate, DateTime currentDate)
        {
            _radium.SetDefferenceDay(createDate, currentDate);
        }
     
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
    
        public List<string[]> GetRadiumForPatient(double weightPatient, double activity)
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