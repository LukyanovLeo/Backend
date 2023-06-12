namespace Backend.Models.Requests
{
    public class LoginRequest
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public double AvgScore { get; set; }
    }
}
