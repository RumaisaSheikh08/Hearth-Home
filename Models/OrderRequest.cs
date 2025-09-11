using StoreEcommerce.DTO;

namespace StoreEcommerce.Models
{
    public class OrderRequest
    {
        public OrderDTO Order { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }
}
