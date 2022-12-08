using ThAmCo_Products_WebService.Dtos;

namespace ThAmCo_Products_WebService.Services
{
    public class ProductsService : IProductsService
    {
        public Task DeleteProductAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task InsertProductAsync(InsertProductDto insertProductDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
