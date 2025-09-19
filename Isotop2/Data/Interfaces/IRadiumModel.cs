using Isotop2.Data.Entities;

namespace Isotop2.Data.Interfaces
{
    internal interface IRadiumModel
    {
        int GetRadiumLastDay();
        int GetDefferenceDay();
        void SetDefferenceDay(DateTime creatureDate, DateTime currentDate);
        Dictionary<Radium, double> CreateRadiumActivityList(double activity);
        (Radium, ActivityByVolume, double) CreateRadiumForPatient(double weightPatient, double activity);
    }
}
