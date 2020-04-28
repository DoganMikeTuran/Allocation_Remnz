using System;
using System.Collections.Generic;

namespace Allocation.Models
{
    public partial class TrackRole
    {
        public int ClientId { get; set; }
        public int RoleId { get; set; }
        public long TrackId { get; set; }

        public virtual FoClient Client { get; set; }
        public virtual FoRole FoRole { get; set; }
        public virtual PrTrack PrTrack { get; set; }
    }
}
