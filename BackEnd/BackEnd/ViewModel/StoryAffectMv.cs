using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.ViewModel
{
    public class StoryAffectMv
    {
        [Required]
        public List<int> storylist { get; set; }

        [Required]
        public int sprintid { get; set; }

        [Required]
        public int duree { get; set; }

    }
}
