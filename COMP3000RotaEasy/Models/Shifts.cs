using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace COMP3000RotaEasy.Models
{
    public partial class Shifts
    {
        public Shifts()
        {
            UsersShifts = new HashSet<UsersShifts>();
        }

        public int ShiftId { get; set; }
        public DateTime ShiftDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public virtual ICollection<UsersShifts> UsersShifts { get; set; }
    }
}
