using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.API.DTOs.v1;
using TomTec.Intermed.Data;
using TomTec.Intermed.Lib.AspNetCore;
using TomTec.Intermed.Lib.AspNetCore.Filters;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.Controllers.v1
{
    [Authorization]
    [ServiceFilter(typeof(KeyNotFoundExceptionFilterAttribute))]
    [ServiceFilter(typeof(UnauthorizedAccessExceptionFilterAttribute))]
    [ServiceFilter(typeof(GenericExceptionFilterAttribute))]
    [Route("v1/specialties")]
    public class SpecialtyController : Controller
    {
        public IRepository<Specialty> _specialtyRepository;

        public SpecialtyController(IRepository<Specialty> specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        [HttpGet("")]
        public IActionResult GetSpecialty()
        {
            var specialties = _specialtyRepository.Get();

            return Ok(new 
            { 
                message = ResponseMessage.Success,
                value = specialties,
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetSpecialty(int id)
        {
            var specialty = _specialtyRepository.Get(id);

            return Ok(new
            {
                message = ResponseMessage.Success,
                value = specialty,
            });
        }

        [HttpPost("")]
        public IActionResult CreateSpecialty([FromBody] SpecialtyDto dto)
        {
            var specialty = _specialtyRepository.Create(dto.ToModel());

            return Created(ResponseMessage.Success, specialty);
        }

        [HttpPut("{id}")]
        public IActionResult GetSpecialty(int id, [FromBody] SpecialtyDto dto)
        {
            var model = dto.ToModel();
            model.Id = id;
            _specialtyRepository.Update(model);

            return Ok(new
            {
                message = ResponseMessage.Success,
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpecialty(int id)
        {
            _specialtyRepository.Delete(id);

            return Ok(new
            {
                message = ResponseMessage.Success,
            });
        }
    }
}
