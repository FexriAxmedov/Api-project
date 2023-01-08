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
    public class DoctorRepository:IDoctorRepository
    {
        private readonly AppDBContext _dbContext;
        public DoctorRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public Doctor AddDoctor(Doctor obj)
        {
            _dbContext.Doctors.Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }
        public List<Doctor> GetDoctors()
        {
            var doctors = _dbContext.Doctors.ToList();
            return doctors;
        }
        public Doctor GetDoctorById(int id)
        {
            var doctor = _dbContext.Doctors.Find(id);
            return doctor;
        }
        public Doctor UpdateDoctor(Doctor doctor)
        {
            var dbDoctor = _dbContext.Doctors.Find(doctor.Id);
            dbDoctor.Name = doctor.Name;
            dbDoctor.Field = doctor.Field;
            dbDoctor.PhoneNumber = doctor.PhoneNumber;
            dbDoctor.EmailAddress = doctor.EmailAddress;
            dbDoctor.UserName = doctor.UserName;
            dbDoctor.Password = doctor.Password;
            dbDoctor.Address = doctor.Address;

            _dbContext.Doctors.Update(dbDoctor);
            _dbContext.SaveChanges();
            return doctor;
        }
        public void DeleteDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Remove(doctor);
            _dbContext.SaveChanges();

        }
    }
}
