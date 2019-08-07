using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace Services
{
    public class UserServices : BaseServices, IUserServices
    {
        public bool deleteRecord(User user)
        {
            return getDB().userRepository.deleteRecord(user);
        }

        public bool deleteRecordByID(decimal id)
        {
            return getDB().userRepository.deleteRecordByID(id);
        }

        public bool deleteRecordByName(string userName)
        {
            return getDB().userRepository.deleteRecordByName(userName);
        }

        public User getByID(decimal id)
        {
            return getDB().userRepository.getByID(id);
        }

        public User getByName(string userName)
        {
            return getDB().userRepository.getByName(userName);
        }

        public List<User> getList()
        {
            return getDB().userRepository.getList();
        }

        public bool insertRecord(User user)
        {
            return getDB().userRepository.insertRecord(user);
        }

        public bool updateRecord(User user)
        {
            return getDB().userRepository.updateRecord(user);
        }
        public bool checkLogin(string userName, string password)
        {
            User user = new User();
            user = getByName(userName);
            if(user == null || user.Password != password)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DataTable getAllUser()
        {
            return ToDataTable<User>(getList());
        }
        private DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }
    }
}
