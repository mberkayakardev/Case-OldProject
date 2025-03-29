using Entities.Concrete.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityFramework.Concrete.EntityConfigurations.AppEntities
{
    public class AppClaimConfigurations : IEntityTypeConfiguration<AppClaim>
    {
        public void Configure(EntityTypeBuilder<AppClaim> builder)
        {
            builder.HasMany(x=> x.AppUserClaims).WithOne(x=> x.AppClaim).HasForeignKey(x=>x.ClaimId);

            builder.HasMany(x => x.AppRoleClaims).WithOne(x => x.AppClaims).HasForeignKey(x => x.ClaimId);

            builder.HasMany(x => x.AppMenus).WithOne(x => x.AppClaim).HasForeignKey(x => x.ClaimId);


              

        }
    }
}
