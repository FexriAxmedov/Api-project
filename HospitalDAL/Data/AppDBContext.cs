using HospitalDAL.DBModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions opts)
            :base(opts) 
        {

        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }

    }
}
