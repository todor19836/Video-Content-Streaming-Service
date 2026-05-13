using System.ComponentModel.DataAnnotations;

namespace Video_Content_Streaming_Service.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public DateTime UploadDate { get; set; }

        public int UploaderId { get; set; }

        public virtual ApplicationUser Uploader { get; set; } = default!;

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}