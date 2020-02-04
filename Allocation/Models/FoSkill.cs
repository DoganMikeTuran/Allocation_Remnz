using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class FoSkill
    {
        public FoSkill()
        {
            EmpSkill = new HashSet<EmpSkill>();
            FoSubSkill = new HashSet<FoSubSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }

        public virtual FoClient Client { get; set; }
        public virtual ICollection<EmpSkill> EmpSkill { get; set; }
        public virtual ICollection<FoSubSkill> FoSubSkill { get; set; }
    }
}
