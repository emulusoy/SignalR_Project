using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            this._aboutService = aboutService;
        }

        [HttpGet]
        public ActionResult AboutList()
        {
            var values=_aboutService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public ActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {                
                AboutDescription = createAboutDto.AboutDescription,
                AboutImageUrl = createAboutDto.AboutImageUrl,
                AboutTitle = createAboutDto.AboutTitle,
            };
            _aboutService.TAdd(about);
            return Ok("About section added successfully");    
        }
        [HttpDelete]
        public ActionResult DeleteAbout(int id)
        {
            var value=_aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("About section deleted successfully!");
        }
        [HttpPut]
        public ActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about=new About()
            {
                AboutID = updateAboutDto.AboutID,
                AboutDescription = updateAboutDto.AboutDescription,
                AboutImageUrl = updateAboutDto.AboutImageUrl,
                AboutTitle = updateAboutDto.AboutTitle,
            };

            _aboutService.TUpdate(about);
            return Ok("About section updated successfully!");
        }
        [HttpGet("GetAbout")]
        public ActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);           
            return Ok(value);
        }
    }
}
