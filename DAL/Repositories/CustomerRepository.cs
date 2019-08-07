using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private TSMEntities _tsmEntity;
        public void Init(TSMEntities tsmEntity)
        {
            if (tsmEntity == null) throw new ArgumentNullException("TSMEntity");
            this._tsmEntity = tsmEntity;
        }

        public bool deleteRecord(Customer customer)
        {
            bool result = false;
            try
            {
                var record = _tsmEntity.tbl_customers.Single(s => s.short_name == customer.Short_name);
                _tsmEntity.tbl_customers.Remove(record);
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
                var record = _tsmEntity.tbl_customers.Single(s => s.id == id);
                _tsmEntity.tbl_customers.Remove(record);
                _tsmEntity.SaveChanges();
                result = true;
                return result;
            }
            catch { return result; }
        }

        public bool deleteRecordByName(string shortName)
        {
            bool result = false;
            try
            {
                var record = _tsmEntity.tbl_customers.Single(s => s.short_name == shortName);
                _tsmEntity.tbl_customers.Remove(record);
                _tsmEntity.SaveChanges();
                result = true;
                return result;
            }
            catch { return result; }
        }

        public Customer getByContract(string contract)
        {
            return _tsmEntity.tbl_customers.Where(w => w.contract == contract).Select(s => new Customer
            {
                Id = s.id,
                Short_name = s.short_name,
                Com_name = s.com_name,
                Com_addr = s.com_addr,
                Contact_name = s.contact_name,
                Contact_phone = s.contact_phone,
                Contract = s.contract,
                Contract_date = s.contract_date,
                Note = s.note
            }).FirstOrDefault();
        }

        public Customer getByID(decimal id)
        {
            return _tsmEntity.tbl_customers.Where(w => w.id == id).Select(s => new Customer
            {
                Id = s.id,
                Short_name = s.short_name,
                Com_name = s.com_name,
                Com_addr = s.com_addr,
                Contact_name = s.contact_name,
                Contact_phone = s.contact_phone,
                Contract = s.contract,
                Contract_date = s.contract_date,
                Note = s.note
            }).FirstOrDefault();
        }

        public Customer getByName(string shortName)
        {
            return _tsmEntity.tbl_customers.Where(w => w.short_name == shortName).Select(s => new Customer
            {
                Id = s.id,
                Short_name = s.short_name,
                Com_name = s.com_name,
                Com_addr = s.com_addr,
                Contact_name = s.contact_name,
                Contact_phone = s.contact_phone,
                Contract = s.contract,
                Contract_date = s.contract_date,
                Note = s.note
            }).FirstOrDefault();
        }

        public List<Customer> getList()
        {
            return _tsmEntity.tbl_customers.Select(s => new Customer
            {
                Id = s.id,
                Short_name = s.short_name,
                Com_name = s.com_name,
                Com_addr = s.com_addr,
                Contact_name = s.contact_name,
                Contact_phone = s.contact_phone,
                Contract = s.contract,
                Contract_date = s.contract_date,
                Note = s.note
            }).ToList();
        }

        
        public bool insertRecord(Customer customer)
        {
            bool result = false;
            try
            {
                tbl_customers _Customer = new tbl_customers();
                _Customer.id = customer.Id;
                _Customer.short_name = customer.Short_name;
                _Customer.com_name = customer.Com_name;
                _Customer.com_addr = customer.Com_addr;
                _Customer.contact_name = customer.Contact_name;
                _Customer.contact_phone = customer.Contact_phone;
                _Customer.contract = customer.Contract;
                _Customer.contract_date = customer.Contract_date;
                _Customer.note = customer.Note;
                _tsmEntity.tbl_customers.Add(_Customer);
                _tsmEntity.SaveChanges();
                result = true;
                return result;
            }
            catch { return result; }
        }

        public bool updateRecord(Customer customer)
        {
            bool result = false;
            try
            {
                var record = _tsmEntity.tbl_customers.Single(s => s.short_name == customer.Short_name);
                record.com_name = customer.Com_name;
                record.com_addr = customer.Com_addr;
                record.contact_name = customer.Contact_name;
                record.contact_phone = customer.Contact_phone;
                record.contract = customer.Contract;
                record.contract_date = customer.Contract_date;
                record.note = customer.Note;
                _tsmEntity.Set<tbl_customers>().AddOrUpdate(record);
                _tsmEntity.SaveChanges();
                result = true;
                return result;
            }
            catch { return result; }
        }
    }
}
