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
    public class HospitalRepository:IHospitalRepository
    {
        private readonly AppDBContext _dbContext;
        public HospitalRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public Hospital AddHospital(Hospital obj)
        {
            _dbContext.Hospitals.Add(obj);  
            _dbContext.SaveChanges(); 
            return obj;
        }
        public List<Hospital> GetHospitals()
        {
            var hospitals = _dbContext.Hospitals.ToList();
            return hospitals;
        }
        public Hospital GetHospitalById(int id)
        {
            var hospital = _dbContext.Hospitals.Find(id);
            return hospital;
        }
        public Hospital UpdateHospital(Hospital hospital)
        {
            var dbHospital = _dbContext.Hospitals.Find(hospital.Id);
            dbHospital.Name = hospital.Name;
            dbHospital.Place=hospital.Place;
            dbHospital.Type=hospital.Type;
            dbHospital.Description = hospital.Description;
            dbHospital.Address = hospital.Address;

            _dbContext.Hospitals.Update(dbHospital);
            _dbContext.SaveChanges();
            return hospital;
        }
        public void DeleteHospital(Hospital hospital)
        {
            _dbContext.Hospitals.Remove(hospital);
            _dbContext.SaveChanges();

        }
    }
}
