using HospitalDAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Interfaces
{
    public interface IAppointmentRepository
    {
        public Appointment AddAppointment(Appointment obj);
    }
}
