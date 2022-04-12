using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BackEnd.Models
{
    public abstract class Utilisateur : IdentityUser
    {
        public string NomComplet { get; set; }
        public string Discriminator { get; private set; }
        public string pathImage { get; set; }
        public virtual ICollection<utilisateurProjets> utilisateurProjets { get; set; }
        public virtual ICollection<UtilisateurReunion> UtilisateurReunions { get; set; }
    }
}
