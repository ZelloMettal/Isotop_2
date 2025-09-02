using System.Linq.Expressions;

namespace Isotop2.Data.Interfaces
{
    internal interface IGetOneEntityWherData<T> where T : class
    {
        T? GetOneEntityWher(Expression<Func<T, bool>> predicate); //Получение одной сущности с условием
    }
}
