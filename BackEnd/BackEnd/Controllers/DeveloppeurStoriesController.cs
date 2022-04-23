using BackEnd.Models;
using BackEnd.Services;
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
        private readonly IDevStory devStory;

        public DeveloppeurStoriesController(ApplicationDbContext context , IDevStory devStory)
        {
            this.context = context;
            this.devStory = devStory;
        }

        [HttpPost]
        public IActionResult addStoryToDev(UtilsateurStoryMv userStory)
        {
            if (!ModelState.IsValid) return Ok("YOU HAVE SOMETHING WRONG");

            string msj = "You Can add only one Developer and one tester to the user story";

            bool ck = context.Sprints.Where(s => !s.FinDeSprint).Any();

            if(!ck) msj = "You Should create New Sprint";

            if (context.Stories.Find(userStory.StoryId) != null && ck)
            {
      
                if(context.Developpeurs.Find(userStory.userId) != null
                    &&
                    !context.DeveloppeurStories.Where(d => d.StoryId == userStory.StoryId).Any())
                {
                    //Dev
                    if (userStory.Duree > 0)
                    {
                        int dayofwork = 0;
                        int bckid = context.Stories.Find(userStory.StoryId).BacklogId;
                        DevStoryMv dvm = devStory.getData(bckid, userStory.userId);
                        dayofwork = dvm.dayofwork;
                        int dur = dvm.ListStory.Sum(s => s.Duree);

                        dur += userStory.Duree;

                        if (dayofwork >= dur)
                        {
                            // add story and dev to DeveloppeurStory
                            DeveloppeurStory devstr = new DeveloppeurStory();
                            devstr.DeveloppeurId = userStory.userId;
                            devstr.StoryId = userStory.StoryId;
                            devstr.DateAffectation = System.DateTime.Now;
                            context.DeveloppeurStories.Add(devstr);
                            // set the Duree in story
                            var str = context.Stories.Find(userStory.StoryId);
                            str.Duree = userStory.Duree;
                            context.SaveChanges();
                            msj = "this dev was added to the user story ";
                        }
                        else
                        {
                            msj = "You don't have enough days";
                        }
                        
                    }
                    else
                    {
                        msj = "you should give value greather than 0 ";
                    }
                   
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
