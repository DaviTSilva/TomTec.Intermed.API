using System;
using System.Collections.Generic;
using System.Text;

namespace TomTec.Intermed.Models
{
    public class Signature : BaseEntity
    {
        public int HealthProfessionalId { get; set; }
        public HealthProfessional HealthProfessional { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime Expire { get; set; }
        public bool IsPayed { get; set; }
        public bool IsFreeTrial { get; set; }
        public bool IsCancelled { get; set; } = false;
        public bool IsYearlyPack { get; set; }
        public double Value { get; set; }
        public int SignatureTypeId { get; set; }
        public SignatureType SignatureType { get; set; }

        public Signature(int healthProfessionalId, HealthProfessional healthProfessional, DateTime startingDate, DateTime expire, bool isPayed, bool isFreeTrial, bool isCancelled, bool isYearlyPack, double value, int signatureTypeId, SignatureType signatureType)
        {
            HealthProfessionalId = healthProfessionalId;
            HealthProfessional = healthProfessional;
            StartingDate = startingDate;
            Expire = expire;
            IsPayed = isPayed;
            IsFreeTrial = isFreeTrial;
            IsCancelled = isCancelled;
            IsYearlyPack = isYearlyPack;
            Value = value;
            SignatureTypeId = signatureTypeId;
            SignatureType = signatureType;
        }

        public Signature()
        {
        }

        public Signature(Signature signature)
        {
            HealthProfessionalId = signature.HealthProfessionalId;
            HealthProfessional = signature.HealthProfessional;
            Expire = signature.Expire;
            IsPayed = signature.IsPayed;
            IsFreeTrial = signature.IsFreeTrial;
            IsCancelled = signature.IsCancelled;
            IsYearlyPack = signature.IsYearlyPack;
            Value = signature.Value;
            SignatureTypeId = signature.SignatureTypeId;
            SignatureType = signature.SignatureType;
        }
    }
}
