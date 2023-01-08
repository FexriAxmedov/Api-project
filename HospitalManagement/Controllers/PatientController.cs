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
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        [HttpPost]
        public ActionResult<Patient> Create(Patient patient)
        {

            var response = _patientRepository.AddPatient(patient);
            return Ok(response);
        }
        [HttpGet]
        public List<Patient> GetPatients()
        {
            var response = _patientRepository.GetPatients();
            return response;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Patient> GetPatientById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var response = _patientRepository.GetPatientById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public ActionResult<Patient> Update(int id, [FromBody] Patient obj)
        {
            if (id == 0 || id != obj.Id)
            {
                return BadRequest();
            }
            var response = _patientRepository.GetPatientById(id);
            if (response == null)
            {
                return NotFound();
            }
            response = _patientRepository.UpdatePatient(obj);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var response = _patientRepository.GetPatientById(id);
            if (response == null)
            {
                return NotFound();
            }
            _patientRepository.DeletePatient(response);
            return NoContent();
        }
    }
}
