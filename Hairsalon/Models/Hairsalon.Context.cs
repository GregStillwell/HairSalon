using Microsoft.EntityFrameworkCore;

namespace Hairsalon.Models
{
  public class HairsalonContext : DbContext
  {
    public DbSet<Client> Client { get; set; }
    public DbSet<Stylists> Stylist { get; set; }

    public HairsalonContext(DbContextOptions options) : base(options) { }
  }
}