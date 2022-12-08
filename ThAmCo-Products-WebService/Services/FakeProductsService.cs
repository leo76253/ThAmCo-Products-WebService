using Microsoft.AspNetCore.Mvc;
using ThAmCo_Products_WebService.Dtos;

namespace ThAmCo_Products_WebService.Services
{
    public class FakeProductsService : IProductsService
    {
        private static ProductDto[] productDtos =
            {
            new ProductDto{ Id = 1, ProductName = "Ball", Quantity = 2, Price = 2, Description = "Generic bouncy ball"},
            new ProductDto{ Id = 2, ProductName = "NoteBook", Quantity = 5, Price = 4, Description = "Plain A4 Notebook"},
            new ProductDto{ Id = 3, ProductName = "Pencil", Quantity = 20, Price = 1, Description = "HB Pencil"},
            new ProductDto{ Id = 4, ProductName = "Pen", Quantity = 18, Price = 1, Description = "Ballpoint Pen"},
            new ProductDto{ Id = 5, ProductName = "Bag", Quantity = 2, Price = 1, Description = "Drawstring bag"}
        };

        public Task<ProductDto> GetProductAsync(int Id)
        {
            return Task.FromResult(productDtos.FirstOrDefault(p => p.Id == Id));
        }

        public Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            return Task.FromResult(productDtos.AsEnumerable());
        }

        public Task InsertProductAsync(InsertProductDto insertProductDto)
        {
            int newId = productDtos.Count() + 2;

            productDtos = productDtos.Append(new ProductDto
            {
                Id = newId,
                ProductName = insertProductDto.ProductName,
                Quantity = insertProductDto.Quantity,
                Price = insertProductDto.Price,
                Description = insertProductDto.Description,
            }).ToArray();

            return Task.CompletedTask;
        }

        public Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var fakeProd = productDtos.FirstOrDefault(p => p.Id == updateProductDto.Id);
            if (fakeProd != null)
            {
                fakeProd.ProductName = updateProductDto.ProductName;
                fakeProd.Quantity = updateProductDto.Quantity;
                fakeProd.Price = updateProductDto.Price;
                fakeProd.Description = updateProductDto.Description;

                return Task.CompletedTask;
            }
            //else
            //{
            //    return Task.FromException($"No Product with id:{updateProductDto.Id}".);
            //}

            return Task.FromResult($"No Product with id:{updateProductDto.Id}");
        }

        public Task DeleteProductAsync(int Id)
        {
            var fakeProd = productDtos.FirstOrDefault(p => p.Id == Id);
            if (fakeProd == null)
            {
                return Task.FromResult($"No Product with id:{Id}");
            }

            productDtos = productDtos.Where(p => p.Id != Id).ToArray();

            return Task.CompletedTask;
        }
    }
}
