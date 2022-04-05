using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TachesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TachesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Taches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tache>>> GetTaches()
        {
            return await _context.Taches.ToListAsync();
        }

        // GET: api/Taches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tache>> GetTache(int id)
        {
            var tache = await _context.Taches.FindAsync(id);

            if (tache == null)
            {
                return NotFound();
            }

            return tache;
        }

        // PUT: api/Taches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTache(int id, Tache tache)
        {
            if (id != tache.Id)
            {
                return BadRequest();
            }

            _context.Entry(tache).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacheExists(id))
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

        //  : api/Taches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tache>> PostTache(Tache tache)
        {
            _context.Taches.Add(tache);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTache", new { id = tache.Id }, tache);
        }

        // DELETE: api/Taches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTache(int id)
        {
            var tache = await _context.Taches.FindAsync(id);
            if (tache == null)
            {
                return NotFound();
            }

            _context.Taches.Remove(tache);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TacheExists(int id)
        {
            return _context.Taches.Any(e => e.Id == id);
        }
    }
}
