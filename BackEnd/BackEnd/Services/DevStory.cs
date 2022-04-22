using BackEnd.Models;
using BackEnd.ViewModel;
using System.Linq;

namespace BackEnd.Services
{
    public class DevStory : IDevStory
    {
        private readonly ApplicationDbContext context;

        public DevStory(ApplicationDbContext context)
        {
            this.context = context;
        }
        public DevStoryMv getData(int bckid , string id)
        {
            DevStoryMv dmv = new DevStoryMv();

            int dayofwork = 0;
            Sprint sprt = context.Sprints.Where(s => !s.FinDeSprint && s.BacklogId == bckid).FirstOrDefault();
            dayofwork = sprt.DureeSprint * sprt.JourTravail;

            var liststory = context.DeveloppeurStories.Where(d => d.DeveloppeurId == id).Join(

                  context.Stories.Where(sq => sq.BacklogId == bckid)
                  .Where(spr => !context.sprintStories.Select(ss => ss.StoryId).Contains(spr.Id)
                  ||
                  context.Sprints.Where(s => !s.FinDeSprint && s.BacklogId == bckid)
                  .Join(context.sprintStories.Where(ss => ss.StoryId == spr.Id),
                  st => st.Id, ss => ss.SprintId, (st, ss) => new { st, ss }).Any()),

                ds => ds.StoryId, s => s.Id, (ds, s) => new
                {
                    ds,
                    s
                }).Select(d => d.s);
            dmv.dayofwork = dayofwork;
            dmv.ListStory = liststory;
            return dmv;
        }
    }
}
