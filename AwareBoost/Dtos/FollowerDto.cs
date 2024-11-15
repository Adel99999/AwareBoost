namespace AwareBoost.Dtos
{
    public class FollowerDto
    {
        public Guid Id { get; set; }         // Unique identifier for the follower relationship
        public string SpecialUserId { get; set; }   // The ID of the special user being followed
        public string SpecialUserName { get; set; }  // Name of the special user (optional if you want to display it)
        public string FollowerId { get; set; }       // The ID of the follower user
        public string FollowerUserName { get; set; } // Name of the follower user (optional if you want to display it)
    }

}
