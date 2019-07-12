using Oreders.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Oreders.API.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}
        public DbSet<Items> Items  { get; set; }
        public DbSet<Units> Units  { get; set; }

        public DbSet<OrderItems> orderItems  { get; set; }

        public DbSet<Order> orders  { get; set; }

        public DbSet<User> Users  { get; set; }
    }
}