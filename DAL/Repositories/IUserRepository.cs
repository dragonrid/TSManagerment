using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        void Init(TSMEntities tsmEntity);
        List<User> getList();
        User getByName(string userName);
        User getByID(decimal id);
        bool insertRecord(User user);
        bool updateRecord(User user);
        bool deleteRecord(User user);
        bool deleteRecordByID(decimal id);
        bool deleteRecordByName(string userName);
    }
}
