using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TomTec.Intermed.Models
{
    /// <summary>
    /// This class is needed for the many-to-many relationship between Roles and Users
    /// </summary>
    public class UsersClaims
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ClaimId { get; set; }
        public Claim Claim { get; set; }

        public System.Security.Claims.Claim ToSecurityClaim()
        {
            return new System.Security.Claims.Claim(Claim.Name, UserId.ToString());
        }
    }
}
