using HospitalDAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Interfaces
{
    public interface IDoctorRepository
    {
        public Doctor AddDoctor(Doctor obj);
        public List<Doctor> GetDoctors();
        public Doctor GetDoctorById(int id);
        public Doctor UpdateDoctor(Doctor doctor);
        public void DeleteDoctor(Doctor doctor);
    }
}
