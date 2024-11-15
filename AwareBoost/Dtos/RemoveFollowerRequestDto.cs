namespace AwareBoost.Dtos
{
    public class RemoveFollowerRequestDto
    {
        public string SpecialUserId { get; set; }  // The ID of the special user
        public string FollowerId { get; set; }     // The ID of the follower user
    }
}
