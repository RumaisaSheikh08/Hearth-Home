using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StoreEcommerce.Data;
using StoreEcommerce.DTO;
using StoreEcommerce.Interfaces;
using StoreEcommerce.Models;
using System.Data.Common;

namespace StoreEcommerce.Services
{
    public class ProductService : IProductInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        public ProductService(ApplicationDbContext context , ILogger<ProductService> logger, IMapper mapper)
        { 
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                _logger.LogInformation("Request to get all the products");

                products = await _context.Products.ToListAsync();

                _logger.LogInformation("Request to get all the products from db {Count}: ", products.Count().ToString());
                
                return products;
                
            }
            catch(DbException dbException)
            {
                _logger.LogError("Database exception incurred: {DBEx}", dbException);
                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError("Database exception incurred: {Ex}", ex);
                return products;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = new Product();
            try
            {
                _logger.LogInformation("Request to get product by id");
                product = await _context.Products.FirstOrDefaultAsync(i => i.ProductId == id);

                _logger.LogInformation("Request to retrieve the product {product}: ", Convert.ToString(product.Name));

                return product;

            }
            catch (DbException dbException)
            {
                _logger.LogError("Database exception incurred: {DBEx}", dbException);
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError("Database exception incurred: {Ex}", ex);
                return product;
            }

        }
        public async Task<string> AddProduct(ProductDetailsDTO product)
        {
            string Message = string.Empty;
            try
            {
                _logger.LogInformation("Request to add a new product by admin");
                var productsAdd = _mapper.Map<Product>(product);

                _logger.LogInformation("Details mapped through mapper {Name:}" , product.Name);

                _logger.LogInformation("Call to add the product to the db made");

                await _context.Products.AddAsync(productsAdd);
                await _context.SaveChangesAsync();
                return Message = "Successfully added to the database";
            }
            catch (DbException dbException)
            {
                _logger.LogError("Database exception incurred: {DBEx}", dbException);
                return Message = "Error occurred";
            }
            catch (Exception ex)
            {
                _logger.LogError("Database exception incurred: {Ex}", ex);
                return Message = "Error occurred";
            }
        }
    }

}
