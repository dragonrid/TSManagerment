using DAL.Data;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class TSMUnitOfWork : ITSMUnitOfWork 
    {
        private UserRepository _userRepository;
        private CustomerRepository _customerRepository;
        private TSMEntities _tsmContext;

        public TSMUnitOfWork()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            _tsmContext = new TSMEntities(Configuration.ConnectionString);
            _userRepository = new UserRepository();
            _userRepository.Init(_tsmContext);
            _customerRepository = new CustomerRepository();
            _customerRepository.Init(_tsmContext);
        }
        public UserRepository userRepository => _userRepository;

        public CustomerRepository customerRepository => _customerRepository;

        public void SaveChange()
        {

        }
    }
}
