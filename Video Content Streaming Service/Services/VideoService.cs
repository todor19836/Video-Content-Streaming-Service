using Video_Content_Streaming_Service.Models;
using Video_Content_Streaming_Service.Repositories;

namespace Video_Content_Streaming_Service.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IWebHostEnvironment _environment;

        public VideoService(IVideoRepository videoRepository, IWebHostEnvironment environment)
        {
            _videoRepository = videoRepository;
            _environment = environment;
        }

        public async Task UploadVideoAsync(Video video, IFormFile file)
        {
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "videos");
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            video.FilePath = uniqueFileName;
            await _videoRepository.AddAsync(video);
        }

        public async Task<IEnumerable<Video>> GetAllVideosAsync() => await _videoRepository.GetAllAsync();
        public async Task<Video?> GetVideoDetailsAsync(int id) => await _videoRepository.GetByIdAsync(id);
    }
}