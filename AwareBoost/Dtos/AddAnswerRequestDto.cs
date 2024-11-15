namespace AwareBoost.Dtos
{
    public class AddAnswerRequestDto
    {

        public string Answer { get; set; } = string.Empty;
        public Guid QuestionId { get; set; }
    }
}
