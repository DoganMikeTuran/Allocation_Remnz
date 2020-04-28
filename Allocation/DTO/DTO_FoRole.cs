using System;
using System.Collections.Generic;
using Allocation.Models;

namespace Allocation.DTO
{
    public class DTO_FoRole
    {
        public DTO_FoRole()
        {
            FoRoleSubSkill = new HashSet<FoRoleSubSkill>();
            TrackRole = new HashSet<TrackRole>();
        }
        public int ClientId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TrackName { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public Boolean Template { get; set; }

        public virtual FoClient Client { get; set; }
        public virtual ICollection<FoRoleSubSkill> FoRoleSubSkill { get; set; }
        public virtual ICollection<TrackRole> TrackRole { get; set; }
    }
}
