using Core.Entities.Concrete.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityFramework.Concrete.Seeds.AppEntities
{
    public class AppUserRoleSeeds : IEntityTypeConfiguration<AppUserRoles>
    {
        public void Configure(EntityTypeBuilder<AppUserRoles> builder)
        {

            builder.HasData(new AppUserRoles
            {
                Id = 1,
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedUserId = null,
                CreatedUserName = "Seed Data",
                ModifiedUserId = null,
                UserId = 1,
                RoleId = 2,



            },
            new AppUserRoles
            {
                Id = 2,
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedUserId = null,
                CreatedUserName = "Seed Data",
                ModifiedUserId = null,
                UserId = 2,
                RoleId = 1,

            });
        }
    }
}
