using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DmlStarterkit.Domain.Entities;

namespace DmlStarterkit.Persistance.Configurations
{
    public class UserRoleVEntityConfiguration : IEntityTypeConfiguration<UserRoleVEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleVEntity> builder)
        {
            builder.ToTable("vuserclaims");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserId).IsRequired();
            builder.Property(u => u.ClaimId).IsRequired();
            builder.Property(r => r.OperationName).IsRequired().HasMaxLength(50);

        }
    }
}
