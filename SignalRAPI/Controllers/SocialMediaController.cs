using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;

using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _SocialMediaService;

        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _SocialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_SocialMediaService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public ActionResult CreateSocialMedia(CreateSocialMediaDto createDto)
        {
            _SocialMediaService.TAdd(new SocialMedia()
            {
                SocialMediaIcon=createDto.SocialMediaIcon,  
                SocialMediaTitle=createDto.SocialMediaTitle,
                SocialMediaUrl=createDto.SocialMediaUrl,
            });

            return Ok("SocialMedia section added successfully");
        }
        [HttpDelete]
        public ActionResult DeleteSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetById(id);
            _SocialMediaService.TDelete(value);
            return Ok("SocialMedia section deleted successfully!");
        }
        [HttpPut]
        public ActionResult UpdateSocialMedia(UpdateSocialMediaDto updateDto)
        {
            _SocialMediaService.TUpdate(new SocialMedia()
            {
                SocialMediaUrl = updateDto.SocialMediaUrl,
                SocialMediaTitle = updateDto.SocialMediaTitle,
                SocialMediaIcon = updateDto.SocialMediaIcon,
                SocialMediaID = updateDto.SocialMediaID,
            });
            return Ok("SocialMedia section updated successfully!");
        }
        [HttpGet("GetSocialMedia")]
        public ActionResult GetSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetById(id);
            return Ok(value);
        }
    }
}
