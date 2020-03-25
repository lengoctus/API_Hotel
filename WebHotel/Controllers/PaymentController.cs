using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebHotel.Models.Dao;
using WebHotel.Models.Entities;
using WebHotel.Models.ModelsView;

namespace WebHotel.Controllers
{
    public class PaymentController : Controller
    {
        private readonly HotelManagementContext _db;
        private readonly IMapper _mapper;

        public PaymentController(HotelManagementContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IActionResult Index(string id)
        {

            try
            {
                if (HttpContext.Session.GetString("id") != null)
                {
                    id = HttpContext.Session.GetString("id");
                }
                //Lay info Room
                int idroom = Convert.ToInt32(id);
                var room = new Room_Dao(_db).GetRoom(idroom);
                ViewBag.room_view = _mapper.Map<Room_View>(room);

                // Xet idRoom cho Booking
                var infobook = HttpContext.Session.GetString("book_view");
                var infobookConvert = JsonConvert.DeserializeObject<Booking_View>(infobook);
                infobookConvert.RoomId = idroom;

                // Luu thong tin Booking cho khach hang
                var customer_view = new Customer_View();
                //customer_view.Booking = new List<Booking_View>();
                //customer_view.Booking.Add(infobookConvert);
                customer_view.Booking_View = new Booking_View
                {
                    InDate = infobookConvert.InDate,
                    OutDate = infobookConvert.OutDate,
                    RoomId = infobookConvert.RoomId,
                    NbPeople = infobookConvert.NbPeople,
                    Address = infobookConvert.Address
                };

                // Xoa Session va tao Session luu thong tin Booking cua khach hang
                HttpContext.Session.Remove("book_view");
                var customerBooking = JsonConvert.SerializeObject(customer_view);
                HttpContext.Session.SetString("customerBooking", customerBooking);


                return View(customer_view);
            }
            catch
            {

                return View();
            }
        }

        [HttpPost]
        public IActionResult LoadData([FromBody]string idroom)
        {
            return Json(idroom);
        }

        [HttpPost]
        public async Task<IActionResult> Register(Customer_View customer)
        {
            try
            {
                // Parse Session thanh Customer_View
                var customer_view = HttpContext.Session.GetString("customerBooking");
                var customerConvert = JsonConvert.DeserializeObject<Customer_View>(customer_view);
                customerConvert.Id = d.Id;

                var booking = _mapper.Map<Booking>(customerConvert.Booking_View);
                booking.CusId = customerConvert.Id;
                booking.Quantiy = customer.Booking_View.Quantity;

                HttpContext.Session.Clear();
                HttpContext.Session.SetString("id", booking.RoomId.ToString());

                // Insert Customer
                var d = new Customer_Dao(_db).Register(_mapper.Map<Customer>(customer));
                using (HttpClient _client = new HttpClient())
                {

                }
                var rs = new BookingRoom_Dao(_db).AddBooking(booking);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("id", customer.Booking_View.RoomId.ToString());
                return View("Index");
            }
        }
    }
}