﻿namespace AwareBoost.Models
{
    public class Upvote
    {
        public Guid Id { get; set; }
        public string AppUserId { get; set; }
        public Guid AnswerId { get; set; }

        // Navigation Properties 
        public AppUsers User { get; set; }
        public Answers Answer { get; set; }
    }
}
