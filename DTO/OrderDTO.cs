namespace StoreEcommerce.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } //Pending,Completed,Cancelled
        public DateTime CreatedAt { get; set; }
    }
}
