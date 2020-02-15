using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class User
    {
        public User()
        {
            UserSubSkill = new HashSet<UserSubSkill>();
        }

        public int ClientId { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual FoClient Client { get; set; }
        public virtual ICollection<UserSubSkill> UserSubSkill { get; set; }
    }
}
