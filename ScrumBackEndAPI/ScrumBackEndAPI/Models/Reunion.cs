using System;
using System.Collections.Generic;

namespace backend.Models.Entity
{
    public class Reunion
    {
        public int Id { get; set; }
        public string Objet { get; set; }
        public DateTime DateReunion { get; set; }
        public string Emplacement { get; set; }
        public string ScrumMasterId { get; set; }
        public ScrumMaster ScrumMaster { get; set; }
        public virtual ICollection<UtilisateurReunion> UtilisateurReunions { get; set; }
    }
}
