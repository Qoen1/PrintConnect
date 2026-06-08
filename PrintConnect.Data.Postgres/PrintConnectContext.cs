using Microsoft.EntityFrameworkCore;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Data.Postgres;

public class PrintConnectContext(DbContextOptions<PrintConnectContext> options) : DbContext(options)
{
    public DbSet<Printer>  Printers => Set<Printer>();
    public DbSet<Job>  Jobs => Set<Job>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}