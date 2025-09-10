using AutoMapper;
using StoreEcommerce.Data;
using StoreEcommerce.Interfaces;

namespace StoreEcommerce.Services
{
    public class ProductService : IProductInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly Logger<ProductService> _logger;
        private readonly IMapper _mapper;
        public ProductService(ApplicationDbContext context , Logger<ProductService> logger, IMapper mapper)
        { 
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
