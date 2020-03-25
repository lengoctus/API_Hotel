using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Hotel.Models.Entities;
using API_Hotel.Models.ModelViews;
using API_Hotel.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Hotel.Controllers
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
        //[HttpGet("{bookingSourse}/{booking}/{RoomSourse}")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Booking_View>>> GetRoom(List<Booking_View> bookingSourse, Booking_View booking, List<Room_View> RoomSourse)
        {
            var listBooking = _mapper.Map<List<Booking>>(bookingSourse);
            var booking_2 = _mapper.Map<Booking>(booking);
            var listRoom = _mapper.Map<List<Room>>(RoomSourse);


            var listBookingResult = await _hotel.BookingRoom(listBooking, booking_2, listRoom);
            if (listBookingResult != null)
            {
                return Ok(_mapper.Map<List<Booking_View>>(listBookingResult));
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
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
