using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Testeur : Utilisateur
    {
        public virtual ICollection<TesteurStory> TesteurStories { get; set; }
    }
}
