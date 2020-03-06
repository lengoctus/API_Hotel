using System;
using System.Collections.Generic;

namespace Web_HotelManagement.Models.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? Dob { get; set; }
        public int? IdCard { get; set; }
        public string Email { get; set; }
        public int? IdDePart { get; set; }
        public int? IdRole { get; set; }
        public decimal? Salary { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
    }
}
