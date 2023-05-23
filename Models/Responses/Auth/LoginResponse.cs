namespace Backend.Models.Requests.Auth
{
    public class LoginResponse
    {
        public bool IsLogedIn { get; set; }


        public LoginResponse(bool isLogedIn)
        {
            IsLogedIn = isLogedIn;
        }
    }
}
