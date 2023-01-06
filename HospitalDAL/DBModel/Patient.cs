﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.DBModel
{
    public class Patient:BaseEntity
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PatientUsername { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
    }
}
