using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[HttpGet("{c}")]
        //public async Task<ActionResult<IEnumerable<FoSubSkill>>> Get(int clientid)
        //{
        //    return await _context.FoSubSkill.Where(x => x.ClientId == fosubskill.ClientId && x.SkillId == fosubskill.SkillId).ToListAsync();
        //}

        //[HttpGet("{clientid}/{skillid}")]
        //[Authorize]
        //public async Task<ActionResult<IEnumerable<FoSubSkill>>> getAllSubSkillBySkillId([FromBody]int clientid, int skillid)
        //{

        //    return await _context.FoSubSkill.Where(x => x.ClientId == clientid && x.SkillId == skillid).ToListAsync();


        //}


        //[HttpPost("{get}")]

        //public async Task<ActionResult<IEnumerable<FoSubSkill>>> getAllSubSkillBySkillId([FromBody]FoSubSkill fosubskill)
        //{

        //    return await _context.FoSubSkill.Where(x => x.ClientId == fosubskill.ClientId && x.SkillId == fosubskill.SkillId).ToListAsync();


        //}

        [HttpGet("{clientid}/{skillid}")]

        public async Task<ActionResult<IEnumerable<FoSubSkill>>> Getai(int clientid, int skillid)
        {
            return await _context.FoSubSkill.Where(x => x.ClientId == clientid && x.SkillId == skillid).ToListAsync();
        }

        [HttpPost]
      
        public void Post([FromBody]FoSubSkill fosubskill) 
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

       

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
