using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public Customer getCustomerByContract(string contract)
        {
            return null;
        }
    }
}
