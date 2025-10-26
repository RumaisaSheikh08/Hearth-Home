namespace StoreEcommerce.Models
{
    public class UserOrderDetails
    {
        public int OrderId { get; set; }
        public string ProductName {  get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
