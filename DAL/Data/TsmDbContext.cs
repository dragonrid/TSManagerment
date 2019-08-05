using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class TsmDbContext : TSMEntities
    {
        private Dictionary<Type, object> dicRepositories = new Dictionary<Type, object>();

        public TsmDbContext(string connectionString) : base(connectionString)
        {
            dicRepositories.Add(typeof(Customer), tbl_customers);
            dicRepositories.Add(typeof(User), tbl_users);
            dicRepositories.Add(typeof(tbl_customers), Customers);
            dicRepositories.Add(typeof(tbl_users), Users);
        }
        public override DbSet<TEntity> Set<TEntity>()
        {
            return (DbSet<TEntity>)dicRepositories[typeof(TEntity)];
            
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
