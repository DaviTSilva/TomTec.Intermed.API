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
    [Route("v1/service-types")]
    public class ServiceTypeController : Controller
    {
        public IRepository<ServiceType> _serviceTypeRepository;

        public ServiceTypeController(IRepository<ServiceType> serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        [HttpGet("")]
        public IActionResult GetServiceType()
        {
            var specialties = _serviceTypeRepository.Get();

            return Ok(new
            {
                message = ResponseMessage.Success,
                value = specialties,
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetServiceType(int id)
        {
            var ServiceType = _serviceTypeRepository.Get(id);

            return Ok(new
            {
                message = ResponseMessage.Success,
                value = ServiceType,
            });
        }

        [HttpPost("")]
        public IActionResult CreateServiceType([FromBody] ServiceTypeDto dto)
        {
            var ServiceType = _serviceTypeRepository.Create(dto.ToModel());

            return Created(ResponseMessage.Success, ServiceType);
        }

        [HttpPut("{id}")]
        public IActionResult GetServiceType(int id, [FromBody] ServiceTypeDto dto)
        {
            var model = dto.ToModel();
            model.Id = id;
            _serviceTypeRepository.Update(model);

            return Ok(new
            {
                message = ResponseMessage.Success,
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteServiceType(int id)
        {
            _serviceTypeRepository.Delete(id);

            return Ok(new
            {
                message = ResponseMessage.Success,
            });
        }
    }
}
