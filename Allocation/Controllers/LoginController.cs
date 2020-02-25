using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Allocation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Allocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly remnz1Context _context;
        // Her opretter vi en instans af klassen vi har lavet
        private readonly JWTSettings _jwtsettings;
        // GET: api/values
        public LoginController(remnz1Context context, IOptions<JWTSettings> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
        }
        [HttpPost]
        public async Task<ActionResult<UserWithToken>> Login([FromBody] User empuser)
        {
            empuser = await _context.User
                .Include(e => e.UserSubSkill)
                .Where(e => e.Firstname == empuser.Firstname && e.Lastname == empuser.Lastname)
                
                .FirstOrDefaultAsync();
            if (empuser == null)
            {
                return NotFound();
            }
            UserWithToken userWithToken = new UserWithToken(empuser);

        
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    
                    new Claim(ClaimTypes.Surname, empuser.ClientId.ToString()),
                    new Claim(JwtRegisteredClaimNames.NameId, empuser.Firstname),
                    new Claim(JwtRegisteredClaimNames.Sub, empuser.Lastname)

                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userWithToken.Token = tokenHandler.WriteToken(token);

            return userWithToken;
        }

        
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
     

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
