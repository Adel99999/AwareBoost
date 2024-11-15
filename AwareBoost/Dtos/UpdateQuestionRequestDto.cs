namespace AwareBoost.Dtos
{
    public class UpdateQuestionRequestDto
    {
        public Guid Id { get; set; }         // The unique identifier of the question being updated
        public string Title { get; set; }    // The updated title of the question
        public Guid? CategoryId { get; set; } // The ID of the updated category (nullable)
        public List<string> Tags { get; set; } // List of tags associated with the question
    }

}
