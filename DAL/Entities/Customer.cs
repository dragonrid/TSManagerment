using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Customer : IEntity
    {
        public decimal Id { get; set; }
        public string Short_name { get; set; }
        public string Com_name { get; set; }
        public string Com_addr { get; set; }
        public string Contact_name { get; set; }
        public string Contact_phone { get; set; }
        public string Contract { get; set; }
        public DateTime? Contract_date { get; set; }
        public string Note { get; set; }
    }
}
