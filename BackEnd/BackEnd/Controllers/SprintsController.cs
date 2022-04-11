using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using BackEnd.Helpers;
using BackEnd.ViewModel;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SprintsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("{pg}/{pgs}/{lib?}")]
        public async Task<ActionResult<IEnumerable<Sprint>>> GetSprints( int pg = 1, int pgs = 5 , string lib = " ")
        {
            List<Sprint> sprints = await _context.Sprints.Where(s=>s.Libelle.Contains((string.IsNullOrWhiteSpace(lib)) ? "" : lib)).ToListAsync();

            int pageSize = (pgs <= 7) ? pgs : 5;

            if (pg < 1) pg = 1;

            int recscount = sprints.Count();

            var pager = new Pager(recscount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = sprints.Skip(recSkip).Take(pager.PageSize).ToList();

            return Ok(new { data, pager });
        }


        // PUT: api/Sprints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSprint(int id, Sprint sprint)
        {
            if (id != sprint.Id)
            {
                return BadRequest();
            }

            _context.Entry(sprint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SprintExists(id))
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

        // POST: api/Sprints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sprint>> PostSprint(SprintMv sprint)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var spr = new Sprint();
            spr.Libelle = sprint.libelle;
            spr.Dateestimeedefin = sprint.dateestimeedefin;

            _context.Sprints.Add(spr);
            await _context.SaveChangesAsync();

            return Ok("INSERTED");
        }

        // DELETE: api/Sprints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSprint(int id)
        {
            var sprint = await _context.Sprints.FindAsync(id);
            if (sprint == null)
            {
                return NotFound();
            }

            _context.Sprints.Remove(sprint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SprintExists(int id)
        {
            return _context.Sprints.Any(e => e.Id == id);
        }
    }
}
