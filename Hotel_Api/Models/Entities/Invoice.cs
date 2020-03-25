using System;
using System.Collections.Generic;

namespace Hotel_Api.Models.Entities
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? IdAccount { get; set; }
        public int? Charge { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual Account IdAccountNavigation { get; set; }
    }
}
