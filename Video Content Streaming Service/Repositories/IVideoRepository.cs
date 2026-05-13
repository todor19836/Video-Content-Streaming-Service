using Video_Content_Streaming_Service.Models;

namespace Video_Content_Streaming_Service.Repositories
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> GetAllAsync();
        Task<Video?> GetByIdAsync(int id);
        Task AddAsync(Video video);
        Task UpdateAsync(Video video);
    }
}