using Isotop2.Data.Entities;

namespace Isotop2.Data.Interfaces
{
    internal interface ITechnetiumModel
    {
        double GetCurrentDecay();
        void SetCurrentDecay(double hour);
        List<CoefficientsForChildren> GetСoefficentСhildrenList();
        void SetCurrentChildrenCoefficent(string range);
        List<ActivityByVolume> CreateListActivityByVolume(double activity);
        Dictionary<Marker, ActivityByVolume> CreateListActivityForAdults(double activity);
        Dictionary<Marker, ActivityByVolume> CreateListActivityForChildren(double activity);
        void LoadVolumeList();
        void LoadMarkerList();
        void LoadChildrenAgeList();
    }
}
