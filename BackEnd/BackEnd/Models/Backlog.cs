using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Backlog
    {
        [ForeignKey("Projet")]
        public int ProjetId { get; set; }
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateDerniereModification { get; set; }
        public virtual Projet Projet { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}
