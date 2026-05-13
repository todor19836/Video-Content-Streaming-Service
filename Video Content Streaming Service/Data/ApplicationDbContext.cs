using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Video_Content_Streaming_Service.Models;

namespace Video_Content_Streaming_Service.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Comment>()
                .HasOne(c => c.Video)
                .WithMany(v => v.Comments)
                .HasForeignKey(c => c.VideoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Video>()
                .HasOne(v => v.Uploader)
                .WithMany(u => u.Videos)
                .HasForeignKey(v => v.UploaderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}