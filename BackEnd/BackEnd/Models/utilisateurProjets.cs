namespace BackEnd.Models
{
    public class utilisateurProjets
    {
        public string utilisateurId { get; set; }
        public virtual Utilisateur utilisateur { get; set; }
        public int ProjetId { get; set; }
        public virtual Projet Projet { get; set; }
    }
}
