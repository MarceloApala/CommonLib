using System;
using System.Collections.Generic;

namespace CommonLib.Models
{
    public class BaseTable
    {
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Status { get; set; }
        public BaseTable() { } 
        public BaseTable(DateTime registerDate, DateTime lastUpdate, string status)
        {
            RegisterDate = registerDate;
            LastUpdate = lastUpdate;
            Status = status;
        }
    }
}
