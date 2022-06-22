using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.API.DTOs.v1;
using TomTec.Intermed.Business;
using TomTec.Intermed.Data;
using TomTec.Intermed.Lib.AspNetCore;
using TomTec.Intermed.Lib.AspNetCore.Filters;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.Controllers.v1
{
    [Authorization]
    [Route("v1/signatures")]
    public class SignatureController : Controller
    {
        private IRepository<Signature> _signatureRepository;
        private ISignatureService _signatureService;

        public SignatureController(IRepository<Signature> signatureRepository)
        {
            _signatureRepository = signatureRepository;
        }

        [HttpPost("")]
        public IActionResult CreateSignature([FromBody] SignatureDto dto)
        {
            var model = _signatureRepository.Create(_signatureService.Generate(dto.HealthProfessionalId, dto.SignatureTypeId, dto.isYearlyPack));
            return Created(ResponseMessage.Success, model);
        }

        [HttpPost("renew/{healthProId}")]
        public IActionResult RenewSignature(int healthProId)
        {
            var model = _signatureRepository.Create(_signatureService.Renew(healthProId));
            return Created(ResponseMessage.Success, model);
        }

        [HttpPost("free-trial")]
        public IActionResult CreateFreeTrialSignature([FromBody] SignatureFreeTrialDto dto)
        {
            var model = _signatureRepository.Create(_signatureService.GenerateFreeTrial(dto.HealthProfessionalId, dto.SignatureTypeId));
            return Created(ResponseMessage.Success, model);
        }

        [HttpGet("")]
        public IActionResult GetSignature()
        {
            var signatures = _signatureRepository.Get(s => s.IsCancelled == false,
                s => s.HealthProfessional,
                s => s.SignatureType);

            return Ok(new { 
                message = ResponseMessage.Success,
                value = signatures
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetSignature(int id)
        {
            var signature = _signatureRepository.Get(id,
                s => s.HealthProfessional,
                s => s.SignatureType);

            return Ok(new
            {
                message = ResponseMessage.Success,
                value = signature
            });
        }

        [HttpDelete("{id}")]
        public IActionResult CancellSignature(int id)
        {
            _signatureRepository.Cancell(id);

            return Ok(new { 
                message = ResponseMessage.Success,
            });
        }
    }
}
