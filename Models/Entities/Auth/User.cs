namespace Backend.Models.Entities.Auth
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime RegisteredAt { get; set; }

        public DateTime LastLoginAt { get; set; }
    }
}
