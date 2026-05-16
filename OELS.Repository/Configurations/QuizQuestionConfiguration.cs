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
    public class QuizQuestionConfiguration : IEntityTypeConfiguration<QuizQuestion>
    {
        public void Configure(EntityTypeBuilder<QuizQuestion> builder)
        {
            builder.ToTable("quiz_questions");
            builder.HasKey(qq => qq.Id);
            builder.Property(qq => qq.Id)
                .ValueGeneratedNever();

            builder.Property(qq => qq.Question)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(qq => qq.QuestionType)
                .IsRequired()
                .HasConversion<int>();
            builder.Property(qq => qq.Point)
                .IsRequired(false);

            builder.HasMany(qq => qq.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);
            builder.HasMany(qq => qq.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o =>  o.QuestionId);
            builder.HasOne(qq => qq.Quiz)
                .WithMany(q => q.Questions)
                .HasForeignKey(qq => qq.QuizId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
