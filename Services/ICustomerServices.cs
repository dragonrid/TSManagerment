﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerServices
    {
        List<Customer> getList();
        Customer getByName(string shortName);
        Customer getByID(decimal id);
        Customer getByContract(string contract);
        bool insertRecord(Customer customer);
        bool updateRecord(Customer customer);
        bool deleteRecord(Customer customer);
        bool deleteRecordByID(decimal id);
        bool deleteRecordByName(string shortName);
    }
}
