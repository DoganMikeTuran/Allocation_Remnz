using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class FoClient
    {
        public FoClient()
        {
            EmpSkill = new HashSet<EmpSkill>();
            EmpSubSkill = new HashSet<EmpSubSkill>();
            EmpUser = new HashSet<EmpUser>();
            FoSkill = new HashSet<FoSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AutoId { get; set; }

        public virtual ICollection<EmpSkill> EmpSkill { get; set; }
        public virtual ICollection<EmpSubSkill> EmpSubSkill { get; set; }
        public virtual ICollection<EmpUser> EmpUser { get; set; }
        public virtual ICollection<FoSkill> FoSkill { get; set; }
    }
}
