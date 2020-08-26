using KeyIdeasTest.Constants.DALConstants;
using KeyIdeasTest.DAL.Models.UserManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyIdeasTest.DAL.ModelConfigurations.UserManagement
{
    class ApplicationRoleClaimConfiguration : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            builder.ToTable(nameof(ApplicationRoleClaim), SchemaConstant.UserManagement);
        }
    }
}
