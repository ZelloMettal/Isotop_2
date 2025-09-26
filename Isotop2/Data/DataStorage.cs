using System.Linq.Expressions;
using Isotop2.Data.Interfaces;
using Isotop2.Services;
using Microsoft.EntityFrameworkCore;

namespace Isotop2.Data
{
    internal class DataStorage<T> : IDataStorage<T> where T : class
    {
        private Logger _logger = new Logger();
        private readonly DataDBContext _DB;
        private readonly DbSet<T> _DBSet;
        public DataStorage()
        {
            _DB = new DataDBContext();
            _DBSet = _DB.Set<T>();
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _DBSet.AsNoTracking();
            return includes.Aggregate(query, (current, includes) => current.Include(includes));
        }

        public bool Add(T? entity)
        {
            _logger.WrittingLogs($"A:Попытка добавления сущности в БД; {DateTime.Now.ToString()}");            
            try
            {                 
                _DB.ChangeTracker.Clear();
                _DBSet.Add(entity);
                _DB.SaveChanges();
                _logger.WrittingLogs($"A:Сущность успешно добавлена в БД; {DateTime.Now.ToString()}");            
                return true;
            }
            catch (Exception ex) 
            {
                _logger.WrittingLogs($"A:Не удалось добавить сущность; {ex.Message}; {DateTime.Now.ToString()}");            
            }
            return false;
        }

        public bool Delete(T? entity)
        {
            _logger.WrittingLogs($"D:Попытка удалить сущности из БД; {DateTime.Now.ToString()}");            
            try 
            {
                _DB.ChangeTracker.Clear();
                _DBSet.Remove(entity);
                _DB.SaveChanges();
                _logger.WrittingLogs($"D:Сущность успешно удалена из БД; {DateTime.Now.ToString()}");            
                return true;
            }
            catch (Exception ex) 
            {
                _logger.WrittingLogs($"D:Не удалось удалить сущность из БД; {ex.Message}; {DateTime.Now.ToString()}");     
            }
            return false;
        }
 
        public bool Update(T? entity)
        {
            _logger.WrittingLogs($"U:Попытка обновить сущности в БД; {DateTime.Now.ToString()}");            
            try
            {
                _DB.ChangeTracker.Clear();
                _DBSet.Update(entity);
                _DB.SaveChanges();
                _logger.WrittingLogs($"U:Сущность успешно обновлена в БД; {DateTime.Now.ToString()}");            
                return true;
            }
            catch (Exception ex)
            {
                _logger.WrittingLogs($"U:Не удалось обновить сущность в БД; {ex.Message}; {DateTime.Now.ToString()}");                  
            }
            return false;
        }
    
        public List<T>? GetAll()
        {
            _logger.WrittingLogs($"G:Попытка получить список всех сущностей из БД; {DateTime.Now.ToString()}");
            List<T>? list;
            try 
            {    
                list = _DBSet.AsNoTracking().ToList();
                _logger.WrittingLogs($"G:Список всех сущностей успешно получен из БД; {DateTime.Now.ToString()}");            
            }
            catch (Exception ex) 
            {
                list = null;
                _logger.WrittingLogs($"G:Не удалось получить список всех сущности из БД; {ex.Message}; {DateTime.Now.ToString()}");
            }
            return list;
        }

        public T? GetById(int? id)
        {
            _logger.WrittingLogs($"G:Попытка получить сущность по ID из БД; {DateTime.Now.ToString()}");
            T? entity;
            try
            { 
                entity = _DBSet.Find(id);
                _logger.WrittingLogs($"G:Сущность по ID успешно получена; {DateTime.Now.ToString()}");
            }
            catch (Exception ex)
            {
                entity = null;
                _logger.WrittingLogs($"G:Не удалось получить сущность по ID; {ex.Message}; {DateTime.Now.ToString()}");
            }
            return entity;
        }
  
        public List<T>? GetAllIcluded(params Expression<Func<T, object>>[] includes)
        {
            _logger.WrittingLogs($"G:Попытка получения списка сущностей из БД жадно; {DateTime.Now.ToString()}");
            List<T>? list;
            try
            {
                list = Include(includes).ToList();
                _logger.WrittingLogs($"G:Список сущностей из БД жадно успешно получен; {DateTime.Now.ToString()}");
            }
            catch (Exception ex)
            {
                list = null;
                _logger.WrittingLogs($"G:Не удалось получить список сущностей из БД жадно; {ex.Message}; {DateTime.Now.ToString()}");
            }
            return list;
        }
  
        public T? GetOneEntityWher(Expression<Func<T, bool>> predicate)
        {
            _logger.WrittingLogs($"G:Попытка получения сущности с условием из БД; {DateTime.Now.ToString()}");
            T? entity;
            try 
            {
                _logger.WrittingLogs($"G:Сущность с условием из БД получена успешно; {DateTime.Now.ToString()}");
                entity = _DBSet.AsNoTracking().Where(predicate).FirstOrDefault();                
            }
            catch (Exception ex) 
            {
                entity = null;
                _logger.WrittingLogs($"G:Не удалось получить сущность с условием из БД; {ex.Message}; {DateTime.Now.ToString()}");
            }
            return entity;
        }
      
        public List<T>? GetAllIcludedAndWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            _logger.WrittingLogs($"G:Попытка получения списка сущностей из БД жадно с условием; {DateTime.Now.ToString()}");
            IQueryable<T>? query = Include(includes);
            List<T>? list;
            try
            { 
                list = query.Where(predicate).ToList();
                _logger.WrittingLogs($"G:Список сущносте из БД жадно с условием успешно получен; {DateTime.Now.ToString()}");
            }
            catch(Exception ex) 
            {
                list = null;
                _logger.WrittingLogs($"G:Не удалось получить список сущностей из БД жадно с условием; {ex.Message}; {DateTime.Now.ToString()}");
            }
            return list;
        }
  
        public T? GetOneEntityIcludedAndWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            _logger.WrittingLogs($"G:Попытка получения сущность из БД жадно с условием; {DateTime.Now.ToString()}");
            IQueryable<T> query = Include(includes);
            T? entity;
            try
            { 
                entity = query.Where(predicate).FirstOrDefault();
                _logger.WrittingLogs($"G:Сущность из БД жадно с условием успешно получена; {DateTime.Now.ToString()}");
            }
            catch( Exception ex) 
            {
                entity = null;
                _logger.WrittingLogs($"G:Не удалось получить сущность из БД жадно с условием; {ex.Message}; {DateTime.Now.ToString()}");
            }
            return entity;
        }
    }
}