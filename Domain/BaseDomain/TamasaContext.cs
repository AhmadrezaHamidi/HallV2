using Microsoft.EntityFrameworkCore;
using tama.Domain.Entity;

namespace tama.Domain.BaseDomain
{
    public class TamasaContext : DbContext
    {
        public TamasaContext(DbContextOptions options) : base(options)
        {
        }
      //  public DbSet<BackUpEntity> BackUpTb { get; set; }
        public DbSet<CustomerEntity> CustomerTb { get; set; }
        public DbSet<TransActionEntity> TransActionTb { get; set; }
    }
}