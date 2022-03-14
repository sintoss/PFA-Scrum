namespace backend.Models.Entity
{
    public class UtilisateurReunion
    {
        public string UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public int ReunionId { get; set; }
        public Reunion Reunion { get; set; }
    }
}
