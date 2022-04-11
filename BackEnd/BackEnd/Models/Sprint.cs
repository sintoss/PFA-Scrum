using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateDerniereModification { get; set; }
        public DateTime? Dateestimeedefin { get; set; }
        public virtual ICollection<SprintStory> SprintStories { get; set; }  
        public virtual ICollection<Release> Releases { get; set; }
        public int BacklogId { get; set; }
        public virtual Backlog Backlog { get; set; }
    }
}
