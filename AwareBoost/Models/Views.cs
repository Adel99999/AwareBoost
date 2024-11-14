namespace AwareBoost.Models
{
    public class Views
    {
        public Guid Id { get; set; }
        public Guid QuesitonId { get; set; }

        //Navigation Property 
        public Questions Question { get; set; }
    }
}

