using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace COMP3000RotaEasy.Models
{
    public partial class Events
    {
        public Events()
        {
            UsersEvents = new HashSet<UsersEvents>();
        }


        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }

        public virtual ICollection<UsersEvents> UsersEvents { get; set; }
    }
}
