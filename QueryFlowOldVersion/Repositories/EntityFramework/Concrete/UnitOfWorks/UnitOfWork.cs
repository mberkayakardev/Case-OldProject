using Core.Repositories.EntityFramework.Abstract;
using Core.Repositories.EntityFramework.Concrete;
using Repositories.EntityFramework.Abstract;
using Repositories.EntityFramework.Concrete.Contexts;
using Repositories.EntityFramework.Concrete.Repositories;

namespace Repositories.EntityFramework.Concrete.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _quizContext;

        #region Costume Repositories
        public IAppUserRepositories AppUserRepositories => new EfAppUserRepositories(_quizContext);
        #endregion

        public UnitOfWork(AppDbContext quizContext)
        {
            _quizContext = quizContext;
        }


        public int SaveChanges()
        {
            return _quizContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _quizContext.SaveChangesAsync();
        }

        IEfGenericRepositories<T> IUnitOfWork.GetGenericRepositories<T>()
        {
            return new EfGenericRepositories<T>(_quizContext);
        }
    }
}
