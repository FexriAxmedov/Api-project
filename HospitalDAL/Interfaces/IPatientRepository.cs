using HospitalDAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Interfaces
{
    public interface IPatientRepository
    {
        public Patient AddPatient(Patient obj);
        public List<Patient> GetPatients();
        public Patient GetPatientById(int id);
        public Patient UpdatePatient(Patient patient);
        public void DeletePatient(Patient patient);
    }
}
