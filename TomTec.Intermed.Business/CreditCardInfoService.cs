using System;
using System.Collections.Generic;
using System.Text;
using TomTec.Intermed.Lib.Utils;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.Business
{
    public class CreditCardInfoService : ICreditCardInfoService
    {
        public void Decrypt(CreditCardInfo creditCardInfo)
        {
            var cryptService = new CryptographyService();
            creditCardInfo.Number = cryptService.Decrypt(creditCardInfo.Number);
            creditCardInfo.Expire = cryptService.Decrypt(creditCardInfo.Expire);
            creditCardInfo.OwnerName = cryptService.Decrypt(creditCardInfo.OwnerName);
            creditCardInfo.CVV = cryptService.Decrypt(creditCardInfo.CVV);
        }

        public void Encrypt(CreditCardInfo creditCardInfo)
        {
            var cryptService = new CryptographyService();
            creditCardInfo.Number = cryptService.Encrypt(creditCardInfo.Number);
            creditCardInfo.Expire = cryptService.Encrypt(creditCardInfo.Expire);
            creditCardInfo.OwnerName = cryptService.Encrypt(creditCardInfo.OwnerName);
            creditCardInfo.CVV = cryptService.Encrypt(creditCardInfo.CVV);
        }
    }
}
