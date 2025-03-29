using Core.Entities.Concrete.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityFramework.Concrete.EntityConfigurations.AppEntities
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasMany(x=> x.AppUserRoles).WithOne(x=> x.Role).HasForeignKey(x=>x.RoleId);

            builder.HasMany(x=> x.AppRoleClaims).WithOne(x=> x.AppRoles).HasForeignKey(x=>x.RoleId);
        }
    }
}
