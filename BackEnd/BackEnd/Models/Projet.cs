using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Projet
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DatePrevueFin { get; set; }
        public int DureeSprint { get; set; }
        public int JourTravail { get; set; }
        public int? BacklogId { get; set; }
        public virtual Backlog Backlog { get; set; }
        public string ScrumMasterId { get; set; }
        public virtual ScrumMaster ScrumMaster { get; set; }
        public virtual ICollection<Reunion> Reunion { get; set; }
        public virtual ICollection<utilisateurProjets> UtilisateurProjets { get; set; }
        public virtual ICollection<ScrumMasterProjet> ScrumMasterProjets { get; set; }

        public Projet()
        {

        }
        public Projet(int id, string nom, DateTime dateDebut, DateTime datePrevueFin)
        {
            this.Id = id;
            this.Nom = nom;
            this.DateDebut = dateDebut;
            this.DatePrevueFin = datePrevueFin;
        }
    }
}
