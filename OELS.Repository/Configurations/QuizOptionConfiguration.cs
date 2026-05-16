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
    public class QuizOptionConfiguration : IEntityTypeConfiguration<QuizOption>
    {
        public void Configure(EntityTypeBuilder<QuizOption> builder)
        {
            builder.ToTable("quiz_options");
            builder.HasKey(qo => qo.Id);
            builder.Property(qo => qo.Id)
                .ValueGeneratedNever();

            builder.Property(qo => qo.OptionText)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(qo => qo.IsCorrect)
                .IsRequired();
            builder.Property(qo => qo.SortOrder)
                .IsRequired(false);

            builder.HasOne(qo => qo.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(qo => qo.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(qo => qo.Answers)
                .WithOne(a => a.SelectedOption)
                .HasForeignKey(a => a.SelectedOptionId);
        }
    }
}
