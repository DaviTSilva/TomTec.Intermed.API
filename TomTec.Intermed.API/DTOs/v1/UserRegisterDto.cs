﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomTec.Intermed.Lib.Utils;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.DTOs.v1
{
    public class UserRegisterDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public IEnumerable<int> ClaimsIds { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfilePictureURL { get; set; }

        //Address
        public string Street { get; set; }
        public string Number { get; set; }
        public string AdditionalInformation { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryName { get; set; }


        public User ToModel()
        {
            string salt = HashHelper.GenerateSalt();
            string password = BCrypt.Net.BCrypt.HashPassword(this.Password, salt);
            var user = new User()
            {
                UserName = this.UserName,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Password = password,
                PasswordSalt = salt,
                UserTypeId = this.UserTypeId,
                BirthDate = this.BirthDate,
                ProfilePictureURL = this.ProfilePictureURL,
                Address = new Address()
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
            };
            user.UsersClaims = this.ClaimsIds.Select(id => new UsersClaims() { ClaimId = id, User = user }).ToList();

            return user;
        }
    }
}
