using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }
        [HttpGet]
        public ActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public ActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                MenuTableName = createMenuTableDto.MenuTableName,
                MenuTableStatus = false,

            };
            _menuTableService.TAdd(menuTable);
            return Ok("MenuTable section added successfully");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            _menuTableService.TDelete(value);
            return Ok("MenuTable section deleted successfully!");
        }
        [HttpPut]
        public ActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                MenuTableID = updateMenuTableDto.MenuTableID,
                MenuTableName = updateMenuTableDto.MenuTableName,
                MenuTableStatus = false,

            };

            _menuTableService.TUpdate(menuTable);
            return Ok("MenuTable section updated successfully!");
        }
        [HttpGet("{id}")]
        public ActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(value);
        }
    }
}
