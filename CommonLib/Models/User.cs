using System;

namespace CommonLib.Models
{

    public partial class User
    {
        public int IdUser { get; set; }
        public string Name { get; set; } 
        public string LastName { get; set; } 
        public string Dni { get; set; } 
        public string Address { get; set; } 
        public string PhoneNumber { get; set; } 
        public string UserName { get; set; } 
        public byte[] Password { get; set; } 
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Status { get; set; } 
        public int? IdRole { get; set; }
        
    }

}
