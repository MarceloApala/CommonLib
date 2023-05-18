using System;

namespace CommonLib.Models
{
    public partial class Sale
    {
        public int IdSale { get; set; }
        public int IdClient { get; set; }
        public DateTime DateSale { get; set; }
        public decimal FullSale { get; set; }
    }

}

