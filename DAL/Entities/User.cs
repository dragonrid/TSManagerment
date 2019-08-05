using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User : IEntity
    {
        public decimal Id { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }
        public string Full_name { get; set; }
        public int Role { get; set; }
        public string Permission { get; set; }
        public bool Is_active { get; set; }
    }
}
