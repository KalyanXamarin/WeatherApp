using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace WeatherApp.DataBase
{
    public class AbstractDataManager<T> where T:class,new()
    {
        private SQLiteConnection _connection;

        public AbstractDataManager(SQLiteConnection connection)
        {
            _connection = connection;
            Init();
        }

        void Init()
        {
            _connection.CreateTable<T>();
        }

        public List<T> Get()
        {
            return _connection.Table<T>().ToList();
        }

        public List<T> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = _connection.Table<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                query = query.OrderBy<TValue>(orderBy);
            }
            return query.ToList();
        }

        public T Get(string id)
        {
            return _connection.Find<T>(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _connection.Find<T>(predicate);
        }

        public int Insert(T entity)
        {
            return _connection.Insert(entity);
        }

        public int InsertOrReplace(T entity)
        {
            return _connection.InsertOrReplace(entity);
        }

        public int InsertOrReplaceAll(List<T> entity)
        {
            return _connection.InsertOrReplace(entity);
        }

        public int InsertAll(List<T> entity)
        {
            return _connection.InsertAll(entity);
        }

        public int Update(T entity)
        {
            return _connection.Update(entity);
        }

        public int Delete(T entity)
        {
            return _connection.Delete(entity);
        }
    }
}
