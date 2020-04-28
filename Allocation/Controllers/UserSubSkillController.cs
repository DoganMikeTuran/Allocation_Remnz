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
    public class UserSubSkillController : Controller
    {
        private readonly remnz1Context _context;

        public UserSubSkillController(remnz1Context context)
        {
            _context = context;

        }
     

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<UserSubSkill>> PostUserSubskill([FromBody]UserSubSkill userSubSkill)
        {

            _context.UserSubSkill.Add(userSubSkill);
            userSubSkill.Proficiency = 100;
           await _context.SaveChangesAsync();

            return userSubSkill;
        }

        
        [HttpPut("{id}/{subskillid}/{clientid}/{proficiency}")]
        public async Task<ActionResult<UserSubSkill>> PutEmpUser(int id, int subskillid, int clientid, int proficiency)
        {
            var updatedUserSubSkill = _context.UserSubSkill.First(x => x.UserId == id && x.SubSkillId == subskillid && x.ClientId == clientid);
            updatedUserSubSkill.Proficiency = proficiency;

            await _context.SaveChangesAsync();
            return updatedUserSubSkill;

        }

        // DELETE api/values/5
        [HttpDelete("{id}/{clientid}/{subskillid}")]
        public async Task<ActionResult<UserSubSkill>> DeleteUserSubSkill(int id, int clientid, int subskillid)
        {

            var empUser = await _context.UserSubSkill.SingleOrDefaultAsync(x => x.UserId == id && x.ClientId == clientid && x.SubSkillId == subskillid);
            if (empUser == null)
            {
                return NotFound();
            }

            _context.UserSubSkill.Remove(empUser);
            await _context.SaveChangesAsync();

            return empUser;
        }
    }
}
