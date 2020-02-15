using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class UserSubSkill
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public int SubSkillId { get; set; }
        public int? Proficiency { get; set; }

        public virtual FoClient Client { get; set; }
        public virtual FoSubSkill FoSubSkill { get; set; }
        public virtual User User { get; set; }
    }
}
