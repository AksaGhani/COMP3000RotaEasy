using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace COMP3000RotaEasy.Models
{
    public partial class Stores
    {
        public Stores()
        {
            UsersStores = new HashSet<UsersStores>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public string StoreAddress { get; set; }
        public string StoreZipCode { get; set; }

        public virtual ICollection<UsersStores> UsersStores { get; set; }
    }
}
