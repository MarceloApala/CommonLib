using System;

namespace CommonLib.Models
{
    public partial class Export
    {
        public int IdExport { get; set; }
        public int IdGarment { get; set; }
        public string NameLocation { get; set; } 
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Status { get; set; }
        public int IdClient { get; set; }
    }
}

