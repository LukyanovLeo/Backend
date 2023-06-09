namespace Backend.Models.Requests
{
    public class EditWorkRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Data { get; set; }
    }
}
