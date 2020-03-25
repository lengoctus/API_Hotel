using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Api.Models.Entities;
using Hotel_Api.Models.ModelViews;
using Hotel_Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Hotel_Api.Models.ModelsView;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel_Api.Controllers
{
    [Route("api/Booking")]
    public class BookingController : Controller
    {

        private readonly IHotel _hotel;
        private readonly IMapper _mapper;

        public BookingController(IHotel hotel, IMapper mapper)
        {
            _hotel = hotel;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpPost("GetRoom")]
        public async Task<ActionResult> GetRoom([FromBody]InfoBooking infoBooking)
        {
            var listBooking = _mapper.Map<List<Booking>>(infoBooking.bookingSourse);
            var booking_2 = _mapper.Map<Booking>(infoBooking.Booking);
            var listRoom = _mapper.Map<List<Room>>(infoBooking.RoomSourse);


            var listBookingResult = await _hotel.BookingRoom(listBooking, booking_2, listRoom);
            if (listBookingResult != null)
            {
                return Ok(_mapper.Map<List<Room>>(listBookingResult));
            }
            return NotFound();
        }



        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var listBooking = await _hotel.GetBooking(id);
            if (listBooking != null)
            {
                return Ok(_mapper.Map<List<Booking_View>>(listBooking));
            }
            return BadRequest();
        }

        // POST api/<controller>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]Booking_View booking_view)
        {
            if (ModelState.IsValid)
            {
                var booking = _mapper.Map<Booking>(booking_view);
                var rs = await _hotel.AddBooking(booking);
                return rs != null ? Ok(_mapper.Map<>)
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
