using System;
using Allocation.Models;

namespace Allocation.DTO
{
    public class DTO_PrTrack
    {
        
        public string RoleName { get; set; }
        public string TrackName { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
    }
}
