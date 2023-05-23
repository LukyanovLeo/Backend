namespace Backend.Models.Requests.Auth
{
    public class RegisterResponse
    {
        public bool IsSuccess { get; set; }

        public RegisterResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
