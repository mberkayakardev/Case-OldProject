using ApiService.Entities.Concrete.AppEntities;
using Core.Repositories.EntityFramework.Concrete;
using Microsoft.EntityFrameworkCore;
using QuizApp.Repositories.EntityFramework.Abstract;
using QuizApp.Repositories.EntityFramework.Concrete.Contexts;

namespace QuizApp.Repositories.EntityFramework.Concrete.Repositories
{
    public class EfAppUserRepositories : EfGenericRepositories<AppUser>, IAppUserRepositories
    {
        public EfAppUserRepositories(AppDbContext context) : base(context)
        {

        }

        public async Task<AppUser> GetAppUserInformationAllById(int id)
        {
            var dbcontext = _Context as AppDbContext;

            var user = await dbcontext.AppUsers
                             .Where(x => x.Id == id)
                             .Include(x => x.UserToken)
                             .Include(x => x.AppUserClaims)
                             .ThenInclude(uc => uc.AppClaim)
                             .Include(x => x.AppUserRoles)
                             .ThenInclude(ur => ur.Role)
                             .ThenInclude(r => r.AppRoleClaims)
                             .ThenInclude(rc => rc.AppClaims)
                             .Include(x => x.AppUserRoles)
                             .ThenInclude(ur => ur.Role)
                             .ThenInclude(r => r.AppUserRoles)
                             .FirstOrDefaultAsync();

            return user;
        }
    }
}
