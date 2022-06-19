using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.Records.v1
{
    public class UserListRecord
    {
        public UserListRecord(IEnumerable<User> users)
        {
            Users = users;
        }

        public IEnumerable<User> Users { get; set; }
    }
}
