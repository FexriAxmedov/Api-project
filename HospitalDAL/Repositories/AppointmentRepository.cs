using HospitalDAL.Data;
using HospitalDAL.DBModel;
using HospitalDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Repositories
{
    public class AppointmentRepository:IAppointmentRepository
    {
        private readonly AppDBContext _dbContext;
        public AppointmentRepository(AppDBContext dBContext) 
        {
            _dbContext=dBContext;
        }
        public Appointment AddAppointment(Appointment obj)
        {
            _dbContext.Appointments.Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }

    }
}
