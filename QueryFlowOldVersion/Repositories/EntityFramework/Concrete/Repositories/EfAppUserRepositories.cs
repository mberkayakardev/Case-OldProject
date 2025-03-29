using ApiService.Entities.Concrete.AppEntities;
using Core.Repositories.EntityFramework.Concrete;
using Repositories.EntityFramework.Abstract;
using Repositories.EntityFramework.Concrete.Contexts;

namespace Repositories.EntityFramework.Concrete.Repositories
{
    public class EfAppUserRepositories : EfGenericRepositories<AppUser>, IAppUserRepositories
    {
        public EfAppUserRepositories(AppDbContext context) : base(context)
        {

        }
    }
}
