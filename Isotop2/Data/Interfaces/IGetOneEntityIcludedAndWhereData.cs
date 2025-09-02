using System.Linq.Expressions;

namespace Isotop2.Data.Interfaces
{
    internal interface IGetOneEntityIcludedAndWhereData<T> where T : class
    {
        T? GetOneEntityIcludedAndWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes); //Получение одной сущности жадной загрузкой и условием
    }
}
