namespace Cars_Auto.ViewModel
{
    public class PurchaseVM
    {
		public int Id { get; set; }   
		public string CarName { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string BuyerName { get; set; } = string.Empty;

        public decimal FinalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CarId { get; set; }
    }
}
