namespace Backend.Models.Requests
{
    public class GetWorksByFilterRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime PublishedAt { get; set; }
    }
}
