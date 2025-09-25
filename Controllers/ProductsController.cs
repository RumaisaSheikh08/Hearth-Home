using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreEcommerce.DTO;
using StoreEcommerce.Interfaces;
using StoreEcommerce.Models;
using StoreEcommerce.Services;

namespace StoreEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductInterface _productInterface;
        private readonly ILogger<IProductInterface> _logger;
        public ProductsController(IProductInterface productInterface , ILogger<IProductInterface> logger)
        { 
            _logger = logger;
            _productInterface = productInterface;
        }

        [HttpGet("getallproducts")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("Request Landed on Product Controller - GetAllProducts");

              
                List<Product> productList = await _productInterface.GetAllProducts();
                if (productList == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(productList);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception incurred: {Ex}", ex);
                return NotFound();
            }
        }

        [HttpGet("getproductbyid/{id}")]
        public async Task<ActionResult<Product>> GetProductByID(int id)
        {
            try
            {
                _logger.LogInformation("Request Landed on Product Controller - GetProductByID {id}" , id);
                Product productById = await _productInterface.GetProductById(id);
                if (productById == null)
                {
                    return NotFound();
                }

                return Ok(productById);

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception incurred: {Ex}", ex);
                return NotFound();
            }
        }

        [HttpPost("addnewproduct")]
        public async Task<ActionResult> AddNewProduct([FromBody] ProductDetailsDTO productDetails)
        {
            try
            {
                _logger.LogInformation("Request Landed on Product Controller - AddNewProduct {Name}", productDetails.Name);
                string message = await _productInterface.AddProduct(productDetails);             
                return Ok(message);

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception incurred: {Ex}", ex);
                return NotFound();
            }
        }

    }
}
