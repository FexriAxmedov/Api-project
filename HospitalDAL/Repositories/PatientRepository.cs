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
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDBContext _dbContext;
        public PatientRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public Patient AddPatient(Patient obj)
        {
            _dbContext.Patients.Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }
        public List<Patient> GetPatients()
        {
            var patients = _dbContext.Patients.ToList();
            return patients;
        }
        public Patient GetPatientById(int id)
        {
            var patient = _dbContext.Patients.Find(id);
            return patient;
        }
        public Patient UpdatePatient(Patient patient)
        {
            var dbPatient = _dbContext.Patients.Find(patient.Id);
            dbPatient.Name = patient.Name;
            dbPatient.EmailAddress = patient.EmailAddress;
            dbPatient.PhoneNumber = patient.PhoneNumber;
            dbPatient.PatientUsername = patient.PatientUsername;
            dbPatient.Password = patient.Password;
            dbPatient.Address = patient.Address;
            dbPatient.BloodType = patient.BloodType;


            _dbContext.Patients.Update(dbPatient);
            _dbContext.SaveChanges();
            return patient;
        }
        public void DeletePatient(Patient patient)
        {
            _dbContext.Patients.Remove(patient);
            _dbContext.SaveChanges();

        }
    }
}