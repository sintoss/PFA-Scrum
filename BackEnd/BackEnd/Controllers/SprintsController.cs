using BackEnd.Helpers;
using BackEnd.Models;
using BackEnd.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet("CurrentSprint/{backId}")]
        public async Task<ActionResult<Sprint>> GetCurrentSprint(int backId)
        {
            var sprint = await _context.Sprints.Where(b => b.BacklogId == backId).OrderByDescending(d => d.DateCreation)
                .FirstOrDefaultAsync();
            if (sprint != null)
            {
                var dateCreation = sprint.DateCreation;
                var dateFin = sprint.Dateestimeedefin;
                var days = new List<DateTime>();

                var daysLeft = ((TimeSpan)(dateFin - dateCreation)).TotalDays;

                for (var i = 0; i < daysLeft; i++)
                {
                    days.Add(new DateTime(dateCreation.AddDays(i).Ticks));
                }
                return Ok(new { sprint, days });
            }
            return BadRequest("There is no current sprint for this moment");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Story>>> GetSprint(int id, [FromHeader(Name = "Authorisation")] string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(jwt);
            var roles = jwtSecurityToken.Claims.First(claim => claim.Type == "roles").Value;
            string uid = jwtSecurityToken.Claims.First(claim => claim.Type == "uid").Value;
            string userId = (!roles.Contains("ScrumMaster")) ? uid : "";

            var stories = await _context.sprintStories.Where(s => s.SprintId == id && (s.Story.DeveloppeurStories.Any(d => d.DeveloppeurId.Contains(userId)) || s.Story.TesteurStories.Any(t => t.TesteurId.Contains(userId))))
                                                      .Select(s => s.Story)
                                                      .ToListAsync();
            if (stories != null)
            {
                return stories;
            }
            return BadRequest("404 Not Found");
        }

        [HttpGet("{backId}/{pg}/{pgs}/{lib?}")]
        public async Task<ActionResult<IEnumerable<Sprint>>> GetSprints(int backId, int pg = 1, int pgs = 5,
            string lib = " ")
        {
            List<Sprint> sprints = await _context.Sprints.Where(s =>
                s.BacklogId == backId
                &&
                s.Libelle.Contains((string.IsNullOrWhiteSpace(lib)) ? "" : lib)).ToListAsync();

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
        public IActionResult PutSprint(int id, Sprint sprint)
        {
            if (id != sprint.Id)
            {
                return BadRequest();
            }

            var spr = _context.Sprints.Find(id);
            spr.Libelle = sprint.Libelle;
            spr.Dateestimeedefin = sprint.Dateestimeedefin;
            spr.DateDerniereModification = DateTime.Now;
            _context.SaveChanges();

            return Ok("UPDATED");
        }

        [HttpPut("{id}/completer")]
        public async Task<IActionResult> completeSprint(int id, Story sprint)
        {
            var spr = _context.Sprints.Find(id);
            spr.FinDeSprint = true;

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

            string msj = "No";

            if( _context.Sprints.All(s => s.FinDeSprint))
            {
                var spr = new Sprint();
                spr.Libelle = sprint.libelle;
                spr.Dateestimeedefin = sprint.dateestimeedefin;
                spr.DateCreation = DateTime.Now;
                spr.BacklogId = sprint.BacklogId;
                spr.DureeSprint = sprint.dureeSprint;
                spr.JourTravail = sprint.jourTravail;
                _context.Sprints.Add(spr);
                msj = "INSERTED";
            }

            await _context.SaveChangesAsync();

            return Ok(msj);
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

            return Ok("DELETED");
        }

        private bool SprintExists(int id)
        {
            return _context.Sprints.Any(e => e.Id == id);
        }

        [HttpGet("affection/{bckid}/{desc?}")]
        public async Task<ActionResult<IEnumerable<Story>>> GetstorywithoutSprint(int bckid, string desc = " ")
        {
            var sto =  await _context.Stories.Where( c => c.BacklogId == bckid &&
                                c.Description.Contains((string.IsNullOrWhiteSpace(desc)) ? "" : desc)).ToListAsync();

            var story =  sto.Where(c => !_context.sprintStories.Select(s => s.StoryId).Contains(c.Id)
                                        &&
                                        _context.DeveloppeurStories.Select(ds=>ds.StoryId).Contains(c.Id)
                                        ).ToList();

            var newData = new List<StoryMv>();

            story.ForEach(d =>
            {
                newData.Add(new StoryMv
                {
                    id = d.Id,
                    description = d.Description,
                    dateCreation = d.DateCreation,
                    dateDerniereModification = (System.DateTime)d.DateDerniereModification,
                    Commentaire = d.Commentaire,
                    BacklogId = d.BacklogId,
                    pathAvtar = GetImage(d.Id)
                });
            });

            return Ok(newData);
        }

        private string GetImage(int UserStoryId)
        {
            string path = _context.DeveloppeurStories.Where(ds => ds.StoryId == UserStoryId).Join(_context.Stories,
                    d => d.StoryId, s => s.Id, (devstory, story) => new { devstory, story })
                .Join(_context.Developpeurs, ds => ds.devstory.DeveloppeurId, d => d.Id, (ds, d) => new { d.pathImage })
                .Select(u => u.pathImage)
                .FirstOrDefault();
            return (string.IsNullOrEmpty(path)) ? @"Ressources\Image\anonymous.png" : path;
        }


        [HttpPost("aff")]
        public async Task<ActionResult<Sprint>> affectstorytosprint(StoryAffectMv sprint)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            if (_context.Sprints.Find(sprint.sprintid) != null  )
            {
                var spr = _context.Sprints.Find(sprint.sprintid);
                sprint.storylist.ForEach(i =>
                {
                    if (_context.Stories.Find(i) != null)
                    {
                        var sprintstories = new SprintStory();
                        sprintstories.StoryId = i;
                        sprintstories.SprintId = sprint.sprintid;
                        _context.sprintStories.Add(sprintstories);
                    }
                });
            }

            await _context.SaveChangesAsync();

            return Ok("List of story was added to the sprint with success");
        }

        [HttpGet("story/{sprintId}/{pg}/{pgs}/{desc?}")]
        public ActionResult<Sprint> getstorysofsprint(int sprintId, int pg = 1, int pgs = 5, string desc = " ")
        {
            var stories = _context.Stories.Where(s =>
                s.Description.Contains((string.IsNullOrWhiteSpace(desc)) ? "" : desc)
            ).Join(_context.sprintStories.Where(ss => ss.SprintId == sprintId),
                s => s.Id, ss => ss.StoryId, (story, sprintstory) => new
                {
                    story
                }).ToList();

            int pageSize = (pgs <= 7) ? pgs : 5;

            if (pg < 1) pg = 1;

            int recscount = stories.Count();

            var pager = new Pager(recscount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = stories.Skip(recSkip).Take(pager.PageSize).ToList();

            return Ok(new { data, pager });
        }

        [HttpGet("check")]
        public async Task<bool> checkIfCanAdd()
        {
            return await _context.Sprints.CountAsync() == 0 ? true : await _context.Sprints.AllAsync(s => s.FinDeSprint);
        }




    }

}