namespace AwareBoost.Dtos
{
    public class CommentDto
    {
        public Guid Id { get; set; }       // Unique identifier for the comment
        public string Comment { get; set; } // The content of the comment
        public DateTime Created_At { get; set; } // The creation date of the comment
        public string UserName { get; set; } // The username of the user who posted the comment
    }

}
