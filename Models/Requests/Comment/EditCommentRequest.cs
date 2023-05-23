namespace Backend.Models.Requests.Comment
{
    public class EditCommentRequest
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int ScoreId { get; set; }
    }
}
