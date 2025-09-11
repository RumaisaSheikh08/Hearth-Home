using StoreEcommerce.DTO;
using StoreEcommerce.Models;

namespace StoreEcommerce.Interfaces
{
    public interface IOrderInterface
    {
        Task<string> CreateOrder(OrderDTO orderRequest , List<OrderItemDTO> orderItems);
        Task <List<UserOrderDetails>> GetOrderByUserId(int userId);
    }
}
