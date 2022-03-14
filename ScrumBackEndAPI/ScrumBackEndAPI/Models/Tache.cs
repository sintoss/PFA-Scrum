using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models.Entity
{
    public enum Etat 
    {
        ToDo,
        Doing,
        Done,
        Tested,
        Approuved
    }
    public class Tache
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateDernierModification { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public Etat Etat { get; set; }
        public int StoryId { get; set; }
        public Story Story { get; set; }
    }
}
