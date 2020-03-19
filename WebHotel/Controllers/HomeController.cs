using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebHotel.Models;
using WebHotel.Models.Dao;
using WebHotel.Models.Entities;
using WebHotel.Models.ModelsView;

namespace WebHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var list = new Room_Dao().GetAccomo().Where(p => p.RoomCategory == 1).Take(4).ToList();
            ViewBag.listAcc_View = _mapper.Map<List<Room_View>>(list);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookingRoom(Booking_View booking)
        {
            var book = _mapper.Map<Booking>(booking);
            var listRoom = new BookingRoom_Dao().GetListRoomForBooking(book);
            return View();
        }

        public IActionResult Ahihi()
        {

            return View();
        }
    }
}