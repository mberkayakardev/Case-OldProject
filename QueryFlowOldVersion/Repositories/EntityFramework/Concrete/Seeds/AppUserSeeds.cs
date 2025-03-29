using ApiService.Entities.Concrete.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrendMusic.ECommerce.Core.Utilities.Security.HashHelper;

namespace Repositories.EntityFramework.Concrete.Seeds
{
    public class AppUserSeeds : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            List<AppUser> UserList = new()
            {
                new()
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
                    UserEmail = "m.berkay.akar@gmail.com",
                    EmailConfirmed = true,
                    UserPassword = HashHelper.CreateSha256Hash("123"),
                    UserFullName = "Berkay Akar",
                    IsBlocked = false,
                    FalseEntryCount = 0,
                },
                
                new()
                {
                    Id = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedUserId = null,
                    CreatedUserName = "Seed Data",
                    ModifiedUserId = null,
                    ModifiedUserName = "Seed Data",
                    UserName = "furkanaltintas",
                    UserPassword=HashHelper.CreateSha256Hash("123"),
                    UserEmail = "f.altintas@gmail.com",
                    EmailConfirmed = true,
                    UserFullName = "Berkay Akar",
                    IsBlocked = false,
                    FalseEntryCount = 0,
                },


            };


            builder.HasData(UserList);
        }
    }
}
