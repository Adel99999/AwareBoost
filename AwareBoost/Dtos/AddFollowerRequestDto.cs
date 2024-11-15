namespace AwareBoost.Dtos
{
    public class AddFollowerRequestDto
    {
        public string SpecialUserId { get; set; }  // The ID of the special user being followed
        public string FollowerId { get; set; }     // The ID of the follower user
    }
}
