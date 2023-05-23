namespace Backend.Models.Requests.Auth
{
    public class RegisterRequest
    {
        public string Login { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }

        public string Email { get; set; }


    }
}
