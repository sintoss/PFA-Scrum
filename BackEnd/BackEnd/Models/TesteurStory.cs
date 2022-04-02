using System;

namespace BackEnd.Models
{
    public class TesteurStory
    {
        public int Id { get; set; }
        public string TesteurId { get; set; }
        public virtual Testeur Testeur { get; set; }
        public int StoryId { get; set; }
        public virtual Story Story { get; set; }
        public DateTime DateAffectation { get; set; }
        public string Commentaire { get; set; }
    }
}
