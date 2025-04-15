using Holistic_2.Data;
using Holistic_2.Data.DTOs;
using Holistic_2.Models;
using Holistic_2.Repositories.Interfaces;

namespace Holistic_2.Repositories.Implementaions
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool AddProduct(ProductDto productDto)
        {
            Product product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                StockQuantity = productDto.StockQuantity,
            };
            _context.Products.Add(product);
            return _context.SaveChanges() > 0;
        }
    }
}
