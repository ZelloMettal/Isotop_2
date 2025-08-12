using System.Linq.Expressions;

namespace Isotop2.Data.Interfaces
{
    internal interface IDataStorage<T> where T : class
    {
        List<T> GetAll(); //Получение всех данных
        List<T> GetAllIcludedAndWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes); //Получение всех данных жадной загрузкой и условием
        T GetOneEntityWher(Expression<Func<T, bool>> predicate); //Получение одной сущности с условием
        T GetOneEntityIcludedAndWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes); //Получение одной сущности жадной загрузкой и условием
        List<T> GetAllIcluded(params Expression<Func<T, object>>[] includes); //Получение всех данных жадной загрузкой
        T GetById(int id); //Получение одной сущности по Id
        void Add(T entity); //Добавление сущности
        void Update(T entity); //Редактирование сущности
        void Delete(T entity); //Удаление сущности
    }
}
