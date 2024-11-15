namespace AwareBoost.Dtos
{
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public string Answer { get; set; } = string.Empty;
        public DateTime Created_At { get; set; }
        public string AppUserId { get; set; }
        public Guid QuestionId { get; set; }
    }
}
