namespace Backend.Models.Requests
{
    public class LoginRequest
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string PasswordRepeat { get; set; }
    }
}
