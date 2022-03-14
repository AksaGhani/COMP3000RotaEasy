using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace COMP3000RotaEasy.Models
{
    public partial class Users
    {
        public Users()
        {
            UsersEvents = new HashSet<UsersEvents>();
            UsersHols = new HashSet<UsersHols>();
            UsersRoles = new HashSet<UsersRoles>();
            UsersShifts = new HashSet<UsersShifts>();
            UsersSickdays = new HashSet<UsersSickdays>();
            UsersStores = new HashSet<UsersStores>();
        }

        public int UserId { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string PhoneNo { get; set; }
        public string HomeAdd { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public int? NoHolHours { get; set; }

        public virtual ICollection<UsersEvents> UsersEvents { get; set; }
        public virtual ICollection<UsersHols> UsersHols { get; set; }
        public virtual ICollection<UsersRoles> UsersRoles { get; set; }
        public virtual ICollection<UsersShifts> UsersShifts { get; set; }
        public virtual ICollection<UsersSickdays> UsersSickdays { get; set; }
        public virtual ICollection<UsersStores> UsersStores { get; set; }
    }
}
