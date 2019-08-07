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
            if (!string.IsNullOrWhiteSpace(_connectionString)) return;
            else
            {
                SqlConnectionStringBuilder sqlStringBuilder = new SqlConnectionStringBuilder();
                sqlStringBuilder.DataSource = servername;
                sqlStringBuilder.InitialCatalog = dbname;
                sqlStringBuilder.Password = EncryptDecryptServices.DecryptString(passsql, "Th41$0nJSC");
                sqlStringBuilder.UserID = usersql;
                sqlStringBuilder.PersistSecurityInfo = true;
                sqlStringBuilder.MultipleActiveResultSets = true;
                sqlStringBuilder.ConnectTimeout = 600;
                sqlStringBuilder.ApplicationName = "EntityFramework";

                EntityConnectionStringBuilder entityStringBuilder = new EntityConnectionStringBuilder();
                entityStringBuilder.ProviderConnectionString = sqlStringBuilder.ConnectionString;
                entityStringBuilder.Provider = "System.Data.SqlClient";
                entityStringBuilder.Metadata = "res://*/TSM.csdl|res://*/TSM.ssdl|res://*/TSM.msl"; 
                _connectionString = entityStringBuilder.ConnectionString;
            }
        }
    }
}
