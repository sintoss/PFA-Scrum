using System;

namespace backend.Models.Entity
{
    public class DeveloppeurStory
    {
        public int Id { get; set; }
        public string DeveloppeurId { get; set; }
        public Developpeur Developpeur { get; set; }
        public int StoryId { get; set; }
        public Story Story { get; set; }
        public DateTime dateAffectation { get; set; }
    }
}
