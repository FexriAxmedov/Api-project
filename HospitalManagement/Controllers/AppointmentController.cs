using HospitalDAL.DBModel;
using HospitalDAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpPost]
        public ActionResult<Appointment> Create(Appointment appointment)
        {
             
       var response=_appointmentRepository.AddAppointment(appointment);
            return Ok(response);
        }
    }
}
