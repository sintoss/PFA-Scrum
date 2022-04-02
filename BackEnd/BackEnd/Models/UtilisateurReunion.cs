namespace BackEnd.Models
{
    public class UtilisateurReunion
    {
        public string UtilisateurId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public int ReunionId { get; set; }
        public virtual Reunion Reunion { get; set; }
    }
}
