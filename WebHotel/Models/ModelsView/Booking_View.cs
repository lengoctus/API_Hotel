using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHotel.Models.ModelsView
{
    public class Booking_View
    {
        public int Id { get; set; }
        public string Luggage { get; set; }
        public DateTime  InDate { get; set; }
        public DateTime  OutDate { get; set; }
        public int  AccId { get; set; }
        public int  CusId { get; set; }
        public string Address { get; set; }
        public int  NbPeople { get; set; }
    }
}
