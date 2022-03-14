namespace backend.Models.Entity
{
    public class ScrumMasterProjet
    {
        public int Id { get; set; }
        public string ScrumMasterId { get; set; }
        public ScrumMaster ScrumMaster { get; set; }
        public int ProjetId { get; set; }
        public Projet Projet { get; set; }
    }
}
