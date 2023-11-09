using EgeYurt_Backend_Task.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgeYurt_Backend_Task.DataAccess.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").HasKey(uo => uo.Id);
            builder.Property(uo => uo.Id).HasColumnName("Id");
            builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(uo => uo.UserId).HasColumnName("UserId");
            builder.Property(u => u.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(uo => uo.OperationClaimId).HasColumnName("OperationClaimId");
            builder.HasIndex(uo => new { uo.UserId, uo.OperationClaimId }, "UK_UserOperationClaims_UserId_OperationClaimId").IsUnique();
            builder.HasOne(uo => uo.User);
            builder.HasOne(uo => uo.OperationClaim);
        }
    }
}
