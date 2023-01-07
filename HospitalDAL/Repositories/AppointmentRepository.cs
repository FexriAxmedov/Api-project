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
        public  List<Appointment> GetAppointments()
        {
            var appointments = _dbContext.Appointments.ToList();
            return appointments;
        }
        public Appointment GetAppointmentById(int id)
        {
            var appointment = _dbContext.Appointments.Find(id);
            return appointment;
        }
        public Appointment UpdateAppointment(Appointment appointment)
        {
            var dbAppointment = _dbContext.Appointments.Find(appointment.Id);
            dbAppointment.AppointmentNumber = appointment.AppointmentNumber;
            dbAppointment.PhoneNumber = appointment.PhoneNumber;
            dbAppointment.AppointmentType = appointment.AppointmentType;
            dbAppointment.AppointmentDate = appointment.AppointmentDate;
            dbAppointment.Description = appointment.Description;


            _dbContext.Appointments.Update(dbAppointment);
            _dbContext.SaveChanges();
            return appointment;
        }
        public void DeleteAppointment(Appointment appointment)
        {
            _dbContext.Appointments.Remove(appointment);
            _dbContext.SaveChanges();

        }
    }
}
