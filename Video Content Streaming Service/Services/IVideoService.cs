using Video_Content_Streaming_Service.Models;

namespace Video_Content_Streaming_Service.Services
{
    public interface IVideoService
    {
        Task<IEnumerable<Video>> GetAllVideosAsync();
        Task<Video?> GetVideoDetailsAsync(int id);
        Task UploadVideoAsync(Video video, IFormFile file);
    }
}