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
        // Her opretter vi en instans af klassen vi har lavet
        private readonly JWTSettings _jwtsettings;

        public EmpUsersController(remnz1Context context, IOptions<JWTSettings> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
        }

        [HttpGet("Login/")]
        public async Task<ActionResult<UserWithToken>> Login([FromBody] EmpUser empuser)
        {
            empuser = await _context.EmpUser
                .Include(e => e.EmpSkill)
                .Where(e => e.Email == empuser.Email && e.Password == e.Password)
                .FirstOrDefaultAsync();
            UserWithToken userWithToken = new UserWithToken(empuser);

            if(userWithToken == null)
            {
                return NotFound();
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, empuser.Email)
                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userWithToken.Token = tokenHandler.WriteToken(token);

            return userWithToken;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpUser>>> GetEmpUserList()
        {
            var UserWithUserSKills = await _context.EmpUser.Include(x => x.EmpSkill).Include(x => x.EmpSubSkill).ToListAsync();
            return UserWithUserSKills;
        }

        // GET: api/EmpUsers/5
        
        [HttpGet("GetEmpUserDetails/{id}")]
        public async Task<ActionResult<EmpUser>> GetEmpUserDetails(int id) 
        {
            var empUser = _context.EmpUser
                .Include(user => user.EmpSkill)
                    .ThenInclude(skill => skill.FoSkill)
                .Include(user => user.EmpSubSkill)
                    .ThenInclude(subskill => subskill.FoSubSkill)
                .Where(user => user.Id == id).FirstOrDefault();

            return empUser;
        }
        [HttpGet("PostEmpUserDetails/")]
        public async Task<ActionResult<EmpUser>> PostEmpUserDetails()
        {
            var empuser = new EmpUser();

            empuser.ClientId = 7;
            empuser.Firstname = "Dogan";
            empuser.Email = "sadas";

            _context.EmpUser.Add(empuser);
            _context.SaveChanges();
            
           
            EmpSkill empskill1 = new EmpSkill();

            empskill1.ClientId = empuser.ClientId;
            empskill1.UserId = empuser.Id;
            empskill1.SkillId = 8;
            empuser.EmpSkill.Add(empskill1);
            _context.SaveChanges();
             


            var empUser = _context.EmpUser
                .Include(user => user.EmpSkill)
                    .ThenInclude(skill => skill.FoSkill)
                .Where(user => user.Id == empuser.Id).FirstOrDefault();



            return empUser;
        }

        // GET: api/EmpUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpUser>> GetEmpUser(int id)
        {
            var empUser = await _context.EmpUser.FindAsync(id);

            if (empUser == null)
            {
                return NotFound();
            }

            return empUser;
        }

        // PUT: api/EmpUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpUser(int id, EmpUser empUser)
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
        public async Task<ActionResult<EmpUser>> PostEmpUser(EmpUser empUser)
        {
            _context.EmpUser.Add(empUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpUser", new { id = empUser.Id }, empUser);
        }

        // DELETE: api/EmpUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpUser>> DeleteEmpUser(int id)
        {
            var empUser = await _context.EmpUser.FindAsync(id);
            if (empUser == null)
            {
                return NotFound();
            }

            _context.EmpUser.Remove(empUser);
            await _context.SaveChangesAsync();

            return empUser;
        }

        private bool EmpUserExists(int id)
        {
            return _context.EmpUser.Any(e => e.Id == id);
        }
    }
}
