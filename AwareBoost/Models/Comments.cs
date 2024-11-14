namespace AwareBoost.Models
{
    public class Comments
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public string AppUserId { get; set; }
        public Guid AnswerId { get; set; }

        //Navigation Properties
        public AppUsers User { get; set; }
        public Answers Answer { get; set; }
    }
}

