using Isotop2.Data.Entities;

namespace Isotop2.Data.Interfaces
{
    internal interface IIodineModel
    {
        Dictionary<Iodine, ActivityByVolume> CreateListActivityIodine(double activity);

    }
}
