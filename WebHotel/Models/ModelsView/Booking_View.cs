using AspNetCore.CustomValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHotel.Models.ModelsView
{
    public class Booking_View
    {
        public int Id { get; set; }
        public string Luggage { get; set; }
        [CompareTo(nameof(OutDate), ComparisonType.SmallerThan)]
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }

        public int RoomId { get; set; }
        public int CusId { get; set; }
        //[Required(ErrorMessage = "Address required!!")]
        public string Address { get; set; }
        public int NbPeople { get; set; }
        public int Quantity { get; set; }

    }
}
