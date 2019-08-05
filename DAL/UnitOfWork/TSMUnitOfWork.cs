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

        public TSMUnitOfWork(string connectionString)
        {
            _tsmContext = new TSMEntities(connectionString);
            _userRepository = new UserRepository();
            _userRepository.Init(_tsmContext);
            _customerRepository = new CustomerRepository();
            _customerRepository.Init(_tsmContext);
        }
        public UserRepository userRepository => _userRepository;

        public CustomerRepository customerRepository => _customerRepository;

    }
}
