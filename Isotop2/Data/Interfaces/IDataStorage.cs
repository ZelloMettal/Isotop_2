using System.Linq.Expressions;

namespace Isotop2.Data.Interfaces
{
    internal interface IDataStorage<T> where T : class
    {
        bool Add(T? entity);
        bool Update(T? entity);
        bool Delete(T? entity);
        List<T>? GetAll();
        List<T>? GetAllIcluded(params Expression<Func<T, object>>[] includes);
        List<T>? GetAllIcludedAndWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        T? GetById(int? id);
        T? GetOneEntityWher(Expression<Func<T, bool>> predicate);
        T? GetOneEntityIcludedAndWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    }
}
