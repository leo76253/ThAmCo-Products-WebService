using Microsoft.EntityFrameworkCore;

namespace ThAmCo_Products_WebService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        
        }
    }
}
