using System;
using System.Collections.Generic;
using System.Text;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.Business
{
    public interface ICreditCardInfoService
    {
        void Encrypt(CreditCardInfo creditCardInfo);
        void Decrypt(CreditCardInfo creditCardInfo);

    }
}
