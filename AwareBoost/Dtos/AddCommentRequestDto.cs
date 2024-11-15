namespace AwareBoost.Dtos
{
    public class AddCommentRequestDto
    {
        public string Comment {  get; set; }    
        public Guid AnswerId { get; set; }
    }
}
