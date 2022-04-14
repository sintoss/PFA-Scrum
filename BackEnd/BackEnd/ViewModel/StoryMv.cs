using System;

namespace BackEnd.ViewModel
{
    public class StoryMv
    {
        public int id { get; set; }

        public string description { get; set; }

        public DateTime dateCreation { get; set; }

        public DateTime dateDerniereModification { get; set; }

        public string pathAvtar { get; set; }

        public string Commentaire { get; set; }
        public int BacklogId { get; set; }

        public string Libelle { get; set; }

    }
}
