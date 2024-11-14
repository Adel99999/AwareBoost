namespace AwareBoost.Models
{
    public class Answers
    {
        public Guid Id { get; set; }
        public string Answer {  get; set; }
        public DateTime Created_At { get; set; } 
        public string AppUserId { get; set; }
        public Guid QuestionId { get; set; }

        // Navigation Properties
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Upvote> Upvotes { get; set; }
        public AppUsers User { get; set; }
        public Questions Question { get; set; }
    }
}
