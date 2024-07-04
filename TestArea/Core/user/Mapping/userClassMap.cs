using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestArea.Domain.Models;

namespace TestArea.Core.Mapping;

public class UserClassMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK____User");

        builder.ToTable("user");

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .HasColumnName("name");

        builder.Property(e => e.Identification)
            .HasMaxLength(255)
            .HasColumnName("identification");

        builder.Property(e => e.Password)
            .HasMaxLength(255)
            .HasColumnName("password");

        builder.Property(e => e.Salt)
            .HasMaxLength(10)
            .HasColumnName("salt");

        builder.Property(e => e.Admin)
            .HasColumnName("admin");

        builder.Property(e => e.IsActive)
            .HasColumnName("is_active");

    }
}


