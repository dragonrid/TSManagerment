using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseServices
    {
        protected virtual string connectionString => ConfigurationServices.ConnectionString;

        protected ITSMUnitOfWork getDB()
        {
            return new TSMUnitOfWork(connectionString);
        }
    }
}
