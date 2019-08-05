using AutoMapper;
using DAL.Data;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected TSMEntities _tsmEntity;
        private DbMapper Mapper = new DbMapper();

        public void Init(TSMEntities tsmEntity)
        {
            if (_tsmEntity == null) throw new ArgumentNullException("TSMEntity");
            this._tsmEntity = tsmEntity;
        }
        public List<T> getList()
        {
            return _tsmEntity.Set<T>().ToList();
        }
        public T getSingle()
        {
            return null;
        }
        public T getByName<TKey>(Expression<Func<T, TKey>> entityKey,string value)
        {
            return null;
        }
        public T getByID(decimal id)
        {
            return null;
        }
        public bool insertRecord(T entity)
        {
            return false;
        }
        public bool updateRecord(T entity)
        {
            return false;
        }
        public bool deleteRecord(T entity)
        {
            return false;
        }
        public bool deleteRecordByID(decimal id)
        {
            return false;
        }
        public bool deleteRecordByName<TKey>(Expression<Func<T, TKey>> entityKey, string value)
        {
            return false;
        }
    }
}
