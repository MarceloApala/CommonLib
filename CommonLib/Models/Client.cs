using System;

namespace CommonLib.Models
{
    public partial class Client
    {
        public int IdClient { get; set; }

        public string Address { get; set; } 

        public string PhoneNumber { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public int Nit { get; set; }

        public string Status { get; set; } 

        public int IdUser { get; set; }
    }
}

