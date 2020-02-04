using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class FoSubSkill
    {
        public FoSubSkill()
        {
            EmpSubSkill = new HashSet<EmpSubSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }
        public int SkillId { get; set; }

        public virtual FoSkill FoSkill { get; set; }
        public virtual ICollection<EmpSubSkill> EmpSubSkill { get; set; }
    }
}
