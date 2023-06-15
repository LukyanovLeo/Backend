namespace Backend.Models.Requests
{
    public class AddWorkRequest
    {
        public string Tag { get; set; }

        public string Description { get; set; }

        public IFormFile Picture { get; set; }
    }
}
