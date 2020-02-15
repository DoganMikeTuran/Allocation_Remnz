using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class FoRoleSubSkill
    {
        public int ClientId { get; set; }
        public int RoleId { get; set; }
        public int SubSkillId { get; set; }
        public int Proficiency { get; set; }

        public virtual FoClient Client { get; set; }
        public virtual FoRole FoRole { get; set; }
        public virtual FoSubSkill FoSubSkill { get; set; }
    }
}
