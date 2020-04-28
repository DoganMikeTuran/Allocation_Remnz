using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class FoClient
    {
        public FoClient()
        {
            FoRole = new HashSet<FoRole>();
            FoRoleSubSkill = new HashSet<FoRoleSubSkill>();
            FoSkill = new HashSet<FoSkill>();
            FoSubSkill = new HashSet<FoSubSkill>();
            PrProject = new HashSet<PrProject>();
            PrTrack = new HashSet<PrTrack>();
            TrackRole = new HashSet<TrackRole>();
            User = new HashSet<User>();
            UserSubSkill = new HashSet<UserSubSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FoRole> FoRole { get; set; }
        public virtual ICollection<FoRoleSubSkill> FoRoleSubSkill { get; set; }
        public virtual ICollection<FoSkill> FoSkill { get; set; }
        public virtual ICollection<FoSubSkill> FoSubSkill { get; set; }
        public virtual ICollection<PrProject> PrProject { get; set; }
        public virtual ICollection<PrTrack> PrTrack { get; set; }
        public virtual ICollection<TrackRole> TrackRole { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<UserSubSkill> UserSubSkill { get; set; }
    }
}
