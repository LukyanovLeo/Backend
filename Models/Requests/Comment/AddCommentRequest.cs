namespace Backend.Models.Requests.Comment
{
    public class AddCommentRequest
    {
        public string Text { get; set; }

        public int ScoreId { get; set; }

        public int UserId { get; set; }
    }
}
