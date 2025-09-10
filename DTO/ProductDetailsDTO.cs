namespace StoreEcommerce.DTO
{
    public class ProductDetailsDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int StockQty { get; set; }
        public string ImageUrl { get; set; }
    }
}
