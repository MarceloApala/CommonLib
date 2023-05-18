namespace CommonLib.Models 
{
    public partial class DetailIncome
    {
        public int IdDetail { get; set; }
        public int IdIncome { get; set; }
        public int IdGarment { get; set; }
        public short Cant { get; set; }
        public decimal Price { get; set; }

    }

}

