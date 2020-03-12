using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebHotel.Models.Entities;
using WebHotel.Models.ModelsView;

namespace WebHotel.Models.Dao
{

    public class Customer_Dao
    {
        private HotelManagementContext _db;

        public Customer_Dao()
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

        //public Task<Customer> Add(Customer_View Customer_view)
        //{
        //    if (_db.Customer.SingleOrDefault(p => p.Phone == Customer_view.Phone) == null)
        //    {
        //        var Customer = new Customer
        //        {
        //            FullName = Customer_view.FullName,
        //            Gender = Customer_view.Gender,
        //            Email = Customer_view.Email,
        //            Phone = Customer_view.Phone,
        //            Password = Enscrypt(Customer_view.Phone.Trim(), Customer_view.Password.Trim())
        //        };
        //        _db.Customer.Add(Customer);
        //        var rs = _db.SaveChanges();

        //        return Task.Run(() => Customer);
        //    }

        //    return Task.FromResult<Customer>(null);
        //}


        //public Task<Customer_View> GetById(int id)
        //{
        //    var Customer = _db.Customer.Find(id);
        //    var Customer_View = new Customer_View
        //    {
        //        FullName = Customer.FullName,
        //        Gender = Customer.Gender    false,
        //        Email = Customer.Email,
        //        Phone = Customer.Phone,
        //        Password = Customer.Password
        //    };

        //    return Task.Run(() => Customer_View);
        //}

        //public Task<List<Customer_View>> GetAll()
        //{
        //    var listBook = _db.Customer.Select(p => new Customer_View
        //    {
        //        FullName = p.FullName,
        //        Gender = p.Gender    false,
        //        Email = p.Email,
        //        Phone = p.Phone
        //    }).ToList();

        //    return Task.Run(() => listBook);
        //}
    }

}
