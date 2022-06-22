using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomTec.Intermed.Data;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.Business
{
    public class SignatureService : ISignatureService
    {
        #region Props

        private const int AVALIATION_MONTHS = 2;
        private const double PREMIUM_MONTHLY_PRICE = 120;
        private const double BASIC_MONTHLY_PRICE = 60;
        private const double PRICE_OFF_YEARLY = 0.10;

        private readonly int BasicTypeId = 1;
        private readonly int PremiumTypeId = 2;


        private IRepository<SignatureType> _signatureTypeRepository;
        private IRepository<Signature> _signatureRepository;

        #endregion

        #region Constructors

        public SignatureService(IRepository<SignatureType> signatureTypeRepository, IRepository<Signature> signatureRepository)
        {
            _signatureTypeRepository = signatureTypeRepository;
            _signatureRepository = signatureRepository;
            try
            {
                BasicTypeId = _signatureTypeRepository.Get(st => st.Name.Equals("Basic")).FirstOrDefault().Id;
                BasicTypeId = _signatureTypeRepository.Get(st => st.Name.Equals("Premium")).FirstOrDefault().Id;
            }
            catch
            {
                BasicTypeId = 1;
                PremiumTypeId = 2;
            }
        }

        #endregion

        public Signature GenerateFreeTrial(int healthProfessionalId, int signatureTypeId)
        {
            var startingDate = CalculateStartingDate(healthProfessionalId);
            var expire = startingDate.AddMonths(AVALIATION_MONTHS).AddDays(1);
            return new Signature() {
                HealthProfessionalId = healthProfessionalId,
                StartingDate = startingDate,
                Expire = expire,
                IsPayed = true,
                IsFreeTrial = true,
                IsCancelled = false,
                IsYearlyPack = false,
                Value = 0d,
                SignatureTypeId = signatureTypeId,
            };
        }

        public Signature Generate(int healthProfessionalId, int signatureTypeId, bool isYearlyPack)
        {
            double value = signatureTypeId == PremiumTypeId ? CalculatePremiumYearlyPrice() : CalculateBasicYearlyPrice();
            var startingDate = CalculateStartingDate(healthProfessionalId);
            var expire = isYearlyPack ? startingDate.AddYears(1).AddDays(1) : startingDate.AddMonths(1).AddDays(1);

            return new Signature()
            {
                HealthProfessionalId = healthProfessionalId,
                StartingDate = startingDate,
                Expire = expire,
                IsPayed = false,
                IsFreeTrial = false,
                IsCancelled = false,
                Value = value,
                IsYearlyPack = isYearlyPack,
                SignatureTypeId = signatureTypeId,
            };
        }

        public Signature Renew(int healthProfessionalId)
        {
            var oldSignature = _signatureRepository.Get(s => s.HealthProfessionalId == healthProfessionalId)
                .Where(s => s.IsCancelled == false)
                .OrderByDescending(s => s.Expire)
                .FirstOrDefault();

            var newSignature = new Signature(oldSignature);           
            UpdateToNewSignature(newSignature);

            return newSignature;
        }
        

        #region Helpers

        private static double CalculatePremiumYearlyPrice()
        {
            return PREMIUM_MONTHLY_PRICE * 12 - (PREMIUM_MONTHLY_PRICE * PRICE_OFF_YEARLY);
        }

        private static double CalculateBasicYearlyPrice()
        {
            return BASIC_MONTHLY_PRICE * 12 - (BASIC_MONTHLY_PRICE * PRICE_OFF_YEARLY);
        }

        private DateTime CalculateStartingDate(int healthProfessionalId)
        {
            try
            {
                var oldSign = _signatureRepository.Get(s => s.HealthProfessionalId == healthProfessionalId)
                    .Where(s => s.IsCancelled == false)
                    .OrderByDescending(s => s.Expire)
                    .FirstOrDefault();

                if(oldSign == null)
                {
                    return DateTime.UtcNow;
                }

                return oldSign.Expire.AddDays(1);
            }
            catch
            {
                return DateTime.UtcNow;
            }
        }

        private void UpdateToNewSignature(Signature newSignature)
        {
            var value = newSignature.SignatureTypeId == PremiumTypeId ? CalculatePremiumYearlyPrice() : CalculateBasicYearlyPrice();
            var startingDate = CalculateStartingDate(newSignature.HealthProfessionalId);
            var expire = newSignature.IsYearlyPack ? startingDate.AddYears(1).AddDays(1) : startingDate.AddMonths(1).AddDays(1);

            newSignature.StartingDate = startingDate;
            newSignature.Expire = expire;
            newSignature.Value = value;
            newSignature.IsFreeTrial = false;
            newSignature.IsPayed = false;
            newSignature.IsCancelled = false;
        }

        #endregion
    }
}
