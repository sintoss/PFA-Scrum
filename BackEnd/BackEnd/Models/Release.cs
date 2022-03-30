using System;

namespace BackEnd.Models
{
    public class Release
    {
        public int Id { get; set; }
        public DateTime DateRelease { get; set; }
        public string Version { get; set; }
        public bool IsValide { get; set; }
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }
    }
}
