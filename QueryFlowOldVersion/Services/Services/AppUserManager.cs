using AutoMapper;
using Repositories.EntityFramework.Abstract;
using Services.Abstract;
using Services.Abstract.Base;

namespace Services.Services
{
    public class AppUserManager : BaseServices, IAppUserServices
    {
        public AppUserManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

    }
}
