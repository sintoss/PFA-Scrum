namespace BackEnd.Models
{
    public class ScrumMasterProjet
    {
        public int Id { get; set; }
        public string ScrumMasterId { get; set; }
        public virtual ScrumMaster ScrumMaster { get; set; }
        public int ProjetId { get; set; }
        public virtual Projet Projet { get; set; }
    }
}
