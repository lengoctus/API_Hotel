using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Hotel.Models.Entities;
using API_Hotel.Models.ModelViews;
using API_Hotel.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Hotel.Controllers
{
    [Route("api/Booking")]
    public class BookingController : ControllerBase
    {
        private readonly IHotel _hotel;
        private readonly IMapper _mapper;

        public BookingController(IHotel hotel, IMapper mapper)
        {
            _hotel = hotel;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Booking_View>>> Gets(string FullName, string Phone)
        {
            var book = await _hotel.Gets(FullName, Phone);
            var listBook_view = _mapper.Map<List<Booking_View>>(book);
            return Ok(listBook_view);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Booking_View>> Add([FromBody]Booking_View booking_view)
        {
            var book = _mapper.Map<Booking>(booking_view);
            var rs = await _hotel.Add(book);

            if (rs == true)
            {
                return Ok("Register Booking Success!!");
            }

            return BadRequest();
        }

    }
}