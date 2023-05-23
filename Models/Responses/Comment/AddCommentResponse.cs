namespace Backend.Models.Requests.Comment
{
    public class AddCommentResponse
    {
        public bool IsSuccess { get; set; }

        public AddCommentResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
