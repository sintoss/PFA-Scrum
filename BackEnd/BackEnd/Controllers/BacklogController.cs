using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BacklogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BacklogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Backlog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Backlog>>> GetBacklogs()
        {
            return await _context.Backlogs.ToListAsync();
        }

        // GET: api/Backlog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Backlog>> GetBacklog(int id)
        {
            return await _context.Backlogs.Where(b=>b.ProjetId==id).FirstOrDefaultAsync();
        }
        // GET: api/Backlog/ajouter
        [HttpPost("ajouter")]
        public async Task<ActionResult<Backlog>> addBacklog([FromBody] Backlog backlog)
        {
            if (ModelState.IsValid)
            {
                _context.Backlogs.Add(backlog);
                await _context.SaveChangesAsync();

                var projet = await _context.Projets.FindAsync(backlog.ProjetId);
                projet.BacklogId = backlog.Id;
                await _context.SaveChangesAsync();

                return backlog;
            }
            return BadRequest();
        }

        // PUT: api/Backlog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBacklog(int id, Backlog backlog)
        {
            if (id != backlog.Id)
            {
                return BadRequest();
            }

            _context.Entry(backlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BacklogExists(id))
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

        // POST: api/Backlog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Backlog>> PostBacklog(Backlog backlog)
        {
            _context.Backlogs.Add(backlog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BacklogExists(backlog.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBacklog", new { id = backlog.Id }, backlog);
        }

        // DELETE: api/Backlog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBacklog(int id)
        {
            var backlog = await _context.Backlogs.FindAsync(id);
            if (backlog == null)
            {
                return NotFound();
            }

            _context.Backlogs.Remove(backlog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BacklogExists(int id)
        {
            return _context.Backlogs.Any(e => e.Id == id);
        }
    }
}
