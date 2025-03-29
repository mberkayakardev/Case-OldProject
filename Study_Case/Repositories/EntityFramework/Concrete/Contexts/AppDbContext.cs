using ApiService.Entities.Concrete.AppEntities;
using Core.Entities.Abstract;
using Core.Entities.Concrete.AppEntities;
using Entities.Concrete;
using Entities.Concrete.AppEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;
using System.Security.Claims;

namespace QuizApp.Repositories.EntityFramework.Concrete.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AppDbContext(DbContextOptions<AppDbContext> opt, IHttpContextAccessor httpContextAccessor) : base(opt)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

        }

        #region DbSets
        public DbSet<AppClaim> AppClaims { get; set; }  
        public DbSet<AppMenus> AppMenus { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppRoleClaim> AppRoleClaims { get; set; }
        public DbSet<AppToken> AppTokens { get; set; }  
        public DbSet<AppUser> AppUsers { get; set; }    
        public DbSet<AppUserClaims> AppUserClaims { get; set; }
        public DbSet<AppUserRoles> AppUserRoles { get; set; }


        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }


        public DbSet<Basket> Baskets{ get; set; }
        public DbSet<BasketDetail> BasketDetails{ get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }

        public override int SaveChanges()
        {
            ApplyAuditingRules();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditingRules();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess,cancellationToken);

        }



        private void ApplyAuditingRules()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userIdClaim = user?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var userName = user?.Identity?.Name;



            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.ModifiedDate = DateTime.Now;
                    entry.Entity.CreatedUserId = (userIdClaim != null ? Convert.ToInt32(userIdClaim.Value) : null);
                    entry.Entity.ModifiedUserId = (userIdClaim != null ? Convert.ToInt32(userIdClaim.Value) : null);
                    entry.Entity.CreatedUserName = (!string.IsNullOrEmpty(userName) ? userName : string.Empty);
                    entry.Entity.ModifiedUserName = (!string.IsNullOrEmpty(userName) ? userName : string.Empty);


                }
                if (entry.State == EntityState.Modified)
                {

                    entry.Property("CreatedDate").IsModified = false;
                    entry.Property("CreatedUserName").IsModified = false;

                    entry.Entity.ModifiedDate = DateTime.Now;
                    entry.Entity.ModifiedUserName = (!string.IsNullOrEmpty(userName) ? userName : string.Empty);
                    entry.Entity.ModifiedUserId = (userIdClaim != null ? Convert.ToInt32(userIdClaim.Value) : null);


                }
            }
        }

    }
}
