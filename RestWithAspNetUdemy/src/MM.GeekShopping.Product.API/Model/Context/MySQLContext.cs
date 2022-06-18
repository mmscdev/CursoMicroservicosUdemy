using Microsoft.EntityFrameworkCore;

namespace MM.GeekShopping.Product.Api.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<MM.GeekShopping.Product.Api.Model.Product> Products { get; set; }
    }
}