using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<T> where T :  class
    {
        void Init(TSMEntities tsmEntity);
        List<T> getList();
        T getSingle();
        T getByName<TKey>(Expression<Func<T, TKey>> entityKey, string value);
        T getByID(decimal id);
        bool insertRecord(T entity);
        bool updateRecord(T entity);
        bool deleteRecord(T entity);
        bool deleteRecordByID(decimal id);
        bool deleteRecordByName<TKey>(Expression<Func<T, TKey>> entityKey, string value);
    }
}
