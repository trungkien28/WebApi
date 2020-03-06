using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext(DbContextOptions<DataAccessContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }
    }

    public class DataAccessContextFactory
    {
        public static DataAccessContext Create(string connectionstring)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Models.DataAccessContext>();
            optionsBuilder.UseMySQL(connectionstring);
            var DataAccessContext = new DataAccessContext(optionsBuilder.Options);
            return DataAccessContext;
        }
    }
}