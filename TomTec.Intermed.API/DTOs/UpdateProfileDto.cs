using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.Lib.Utils;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.DTOs
{
    public class UpdateProfileDto
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
        public int AddressId { get; set; }


        public User ToModel()
        {
            string salt = HashHelper.GeneratePasswordSalt();
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
                AddressId = this.AddressId,
            };
            user.UsersClaims = this.ClaimsIds.Select(id => new UsersClaims() { ClaimId = id, User = user }).ToList();

            return user;
        }
    }
}
