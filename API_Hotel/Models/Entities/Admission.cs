using System;
using System.Collections.Generic;

namespace API_Hotel.Models.Entities
{
    public partial class Admission
    {
        public Admission()
        {
            Accommodation = new HashSet<Accommodation>();
        }

        public int Id { get; set; }
        public int? IdCard { get; set; }
        public string Luggage { get; set; }
        public DateTime? InDate { get; set; }
        public DateTime? OutDate { get; set; }
        public int? AccId { get; set; }

        public virtual ICollection<Accommodation> Accommodation { get; set; }
    }
}
