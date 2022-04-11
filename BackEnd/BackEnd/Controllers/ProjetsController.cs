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
        public async Task<ActionResult<IEnumerable<Projet>>> GetProjets([FromHeader(Name = "Authorisation")] string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(jwt);
            string id = jwtSecurityToken.Claims.First(claim => claim.Type == "uid").Value;
            return await _context.Projets.Where(p => p.ScrumMasterId.Equals(id) || p.UtilisateurProjets.Where(up => up.UtilisateurId.Equals(id)).Count()>0).ToListAsync();
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
        public async Task<ActionResult<IEnumerable<UtilisateurProjet>>> addMembres(int projetId, [FromBody] IEnumerable<UtilisateurProjet> utilisateurProjets)
        {
            _context.UtilisateurProjets.AddRange(utilisateurProjets);
            await _context.SaveChangesAsync();

            return await _context.UtilisateurProjets.Include(up => up.Utilisateur).Where(up => up.ProjetId == projetId).ToListAsync();
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
        public async Task<ActionResult<UtilisateurProjet>> Delete(int projetId, string userId)
        {
            var utilisateurProjet = await _context.UtilisateurProjets.Where(up => up.ProjetId == projetId && up.UtilisateurId.Equals(userId)).FirstOrDefaultAsync();
            if (utilisateurProjet == null)
            {
                return NotFound();
            }

            _context.UtilisateurProjets.Remove(utilisateurProjet);
            await _context.SaveChangesAsync();

            return utilisateurProjet;
        }

        private bool ProjetExists(int id)
        {
            return _context.Projets.Any(e => e.Id == id);
        }
    }
}
