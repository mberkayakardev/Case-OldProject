using ApiService.Entities.Concrete.AppEntities;
using Core.Repositories.EntityFramework.Abstract;

namespace Repositories.EntityFramework.Abstract
{
    public interface IAppUserRepositories : IEfGenericRepositories<AppUser>
    {
    }
}
