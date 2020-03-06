using API_Hotel.Models.Entities;
using API_Hotel.Models.ModelViews;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public Task<List<Booking>> Gets()
        {
            try
            {
                var list = _db.Booking.AsNoTracking().ToList();
                return Task.Run(() => list);
            }
            catch(Exception e)
            {
                var d = e.Message;
                return Task.FromResult<List<Booking>>(null);
            }
        }

        public Task<List<Booking>> Gets(string FullName, string Phone)
        {
            try
            {
                if (!string.IsNullOrEmpty(FullName) && string.IsNullOrEmpty(Phone))
                {
                    var findBook_fullname = _db.Booking.AsNoTracking().Where(p => p.FullName.ToLower() == FullName.Trim().ToLower()).ToList();
                    return Task.Run(() => findBook_fullname);
                }
                else if (!string.IsNullOrEmpty(Phone) && string.IsNullOrEmpty(FullName))
                {
                    var findBook_phone = _db.Booking.AsNoTracking().Where(p => p.Phone == Phone.Trim()).ToList();
                    return Task.Run(() => findBook_phone);
                }
                else if (!string.IsNullOrEmpty(FullName) && !string.IsNullOrEmpty(Phone))
                {
                    var findBook = _db.Booking.AsNoTracking().Where(p => (p.FullName.ToLower() == FullName.Trim().ToLower()) && (p.Phone == Phone.Trim())).ToList();
                    return Task.Run(() => findBook);
                }
                else if (string.IsNullOrEmpty(FullName) && string.IsNullOrEmpty(Phone))
                {
                     return Task.Run(() => Gets());
                }
            }
            catch
            {
                return Task.Run(() => Gets());
            }

            return Task.Run(() => Gets());
        }


        public Task<bool> Add(Booking book)
        {
            try
            {
                if (_db.Booking.AsNoTracking().SingleOrDefault(p => p.Phone == book.Phone.Trim()) == null)
                {
                    book.Password = Enscrypt(book.Phone, book.Password);
                    _db.Booking.Add(book);
                    int rs = _db.SaveChanges();
                    return rs > 0 ? Task.FromResult<bool>(true) : Task.FromResult<bool>(false);
                }
            }
            catch
            {
                return Task.FromResult<bool>(false);
            }
            return Task.FromResult<bool>(false);

        }


    }
}
