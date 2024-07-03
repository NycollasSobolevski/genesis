using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestArea.Domain.Models;

namespace TestArea.Core.Mapping;

public class TestClassMap : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK____Test");

        builder.ToTable("test");

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.Code)
            .HasMaxLength(25)
            .HasColumnName("code");

        builder.Property(e => e.Title)
            .HasMaxLength(255)
            .HasColumnName("title");

        builder.Property(e => e.Description)
            .HasColumnName("description");

        builder.Property(e => e.Attempts)
            .HasColumnName("attempts");

        builder.Property(e => e.Question)
            .HasColumnName("question");

        builder.Property(e => e.Answer)
            .HasColumnName("answer");

        builder.Property(e => e.IsActive)
            .HasColumnName("is_active");

        builder.Property(e => e.Errors)
            .HasColumnName("errors");

    }
}


