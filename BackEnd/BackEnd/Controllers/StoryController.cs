using BackEnd.Helpers;
using BackEnd.Models;
using BackEnd.Services;
using BackEnd.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IDevStory devStory;

        public StoryController(ApplicationDbContext context, IDevStory devStory)
        {
            _context = context;
            this.devStory = devStory;
        }

        // GET: api/Story
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> GetStories()
        {
            return await _context.Stories.ToListAsync();
        }

        [HttpGet("{bckid}/{pg}/{pgs}/{desc?}")]
        public async Task<IActionResult> GetStoriesByBacklog(int bckid, int pg = 1, int pgs = 5, string desc = " ")
        {
            var complexType = await _context.Stories.Where(s => s.BacklogId == bckid
                                                                &&
                                                                s.Description.Contains(
                                                                    (string.IsNullOrWhiteSpace(desc)) ? "" : desc))
                .ToListAsync();

            int pageSize = (pgs <= 7) ? pgs : 5;

            if (pg < 1) pg = 1;

            int recscount = complexType.Count();

            var pager = new Pager(recscount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = complexType.Skip(recSkip).Take(pager.PageSize).ToList();

            var newData = new List<StoryMv>();

            data.ForEach(d =>
            {
                if (d.DateDerniereModification != null)
                    newData.Add(new StoryMv
                    {
                        id = d.Id,
                        description = d.Description,
                        dateCreation = d.DateCreation,
                        dateDerniereModification = (System.DateTime) d.DateDerniereModification,
                        Commentaire = d.Commentaire,
                        BacklogId = d.BacklogId,
                        pathAvtar = GetImage(d.Id),
                        Libelle = _context.sprintStories.Where(sp => sp.StoryId == d.Id).Join(_context.Sprints,
                            sp => sp.SprintId, s => s.Id,
                            (sprintstory, sprint) => sprint.Libelle).FirstOrDefault()
                    });
            });

            return Ok(new {newData, pager});
        }

        [HttpGet("AllStoriesByID/{backlogId}")]
        public async Task<ActionResult<IEnumerable<Story>>> GetAllStoriesByBacklog(int backlogId)
        {
            var storyList = await _context.Stories.Where(b => b.BacklogId == backlogId).ToListAsync();
            if (storyList == null)
            {
                return NotFound();
            }

            return storyList;
        }

        private string GetImage(int UserStoryId)
        {
            string path = _context.DeveloppeurStories.Where(ds => ds.StoryId == UserStoryId).Join(_context.Stories,
                    d => d.StoryId, s => s.Id, (devstory, story) => new {devstory, story})
                .Join(_context.Developpeurs, ds => ds.devstory.DeveloppeurId, d => d.Id, (ds, d) => new {d.pathImage})
                .Select(u => u.pathImage)
                .FirstOrDefault();
            return (string.IsNullOrEmpty(path)) ? @"Ressources\Image\anonymous.png" : path;
        }

        // PUT: api/Story/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStory(int id, Story story)
        {
            if (id != story.Id)
            {
                return BadRequest();
            }

            story.DateDerniereModification = System.DateTime.Now;
            _context.Entry(story).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryExists(id))
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

        [HttpPut("{id}/changerEtat")]
        public async Task<ActionResult<Story>> ChangerEtat(int id, Story story)
        {
            _context.Entry(story).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return story;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Story
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Story> PostInspection(Story story)
        {
            story.DateCreation = System.DateTime.Now;
            story.DateDerniereModification = System.DateTime.Now;
            _context.Stories.Add(story);
            _context.SaveChangesAsync();
            return story;
        }

        // DELETE: api/Story/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGetStory(int id)
        {
            var story = await _context.Stories.FindAsync(id);
            if (story == null)
            {
                return NotFound();
            }

            _context.Stories.Remove(story);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoryExists(int id)
        {
            return _context.Stories.Any(e => e.Id == id);
        }

        [HttpGet("checkWorkLeftForDev/{id}/{bckid}")]
        public async Task<IActionResult> CheckDayLeftForDev(string id, int bckid)
        {
            int dayofwork = 0;
            string msj = "";
            if (_context.Sprints.Any(s => !s.FinDeSprint))
            {
                DevStoryMv dvm = devStory.getData(bckid, id);
                dayofwork = dvm.dayofwork;
                int duree = dvm.ListStory.Sum(s => s.Duree);

                msj += "Total work Day of sprint = " + dayofwork;
                dayofwork -= duree;
                msj += ";Day work Left  = " + dayofwork;
                foreach (var item in dvm.ListStory)
                {
                    msj += ";" + item.Description + " -- Duree = " + item.Duree;
                }
            }

            return Ok(new {dayofwork, msj});
        }


        [HttpDelete("Init/{id}")]
        public async Task<IActionResult> initStory(int id)
        {
            var story = await _context.Stories.FindAsync(id);
            if (story != null)
            {
                story.Duree = 0;
                // deleted from devstory and teststory and sprintstory if exist
                var temp1 = _context.DeveloppeurStories.Where(ds => ds.StoryId == id).FirstOrDefault();
                if (temp1 != null) _context.DeveloppeurStories.Remove(temp1);
                var temp2 = _context.TesteurStory.Where(ts => ts.StoryId == id).FirstOrDefault();
                if (temp2 != null) _context.TesteurStory.Remove(temp2);
                var temp3 = _context.sprintStories.Where(ss => ss.StoryId == id).FirstOrDefault();
                if (temp3 != null) _context.sprintStories.Remove(temp3);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}