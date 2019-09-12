using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface ITSMUnitOfWork
    {
        UserRepository userRepository { get; }
        CustomerRepository customerRepository { get; }

        void SaveChange();
    }
}
