using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OELS.Core.Models;
using OELS.Repository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OELS.Repository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.FullName)
                .HasMaxLength(100)
                .HasDefaultValue(UtilsFunction.GenerateDefaultName())
                .IsRequired();
            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();
            builder.HasIndex(u => u.Email)
                .IsUnique();
            builder.Property(u => u.Password_Hash)
                .HasMaxLength (255)
                .IsRequired();
            builder.Property(u => u.Role)
                .HasMaxLength(10)
                .IsRequired()
                .HasConversion<int>();
            builder.Property(u => u.Avatar_Url)
                .HasMaxLength(255);
            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedAt);
        }
    }
}
