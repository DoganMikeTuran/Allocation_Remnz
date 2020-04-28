using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allocation.DTO;
using Allocation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Allocation.Controllers
{
    [Route("api/[controller]")]
    public class SubSkillController : Controller
    {
        private readonly remnz1Context _context;

        public SubSkillController(remnz1Context context)
        {
            _context = context;

        }

        [HttpGet("{clientid}/{skillid}")]

        public async Task<ActionResult<IEnumerable<FoSubSkill>>> GetSubSkillsBySkillid(int clientid, int skillid)
        {
            return await _context.FoSubSkill.Where(x => x.ClientId == clientid && x.SkillId == skillid).ToListAsync();
        }


        [HttpGet("get/{roleid}/{clientid}")]
        public async Task<IEnumerable<DTO_SubSkill>> GetAllSubSkillWithIncluding(int roleid, int clientid)
        {
            return await _context.FoSubSkill.Where(x => x.ClientId == clientid).Include(e => e.FoRoleSubSkill).Include(e => e.FoSkill)
            .Select(subskill => new DTO_SubSkill
            {
                Id = subskill.Id,
                Name = subskill.Name,
                ClientId = subskill.ClientId,
                SkillName = subskill.FoSkill.Name,
                FoRoleSubSkill = subskill.FoRoleSubSkill.Where(s => s.RoleId == roleid).Select(x => new FoRoleSubSkill
                {
                    Proficiency = x.Proficiency,
                    RoleId = x.RoleId,
                    SubSkillId = x.SubSkillId,
                    ClientId = x.ClientId
                }).ToList(),
            }).ToListAsync();

        }

        [HttpPost]
      
        public void PostSubSkill([FromBody]FoSubSkill fosubskill) 
        {
            try
            {
                _context.FoSubSkill.Add(fosubskill);

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            
        }
    }
}
