using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;

        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _ContactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_ContactService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public ActionResult CreateContact(CreateContactDto createDto)
        {
            _ContactService.TAdd(new Contact()
            {
                ContactPhone = createDto.ContactPhone,
                ContactMail = createDto.ContactMail,    
                ContactLocation = createDto.ContactLocation,
                FooterDescription = createDto.FooterDescription,    
            });

            return Ok("Contact section added successfully");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteContact(int id)
        {
            var value = _ContactService.TGetById(id);
            _ContactService.TDelete(value);
            return Ok("Contact section deleted successfully!");
        }
        [HttpPut]
        public ActionResult UpdateContact(UpdateContactDto updateDto)
        {
            _ContactService.TUpdate(new Contact()
            {
                ContactID = updateDto.ContactID,
                ContactLocation = updateDto.ContactLocation,
                ContactMail = updateDto.ContactMail,    
                ContactPhone = updateDto.ContactPhone,  
                FooterDescription = updateDto.FooterDescription,    
                
            });
            return Ok("Contact section updated successfully!");
        }
        [HttpGet("{id}")]
        public ActionResult GetContact(int id)
        {
            var value = _ContactService.TGetById(id);
            return Ok(value);
        }
    }
}
