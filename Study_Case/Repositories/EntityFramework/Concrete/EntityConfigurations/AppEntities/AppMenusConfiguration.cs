using Core.Entities.Concrete.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityFramework.Concrete.EntityConfigurations.AppEntities
{
    public class AppMenusConfiguration : IEntityTypeConfiguration<AppMenus>
    {
        public void Configure(EntityTypeBuilder<AppMenus> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
