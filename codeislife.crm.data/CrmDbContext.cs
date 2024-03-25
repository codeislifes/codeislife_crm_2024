using codeislife.crm.data.domain;
using codeislife.crm.data.domain.Builders;
using Microsoft.EntityFrameworkCore;

namespace codeislife.crm.data;
public class CrmDbContext : DbContext
{
    public CrmDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Contact> Contact { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<CustomerContact> CustomerContact { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeadBuilder).Assembly);
    }
}
