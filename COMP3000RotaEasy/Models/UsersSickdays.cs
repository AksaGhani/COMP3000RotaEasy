using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace COMP3000RotaEasy.Models
{
    public partial class UsersSickdays
    {
        public int UserId { get; set; }
        public int SickdayId { get; set; }

        public virtual Sickdays Sickday { get; set; }
        public virtual Users User { get; set; }
    }
}
