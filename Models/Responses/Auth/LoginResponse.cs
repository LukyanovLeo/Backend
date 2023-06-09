namespace Backend.Models.Responses
{
    public class LoginResponse : ResponseBase
    {
        public int UserId { get; set; }

        public string UserLogin { get; set; }

        public string UserName { get; set; }
    }
}
