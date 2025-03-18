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
            });

            return Ok("Product section added successfully");
        }
        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            var value = _ProductService.TGetById(id);
            _ProductService.TDelete(value);
            return Ok("Product section deleted successfully!");
        }
        [HttpPut]
        public ActionResult UpdateProduct(UpdateProductDto updateDto)
        {
            _ProductService.TAdd(new Product()
            {
                ProductDescription = updateDto.ProductDescription,
                ProductName = updateDto.ProductName,        
                ProductStatus = updateDto.ProductStatus,    
                 ProductID = updateDto.ProductID,
                 ProductImageUrl = updateDto.ProductImageUrl,
                 ProductPrice = updateDto.ProductPrice,
            });
            return Ok("Product section updated successfully!");
        }
        [HttpGet("GetProduct")]
        public ActionResult GetProduct(int id)
        {
            var value = _ProductService.TGetById(id);
            return Ok(value);
        }
    }
}
