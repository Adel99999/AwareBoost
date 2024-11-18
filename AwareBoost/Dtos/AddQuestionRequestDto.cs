namespace AwareBoost.Dtos
{
    public class AddQuestionRequestDto
    {
        public string Title { get; set; }     // The title of the question
        public string Content { get; set; }
        public Guid? CategoryId { get; set; } // The ID of the category (nullable)
        public List<string> Tags { get; set; } // List of tags for the question
    }

}
