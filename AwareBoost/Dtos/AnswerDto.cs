namespace AwareBoost.Dtos
{
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public string Answer { get; set; } = string.Empty;
        public DateTime Created_At { get; set; }
        public int UpvotesCount { get; set; }
        public string UserName { get; set; } // The user who posted the answer
        public string AppUserId { get; set; }
        public Guid QuestionId { get; set; }
    }
}
