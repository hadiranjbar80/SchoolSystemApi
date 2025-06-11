using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityMapper
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.FatherName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.ParentPhoneNumber)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.PostalCode)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(500);  
        }
    }
}