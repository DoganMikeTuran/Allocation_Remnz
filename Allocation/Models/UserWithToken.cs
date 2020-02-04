using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allocation.Models
{
    public class UserWithToken
    {
        public UserWithToken(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string Token { get; internal set; }
        public string firstname { get; set; }
        public string lastname { get; set; }


    }
}
