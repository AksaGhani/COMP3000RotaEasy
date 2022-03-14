using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace COMP3000RotaEasy.Models
{
    public partial class OpeningHours
    {
        public int StoreId { get; set; }
        public string OpeningTimes { get; set; }
        public string ClosingTimes { get; set; }
        public string DayOfWeek { get; set; }

        public virtual Stores Store { get; set; }
    }
}
