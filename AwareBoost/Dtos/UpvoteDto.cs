namespace AwareBoost.Dtos
{
    public class UpvoteDto
    {
        public Guid Id { get; set; }
        public string AppUserId { get; set; }
        public Guid AnswerId { get; set; }
    }

}
