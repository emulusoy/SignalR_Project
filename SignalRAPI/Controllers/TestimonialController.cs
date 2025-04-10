﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;

using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _TestimonialService;

        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _TestimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_TestimonialService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public ActionResult CreateTestimonial(CreateTestimonialDto createDto)
        {
            _TestimonialService.TAdd(new Testimonial()
            {
                TestimonialComment=createDto.TestimonialComment,
                TestimonialImageUrl=createDto.TestimonialImageUrl,  
                TestimonialTitle=createDto.TestimonialTitle,  
                TestimonialName=createDto.TestimonialName,
                TestimonialStatus=createDto.TestimonialStatus,
            });

            return Ok("Testimonial section added successfully");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteTestimonial(int id)
        {
            var value = _TestimonialService.TGetById(id);
            _TestimonialService.TDelete(value);
            return Ok("Testimonial section deleted successfully!");
        }
        [HttpPut]
        public ActionResult UpdateTestimonial(UpdateTestimonialDto updateDto)
        {
            _TestimonialService.TUpdate(new Testimonial()
            {
                TestimonialComment = updateDto.TestimonialComment,
                TestimonialImageUrl = updateDto.TestimonialImageUrl,
                TestimonialTitle = updateDto.TestimonialTitle,
                TestimonialName = updateDto.TestimonialName,
                TestimonialStatus = updateDto.TestimonialStatus,
                TestimonialID =updateDto.TestimonialID,
            });
            return Ok("Testimonial section updated successfully!");
        }
        [HttpGet("{id}")]
        public ActionResult GetTestimonial(int id)
        {
            var value = _TestimonialService.TGetById(id);
            return Ok(value);
        }
    }
}
