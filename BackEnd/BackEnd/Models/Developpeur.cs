using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Developpeur : Utilisateur
    {
        public virtual ICollection<DeveloppeurStory> DeveloppeurStories { get; set; }
    }
}
