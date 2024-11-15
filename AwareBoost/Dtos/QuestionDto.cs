namespace AwareBoost.Dtos
{
    public class QuestionDto
    {
        public Guid Id { get; set; }           // Unique identifier for the question
        public string Title { get; set; }      // The title of the question
        public DateTime Created_At { get; set; } // The creation date of the question
        public string UserName { get; set; }   // The username of the user who posted the question
        public string CategoryName { get; set; } // The name of the category (optional)
        public int AnswerCount { get; set; }   // The count of answers for the question
        public List<string> Tags { get; set; } // List of tags associated with the question
    }


}
