using DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ConfigurationServices
    {
        private static string _connectionString;
        public static string ConnectionString => _connectionString;

        public static void Init(string servername,string dbname,string passsql,string usersql)
        {
            Configuration.Init(servername, dbname, passsql, usersql);
        }
    }
}
