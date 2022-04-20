using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
   
    public class Tache
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateDerniereModification { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DefaultValue(false)]
        public Boolean Etat { get; set; }
        public int StoryId { get; set; }
        public virtual Story Story { get; set; }
    }
}
