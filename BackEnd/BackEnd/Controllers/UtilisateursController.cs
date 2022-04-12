using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UtilisateursController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<UtilisateursController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUsers()
        {
            return await _context.Utilisateurs.Where(u => u.Discriminator.Equals("Developpeur") || u.Discriminator.Equals("Testeur")).ToListAsync();
        }

        // GET api/<UtilisateursController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UtilisateursController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UtilisateursController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
