namespace ThAmCo_Products_WebService.Dtos
{
    public class InsertProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
