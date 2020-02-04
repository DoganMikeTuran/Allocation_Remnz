using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allocation.Models
{
    public class UserWithToken
    {
        public UserWithToken(EmpUser empuser)
        {
            this.empuser = empuser;
        }

        public string Token { get; internal set; }
        public EmpUser empuser { get; set; }


    }
}
