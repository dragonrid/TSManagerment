using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace Services
{
    public class CustomerServices : BaseServices, ICustomerServices
    {
        public bool deleteRecord(Customer customer)
        {
            return getDB().customerRepository.deleteRecord(customer);
        }

        public bool deleteRecordByID(decimal id)
        {
            return getDB().customerRepository.deleteRecordByID(id);
        }

        public bool deleteRecordByName(string shortName)
        {
            return getDB().customerRepository.deleteRecordByName(shortName);
        }

        public Customer getByContract(string contract)
        {
            return getDB().customerRepository.getByContract(contract);
        }

        public Customer getByID(decimal id)
        {
            return getDB().customerRepository.getByID(id);
        }

        public Customer getByName(string shortName)
        {
            return getDB().customerRepository.getByName(shortName);
        }

        public List<Customer> getList()
        {
            return getDB().customerRepository.getList();
        }

        public bool insertRecord(Customer customer)
        {
            return getDB().customerRepository.insertRecord(customer);
        }

        public bool updateRecord(Customer customer)
        {
            return getDB().customerRepository.updateRecord(customer);
        }
    }
}
