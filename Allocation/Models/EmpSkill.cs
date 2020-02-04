using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class EmpSkill
    {
        public int SkillId { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }

        public virtual FoClient Client { get; set; }
        public virtual EmpUser EmpUser { get; set; }
        public virtual FoSkill FoSkill { get; set; }
    }
}
