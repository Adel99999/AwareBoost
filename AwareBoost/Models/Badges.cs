namespace AwareBoost.Models
{
    public class Badges
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        //Navigation Properties 
        public ICollection<AppUsers> Users { get; set; }
    }
}

