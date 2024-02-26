using codeislife.crm.data.domain;
using Microsoft.EntityFrameworkCore;

namespace codeislife.crm.data;
public class CrmDbContext : DbContext
{
    public CrmDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customer { get; set; }
    public DbSet<Lead> Lead { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Lead>()
            .HasOne(l => l.Customer)
            .WithMany(c => c.Leads)
            .HasForeignKey(p => p.CustomerId)
            .IsRequired(false);

        modelBuilder.Entity<Lead>()
            .Property(p => p.Comment)
            .HasMaxLength(500)
            .IsRequired(false);
    }
}
