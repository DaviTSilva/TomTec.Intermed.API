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
using TomTec.Intermed.Lib.Utils;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.Controllers.v1
{
    [Authorization]
    [ServiceFilter(typeof(KeyNotFoundExceptionFilterAttribute))]
    [ServiceFilter(typeof(UnauthorizedAccessExceptionFilterAttribute))]
    [ServiceFilter(typeof(GenericExceptionFilterAttribute))]
    [Route("v1/credit-card-infos")]
    public class CreditCardInfoController : Controller
    {
        private IRepository<CreditCardInfo> _creditCardInfoRepository;
        private IRepository<HealthProfessional> _healthProInfoRepository;
        private ICreditCardInfoService _creditCardInfoService;
        private JwtService _jwtService;

        public CreditCardInfoController(IRepository<CreditCardInfo> creditCardInfoRepository, IRepository<HealthProfessional> healthProInfoRepository, ICreditCardInfoService creditCardInfoService)
        {
            _creditCardInfoRepository = creditCardInfoRepository;
            _healthProInfoRepository = healthProInfoRepository;
            _creditCardInfoService = creditCardInfoService;
            _jwtService = new JwtService();
        }

        [HttpGet("")]
        public IActionResult GetCreditCardInfo()
        {
            var creditCardInfos = _creditCardInfoRepository.Get();

            return Ok(new {
                message = ResponseMessage.Success,
                value = creditCardInfos,
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetCreditCardInfo(int id)
        {
            var creditCardInfo = _creditCardInfoRepository.Get(id);

            return Ok(new
            {
                message = ResponseMessage.Success,
                value = creditCardInfo,
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCreditCardinfo(int id, [FromBody] CreditCardInfoDto dto)
        {
            var model = dto.ToModel();
            model.Id = id;
            _creditCardInfoService.Encrypt(model);
            _creditCardInfoRepository.Update(model);

            return Ok(new {
                message = ResponseMessage.Success
            });
        }

        [HttpGet("{id}/decrypted")]
        public IActionResult GetCreditCardInfoDecrypt(int id)
        {
            var creditCardInfo = _creditCardInfoRepository.Get(id);
            VerifyAccess(id);
            _creditCardInfoService.Decrypt(creditCardInfo);

            return Ok(new
            {
                message = ResponseMessage.Success,
                value = creditCardInfo,
            });
        }

        private void VerifyAccess(int creditCardInfoId)
        {
            var jwtToken = Request.Cookies["token"];
            var token = _jwtService.Verify(jwtToken);
            int currentUserId = int.Parse(token.Issuer);

            var userId = _healthProInfoRepository.Get(h => h.CreditCardInfoId == creditCardInfoId).FirstOrDefault().UserId;
            if(userId != currentUserId)
            {
                throw new UnauthorizedAccessException($"User with Id '{currentUserId}' tried to access credit card information which belongs to user {userId}");
            }
        }
    }
}
