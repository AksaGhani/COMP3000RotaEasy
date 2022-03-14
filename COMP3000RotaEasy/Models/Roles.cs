﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace COMP3000RotaEasy.Models
{
    public partial class Roles
    {
        public Roles()
        {
            UsersRoles = new HashSet<UsersRoles>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int ContractedHours { get; set; }

        public virtual ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
