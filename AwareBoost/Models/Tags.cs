﻿namespace AwareBoost.Models
{
    public class Tags
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }

        // Navigation Property 
        public ICollection<Questions> Questions { get; set; }
    }
}
