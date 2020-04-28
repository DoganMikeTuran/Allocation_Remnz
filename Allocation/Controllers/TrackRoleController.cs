using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allocation.DTO;
using Allocation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Allocation.Controllers
{
    [Route("api/[controller]")]
    public class TrackRoleController : Controller
    {
        private readonly remnz1Context _context;

        public TrackRoleController(remnz1Context context)
        {
            _context = context;

        }

        [HttpGet("{clientid}/{projectid}")]

        public async Task<ActionResult<IEnumerable<DTO_PrTrack>>> GetTracknameRolename(int clientid, int projectid)
        
        {
            var myList = await _context.PrTrack.Where(x => x.ClientId == clientid && x.ProjectId == projectid).Include(e => e.TrackRole).Where(e => e.ProjectId == projectid).ToListAsync();

            var result = await _context.PrTrack
    .Where(x => x.ClientId == clientid && x.ProjectId == projectid)
    .SelectMany(track => track.TrackRole)
    .Select(trackRole => new DTO_PrTrack
    {
     
        RoleName = trackRole.FoRole.Name,
        TrackName = trackRole.PrTrack.Name,
        Startdate = trackRole.PrTrack.Startdate,
        Enddate = trackRole.PrTrack.Enddate,
    })
    .ToListAsync();

            var emptyResults = await _context.PrTrack
    .Where(x => x.ClientId == clientid && x.ProjectId == projectid)
    .Where(track => !track.TrackRole.Any())
    .Select(track => new DTO_PrTrack
    {
        TrackName = track.Name,
        Startdate = track.Startdate,
        Enddate = track.Enddate,
    })
    .ToListAsync();
            var concattedList = result.Concat(emptyResults).ToList();

            return concattedList;
        }

        [HttpPost]
        public async Task<ActionResult<TrackRole>> PostTrackRole([FromBody]TrackRole trackRole)
        {

            _context.TrackRole.Add(trackRole);
           
            await _context.SaveChangesAsync();

            return trackRole;
        }

        [HttpDelete("{trackid}/{clientid}/{roleid}")]
        public async Task<ActionResult<TrackRole>> DeleteTrackRole(int trackid, int clientid, int roleid)
        {

            var trackRole = await _context.TrackRole.SingleOrDefaultAsync(x => x.TrackId == trackid && x.ClientId == clientid && x.RoleId == roleid);
            if (trackRole == null)
            {
                return NotFound();
            }

            _context.TrackRole.Remove(trackRole);
            await _context.SaveChangesAsync();

            return trackRole;
        }
    }
}
