using KeyIdeasTest.Constants.DALConstants;
using KeyIdeasTest.DAL.ModelConfigurations.UserManagement;
using KeyIdeasTest.DAL.Models.UserManagement;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KeyIdeasTest.DAL
{
    public class KeyIdeasTestDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {
        public KeyIdeasTestDBContext(DbContextOptions<KeyIdeasTestDBContext> options, IConfiguration configuration) : base(options: options)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"],
                    sqlServer => sqlServer.MigrationsHistoryTable(DataBaseConstant.MigrationTable, DataBaseConstant.MigrationSchema));
            }
        }

        //============UserManagement==========//
        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public virtual DbSet<ApplicationRoleClaim> ApplicationRoleClaims { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<ApplicationUserClaim> ApplicationUserClaims { get; set; }
        public virtual DbSet<ApplicationUserLogin> ApplicationUserLogins { get; set; }
        public virtual DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public virtual DbSet<ApplicationUserToken> ApplicationUserTokens { get; set; }
        //====================================//

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //===========UserManagement===========//
            builder.ApplyConfiguration(new ApplicationRoleClaimConfiguration());
            builder.ApplyConfiguration(new ApplicationRoleConfiguration());
            builder.ApplyConfiguration(new ApplicationUserClaimConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ApplicationUserLoginConfiguration());
            builder.ApplyConfiguration(new ApplicationUserRoleConfiguration());
            builder.ApplyConfiguration(new ApplicationUserTokenConfiguration());
            //====================================//
        }
    }
}
