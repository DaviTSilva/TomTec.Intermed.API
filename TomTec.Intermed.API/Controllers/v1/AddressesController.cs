using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.API.DTOs;
using TomTec.Intermed.Data;
using TomTec.Intermed.Lib.AspNetCore;
using TomTec.Intermed.Lib.AspNetCore.Filters;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.Controllers.v1
{
    [Authorization]
    [Route("v1/addresses")]
    public class AddressesController : Controller
    {
        private readonly IRepository<Address> _addressRepository;

        public AddressesController(IRepository<Address> addressRepository)
        {
            this._addressRepository = addressRepository;
        }

        [HttpGet("")]
        public IActionResult GetAddresses()
        {
            var adresses = _addressRepository.Get();
            return Ok(new
            {
                message = ResponseMessage.Success,
                value = adresses
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetAddress(int id)
        {
            var address = _addressRepository.Get(id);
            return Ok(new
            {
                message = ResponseMessage.Success,
                value = address
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdress([FromBody] AddressDto dto, int id)
        {
            var address = dto.ToModel();
            address.Id = id;
            _addressRepository.Update(address);
            return Ok(new
            {
                message = ResponseMessage.Success,
            });
        }
    }
}
