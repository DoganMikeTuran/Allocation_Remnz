using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allocation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Allocation.Controllers
{
    [Route("api/[controller]")]
    public class TrackController : Controller
    {
        private readonly remnz1Context _context;

        public TrackController(remnz1Context context)
        {
            _context = context;

        }

        // GET: api/values
        [HttpGet("{clientid}/{projectid}")]

        public async Task<ActionResult<IEnumerable<PrTrack>>> GetTrackByProjectId(int clientid, int projectid)
        {
            return await _context.PrTrack.Where(x => x.ClientId == clientid && x.ProjectId == projectid).ToListAsync();

        }

        [HttpPost]
        public string Post([FromBody]PrTrack prtrack)
        {
            
           _context.PrTrack.Add(prtrack);
            _context.SaveChanges();
            return prtrack.Id.ToString();
        }

    }
}
