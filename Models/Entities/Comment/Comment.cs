using Backend.Models.Enums;

namespace Backend.Models.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public Scores Score { get; set; }

        public int UserId { get; set; }

        public DateTime PublishedAt { get; set; }
    }
}
