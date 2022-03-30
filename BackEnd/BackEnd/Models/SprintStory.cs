namespace BackEnd.Models
{
    public class SprintStory
    {
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }
        public int StoryId { get; set; }
        public Story Story { get; set; }
    }
}
