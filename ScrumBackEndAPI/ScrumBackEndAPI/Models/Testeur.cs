
using System.Collections.Generic;

namespace backend.Models.Entity
{
    public class Testeur : Utilisateur
    {
        public virtual ICollection<TesteurStory> TesteurStories { get; set; }
    }
}
