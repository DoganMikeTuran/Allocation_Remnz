using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class PrTrack
    {
        public PrTrack()
        {
            TrackRole = new HashSet<TrackRole>();
        }

        public int ClientId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public long ProjectId { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual FoClient Client { get; set; }
        public virtual PrProject PrProject { get; set; }
        public virtual ICollection<TrackRole> TrackRole { get; set; }
    }
}
