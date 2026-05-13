namespace Video_Content_Streaming_Service.ViewModels
{
    public class VideoViewModel
    {
        public int VideoId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public string UploaderName { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; }
    }
}