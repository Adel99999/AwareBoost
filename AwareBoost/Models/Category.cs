namespace AwareBoost.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties 
        public ICollection<Questions> Questions { get; set; }
    }
}

