using API_Hotel.Models.Entities;
using API_Hotel.Models.ModelViews;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API_Hotel.Services
{
    public class HotelManagement
    {
        private readonly ConnectDbContext _db;
        private readonly IMapper _mapper;

        public HotelManagement(ConnectDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public string Enscrypt(string Phone, string Password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Phone + Password));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }


        public Task<Booking_View> GetBookingByUserName(string phone, string password)
        {
            var bk = _db.Booking.SingleOrDefault(p => p.Phone == phone && p.Password == Enscrypt(phone, password));
            return Task.Run(() => _mapper.Map<Booking_View>(bk));
        }

        public Task<IEnumerable<Account_View>> GetListAccount()
        {
            var listAccount = _db.Account.ToList();

            return Task.Run(() => _mapper.Map<IEnumerable<Account_View>>(listAccount));
        }

        public Task<IEnumerable<Booking_View>> GetListBooking()
        {
            var listBooking = _db.Booking.ToList();
            return Task.Run(() => _mapper.Map<IEnumerable<Booking_View>>(listBooking));
        }

        public Task<Booking_View> RegisterBooking(Booking_View booking_view)
        {
            var book = _mapper.Map<Booking>(booking_view);
            if (_db.Booking.Find(booking_view.Phone) != null)
            {
                return null;
            }
            _db.Booking.Add(book);
            _db.SaveChanges();

            booking_view = _mapper.Map<Booking_View>(book);

            return Task.Run(() => booking_view);
        }
    }
}
