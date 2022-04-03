using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BackEnd.Models
{
    public abstract class Utilisateur : IdentityUser
    {
        public string NomComplet { get; set; }
        public virtual ICollection<UtilisateurProjet> UtilisateurProjets { get; set; }
        public virtual ICollection<UtilisateurReunion> UtilisateurReunions { get; set; }
    }
}
