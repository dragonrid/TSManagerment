using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private TSMEntities _tsmEntity;
        public void Init(TSMEntities tsmEntity)
        {
            if (tsmEntity == null) throw new ArgumentNullException("TSMEntity");
            this._tsmEntity = tsmEntity;
        }

        public bool deleteRecord(User user)
        {
            bool result = false;
            try
            {
                var record = _tsmEntity.tbl_users.Single(s => s.user_name == user.User_name);
                _tsmEntity.tbl_users.Remove(record);
                _tsmEntity.SaveChanges();
                result = true;
                return result;
            }
            catch { return result; }
        }

        public bool deleteRecordByID(decimal id)
        {
            bool result = false;
            try
            {
                var record = _tsmEntity.tbl_users.Single(s => s.id == id);
                _tsmEntity.tbl_users.Remove(record);
                _tsmEntity.SaveChanges();
                result = true;
                return result;
            }
            catch { return result; }
        }

        public bool deleteRecordByName(string userName)
        {
            bool result = false;
            try
            {
                var record = _tsmEntity.tbl_users.Single(s => s.user_name == userName);
                _tsmEntity.tbl_users.Remove(record);
                _tsmEntity.SaveChanges();
                result = true;
                return result;
            }
            catch { return result; }
        }

        public User getByID(decimal id)
        {
            return _tsmEntity.tbl_users.Where(w=>w.id == id).Select(s => new User
            {
                Id = s.id,
                User_name = s.user_name,
                Full_name = s.full_name,
                Password = s.password,
                Role = s.role,
                Permission = s.permission,
                Is_active = s.is_active
            }).FirstOrDefault();
        }

        public User getByName(string userName)
        {
            return _tsmEntity.tbl_users.Where(w => w.user_name == userName).Select(s => new User
            {
                Id = s.id,
                User_name = s.user_name,
                Full_name = s.full_name,
                Password = s.password,
                Role = s.role,
                Permission = s.permission,
                Is_active = s.is_active
            }).FirstOrDefault();
        }

        public List<User> getList()
        {
            return _tsmEntity.tbl_users.Select(s => new User
            {
                Id= s.id,
                User_name = s.user_name,
                Full_name = s.full_name,
                Password = s.password,
                Role = s.role,
                Permission = s.permission,
                Is_active = s.is_active
            }).ToList();
        }        

        public bool insertRecord(User user)
        {
            bool result = false;
            try
            {
                tbl_users _User = new tbl_users();
                _User.id = user.Id;
                _User.user_name = user.User_name;
                _User.password = user.Password;
                _User.role = user.Role;
                _User.permission = user.Permission;
                _User.is_active = user.Is_active;
                _tsmEntity.tbl_users.Add(_User);
                _tsmEntity.SaveChanges();
                result = true;
                return result;
            }
            catch { return result; }
        }

        public bool updateRecord(User user)
        {
            bool result = false;
            try
            {
                var record = _tsmEntity.tbl_users.Single(s => s.user_name == user.User_name);
                record.password = user.Password;
                record.role = user.Role;
                record.permission = user.Permission;
                record.is_active = user.Is_active;
                _tsmEntity.Set<tbl_users>().AddOrUpdate(record);
                _tsmEntity.SaveChanges();
                result = true;
                return result;
            }
            catch { return result; }
        }
    }
}
