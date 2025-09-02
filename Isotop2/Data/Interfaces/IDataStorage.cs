using System.Linq.Expressions;

namespace Isotop2.Data.Interfaces
{
    internal interface IDataStorage<T> where T : class
    {
        bool Add(T? entity); //Добавление сущности
        bool Update(T? entity); //Редактирование сущности
        bool Delete(T? entity); //Удаление сущности
        List<T>? GetAll(); //Получение всех данных
        List<T>? GetAllIcluded(params Expression<Func<T, object>>[] includes); //Получение всех данных жадной загрузкой
        List<T>? GetAllIcludedAndWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes); //Получение всех данных жадной загрузкой и условием
        T? GetById(int? id); //Получение одной сущности по ID
        T? GetOneEntityWher(Expression<Func<T, bool>> predicate); //Получение одной сущности с условием
        T? GetOneEntityIcludedAndWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes); //Получение одной сущности жадной загрузкой и условием
    }
}
