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
    public class RoleController : Controller
    {
        private readonly remnz1Context _context;

        public RoleController(remnz1Context context)
        {
            _context = context;

        }
        // GET: api/values
        [HttpGet("{clientid}")]

        public async Task<ActionResult<IEnumerable<FoRole>>> GetAllRolesByClientId(int clientid)
        {
            return await _context.FoRole.Where(x => x.ClientId == clientid).ToListAsync();
        }

        [HttpGet("get/{clientid}/{trackid}")]
        public async Task<IEnumerable<DTO_FoRole>> GetAllRolesIncludingTrackRole(int clientid, int trackid)
        {
            return await _context.FoRole.Where(x => x.ClientId == clientid).Include(e => e.TrackRole)
            .Select(role => new DTO_FoRole
            {
                Id = role.Id,
                Name = role.Name,
                ClientId = role.ClientId,
                Startdate = role.Startdate,
                Enddate = role.Enddate,
                Template = role.Template,
                TrackRole = role.TrackRole.Where(s => s.TrackId == trackid).Select(x => new TrackRole
                {
                    
                    RoleId = x.RoleId,
                    TrackId = x.TrackId,
                    ClientId = x.ClientId
                }).ToList(),
            }).ToListAsync();

        }

        [HttpPost]
        public FoRole Post([FromBody]FoRole forole)
        {

            forole.Template = true;
            _context.FoRole.Add(forole);
            
            _context.SaveChanges();
            return forole;
        }
    }
}
