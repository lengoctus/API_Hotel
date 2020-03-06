using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Web_HotelManagement.Models.Entities;
using Web_HotelManagement.Models.ModelsView;

namespace Web_HotelManagement.Models.Dao
{
    public class Booking_Dao
    {
        private HotelManagementContext _db;

        public Booking_Dao()
        {
            _db = new HotelManagementContext();
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

        public Task<Booking> Add(Booking_View booking_view)
        {
            if (_db.Booking.SingleOrDefault(p => p.Phone == booking_view.Phone) == null)
            {
                var booking = new Booking
                {
                    FullName = booking_view.FullName,
                    Gender = booking_view.Gender,
                    Email = booking_view.Email,
                    Phone = booking_view.Phone,
                    Password = Enscrypt(booking_view.Phone.Trim(), booking_view.Password.Trim())
                };
                _db.Booking.Add(booking);
                var rs = _db.SaveChanges();

                return Task.Run(() => booking);
            }

            return Task.FromResult<Booking>(null);
        }


        public Task<Booking_View> GetById(int id)
        {
            var booking = _db.Booking.Find(id);
            var booking_View = new Booking_View
            {
                FullName = booking.FullName,
                Gender = booking.Gender ?? false,
                Email = booking.Email,
                Phone = booking.Phone,
                Password = booking.Password
            };

            return Task.Run(() => booking_View);
        }

        public Task<List<Booking_View>> GetAll()
        {
            var listBook = _db.Booking.Select(p => new Booking_View
            {
                FullName = p.FullName,
                Gender = p.Gender ?? false,
                Email = p.Email,
                Phone = p.Phone
            }).ToList();

            return Task.Run(() => listBook);
        }
    }
}
