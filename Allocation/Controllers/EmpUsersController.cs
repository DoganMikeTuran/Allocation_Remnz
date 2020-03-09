using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Allocation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Allocation.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmpUsersController : ControllerBase
    {
        private readonly remnz1Context _context;

        public EmpUsersController(remnz1Context context)
        {
            _context = context;
            
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetEmpUserList()
        //{
        //    var UserWithUserSKills = await _context.User.Include(x => x.UserSubSkill).ToListAsync();
        //    return UserWithUserSKills;
        //}
        [HttpGet("{subskillid}/{clientid}")]
        public async Task<ActionResult<IEnumerable<User>>> GetEmpUserList(int subskillid, int clientid)
        {
            var UsersBySubSkill = _context.User.Select(user => new User
            {
                Id = user.Id,
                Username = user.Username,
                Lastname = user.Lastname,
                Firstname = user.Firstname,
                ClientId = user.ClientId,

                UserSubSkill = user.UserSubSkill.Where(s => s.SubSkillId == subskillid).ToList(),
            }).Where(x => x.ClientId == clientid);


            return await UsersBySubSkill.ToListAsync();
        }

        // GET: api/EmpUsers/5

        //[HttpGet("GetEmpUserDetails/{id}")]
        //[Authorize]
        //public ActionResult<User> GetEmpUserDetails(int id)
        //{
        //    var empUser = _context.User
        //        .Include(user => user.UserSubSkill)
        //            .ThenInclude(subskill => subskill.FoSubSkill)
        //        .Where(user => user.Id == id).FirstOrDefault();

        //    return empUser;
        //}

        [HttpPost("PostEmpUserDetails/")]
        public ActionResult<User> PostEmpUserDetails()
        {
            var empuser = new User();

            empuser.ClientId = 7;
            empuser.Firstname = "Dogan";
            

            _context.User.Add(empuser);
            _context.SaveChanges();





            var empUser = _context.User
                .Where(user => user.Id == empuser.Id).FirstOrDefault();



            return empUser;
        }

        // GET: api/EmpUsers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetEmpUser(int id)
        //{
        //    var empUser = await _context.User.FindAsync(id);

        //    if (empUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return empUser;
        //}

        // PUT: api/EmpUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpUser(int id, User empUser)
        {
            if (id != empUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(empUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmpUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
       
        [HttpPost]
        [Authorize]
        public User PostEmpUser(User empUser)
        {
         
            _context.User.Add(empUser);
             _context.SaveChangesAsync();

            return empUser;
        }

        // DELETE: api/EmpUsers/5
        [HttpDelete("{id}/{clientid}")]
        public async Task<ActionResult<User>> DeleteEmpUser(int id, int clientid)
        {
            
            var empUser = await _context.User.SingleOrDefaultAsync(x => x.Id == id && x.ClientId == clientid);
            if (empUser == null)
            {
                return NotFound();
            }

            _context.User.Remove(empUser);
            await _context.SaveChangesAsync();

            return empUser;
        }

        private bool EmpUserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
