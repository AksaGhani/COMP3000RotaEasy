using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace COMP3000RotaEasy.Models
{
    public partial class Holidays
    {
        public Holidays()
        {
            UsersHols = new HashSet<UsersHols>();
        }

        public int HolidayId { get; set; }
        public string HolidayName { get; set; }
        public DateTime HolidayStart { get; set; }
        public DateTime HolidayEnd { get; set; }

        public virtual ICollection<UsersHols> UsersHols { get; set; }
    }
}
