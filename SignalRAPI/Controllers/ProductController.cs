using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _ProductService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_ProductService.TGetListAll());
            return Ok(values);
        }
        [HttpGet("ProductCount")]
        public ActionResult ProductCount()
        {
            return Ok(_ProductService.TProductCount());
        }
        [HttpGet("TProductCountByCategoryNameHamburger")]
        public ActionResult TProductCountByCategoryNameHamburger()
        {
            return Ok(_ProductService.TProductCountByCategoryNameHamburger());
        }
        [HttpGet("TProductCountByCategoryNameDrink")]
        public ActionResult TProductCountByCategoryNameDrink()
        {
            return Ok(_ProductService.TProductCountByCategoryNameDrink());
        }
        [HttpGet("ProductPriceAvg")]
        public ActionResult ProductPriceAvg()
        {
            return Ok(_ProductService.TProductPriceAvg());
        }
        [HttpGet("ProductNameByMaxPrice")]
        public ActionResult ProductNameByMaxPrice()
        {
            return Ok(_ProductService.TProductNameByMaxPrice());
        }
        [HttpGet("ProductNameByMinPrice")]
        public ActionResult ProductNameByMinPrice()
        {
            return Ok(_ProductService.TProductNameByMinPrice());
        }
        
            [HttpGet("ProductPriceByHamburger")]
        public ActionResult ProductPriceByHamburger()
        {
            return Ok(_ProductService.TProductPriceByHamburger());
        }

        [HttpGet("ProductListWithCategory")]
        public ActionResult ProductListWithCategory()
        {
            var context =new  SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                
                ProductDescription = y.ProductDescription,
                ProductID = y.ProductID,
                ProductImageUrl = y.ProductImageUrl,
                ProductName = y.ProductName,
                ProductPrice = y.ProductPrice,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName,
            });
            return Ok(values);
        }
        [HttpPost]
        public ActionResult CreateProduct(CreateProductDto createDto)
        {
            _ProductService.TAdd(new Product()
            {
                
                ProductStatus = createDto.ProductStatus,
                ProductName = createDto.ProductName,    
                ProductDescription = createDto.ProductDescription,  
                ProductPrice = createDto.ProductPrice,  
                ProductImageUrl = createDto.ProductImageUrl,
                CategoryID = createDto.CategoryID,
            });

            return Ok("Product section added successfully");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var value = _ProductService.TGetById(id);
            _ProductService.TDelete(value);
            return Ok("Product section deleted successfully!");
        }
        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            var value = _ProductService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public ActionResult UpdateProduct(UpdateProductDto updateDto)
        {
            _ProductService.TUpdate(new Product()
            {
                ProductID = updateDto.ProductID,
                ProductDescription = updateDto.ProductDescription,
                ProductName = updateDto.ProductName,        
                ProductStatus = updateDto.ProductStatus,    
                 ProductImageUrl = updateDto.ProductImageUrl,
                 ProductPrice = updateDto.ProductPrice,
                 CategoryID=updateDto.CategoryID
            });
            return Ok("Product section updated successfully!");
        }

    }
}
