using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _FeatureService;

        private readonly IMapper _mapper;

        public FeatureController(IFeatureService FeatureService, IMapper mapper)
        {
            _FeatureService = FeatureService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_FeatureService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public ActionResult CreateFeature(CreateFeatureDto createDto)
        {
            _FeatureService.TAdd(new Feature()
            {
                FeatureTitle=createDto.FeatureTitle,    
                FeatureDescription=createDto.FeatureDescription,    
            });

            return Ok("Feature section added successfully");
        }
        [HttpDelete]
        public ActionResult DeleteFeature(int id)
        {
            var value = _FeatureService.TGetById(id);
            _FeatureService.TDelete(value);
            return Ok("Feature section deleted successfully!");
        }
        [HttpPut]
        public ActionResult UpdateFeature(UpdateFeatureDto updateDto)
        {
            _FeatureService.TAdd(new Feature()
            {
                FeatureDescription = updateDto.FeatureDescription,
                FeatureID = updateDto.FeatureID,    
                FeatureTitle = updateDto.FeatureTitle,  
                
            });
            return Ok("Feature section updated successfully!");
        }
        [HttpGet("GetFeature")]
        public ActionResult GetFeature(int id)
        {
            var value = _FeatureService.TGetById(id);
            return Ok(value);
        }
    }
}
