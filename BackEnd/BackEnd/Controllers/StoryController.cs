﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Helpers;
using BackEnd.Models;
using BackEnd.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Story
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> GetStories()
        {
            return await _context.Stories.ToListAsync();
        }

        [HttpGet("{bckid}/{pg}/{pgs}/{desc?}")]
        public async Task<IActionResult> GetStoriesByBacklog(int bckid  , int pg = 1 , int pgs = 5, string desc = " " )
        {
            List<Story> stories = await _context.Stories.Where(s => s.BacklogId == bckid
              && 
              s.Description.Contains((string.IsNullOrWhiteSpace(desc)) ? "" : desc)).ToListAsync();

            int pageSize = (pgs <= 7 ) ? pgs : 5;

            if (pg < 1) pg = 1;

            int recscount = stories.Count();

            var pager = new Pager(recscount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = stories.Skip(recSkip).Take(pager.PageSize).ToList();

            var newData = new List<StoryMv>();

            data.ForEach(d =>
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

            return Ok(new { newData, pager } ) ;
        }

        private string GetImage(int UserStoryId)
        {
            string path = _context.DeveloppeurStories.Where(ds=>ds.StoryId == UserStoryId).Join(_context.Stories, d => d.StoryId, s => s.Id, (devstory, story) => new { devstory, story })
                .Join(_context.Developpeurs, ds => ds.devstory.DeveloppeurId, d => d.Id, (ds,d) => new { d.pathImage }).Select(u => u.pathImage)
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

        // POST: api/Story
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Story> PostInspection(Story story)
        {
            _context.Stories.Add(story);
            _context.SaveChangesAsync();

            return  new Story();
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
    }
}
