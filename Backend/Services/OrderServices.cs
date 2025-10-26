using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreEcommerce.Data;
using StoreEcommerce.DTO;
using StoreEcommerce.Interfaces;
using StoreEcommerce.Models;
using System.Data.Common;

namespace StoreEcommerce.Services
{
    public class OrderServices : IOrderInterface
    {
        private readonly ILogger<OrderServices> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public OrderServices(ILogger<OrderServices> logger, ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<string> CreateOrder(OrderDTO orderRequest, List<OrderItemDTO> orderItems)
        {
            string Message = string.Empty;
            try
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                _logger.LogInformation("Request to order a product");
                //First an entry to the db will be made to create an order and gets it id
                var userOrder = _mapper.Map<Order>(orderRequest);
                await _context.Orders.AddAsync(userOrder);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Order has been successfully created {Order ID} ", Convert.ToString(userOrder.OrderId));

                var orderItemEntities = orderItems.Select(item => new OrderItems
                {
                    OrderId = userOrder.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList();

                await _context.OrderItems.AddRangeAsync(orderItemEntities);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                _logger.LogInformation("Order Details has been successfully Added");
                return Message = "Order Successfully Generated";
            }
            catch (DbException dbException)
            {
                _logger.LogError("Database exception incurred: {DBEx}", dbException);
                return Message = "Error occurred";
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception incurred: {Ex}", ex);
                return Message = "Error occurred";
            }
        }
        public async Task<List<UserOrderDetails>> GetOrderByUserId(int userId)
        {
            List<UserOrderDetails> orderItems = null;
            try
            {
                _logger.LogInformation("Order Details Requested For User {UserID} ", Convert.ToString(userId));
                //In order to add joins we've added navigation to make it simpler and fetch all the details
              
                var orderDetailsUser = from order in _context.Orders
                                       join items in _context.OrderItems
                                       on order.OrderId equals items.OrderId
                                       join product in _context.Products
                                       on items.ProductId equals product.ProductId
                                       where order.UserId == userId
                                       select new UserOrderDetails { 
                                           OrderId = order.OrderId,
                                           ProductName = product.Name,
                                           Price = items.Price,
                                           TotalAmount = order.TotalAmount,
                                           Status = order.Status                               
                                       };
                var result  = await orderDetailsUser.ToListAsync();
                return result;

            }
            catch (DbException dbException)
            {
                _logger.LogError("Database exception incurred: {DBEx}", dbException);
                return orderItems;
            }
            catch (Exception ex)
            {
                _logger.LogError("Database exception incurred: {Ex}", ex);
                return orderItems;
            }
        }
    }
}
