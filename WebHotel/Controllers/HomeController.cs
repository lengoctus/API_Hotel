using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private readonly HotelManagementContext _db;
        private readonly string UrlApi = "http://localhost:8011/api/";

        public HomeController(ILogger<HomeController> logger, IMapper mapper, HotelManagementContext db)
        {
            _logger = logger;
            _mapper = mapper;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = new Room_Dao(_db).GetAccomo().Where(p => p.RoomCategory == 1).Take(4).ToList();
            ViewBag.listAcc_View = _mapper.Map<List<Room_View>>(list);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookingRoom(Booking_View booking)
        {
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Booking>(booking);
                var listBooking_View = _mapper.Map<List<Booking_View>>(_db.Booking.ToList());
                var listRoom_View = _mapper.Map<List<Room_View>>(_db.Room.ToList());
                var infoBooking = new InfoBooking
                {
                    bookingSourse = listBooking_View,
                    Booking = booking,
                    RoomSourse = listRoom_View
                };




                using (HttpClient _client = new HttpClient())
                {
                    var content = JsonConvert.SerializeObject(infoBooking);
                    var httpResponse = await _client.PostAsync(UrlApi + "Booking/GetRoom", new StringContent(content, Encoding.Default, "application/json"));
                    ViewBag.listRoom = JsonConvert.DeserializeObject<List<Room>>(httpResponse.Content.ReadAsStringAsync().Result);
                }
                //var createdTask = JsonConvert.DeserializeObject<InfoBooking>(await httpResponse.Content.ReadAsStringAsync());

                //ViewBag.listRoom = await new BookingRoom_Dao().GetListRoomForBooking(book, _mapper);

                string book_view = JsonConvert.SerializeObject(_mapper.Map<Booking_View>(book));
                HttpContext.Session.SetString("book_view", book_view);

                return View();
            };
            return RedirectToAction("Index");
        }

    }
}