using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cliente> clientes { get; set; }
    }
}