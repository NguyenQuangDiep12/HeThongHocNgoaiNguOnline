using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OELS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OELS.Repository.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("languages");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id)
                .ValueGeneratedNever();

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(l => l.Code)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(l => new {l.Name, l.Code});
            builder.HasMany(l => l.Courses)
                .WithOne(c => c.Language)
                .HasForeignKey(c => c.LanguageId);
        }
    }
}
