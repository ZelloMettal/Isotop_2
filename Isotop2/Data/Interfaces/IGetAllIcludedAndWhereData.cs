using System.Linq.Expressions;

namespace Isotop2.Data.Interfaces
{
    internal interface IGetAllIcludedAndWhereData<T> where T : class
    {
        List<T>? GetAllIcludedAndWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes); //Получение всех данных жадной загрузкой и условием
    }
}
