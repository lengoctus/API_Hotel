using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_HotelManagement.Models;
using Web_HotelManagement.Models.Dao;
using Web_HotelManagement.Models.Entities;
using Web_HotelManagement.Models.ModelsView;

namespace Web_HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var list = await new Booking_Dao().GetAll();
            return View(list);
        }

        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Booking_View booking)
        {
            var rs = await new Booking_Dao().Add(booking);
            ViewBag.rs = rs != null ? "Success" : "Failed";
            return View();
        }

    }
}
