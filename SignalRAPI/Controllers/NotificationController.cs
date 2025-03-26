using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
           Notification notification = new Notification()
           {
               Description= createNotificationDto.Description,
               Date= Convert.ToDateTime(DateTime.Now.ToShortDateString()),
               Type=createNotificationDto.Type,
               Icon=createNotificationDto.Icon,
               Status=false,
           };
            _notificationService.TAdd(notification);
            return Ok("Added successfuly");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Notification deleted successfully!");
        }
        [HttpGet("{id}")]
        public ActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification()
            {
                NotificationID=updateNotificationDto.NotificationID,
                Description = updateNotificationDto.Description,
                Date = updateNotificationDto.Date,
                Type = updateNotificationDto.Type,
                Icon = updateNotificationDto.Icon,
                Status = updateNotificationDto.Status   ,
            };
            _notificationService.TUpdate(notification);
            return Ok("Updated successfuly");
        }
        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            {
                _notificationService.TNotificationStatusChangeToFalse(id);
                return Ok("Updated False");
            }
        }
        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            {
                _notificationService.TNotificationStatusChangeToTrue(id);
                return Ok("Updated True");
            }
        }
    }
}
