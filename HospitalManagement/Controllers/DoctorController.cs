using HospitalDAL.DBModel;
using HospitalDAL.Interfaces;
using HospitalDAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        [HttpPost]
        public ActionResult<Doctor> Create(Doctor doctor)
        {

            var response = _doctorRepository.AddDoctor(doctor);
            return Ok(response);
        }
        [HttpGet]
        public List<Doctor> GetDoctors()
        {
            var response = _doctorRepository.GetDoctors();
            return response;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Doctor> GetDoctorById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var response = _doctorRepository.GetDoctorById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public ActionResult<Doctor> Update(int id, [FromBody] Doctor obj)
        {
            if (id == 0 || id != obj.Id)
            {
                return BadRequest();
            }
            var response = _doctorRepository.GetDoctorById(id);
            if (response == null)
            {
                return NotFound();
            }
            response = _doctorRepository.UpdateDoctor(obj);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var response = _doctorRepository.GetDoctorById(id);
            if (response == null)
            {
                return NotFound();
            }
            _doctorRepository.DeleteDoctor(response);
            return NoContent();
        }
    }
}
