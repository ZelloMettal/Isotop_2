using System.Linq.Expressions;

namespace Isotop2.Data.Interfaces
{
    internal interface IGetAllIcludedData<T> where T : class
    {
        List<T>? GetAllIcluded(params Expression<Func<T, object>>[] includes); //Получение всех данных жадной загрузкой
    }
}
