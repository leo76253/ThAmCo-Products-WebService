namespace ThAmCo_Products_WebService.Endpoints
{
    public static class ProductsEndpoints
    {
        public static void MapProductsEndpoints(this WebApplication app)
        {
            app.MapGet("/test", () => "External endpoint test");
        }
    }
}
