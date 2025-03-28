using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;


        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
            
        }

        [HttpGet]
        public ActionResult SliderList()
        {
            var values = _sliderService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public ActionResult CreateSlider(CreateSliderDto createDto)
        {
            _sliderService.TAdd(new Slider()
            {
               Title1=createDto.Title1,
               Description1=createDto.Description1, 
               Description2 = createDto.Description2,
               Description3 = createDto.Description3,
               Title2 = createDto.Title2,
              Title3=createDto.Title3, 
            });

            return Ok("Slider section added successfully");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Slider section deleted successfully!");
        }
        [HttpPut]
        public ActionResult UpdateSlider(UpdateSliderDto updateDto)
        {
            _sliderService.TUpdate(new Slider()
            {
                Title1 = updateDto.Title1,
                Description1 = updateDto.Description1,
                Description2 = updateDto.Description2,
                Description3 = updateDto.Description3,
                Title2 = updateDto.Title2,
                Title3 = updateDto.Title3,
                SliderID = updateDto.SliderID,
            });
            return Ok("Slider section updated successfully!");
        }
        [HttpGet("{id}")]
        public ActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(value);
        }
    }
}
