using ApiService.Entities.Concrete.AppEntities;
using Core.Repositories.EntityFramework.Abstract;

namespace QuizApp.Repositories.EntityFramework.Abstract
{
    public interface IAppUserRepositories : IEfGenericRepositories<AppUser>
    {
        Task<AppUser> GetAppUserInformationAllById(int id);
    }
}
