using HospitalDAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Interfaces
{
    public interface IHospitalRepository
    {
        public Hospital AddHospital(Hospital obj);
        public List<Hospital> GetHospitals();
        public Hospital GetHospitalById(int id);
        public Hospital UpdateHospital(Hospital hospital);
        public void DeleteHospital(Hospital hospital);
    }
}

