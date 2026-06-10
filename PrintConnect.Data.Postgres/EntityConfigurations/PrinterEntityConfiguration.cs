using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Data.Postgres.EntityConfigurations;

public class PrinterEntityConfiguration: IEntityTypeConfiguration<Printer>
{
    public void Configure(EntityTypeBuilder<Printer> model)
    {
    }
}