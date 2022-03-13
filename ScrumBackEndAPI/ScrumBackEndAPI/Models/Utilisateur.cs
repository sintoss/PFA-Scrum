using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models.Entity
{

    public enum Role
    {
        ScrumMaster,
        ProductOwner,
        Developpeur,
        Testeur
    }
    public abstract class Utilisateur : IdentityUser
    {
        public string NomComplet { get; set; }
        public virtual ICollection<UtilisateurProjet> UtilisateurProjets { get; set; }
        public virtual ICollection<UtilisateurReunion> UtilisateurReunions { get; set; }
    }
}
