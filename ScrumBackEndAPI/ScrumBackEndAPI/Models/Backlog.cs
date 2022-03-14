using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models.Entity
{
    public class Backlog
    {
        [ForeignKey("Projet")]
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateDernierModification { get; set; }
        public int ProjetId { get; set; }
        public Projet Projet { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}
