namespace CommonLib.Models
{
    public partial class Garment
    {

        public int IdGarment { get; set; }
        public string Guy { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public int IdSize { get; set; }
        public int IdUser { get; set; }
        public decimal Price { get; set; }
        public int IdSupplier { get; set; }
        public byte[] Photo { get; set; }
        public int IdCategory { get; set; }
        public int IdDetailSale { get; set; }
    }
}

