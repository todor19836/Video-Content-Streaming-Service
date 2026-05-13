using AutoMapper;
using Video_Content_Streaming_Service.Models;
using Video_Content_Streaming_Service.ViewModels;

namespace Video_Content_Streaming_Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideoViewModel>()
                .ForMember(dest => dest.UploaderName, opt => opt.MapFrom(src => src.Uploader.UserName))
                .ForMember(dest => dest.UploadDate, opt => opt.MapFrom(src => src.UploadDate))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => "/videos/" + src.FilePath));

            CreateMap<CreateVideoViewModel, Video>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FilePath, opt => opt.Ignore());

            CreateMap<VideoViewModel, Video>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.VideoId))
                .ForMember(dest => dest.UploaderId, opt => opt.Ignore())
                .ForMember(dest => dest.FilePath, opt => opt.Ignore());
        }
    }
}