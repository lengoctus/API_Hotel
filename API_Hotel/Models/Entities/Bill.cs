using System;
using System.Collections.Generic;

namespace API_Hotel.Models.Entities
{
    public partial class Bill
    {
        public int Id { get; set; }
        public int? CusId { get; set; }
        public DateTime? DateCreate { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? BookId { get; set; }

        public virtual Customer Cus { get; set; }
    }
}
