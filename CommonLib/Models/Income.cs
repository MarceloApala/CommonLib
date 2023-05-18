using System;

namespace CommonLib.Models
{
    public partial class Income
    {
        public int IdIncome { get; set; }
        public int IdUser { get; set; }
        public string TypeComprobant { get; set; } 
        public string SerieComprobant { get; set; } 
        public string NumComprobant { get; set; } 
        public DateTime RegisterDate { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; } 
        public int IdSupplier { get; set; }

    }

}

