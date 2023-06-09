namespace Backend.Models.Entities
{
    public class Work
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public string Data { get; set; }

        public DateTime PublishedAt { get; set; }

        public DateTime EditedAt { get; set; }
    }
}
