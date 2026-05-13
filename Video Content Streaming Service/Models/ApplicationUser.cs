using Microsoft.AspNetCore.Identity;

namespace Video_Content_Streaming_Service.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
    }
}