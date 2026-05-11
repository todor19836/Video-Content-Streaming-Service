using System.ComponentModel.DataAnnotations;

namespace VideoStreaming.Web.Models
{
    public class Video
    {
        public int VideoId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime UploadDate { get; set; }

        public int Duration { get; set; }

        public int Views { get; set; }

        public string UploaderId { get; set; }

        public ApplicationUser Uploader { get; set; }
    }
}