using Microsoft.EntityFrameworkCore;
using ThAmCo_Products_WebService.Data;
using ThAmCo_Products_WebService.Dtos;
using ThAmCo_Products_WebService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<IProductsService, FakeProductsService>();
}
else
{
    //builder.Services.AddTransient<IProductsService, ProductsService>();
    builder.Services.AddSingleton<IProductsService, FakeProductsService>(); //FAKE ONLY 
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //builder.Services.AddTransient<IProductsService, FakeProductsService>();
    //builder.Services.AddSingleton<IProductsService, FakeProductsService>();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    //builder.Services.AddTransient<IProductsService, ProductsService>();
}

app.UseHttpsRedirection();


app.MapGet("/api/", async (IProductsService product) => 
    await product.GetProductsAsync());

app.MapGet("/api/{id}", async (IProductsService product, int id) => 
    await product.GetProductAsync(id));

app.MapPut("/api/", async (IProductsService product, UpdateProductDto updateProductDto) => 
    await product.UpdateProductAsync(updateProductDto));

app.MapPost("/api/", async (IProductsService product, InsertProductDto insertProductDto) =>
    await product.InsertProductAsync(insertProductDto));

app.MapDelete("/api/{id}", async (IProductsService product, int id) =>
    await product.DeleteProductAsync(id));

app.Run();