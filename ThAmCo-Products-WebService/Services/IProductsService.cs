using ThAmCo_Products_WebService.Dtos;

namespace ThAmCo_Products_WebService.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductAsync(int Id);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task InsertProductAsync(InsertProductDto insertProductDto);
        Task DeleteProductAsync(int Id);
    }
}
