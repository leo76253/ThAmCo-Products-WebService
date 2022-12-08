using Microsoft.EntityFrameworkCore;
using ThAmCo_Products_WebService.Data;
using ThAmCo_Products_WebService.Dtos;
using ThAmCo_Products_WebService.Endpoints;
using ThAmCo_Products_WebService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//just dev for now
builder.Services.AddTransient<IProductsService, FakeProductsService>();

//builder.Services.AddHttpClient<IProductsService, ProductsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Endpoints serperated for readability
//app.MapProductsEndpoints();
//app.MapFakeProductsEndpoints();


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