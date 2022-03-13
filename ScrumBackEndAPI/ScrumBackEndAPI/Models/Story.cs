﻿using System;
using System.Collections.Generic;

namespace backend.Models.Entity
{
    public class Story
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateDernierModification { get; set; }
        public string Commentaire { get; set; }
        public int BacklogId { get; set; }
        public Backlog Backlog { get; set; }
        public virtual ICollection<Tache> Taches { get; set; }
        public virtual ICollection<SprintStory> SprintStories { get; set; }
        public virtual ICollection<DeveloppeurStory> DeloppeurStories { get; set; }
        public virtual ICollection<TesteurStory> TesteurStories { get; set; }
    }
}
