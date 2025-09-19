using Isotop2.Data.Entities;

namespace Isotop2.Data.Interfaces
{
    internal interface IMainModel
    {
        bool GetUserRole();
        void SetUserRole(bool isAdmin);
        string GetUserName();
        void SetUserName(string userName);
        void SetTechnetiumCurrentDecay(double hour);
        List<CoefficientsForChildren> GetСoefficentСhildrenList();
        void SetChildrenCoefficent(string range);
        List<ActivityByVolume> GetListActivityByVolume(double activity);
        Dictionary<Marker, ActivityByVolume> GetAdultPrintList();
        Dictionary<Marker, ActivityByVolume> GetChildrenPrintList();
        List<string[]> GetListTechnetiumAdultPatient(double newActivity, double oldActivity);
        List<string[]> GetListTechnetiumChildPatient(double newActivity, double old_Activity);
        void RefrashDataTechnetium();
        List<string[]> GetListDataIodine(double activity, DateTime startDate);
        bool IsExpiredRadium();
        int GetDefferenceDay();
        void SetDifferenceDayRadium(DateTime createDate, DateTime currentDate);
        List<string[]> GetListDataRadium(double activity);
        List<string[]> GetRadiumForPatient(double weightPatient, double activity);

    }
}
