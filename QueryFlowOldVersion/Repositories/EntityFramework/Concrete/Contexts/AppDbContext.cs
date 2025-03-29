﻿using ApiService.Entities.Concrete.AppEntities;
using Core.Entities.Abstract;
using Core.Entities.Concrete.AppEntities;
using Entities.Concrete;
using Entities.Concrete.AppEntities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repositories.EntityFramework.Concrete.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        #region DbSets

        #region AppEntities
        public DbSet<AppApplications> AppApplications { get; set; }
        public DbSet<AppClaim> AppClaims { get; set; }
        public DbSet<AppMenus> AppMenus { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppRoleClaim> AppRoleClaims { get; set; }
        public DbSet<AppToken> AppTokens { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserClaims> AppUserClaims { get; set; }
        public DbSet<AppUserRoles> AppUserRoles { get; set; }
        #endregion

        #region SurveyEntities
        public DbSet<MVCMenus> MVCMenus { get; set; }
        public DbSet<QuestionAnswers> QuestionAnswers { get; set; }
        public DbSet<QuestionsMedias> QuestionsMedias { get; set; }
        public DbSet<QuestionTypes> QuestionTypes { get; set; }
        public DbSet<SurveyCards> SurveyCards { get; set; }
        public DbSet<SurveyQuestions> SurveyQuestions { get; set; }
        public DbSet<SurveysForUser> SurveysForUser { get; set; }

        #endregion

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
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditingRules()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.ModifiedDate = DateTime.UtcNow;

                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedDate").IsModified = false;
                    entry.Entity.ModifiedDate = DateTime.UtcNow;
                }
            }
        }


    }
}
