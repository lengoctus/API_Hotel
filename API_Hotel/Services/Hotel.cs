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

        public Task<List<Customer>> Gets()
        {
            try
            {
                var list = _db.Customer.AsNoTracking().ToList();
                return Task.FromResult<List<Customer>>(list);
            }
            catch (Exception e)
            {
                var d = e.Message;
                return Task.FromResult<List<Customer>>(null);
            }
        }

        public Task<List<Customer>> Gets(string FullName, string Phone)
        {
            try
            {
                if (!string.IsNullOrEmpty(FullName) && string.IsNullOrEmpty(Phone))
                {
                    var findBook_fullname = _db.Customer.AsNoTracking().Where(p => p.FullName.ToLower() == FullName.Trim().ToLower()).ToList();
                    return Task.FromResult<List<Customer>>(findBook_fullname);
                }
                else if (!string.IsNullOrEmpty(Phone) && string.IsNullOrEmpty(FullName))
                {
                    var findBook_phone = _db.Customer.AsNoTracking().Where(p => p.Phone == Phone.Trim()).ToList();
                    return Task.FromResult<List<Customer>>(findBook_phone);
                }
                else if (!string.IsNullOrEmpty(FullName) && !string.IsNullOrEmpty(Phone))
                {
                    var findBook = _db.Customer.AsNoTracking().Where(p => (p.FullName.ToLower() == FullName.Trim().ToLower()) && (p.Phone == Phone.Trim())).ToList();
                    return Task.FromResult<List<Customer>>(findBook);
                }
                else if (string.IsNullOrEmpty(FullName) && string.IsNullOrEmpty(Phone))
                {
                    return Task.Run(() => this.Gets());
                }
            }
            catch
            {
                return Task.Run(() => this.Gets());
            }

            return Task.Run(() => this.Gets());
        }

        public Task<bool> UpdateInfo(int CusId, Customer Cus, IMapper mapper)
        {
            try
            {
                var customer = _db.Customer.SingleOrDefault(p => p.Id == CusId);
                if (customer != null)
                {
                    Cus.Password = Enscrypt(Cus.Phone, Cus.Password);
                    customer = mapper.Map(Cus, customer);

                    int a = _db.SaveChanges();
                    return Task.FromResult<bool>(true);
                }
            }
            catch(Exception e)
            {
                var d = e.Message;
                return Task.FromResult<bool>(false);
            }
            return Task.FromResult<bool>(false);

        }


    }
}
