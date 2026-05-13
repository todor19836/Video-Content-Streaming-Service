using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Video_Content_Streaming_Service.Services;
using Video_Content_Streaming_Service.ViewModels;

namespace Video_Content_Streaming_Service.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public HomeController(IVideoService videoService, IMapper mapper)
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
    }
}