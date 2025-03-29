using ApiService.Entities.Concrete.AppEntities;
using Core.Entities.Concrete.AppEntities;
using Entities.Concrete.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuizApp.Repositories.EntityFramework.Concrete.EntityConfigurations.AppEntities
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // User ile token arasındaki ilişki belirlendi 
            builder.HasOne(x => x.UserToken).WithOne(x => x.AppUser).HasForeignKey<AppToken>(x => x.AppUserId);

            builder.HasMany(x => x.AppUserClaims).WithOne(x => x.AppUser).HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.AppUserRoles).WithOne(x => x.AppUser).HasForeignKey(x => x.UserId);

        }
    }
}
