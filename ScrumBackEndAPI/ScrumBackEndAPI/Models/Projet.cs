﻿using System;
using System.Collections.Generic;

namespace backend.Models.Entity
{
    public class Projet
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DatePrevueFin { get; set; }
        public int? BacklogId { get; set; }
        public Backlog Backlog { get; set; }
        public string ScrumMasterId { get; set; }
        public ScrumMaster ScrumMaster { get; set; }
        public virtual ICollection<Reunion> Reunion { get; set; }
        public virtual ICollection<UtilisateurProjet> UtilisateurProjets { get; set; }
        public virtual ICollection<ScrumMasterProjet> ScrumMasterProjets { get; set; }
    }
}