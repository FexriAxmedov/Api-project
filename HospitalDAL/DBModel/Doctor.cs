using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.DBModel
{
    public class Doctor:BaseEntity
    {
        public string Name { get; set; }
        public string Field { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
