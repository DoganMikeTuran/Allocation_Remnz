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
    public class PrProjectController : Controller
    {
        private readonly remnz1Context _context;

        public PrProjectController(remnz1Context context)
        {
            _context = context;

        }
        [HttpGet("{clientid}")]

        public async Task<ActionResult<IEnumerable<PrProject>>> Get(int clientid)
        {
            return await _context.PrProject.Where(x => x.ClientId == clientid).ToListAsync();
        }



        [HttpPost]
        public string Post([FromBody]PrProject prproject)
        {
            prproject.Template = true;
            _context.PrProject.Add(prproject);
            _context.SaveChanges();
            return prproject.Id.ToString();
        }
    }
}
