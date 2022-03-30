namespace BackEnd.Models
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
