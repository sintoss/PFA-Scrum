using System;

namespace BackEnd.ViewModel
{
    public class ProjetModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DatePrevueFin { get; set; }
        public int StoryNumber { get; set; }

        public double completedStory { get; set; }

        public ProjetModel()
        {

        }

        public ProjetModel(int id, string nom, DateTime? date_debut, DateTime? date_prevu_fin, int story_number, double c)
        {
            this.Id = id;
            this.Nom = nom;
            this.DateDebut = date_debut;
            this.DatePrevueFin = date_prevu_fin;
            this.StoryNumber = story_number;
            this.completedStory = c;
        }
    }
}
