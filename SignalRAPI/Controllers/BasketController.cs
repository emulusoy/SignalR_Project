using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalRAPI.Model;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id) 
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values=context.Baskets.Include(x=>x.Product).Where(y=>y.MenuTableID==id).Select(z=>new ResultBasketListWithProduct
            {
                MenuTableID = z.MenuTableID,
                BasketID=z.BasketID,
                Count=z.Count,
                Price=z.Price,
                ProductID=z.ProductID,
                ProductName = z.Product.ProductName,
                TotalPrice = z.TotalPrice

             
            }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                MenuTableID = createBasketDto.MenuTableID,
                Count = 1,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.ProductPrice).FirstOrDefault(),
                TotalPrice = createBasketDto.TotalPrice,
            });
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Product deleted from the basket");
        }
    }
}
