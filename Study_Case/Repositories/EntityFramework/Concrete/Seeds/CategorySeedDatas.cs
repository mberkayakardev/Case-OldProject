using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityFramework.Concrete.Seeds
{
    public class CategorySeedDatas : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            List<Categories> categories = new() { 
            
                new Categories()
                {
                    Id = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedUserId = null,
                    CreatedUserName = "Seed Data",
                    ModifiedUserId = null,
                     ModifiedUserName = "Seed Data",
                     CategoryName = "Akıllı Telefon ",
                     CategoryDescription = "Akıllı Telefon kategorisi "
                },
                   new Categories()
                {
                    Id = 2,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedUserId = null,
                    CreatedUserName = "Seed Data",
                    ModifiedUserId = null,
                     ModifiedUserName = "Seed Data",
                     CategoryName = "Bilgisayar",
                     CategoryDescription = "Laptop ve Masaüstü Bilgisayarlar"
                }
,
               new Categories()
                {
                    Id = 3,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedUserId = null,
                    CreatedUserName = "Seed Data",
                    ModifiedUserId = null,
                     ModifiedUserName = "Seed Data",
                     CategoryName = "Bilgisayar bileşenleri ",
                     CategoryDescription = "Harici bilgisayar parçaları "
                }
            };


            builder.HasData(categories);


        }
    }
}
