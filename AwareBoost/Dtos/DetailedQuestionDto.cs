namespace AwareBoost.Dtos
{
    public class DetailedQuestionDto
    {
            public Guid Id { get; set; } // Question ID
            public string Title { get; set; } // Title of the question
            public string Content { get; set; } // Content/body of the question
            public DateTime Created_At { get; set; } // Creation timestamp
            public string UserName { get; set; } // The user who posted the question
            public string CategoryName { get; set; } // Category to which the question belongs
            public List<AnswerDto> Answers { get; set; } // List of answers for the question
        
    }
}
