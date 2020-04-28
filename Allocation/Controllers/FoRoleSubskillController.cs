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
    public class FoRoleSubskillController : Controller
    {
        private readonly remnz1Context _context;

        public FoRoleSubskillController(remnz1Context context)
        {
            _context = context;

        }
        [HttpGet("{clientid}/{roleid}")]

        public async Task<ActionResult<IEnumerable<FoRoleSubSkill>>> GetSubSkillsByRoleId(int clientid, int roleid)
        {
            return await _context.FoRoleSubSkill.Where(x => x.ClientId == clientid && x.RoleId == roleid).Include(e => e.FoSubSkill).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<FoRoleSubSkill>> PostUserSubskill([FromBody]FoRoleSubSkill forolesubskill)
        {

            _context.FoRoleSubSkill.Add(forolesubskill);
            forolesubskill.Proficiency = 100;
            
            await _context.SaveChangesAsync();

            return forolesubskill;
        }



        [HttpPut("{roleid}/{subskillid}/{clientid}/{proficiency}")]
        public async Task<ActionResult<FoRoleSubSkill>> PutRoleSubSkillProficiency(int roleid, int subskillid, int clientid, int proficiency)
        {
            var updatedFoRoleSubSkill = _context.FoRoleSubSkill.First(x => x.RoleId == roleid && x.SubSkillId == subskillid && x.ClientId == clientid);
            updatedFoRoleSubSkill.Proficiency = proficiency;

            await _context.SaveChangesAsync();
            return updatedFoRoleSubSkill;

        }

        // DELETE api/values/5
        [HttpDelete("{roleid}/{clientid}/{subskillid}")]
        public async Task<ActionResult<FoRoleSubSkill>> DeleteFoRoleSubSkill(int roleid, int clientid, int subskillid)
        {

            var roleSubSkill = await _context.FoRoleSubSkill.SingleOrDefaultAsync(x => x.RoleId == roleid && x.ClientId == clientid && x.SubSkillId == subskillid);
            if (roleSubSkill == null)
            {
                return NotFound();
            }

            _context.FoRoleSubSkill.Remove(roleSubSkill);
            await _context.SaveChangesAsync();

            return roleSubSkill;
        }

    }
}
