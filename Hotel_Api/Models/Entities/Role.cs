using System;
using System.Collections.Generic;

namespace Hotel_Api.Models.Entities
{
    public partial class Role
    {
        public Role()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
