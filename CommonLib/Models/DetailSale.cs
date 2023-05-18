using System;

namespace CommonLib.Models
{
    public partial class DetailSale
    {
        public int IdDetailSale { get; set; }
        public int IdSale { get; set; }
        public int IdGarment { get; set; }
        public string Amount { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Status { get; set; } 
        public int IdExport { get; set; }
    }
}