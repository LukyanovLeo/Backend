namespace Backend.Models.Requests
{
    public class RegisterRequest
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }

        public double AvgScore { get; set; }
    }
}
