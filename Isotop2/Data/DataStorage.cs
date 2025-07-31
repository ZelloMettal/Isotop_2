using System.Linq.Expressions;
using Isotop2.Data.Interfaces;
using Isotop2.Services;
using Microsoft.EntityFrameworkCore;

namespace Isotop2.Data
{
    internal class DataStorage<T> : IDataStorage<T> where T : class
    {
        private readonly DataDBContext DB; //Контектс
        private readonly DbSet<T> DBSet; //Сущность
        public DataStorage()
        {
            DB = new DataDBContext();
            DBSet = DB.Set<T>();
        }

        //Метод добавления сущности
        public void Add(T entity)
        {
            DB.ChangeTracker.Clear();
            DBSet.Add(entity);
            DB.SaveChanges();
        }
        //Метод Удаления сущности
        public void Delete(T entity)
        {
            DB.ChangeTracker.Clear();
            DBSet.Remove(entity);
            DB.SaveChanges();
        }
        //Метод изменения сущности
        public void Update(T entity)
        {
            DB.ChangeTracker.Clear();
            DBSet.Update(entity);
            DB.SaveChanges();
        }
        //Метод получение списка сущностей
        public List<T> GetAll()
        {
            List<T> list = DBSet.AsNoTracking().ToList();
            return list;
        }
        //Метод получение сущности по Id
        public T GetById(int id)
        {
            T? entity = DBSet.Find(id);
            return entity;
        }
        //Метод плучения списка сущностей жадной загрузкой
        public List<T> GetAllIcluded(params Expression<Func<T, object>>[] includes)
        {
            List<T> list = Include(includes).ToList();
            return list;
        }
        //Метод плучения одной сущности с условием
        public T GetOneEntityWher(Expression<Func<T, bool>> predicate)
        {
            T entity = DBSet.AsNoTracking().Where(predicate).FirstOrDefault();
            return entity;
        }
        //Метод получения списка сущностей жадной загрузкой с условием
        public List<T> GetAllIcludedAndWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = Include(includes);
            List<T> list = query.Where(predicate).ToList();
            return list;
        }
        //Метод получение одного элемента жадной загрузкой и условием
        public T GetOneEntityIcludedAndWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = Include(includes);
            T entity = query.Where(predicate).FirstOrDefault();
            return entity;
        }
        //Метод формирования запроса для жадной загрузки
        private IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DBSet.AsNoTracking();
            return includes.Aggregate(query, (current, includes) => current.Include(includes));
        }
    }
}
