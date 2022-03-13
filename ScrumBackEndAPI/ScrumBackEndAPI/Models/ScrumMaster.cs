
using System.Collections.Generic;

namespace backend.Models.Entity
{
    public class ScrumMaster : Utilisateur
    {
        public virtual ICollection<ScrumMasterProjet> ScrumMasterProjet { get; set; }
        public virtual ICollection<Reunion> Reunions { get; set; }
    }
}
