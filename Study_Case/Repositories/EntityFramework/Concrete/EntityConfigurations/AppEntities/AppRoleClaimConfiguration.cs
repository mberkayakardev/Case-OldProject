using Core.Entities.Concrete.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityFramework.Concrete.EntityConfigurations.AppEntities
{
    public class AppRoleClaimConfiguration : IEntityTypeConfiguration<AppRoleClaim>
    {
        public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            builder.HasOne(x=> x.AppRoles).WithMany(x=>x.AppRoleClaims).HasForeignKey(x=>x.RoleId);

            builder.HasOne(x => x.AppClaims).WithMany(x => x.AppRoleClaims).HasForeignKey(x => x.ClaimId);

        }
    }
}
