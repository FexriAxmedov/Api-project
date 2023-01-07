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
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }
        [HttpPost]
        public ActionResult<Hospital> Create(Hospital hospital)
        {

            var response = _hospitalRepository.AddHospital(hospital);
            return Ok(response);
        }
        [HttpGet]
        public List<Hospital> GetHospitals()
        {
            var response = _hospitalRepository.GetHospitals();
            return response;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Hospital> GetHospitalById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var response = _hospitalRepository.GetHospitalById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public ActionResult<Hospital> Update(int id, [FromBody] Hospital obj)
        {
            if (id == 0 || id != obj.Id)
            {
                return BadRequest();
            }
            var response = _hospitalRepository.GetHospitalById(id);
            if (response == null)
            {
                return NotFound();
            }
            response = _hospitalRepository.UpdateHospital(obj);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var response = _hospitalRepository.GetHospitalById(id);
            if (response == null)
            {
                return NotFound();
            }
            _hospitalRepository.DeleteHospital(response);
            return NoContent();
        }
    }
}
