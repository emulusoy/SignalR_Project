using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _DiscountService;

        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _DiscountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_DiscountService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public ActionResult CreateDiscount(CreateDiscountDto createDto)
        {
            _DiscountService.TAdd(new Discount()
            {
                DiscountAmount=createDto.DiscountAmount,
                DiscountDescription=createDto.DiscountDescription,  
                DiscountImageUrl=createDto.DiscountImageUrl,    
                DiscountTitle=createDto.DiscountTitle,  
            });

            return Ok("Discount section added successfully");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteDiscount(int id)
        {
            var value = _DiscountService.TGetById(id);
            _DiscountService.TDelete(value);
            return Ok("Discount section deleted successfully!");
        }
        [HttpPut]
        public ActionResult UpdateDiscount(UpdateDiscountDto updateDto)
        {
            _DiscountService.TUpdate(new Discount()
            {
                DiscountTitle = updateDto.DiscountTitle,
                DiscountDescription = updateDto.DiscountDescription,    
                DiscountID=updateDto.DiscountID,    
                DiscountImageUrl = updateDto.DiscountImageUrl,
                DiscountAmount = updateDto.DiscountAmount,
                
            });
            return Ok("Discount section updated successfully!");
        }
        [HttpGet("{id}")]
        public ActionResult GetDiscount(int id)
        {
            var value = _DiscountService.TGetById(id);
            return Ok(value);
        }
    }
}
