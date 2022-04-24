using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
   
    public class Tache
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateDerniereModification { get; set; }
        [DefaultValue(false)]
        public bool Etat { get; set; }
        public int StoryId { get; set; }
        public virtual Story Story { get; set; }
    }
}
