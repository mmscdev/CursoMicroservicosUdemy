using Microsoft.EntityFrameworkCore;

namespace MM.GeekShopping.Product.WebApi.Model.Context
{
    public class BdMySqlContext : DbContext
    {
        public BdMySqlContext() { }
        public BdMySqlContext(DbContextOptions<BdMySqlContext> options) : base(options) { }

        public DbSet<MM.GeekShopping.Model.Product.WebApi.Model.Product> Products { get; set; }
    }
}