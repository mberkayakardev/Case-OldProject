using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityFramework.Concrete.Seeds
{
    public class ProductsSeedDatasa : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            List<Products> products = new(){
                new Products
                {
                     Id = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedUserId = null,
                    CreatedUserName = "Seed Data",
                    ModifiedUserId = null,
                     ModifiedUserName = "Seed Data",
                     ProductName = "Iphone 14",
                     ProductDescription = "128 gb lık versiyon",
                     ProductPrice =20000,
                     CategoryId = 1
                },
                new Products()
                {
                     Id = 2,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedUserId = null,
                    CreatedUserName = "Seed Data",
                    ModifiedUserId = null,
                     ModifiedUserName = "Seed Data",
                     ProductName = "Samsung S24 FE",
                     ProductDescription = "128 gb lık versiyon",
                     ProductPrice =15000,
                     CategoryId = 1

                },
                new Products()
                {
                    Id = 3,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedUserId = null,
                    CreatedUserName = "Seed Data",
                    ModifiedUserId = null,
                    ModifiedUserName = "Seed Data",
                    ProductName = "Monster Laptop",
                    ProductDescription = "Yazilimci Bilgisayarı",
                    ProductPrice =40000,
                    CategoryId = 2

                },
                new Products()
                {
                    Id = 4,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedUserId = null,
                    CreatedUserName = "Seed Data",
                    ModifiedUserId = null,
                    ModifiedUserName = "Seed Data",
                    ProductName = "ssd ",
                    ProductDescription = "500 Gb",
                    ProductPrice =1000,
                    CategoryId = 3

                },

            };

            builder.HasData(products);
        }
    }
}
