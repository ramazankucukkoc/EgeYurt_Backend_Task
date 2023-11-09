using EgeYurt_Backend_Task.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgeYurt_Backend_Task.DataAccess.EntityConfigurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens").HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("Id");
            builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(r => r.UserId).HasColumnName("UserId");
            builder.Property(r => r.Token).HasColumnName("Token");
            builder.Property(r => r.Expires).HasColumnName("Expires");
            builder.Property(u => u.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            builder.HasOne(r => r.User);
        }
    }
}
