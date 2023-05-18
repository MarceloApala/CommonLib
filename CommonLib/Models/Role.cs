using System;

namespace CommonLib.Models 
{
    public class Role:BaseTable
    {
        public int IdRole { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }

        public Role()
        {
        }
        public Role(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Role(int idRole, string name, string description, DateTime registerDate, DateTime lastUpdate, string status)
            : base(registerDate, lastUpdate, status)
        {
            IdRole = idRole;
            Name = name;
            Description = description;
            RegisterDate = registerDate;
            LastUpdate = lastUpdate;
            Status = status;    
        }
    }
}

