using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
