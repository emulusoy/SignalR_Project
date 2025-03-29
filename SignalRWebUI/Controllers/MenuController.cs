using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id; // Burada MenuTableId değerini ayarlıyoruz
                            

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7002/api/Product/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);

        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id, int menuTableId)
        {
            if (menuTableId == 0)
            {
                return BadRequest("MenuTableId 0 geliyor.");
            }

            CreateBasketDto createBasketDto = new CreateBasketDto()
            {
                ProductID = id,
                MenuTableID = menuTableId // Gelen MenuTableID burada kullanılıyor
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7002/api/Basket", stringContent);

            var client2 = _httpClientFactory.CreateClient();
            //var jsonData2 = JsonConvert.SerializeObject(updateCategoryDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client2.GetAsync("https://localhost:7002/api/MenuTables/ChangeMenuTablesStatusToTrue?id=" + menuTableId);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return Json(createBasketDto);

        }
    }
}
