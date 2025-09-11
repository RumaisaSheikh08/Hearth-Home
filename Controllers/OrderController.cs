using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreEcommerce.Interfaces;
using StoreEcommerce.Models;

namespace StoreEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderInterface _orderInterface;
        private readonly ILogger<IOrderInterface> _logger;
        public OrderController(IOrderInterface orderInterface , ILogger<IOrderInterface> logger) 
        { 
            _orderInterface = orderInterface;
            _logger = logger;
        }

        [HttpPost("CreateNewOrder")]
        public async Task<ActionResult<string>> CreateNewOrder(OrderRequest orderRequest)
        {
            string requestMessage = string.Empty;
            try
            {
                _logger.LogInformation("Request Landed on Order Controller - CreateNewOrder");
                requestMessage = await _orderInterface.CreateOrder(orderRequest.Order, orderRequest.Items);
                return Ok(requestMessage);

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception incurred: {Ex}", ex);
                return NotFound();
            }
        }

        [HttpGet("GetUserOrder/{id}")]
        public async Task<ActionResult<List<UserOrderDetails>>> GetUserOrderById(int id)
        {
            try
            {
                _logger.LogInformation("Request Landed on Order Controller - GetUserOrderById {User ID}", id.ToString());
                var userOrderDetails = await _orderInterface.GetOrderByUserId(id);
                if (userOrderDetails == null)
                {
                    return NotFound();
                }

                return Ok(userOrderDetails);

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception incurred: {Ex}", ex);
                return NotFound();
            }
        }

    }
}
