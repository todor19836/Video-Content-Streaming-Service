using System.ComponentModel.DataAnnotations;

namespace Video_Content_Streaming_Service.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public int VideoId { get; set; }
        public virtual Video Video { get; set; } = default!;

        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = default!;
    }
}