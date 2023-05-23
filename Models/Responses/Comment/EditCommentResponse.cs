namespace Backend.Models.Requests.Comment
{
    public class EditCommentResponse
    {
        public bool IsSuccess { get; set; }

        public EditCommentResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
