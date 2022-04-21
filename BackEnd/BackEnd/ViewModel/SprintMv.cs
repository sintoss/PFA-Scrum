using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.ViewModel
{
    public class SprintMv
    {
        [Required, StringLength(50)]
        public string libelle { get; set; }
        [Required]
        public DateTime dateestimeedefin { get; set; }

        [Required]
        public int BacklogId { get; set; }

        public int dureeSprint { get; set; }

        public int jourTravail { get; set; }


    }
}
