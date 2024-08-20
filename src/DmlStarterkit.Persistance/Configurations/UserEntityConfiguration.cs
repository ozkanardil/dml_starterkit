using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DmlStarterkit.Domain.Entities;

namespace DmlStarterkit.Persistance.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Property(u => u.NickName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.PasswordSalt).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.RecoveryCode).IsRequired();
            builder.Property(u => u.Status).IsRequired();
            builder.Property(u => u.RefreshTokenA);
            builder.Property(u => u.RefreshTokenExpr);
        }
    }
}
