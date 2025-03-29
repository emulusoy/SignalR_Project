﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;


        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            this._aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult AboutList()
        {
            var values=_aboutService.TGetListAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(values));
        }
        [HttpPost]
        public ActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(value);
            return Ok("About section added successfully");    
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteAbout(int id)
        {
            var value=_aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("About section deleted successfully!");
        }
        [HttpPut]
        public ActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);

            _aboutService.TUpdate(value);
            return Ok("About section updated successfully!");
        }
        [HttpGet("{id}")]
        public ActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);           
            return Ok(_mapper.Map<GetAboutDto>(value));
        }
    }
}
