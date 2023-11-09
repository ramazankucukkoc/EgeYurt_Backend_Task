using EgeYurt_Backend_Task.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgeYurt_Backend_Task.DataAccess.EntityConfigurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims").HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("Id");
            builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(o => o.Name).HasColumnName("Name");
            builder.Property(u => u.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.HasIndex(o => o.Name, "UK_OperationClaims_Name").IsUnique();

            OperationClaim[] operationClaims = { new(1, "Admin", DateTime.Now, DateTime.Now, false), new(2, "Kullanıcı", DateTime.Now, DateTime.Now, false) };
            builder.HasData(operationClaims);
        }
    }
}
