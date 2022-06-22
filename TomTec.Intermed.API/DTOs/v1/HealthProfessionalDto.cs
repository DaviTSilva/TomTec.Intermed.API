using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.Business;
using TomTec.Intermed.Lib.Utils;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.DTOs.v1
{
    public class HealthProfessionalDto
    {
        public int UserId { get; set; }
        public int ServiceTypeId { get; set; }
        public int SpecialtyId { get; set; }
        public string Description { get; set; }

        //Address
        public string Street { get; set; }
        public string Number { get; set; }
        public string AdditionalInformation { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryName { get; set; }

        //Contacts
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Link { get; set; }
        public string CelphoneNumber { get; set; }

        //CreditCardInfo
        public string CreditCardName { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardExpire { get; set; }
        public string CreditCardOwnerName { get; set; }
        public string CreditCardCVV { get; set; }

        public HealthProfessional toModel()
        {
            var model = new HealthProfessional()
            {
                UserId = this.UserId,
                ServiceTypeId = this.ServiceTypeId,
                Description = this.Description,
                ContactCard = new ContactCard()
                {
                    Email = this.Email,
                    Phone = this.Phone,
                    Link = this.Link,
                    CelphoneNumber = this.CelphoneNumber,
                    CreationDate = DateTime.UtcNow,
                },
                ConsultingAddress = new Address()
                {
                    Street = this.Street,
                    Number = this.Number,
                    AdditionalInformation = this.AdditionalInformation,
                    PostalCode = this.PostalCode,
                    City = this.City,
                    State = this.State,
                    CountryName = this.CountryName,
                    CreationDate = DateTime.UtcNow,
                },
                Rate = 0,
                CreditCardInfo = new CreditCardInfo()
                {
                    Name = CreditCardName,
                    Number = this.CreditCardNumber,
                    Expire = this.CreditCardExpire,
                    OwnerName = this.CreditCardOwnerName,
                    CVV = CreditCardCVV,
                    CreationDate = DateTime.UtcNow,
                },
            };
            new CreditCardInfoService().Encrypt(model.CreditCardInfo);
            return model;
        }
    }
}
