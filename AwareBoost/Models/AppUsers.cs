using AwareBoost.Helpers;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace AwareBoost.Models
{
    public class AppUsers :IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        // Navigation Properties
        public ICollection<Upvote> Upvotes { get; set; }

        // Followers
        public ICollection<Followers> Followers { get; set; } // this for the special users
        public ICollection<Followers> Followings { get; set; } // this is for normal users who question only they only can follow not followed


        // Badges
        public ICollection<Badges> Badges { get; set; }

        // Questions
        public ICollection<Questions> Questions { get; set; }

        // Answers
        public ICollection<Answers> Answers { get; set; }

        
        public ICollection<Comments> Comments { get; set; }
    }
}
