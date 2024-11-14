namespace AwareBoost.Models
{
    public class Questions
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Created_At { get; set; }
        public string AppUserId { get; set; }
        public Guid? CategoryId { get; set; }

        //Navigation Properties
        public Category Category { get; set; }
        public AppUsers User { get; set; }
        public ICollection<Answers> Answers { get; set; }
        public ICollection<Views> Views { get; set; }
        public ICollection<Tags> Tags { get; set; }

    }
}

