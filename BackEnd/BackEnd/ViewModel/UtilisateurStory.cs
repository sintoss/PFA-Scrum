using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.ViewModel
{
    public class UtilisateurStory
    {
        public virtual ICollection<DeveloppeurStory> DeveloppeurStories { get; set; }
        public virtual ICollection<TesteurStory> TesteurStories { get; set; }

        public UtilisateurStory(ICollection<DeveloppeurStory> developpeurStories, ICollection<TesteurStory> testeurStories)
        {
            DeveloppeurStories = developpeurStories;
            TesteurStories = testeurStories;
        }
    }
}
