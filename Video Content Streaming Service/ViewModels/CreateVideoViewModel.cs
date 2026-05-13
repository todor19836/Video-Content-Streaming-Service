using System.ComponentModel.DataAnnotations;

namespace Video_Content_Streaming_Service.ViewModels
{
    public class CreateVideoViewModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a video file.")]
        public IFormFile VideoFile { get; set; }
    }
}