using System.ComponentModel.DataAnnotations;

namespace BackEnd.ViewModel
{
    public class UtilsateurStoryMv
    {
        [Required]
        public string userId { get; set; }

        [Required]
        public int StoryId { get; set; }

        public int Duree { get; set; }

    }
}
