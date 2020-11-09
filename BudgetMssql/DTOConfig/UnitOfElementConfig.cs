using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budget.Mssql
{
    public class UnitOfElementConfig: IEntityTypeConfiguration<UnitOfElementDTO>
    {
        public void Configure(EntityTypeBuilder<UnitOfElementDTO> builder)
    {
        builder.ToTable("Units").Property(c => c.ShortName).IsRequired().HasMaxLength(20);
        builder.ToTable("Units").Property(c => c.FullName).IsRequired().HasMaxLength(120);
        builder.ToTable("Units").HasKey(c => c.Id);
    }
    }
}