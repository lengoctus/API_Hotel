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
    [ApiController]
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
        public async Task<IActionResult> Get()
        {
            var listBook = await _hotel.GetList();

            var listbook_view = _mapper.Map<List<Booking_View>>(listBook);
            return Ok(listbook_view);
        }

        public async Task<IActionResult> Register(Booking_View book_view)
        {
            if (ModelState.IsValid)
            {
                var book = await _hotel.RegisterBooking(_mapper.Map<Booking>(book_view));
                if (book != null)
                {
                    return Ok(_mapper.Map<Booking_View>(book));
                }
            }
            return BadRequest();
        }

    }
}