using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Hotel.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Hotel.Controllers
{
    [ApiController]
    [Route("api/Booking")]
    public class BookingController : ControllerBase
    {
        private readonly ConnectDbContext _db;

        public BookingController(ConnectDbContext db)
        {
            _db = db;
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {

            return Ok(_db.Booking.ToList());
        }

    }
}