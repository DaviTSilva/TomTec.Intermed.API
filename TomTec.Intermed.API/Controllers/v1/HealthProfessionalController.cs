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
    [KeyNotFoundExceptionFilter]
    [UnauthorizedAccessExceptionFilter]
    [GenericExceptionFilter]
    [Route("v1/health-professionals")]
    public class HealthProfessionalController : Controller
    {
        private IRepository<HealthProfessional> _healthProfessionalRepository;

        public HealthProfessionalController(IRepository<HealthProfessional> healthProfessionalRepository)
        {
            _healthProfessionalRepository = healthProfessionalRepository;
        }

        [HttpPost("")]
        public IActionResult CreateHealthProfessional([FromBody] HealthProfessionalDto dto)
        {
            var healthProfessional = _healthProfessionalRepository.Create(dto.toModel());

            return Created(ResponseMessage.Success, healthProfessional);
        }

        [HttpGet("")]
        public IActionResult GetHealthProfessionals()
        {
            var healthProfessionals = _healthProfessionalRepository.Get(
                h => h.ServiceType,
                h => h.ConsultingAddress, 
                h => h.ContactCard, 
                h => h.CreditCardInfo) ;

            return Ok(new {
                message = ResponseMessage.Success,
                value = healthProfessionals,
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetHealthProfessionals(int id)
        {
            var healthProfessional = _healthProfessionalRepository.Get(id, 
                h => h.ServiceType,
                h => h.ConsultingAddress,
                h => h.ContactCard,
                h => h.CreditCardInfo);

            return Ok(new{
                message = ResponseMessage.Success,
                value = healthProfessional,
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHealthProfessional([FromBody] UpdateHealthProfessionalDto dto, int id)
        {
            var model = dto.toModel();
            model.Id = id;
            _healthProfessionalRepository.Update(model);

            return Ok(new { 
                message = ResponseMessage.Success,
            });
        }
    }
}
