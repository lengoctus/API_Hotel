using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHotel.Models.ModelsView
{
    public class Accomodation_View
    {
        public int Id { get; set; }
        public string AccName { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public int AccCategory { get; set; }
        public bool IsService { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
    }
}
