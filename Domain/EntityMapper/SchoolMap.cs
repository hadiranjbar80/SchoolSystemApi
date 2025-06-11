using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityMapper
{
    public class SchoolMap : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(x => x.SchoolCode);
            builder.Property(x => x.SchoolCode)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(250); 
        }
    }
}