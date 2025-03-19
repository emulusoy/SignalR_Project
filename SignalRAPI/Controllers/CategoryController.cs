using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult CategoryList()
        {
            var values =_mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());   
            return Ok(values);
        }
        [HttpPost]
        public ActionResult CreateCategory(CreateCategoryDto createDto)
        {
            _categoryService.TAdd(new Category()
            {
                CategoryName = createDto.CategoryName,
                CategoryStatus = true,
            });
            
            return Ok("Category section added successfully");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Category section deleted successfully!");
        }
        [HttpPut]
        public ActionResult UpdateCategory(UpdateCategoryDto updateDto)
        {
            _categoryService.TAdd(new Category()
            {
                CategoryID = updateDto.CategoryID,
                CategoryName = updateDto.CategoryName,
                CategoryStatus = true,
            });
            return Ok("Category section updated successfully!");
        }
        [HttpGet("{id}")]
        public ActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }
    }
}
