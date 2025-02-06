using System.ComponentModel.DataAnnotations.Schema;

namespace GameUniverse.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }

        public string Content { get; set; }

        public DateTime CommentDate { get; set; } = DateTime.Now;
    }
}
