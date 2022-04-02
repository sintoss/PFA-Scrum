namespace BackEnd.Models
{
    public class UtilisateurProjet
    {
        public string UtilisateurId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public int ProjetId { get; set; }
        public virtual Projet Projet { get; set; }
    }
}
