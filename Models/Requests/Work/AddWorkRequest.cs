namespace Backend.Models.Requests
{
    public class AddWorkRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public string Data { get; set; }
    }
}
