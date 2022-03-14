using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace COMP3000RotaEasy.Models
{
    public partial class Sickdays
    {
        public Sickdays()
        {
            UsersSickdays = new HashSet<UsersSickdays>();
        }

        public int SickdayId { get; set; }
        public DateTime SickStart { get; set; }
        public DateTime SickEnd { get; set; }
        public int? UnpaidHours { get; set; }
        public int? PaidHours { get; set; }

        public virtual ICollection<UsersSickdays> UsersSickdays { get; set; }
    }
}
