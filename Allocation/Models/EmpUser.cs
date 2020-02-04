using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class EmpUser
    {
        public EmpUser()
        {
            EmpSkill = new HashSet<EmpSkill>();
            EmpSubSkill = new HashSet<EmpSubSkill>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string OrgUnit { get; set; }
        public string JobTitle { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public int? Status { get; set; }
        public double? TAllocation { get; set; }

        public string Password { get; set; }

        public virtual FoClient Client { get; set; }
        public virtual ICollection<EmpSkill> EmpSkill { get; set; }
        public virtual ICollection<EmpSubSkill> EmpSubSkill { get; set; }
    }
}
