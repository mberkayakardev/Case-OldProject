using ApiService.Entities.Concrete.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrendMusic.ECommerce.Core.Utilities.Security.HashHelper;

namespace Repositories.EntityFramework.Concrete.Seeds.AppEntities
{
    public class AppUserSeeds : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            List<AppUser> Users = new List<AppUser>
            {
                new AppUser
                {
                       Id = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedUserId = null,
                    CreatedUserName = "Seed Data",
                    ModifiedUserId = null,
                     ModifiedUserName = "Seed Data",
                     UserName = "berkayakar",
                     UserEmail = "berkayakar@gmail.com",
                     EmailConfirmed = true,
                     UserFullName = "Berkay AKAR",
                     UserPassword = HashHelper.CreateSha256Hash("123"),
                     IsBlocked = false,
                     FalseEntryCount = 0,
                },
                         new AppUser
                {
                       Id = 2,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedUserId = null,
                    CreatedUserName = "Seed Data",
                    ModifiedUserId = null,
                     ModifiedUserName = "Seed Data",
                     UserName = "alturadmin",
                     UserEmail = "alturadmin@gmail.com",
                     EmailConfirmed = true,
                     UserFullName = "Altur Admin ",
                     UserPassword = HashHelper.CreateSha256Hash("123"),
                     IsBlocked = false,
                     FalseEntryCount = 0,
                }
            };

            builder.HasData(Users);
        }
    }
}
