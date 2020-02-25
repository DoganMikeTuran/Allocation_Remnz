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
    public class SkillController : Controller
    {
        private readonly remnz1Context _context;

        public SkillController(remnz1Context context)
        {
            _context = context;

        }

        // GET: api/values
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<FoSkill>>> getAllSkills()
        {
            return await _context.FoSkill.ToListAsync();

        }
        
        //[HttpGet("{get}")]
        //public async Task<ActionResult<IEnumerable<FoSkill>>> getAllSkillsByClientId([FromBody]FoSkill foskill)
        //{
        //    return await _context.FoSkill.Where(x => x.ClientId == foskill.ClientId).ToListAsync();


        //}

        // GET api/values/5
        [HttpGet("{clientid}")]
        
        public async Task<ActionResult<IEnumerable<FoSkill>>> Get(int clientid)
        {
            return await _context.FoSkill.Where(x => x.ClientId == clientid).ToListAsync();
        }

     
       [HttpPost]
        public string Post([FromBody]FoSkill foskill)
        {
            _context.FoSkill.Add(foskill);
            _context.SaveChanges();
            return foskill.Id.ToString();
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
