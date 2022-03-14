using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace COMP3000RotaEasy.Models
{
    public partial class UsersHols
    {
        public int UserId { get; set; }
        public int HolidayId { get; set; }

        public virtual Holidays Holiday { get; set; }
        public virtual Users User { get; set; }
    }
}
