using System;
using System.Collections.Generic;
using System.Text;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.Business
{
    public interface ISignatureService
    {
        Signature GenerateFreeTrial(int HealthProfessionalId, int signatureTypeId, bool isYearlyPack);
        Signature Generate(int healthProfessionalId, int signatureTypeId, bool isYearlyPack);
        Signature Renew(int healthProfessionalId);
    }
}
