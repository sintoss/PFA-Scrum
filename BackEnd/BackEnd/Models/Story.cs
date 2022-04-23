using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public enum Etat
    {
        ToDo,
        Doing,
        Done,
        Tested,
        Approuved
    }

    public class Story
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateDerniereModification { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DatePrevuFin { get; set; }
        public DateTime? DateFin { get; set; }
        public string Commentaire { get; set; }
        public int BacklogId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DefaultValue(Etat.ToDo)]
        public Etat Etat { get; set; }
        public virtual Backlog Backlog { get; set; }
        public virtual ICollection<Tache> Taches { get; set; }
        public virtual ICollection<SprintStory> SprintStories { get; set; }
        public virtual ICollection<DeveloppeurStory> DeveloppeurStories { get; set; }
        public virtual ICollection<TesteurStory> TesteurStories { get; set; }
    }
}