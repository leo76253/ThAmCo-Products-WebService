﻿using ThAmCo_Products_WebService.Dtos;

namespace ThAmCo_Products_WebService.Endpoints
{
    public static class FakeProductsEndpoints
    {
        private static ProductDto[] productDtos =
            {
            new ProductDto{ Id = 1, ProductName = "Ball", Quantity = 2, Price = 2, Description = "Generic bouncy ball"},
            new ProductDto{ Id = 2, ProductName = "NoteBook", Quantity = 5, Price = 4, Description = "Plain A4 Notebook"},
            new ProductDto{ Id = 3, ProductName = "Pencil", Quantity = 20, Price = 1, Description = "HB Pencil"},
            new ProductDto{ Id = 4, ProductName = "Pen", Quantity = 18, Price = 1, Description = "Ballpoint Pen"},
            new ProductDto{ Id = 5, ProductName = "Bag", Quantity = 2, Price = 1, Description = "Drawstring bag"}
        };

        public static void MapFakeProductsEndpoints(this WebApplication app)
        {
            app.MapGet("/faketest", () => "External endpoint test - fake");

            app.MapGet("/", () => productDtos.ToList());

            app.MapGet("/Product/{id}", (int id) => productDtos.FirstOrDefault(p => p.Id == id));

            //app.MapPost()
        }


    }
}
