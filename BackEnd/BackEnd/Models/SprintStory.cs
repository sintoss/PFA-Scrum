namespace BackEnd.Models
{
    public class SprintStory
    {
        public int SprintId { get; set; }
        public virtual Sprint Sprint { get; set; }
        public int StoryId { get; set; }
        public virtual Story Story { get; set; }
    }
}
