using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap(); 
            CreateMap<About, UpdateAboutDto>().ReverseMap(); 
            CreateMap<About, CreateAboutDto>().ReverseMap(); 
            CreateMap<About, GetAboutDto>().ReverseMap(); 
        }
    }
}
