using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloppeurStoriesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DeveloppeurStoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult addStoryToDev(DeveloppeurStory developpeurStory)
        {
            if (!ModelState.IsValid) return Ok("YOU HAVE SOMETHING WRONG");
            if(context.Developpeurs.Find(developpeurStory.DeveloppeurId) != null 
                &&
               context.Stories.Find(developpeurStory.StoryId) != null
                &&
               context.DeveloppeurStories.FirstOrDefault(ds=>ds.StoryId == developpeurStory.StoryId) == null)
            {
                developpeurStory.DateAffectation = System.DateTime.Now;
                context.DeveloppeurStories.Add(developpeurStory);
                context.SaveChanges();
            }
            return Ok("INSERTED");
        }

    }
}
