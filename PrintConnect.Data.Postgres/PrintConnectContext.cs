using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Data.Postgres;

public class PrintConnectContext(DbContextOptions<PrintConnectContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Printer>  Printers => Set<Printer>();
    public DbSet<Job>  Jobs => Set<Job>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrintConnectContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}