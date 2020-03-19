using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHotel.Models.ModelsView
{
    public class Room_View
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public int RoomCategory { get; set; }
        public bool IsService { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
    }
}
