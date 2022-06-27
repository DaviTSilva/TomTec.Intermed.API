using Microsoft.AspNetCore.Http;
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
    [Route("v1/contact-cards")]
    public class ContactCardController : Controller
    {
        private IRepository<ContactCard> _contactCardRepository;

        public ContactCardController(IRepository<ContactCard> contactCardRepository)
        {
            _contactCardRepository = contactCardRepository;
        }

        [HttpGet("")]
        public IActionResult GetContactCards()
        {
            var contactCards = _contactCardRepository.Get();

            return Ok(new { 
                message = ResponseMessage.Success,
                value = contactCards,
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetContactCards(int id)
        {
            var contactCards = _contactCardRepository.Get(id);

            return Ok(new
            {
                message = ResponseMessage.Success,
                value = contactCards,
            });
        }

        [HttpPut("{id}")]
        public IActionResult GetContactCards(int id, [FromBody] ContactCardDto dto)
        {
            var model = dto.ToModel();
            model.Id = id;
            _contactCardRepository.Update(model);

            return Ok(new
            {
                message = ResponseMessage.Success,
            });
        }
    }
}
