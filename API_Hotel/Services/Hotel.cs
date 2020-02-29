using API_Hotel.Models.Entities;
using API_Hotel.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API_Hotel.Services
{
    public class Hotel : IHotel
    {
        private readonly ConnectDbContext _db;

        public Hotel(ConnectDbContext db)
        {
            _db = db;
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

        public Task<List<Booking>> GetList()
        {
            var list = _db.Booking.ToList();

            return Task.Run(() => list);
        }

        public Task<Booking> RegisterBooking(Booking book)
        {
            if (_db.Booking.Find(book.Phone) == null)
            {
                book.Password = Enscrypt(book.Phone, book.Password);
                _db.Add(book);
                _db.SaveChanges();
                return Task.Run(() => book);
            }
            return null;
        }
    }
}
