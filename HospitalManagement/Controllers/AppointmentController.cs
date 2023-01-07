using HospitalDAL.DBModel;
using HospitalDAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [HttpGet]
        public List<Appointment> GetAppointments()
        {
            var response=_appointmentRepository.GetAppointments();
            return response;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Appointment> GetAppointmentById(int id)
        {
         if (id == 0)
            {
                return BadRequest();
            }
            var response = _appointmentRepository.GetAppointmentById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public ActionResult<Appointment> Update(int id,[FromBody]Appointment obj)
        {
            if (id == 0 || id!=obj.Id)
            {
                return BadRequest();
            }
            var response = _appointmentRepository.GetAppointmentById(id);
            if (response == null)
            {
                return NotFound();
            }
            response=_appointmentRepository.UpdateAppointment(obj);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0 )
            {
                return BadRequest();
            }
            var response = _appointmentRepository.GetAppointmentById(id);
            if (response == null)
            {
                return NotFound();
            }
      _appointmentRepository.DeleteAppointment(response); 
            return NoContent(); 
        }
    }
 }

