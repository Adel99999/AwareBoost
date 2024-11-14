namespace AwareBoost.Models
{
    public class Followers
    {
        public Guid Id { get; set; }  

        
        public string SpecialUserId { get; set; }
        public AppUsers SpecialUser { get; set; }  
        public string FollowerId { get; set; }

        public AppUsers FollowerUser { get; set; }  

    }
}
