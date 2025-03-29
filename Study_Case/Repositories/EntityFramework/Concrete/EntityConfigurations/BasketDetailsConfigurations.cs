using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace Repositories.EntityFramework.Concrete.EntityConfigurations
{
    public class BasketDetailsConfigurations : IEntityTypeConfiguration<BasketDetail>
    {
        public void Configure(EntityTypeBuilder<BasketDetail> builder)
        {
            builder.HasOne(x=> x.Basket).WithMany(x=> x.BasketDetails).HasForeignKey(x=>x.BasketId);

            builder.HasOne(x=> x.Products).WithOne(x=> x.BasketDetail).HasForeignKey<BasketDetail>(x=> x.ProductId);
        }
    }
}
