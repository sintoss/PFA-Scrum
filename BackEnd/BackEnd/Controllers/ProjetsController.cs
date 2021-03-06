using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;
using BackEnd.ViewModel;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Projets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetModel>>> GetProjets([FromHeader(Name = "Authorisation")] string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(jwt);
            string id = jwtSecurityToken.Claims.First(claim => claim.Type == "uid").Value;

            return await _context.Projets.Where(p => p.ScrumMasterId.Equals(id) || p.UtilisateurProjets.Where(up => up.utilisateurId.Equals(id)).Count()>0)
                                         .Select(p => new ProjetModel(
                                                                        p.Id,
                                                                        p.Nom, 
                                                                        p.DateDebut, 
                                                                        p.DatePrevueFin, 
                                                                        p.Backlog.Stories.Count(), 
                                                                        (Math.Truncate(((double)p.Backlog.Stories.Where(s => s.Etat == Etat.Approuved).Count() / (double) ((p.Backlog.Stories.Count() == 0 ) ? 1 : p.Backlog.Stories.Count())) *100))))
                                         .ToListAsync();

           

        }

        // GET: api/Projets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projet>> GetProjet(int id)
        {
            var projet = await _context.Projets.FindAsync(id);

            if (projet == null)
            {
                return NotFound();
            }

            return projet;
        }

        // POST: api/Projets/ajouter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ajouter")]
        public async Task<ActionResult<Projet>> addProjet([FromBody] Projet projet)
        {
            if(ModelState.IsValid && !_context.Projets.Any(p => p.Nom == projet.Nom))
            {
                _context.Projets.Add(projet);
                await _context.SaveChangesAsync();

                return projet;
            }
            return BadRequest();
        }

        [HttpPost("{projetId}/membres/ajouter")]
        public async Task<ActionResult<IEnumerable<utilisateurProjets>>> addMembres(int projetId, [FromBody] IEnumerable<utilisateurProjets> utilisateurProjets)
        {
            _context.utilisateurProjets.AddRange(utilisateurProjets);
            await _context.SaveChangesAsync();

            return await _context.utilisateurProjets.Include(up => up.utilisateur).Where(up => up.ProjetId == projetId).ToListAsync();
        }

        // DELETE: api/Projets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjet(string id)
        {
            var projet = await _context.Projets.FindAsync(id);
            if (projet == null)
            {
                return NotFound();
            }

            _context.Projets.Remove(projet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{projetId}/membres/supprimer/{userId}")]
        public async Task<ActionResult<utilisateurProjets>> Delete(int projetId, string userId)
        {
            var utilisateurProjet = await _context.utilisateurProjets.Where(up => up.ProjetId == projetId && up.utilisateurId.Equals(userId)).FirstOrDefaultAsync();

            if (utilisateurProjet == null)
            {
                return NotFound();
            }

            _context.utilisateurProjets.Remove(utilisateurProjet);
            await _context.SaveChangesAsync();

            return utilisateurProjet;
        }

        private bool ProjetExists(int id)
        {
            return _context.Projets.Any(e => e.Id == id);
        }


    }
}
