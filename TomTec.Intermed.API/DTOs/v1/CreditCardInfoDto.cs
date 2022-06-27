using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.DTOs.v1
{
    public class CreditCardInfoDto
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Expire { get; set; }
        public string OwnerName { get; set; }
        public string CVV { get; set; }

        public CreditCardInfo ToModel()
        {
            return new CreditCardInfo()
            {
                Name = this.Name,
                Number = this.Number,
                Expire = this.Expire,
                OwnerName = this.OwnerName,
                CVV = this.CVV,
                FourLastNumbers = this.Number.Substring(this.Number.Length - 4),
            };
        }
    }
}
