using Microsoft.EntityFrameworkCore;
using Video_Content_Streaming_Service.Data;
using Video_Content_Streaming_Service.Models;

namespace Video_Content_Streaming_Service.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly ApplicationDbContext _context;

        public VideoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Video>> GetAllAsync()
        {
            return await _context.Videos
                .Include(v => v.Uploader)
                .ToListAsync();
        }

        public async Task<Video?> GetByIdAsync(int id)
        {
            return await _context.Videos
                .Include(v => v.Uploader)
                .Include(v => v.Comments)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(Video video)
        {
            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Video video)
        {
            _context.Videos.Update(video);
            await _context.SaveChangesAsync();
        }
    }
}