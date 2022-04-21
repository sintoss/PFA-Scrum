using BackEnd.Models;
using BackEnd.ViewModel;
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
        public IActionResult addStoryToDev(UtilsateurStoryMv userStory)
        {
            if (!ModelState.IsValid) return Ok("YOU HAVE SOMETHING WRONG");

            string msj = "You Can add only one Developer and one tester to the user story";

            if(context.Stories.Find(userStory.StoryId) != null)
            {
      
                if(context.Developpeurs.Find(userStory.userId) != null
                    &&
                    !context.DeveloppeurStories.Where(d => d.StoryId == userStory.StoryId).Any())
                {
                    //Dev

                    DeveloppeurStory devstr = new DeveloppeurStory();
                    devstr.DeveloppeurId = userStory.userId;
                    devstr.StoryId = userStory.StoryId;
                    devstr.DateAffectation = System.DateTime.Now;
                    context.DeveloppeurStories.Add(devstr);
                    context.SaveChanges();
                    msj = "this dev was added to the user story ";

                }
                else if(context.Testeurs.Find(userStory.userId) != null
                    &&
                    !context.TesteurStory.Where(d=>d.StoryId == userStory.StoryId).Any())
                {
                    //test

                    TesteurStory teststr = new TesteurStory();
                    teststr.TesteurId = userStory.userId;
                    teststr.StoryId = userStory.StoryId;
                    teststr.DateAffectation = System.DateTime.Now;
                    context.TesteurStory.Add(teststr);
                    context.SaveChanges();
                    msj = "this tester was added to the user story ";

                }

            }
            
         
            
            return Ok(msj);
        }

    }
}
