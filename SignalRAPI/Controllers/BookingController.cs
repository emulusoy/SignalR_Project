using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public ActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public ActionResult CreateBooking(CreateBookingDto createDto)
        {
            Booking booking = new Booking()
            {
                BookingDate = createDto.BookingDate,
                BookingMail = createDto.BookingMail,
                BookingName = createDto.BookingName,
                BookingPersonCount = createDto.BookingPersonCount,
                BookingPhone = createDto.BookingPhone,
            };
            _bookingService.TAdd(booking);
            return Ok("Booking section added successfully");
        }
        [HttpDelete]
        public ActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Booking section deleted successfully!");
        }
        [HttpPut]
        public ActionResult UpdateBooking(UpdateBookingDto updateDto)
        {
            Booking booking=new Booking()
            {
                BookingID = updateDto.BookingID,
                BookingDate = updateDto.BookingDate,
                BookingMail = updateDto.BookingMail,
                BookingName = updateDto.BookingName,
                BookingPersonCount = updateDto.BookingPersonCount,
                BookingPhone = updateDto.BookingPhone,
            };

            _bookingService.TUpdate(booking);   
            return Ok("Booking section updated successfully!");
        }
        [HttpGet("GetBooking")]
        public ActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}
