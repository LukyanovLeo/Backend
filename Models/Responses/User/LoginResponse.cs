namespace Backend.Models.Responses
{
    public class LoginResponse : ResponseBase
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public double AvgScore { get; set; }
    }
}
