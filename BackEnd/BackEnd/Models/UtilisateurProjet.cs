namespace BackEnd.Models
{
    public class UtilisateurProjet
    {
        public string UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public int ProjetId { get; set; }
        public Projet Projet { get; set; }
    }
}
