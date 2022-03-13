
using System.Collections.Generic;

namespace backend.Models.Entity
{
    public class Developpeur : Utilisateur
    {
        public virtual ICollection<DeveloppeurStory> DeveloppeurStories { get; set; }
    }
}
