using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allocation.DTO;
using Allocation.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]FoSkill foskill)
        {
           _context.FoSkill.Add(foskill);
            _context.SaveChangesAsync();
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
