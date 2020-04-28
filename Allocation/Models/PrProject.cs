using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class PrProject
    {
        public PrProject()
        {
            PrTrack = new HashSet<PrTrack>();
        }

        public int ClientId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public bool? Template { get; set; }

        public virtual FoClient Client { get; set; }
        public virtual ICollection<PrTrack> PrTrack { get; set; }
    }
}
