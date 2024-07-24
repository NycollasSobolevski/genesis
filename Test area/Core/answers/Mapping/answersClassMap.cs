using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestArea.Domain.Models;

namespace Test_area.Core.Mapping;

public class AnswersClassMap : IEntityTypeConfiguration<Answers>
{
    public void Configure(EntityTypeBuilder<Answers> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK____Answers");

        builder.ToTable("answers");

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.Student)
            .HasMaxLength(255)
            .HasColumnName("student");

        builder.Property(e => e.Answer)
            .HasColumnName("answer");

        builder.Property(e => e.Attempts)
            .HasColumnName("attempts");

        builder.Property(e => e.Time)
            .HasColumnName("time");

        builder.Property(e => e.IdTest)
            .HasColumnName("id_test");

        builder.Property(e => e.IsActive)
            .HasColumnName("is_active");

        builder.Property(e => e.Grade)
            .HasColumnName("grade");

    }
}


