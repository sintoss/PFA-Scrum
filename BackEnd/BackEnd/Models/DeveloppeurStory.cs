﻿using System;

namespace BackEnd.Models
{
    public class DeveloppeurStory
    {
        public int Id { get; set; }
        public string DeveloppeurId { get; set; }
        public virtual Developpeur Developpeur { get; set; }
        public int StoryId { get; set; }
        public virtual Story Story { get; set; }
        public DateTime DateAffectation { get; set; }
    }
}
