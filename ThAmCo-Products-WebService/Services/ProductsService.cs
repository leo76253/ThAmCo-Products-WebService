using Microsoft.EntityFrameworkCore;
using ThAmCo_Products_WebService.Data;
using ThAmCo_Products_WebService.Dtos;

namespace ThAmCo_Products_WebService.Services
{
    public class ProductsService : IProductsService
    {
        public readonly DataContext _context;
        public ProductsService(DataContext dataContext) 
        { 
            _context = dataContext;
        }
        public async Task<ProductDto> GetProductAsync(int Id)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            return await _context.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Quantity = p.Quantity,
                Price = p.Price,
                Description = p.Description
            }).ToListAsync();
            
        }

        public Task InsertProductAsync(InsertProductDto insertProductDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
