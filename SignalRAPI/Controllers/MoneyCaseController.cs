using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRAPI.Controllers
{
    public class MoneyCaseController : Controller
    {
        private readonly IMoneyCaseService _moneyCaseService;

        public MoneyCaseController(IMoneyCaseService moneyCaseService)
        {
            _moneyCaseService = moneyCaseService;
        }

        [HttpGet("TotalMoneyCaseAmount")]

        public IActionResult TotalMoneyCaseAmount() 
        {
            return Ok(_moneyCaseService.TTotalMoneyCaseAmount());
        }
    }
}
