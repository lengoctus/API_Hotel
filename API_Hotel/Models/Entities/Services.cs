using System;
using System.Collections.Generic;

namespace API_Hotel.Models.Entities
{
    public partial class Services
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int MealId { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }

        public virtual Meals Meal { get; set; }
        public virtual Room Room { get; set; }
    }
}
