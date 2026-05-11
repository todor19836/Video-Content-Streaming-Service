using System.ComponentModel.DataAnnotations;

namespace VideoStreaming.Web.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CommentDate { get; set; }

        public int VideoId { get; set; }

        public Video Video { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}