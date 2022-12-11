using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo_Products_WebService.Data
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; } 
        public bool IsDeleted { get; set; } = false;
    }
}
