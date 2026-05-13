using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Video_Content_Streaming_Service.Models;
using Video_Content_Streaming_Service.Services;
using Video_Content_Streaming_Service.ViewModels;

namespace Video_Content_Streaming_Service.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public VideoController(IVideoService videoService, IMapper mapper)
        {
            _videoService = videoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var videos = await _videoService.GetAllVideosAsync();
            var viewModel = _mapper.Map<IEnumerable<VideoViewModel>>(videos);
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var video = await _videoService.GetVideoDetailsAsync(id);
            if (video == null) return NotFound();

            var viewModel = _mapper.Map<VideoViewModel>(video);
            return View(viewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVideoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (int.TryParse(userIdString, out int userId))
                {
                    var video = _mapper.Map<Video>(model);
                    video.UploaderId = userId;
                    video.UploadDate = DateTime.Now;

                    await _videoService.UploadVideoAsync(video, model.VideoFile);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
    }
}