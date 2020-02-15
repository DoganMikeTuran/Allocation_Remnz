using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allocation.Models
{
    public class UserWithToken
    {
        public UserWithToken(User empuser)
        {
            this.firstname = empuser.Firstname;
            this.lastname = empuser.Lastname;
            
        }

        public string Token { get; internal set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        


    }
}
