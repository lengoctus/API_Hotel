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
        public async Task<ActionResult<List<Booking_View>>> Gets()
        {
            var listBook = await _hotel.Gets();

            var listbook_view = _mapper.Map<List<Booking_View>>(listBook);
            return Ok(listbook_view);
        }

     
        [HttpGet("{phone}")]
        public async Task<ActionResult<Booking_View>> Get(string phone)
        {
            var book = await _hotel.Get(phone);

            if (book == null)
            {
                return NotFound();
            }

            var book_view = _mapper.Map<Booking_View>(book);
            return Ok(book_view);
        }

    }
}