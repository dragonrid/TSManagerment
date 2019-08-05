using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class DbMapper 
    {
        private IMapper mapper;
        public IMapper Mapping { get => mapper; }
        public DbMapper()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<tbl_users, User>();
                config.CreateMap<User, tbl_users>();
                config.CreateMap<tbl_customers, Customer>();
                config.CreateMap<Customer, tbl_customers>();
            });
            mapper = mapperConfig.CreateMapper();
        }
    }
}
