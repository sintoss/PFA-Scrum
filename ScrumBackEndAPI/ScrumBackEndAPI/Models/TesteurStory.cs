using System;

namespace backend.Models.Entity
{
    public class TesteurStory
    {
        public int Id { get; set; }
        public string TesteurId { get; set; }
        public Testeur Testeur { get; set; }
        public int StoryId { get; set; }
        public Story Story { get; set; }
        public DateTime dateAffectation { get; set; }
        public string Commentaire { get; set; }
    }
}
