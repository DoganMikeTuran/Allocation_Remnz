using System;
using System.Collections.Generic;
using Allocation.Models;

namespace Allocation.DTO
{
    public class DTO_SubSkill
    {
        public DTO_SubSkill()
        {
            FoRoleSubSkill = new HashSet<FoRoleSubSkill>();
            UserSubSkill = new HashSet<UserSubSkill>();
        }
        
        public int ClientId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SkillName { get; set; }
        public int? IdealProficiency { get; set; }

        public virtual ICollection<FoRoleSubSkill> FoRoleSubSkill { get; set; }
        public virtual ICollection<UserSubSkill> UserSubSkill { get; set; }
        public virtual FoSkill FoSkill { get; set; }

    }
}
