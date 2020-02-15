using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class FoRole
    {
        public FoRole()
        {
            FoRoleSubSkill = new HashSet<FoRoleSubSkill>();
        }

        public int ClientId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual FoClient Client { get; set; }
        public virtual ICollection<FoRoleSubSkill> FoRoleSubSkill { get; set; }
    }
}
