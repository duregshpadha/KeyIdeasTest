using KeyIdeasTest.Constants.DALConstants;
using KeyIdeasTest.DAL.Models.UserManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyIdeasTest.DAL.ModelConfigurations.UserManagement
{
    class ApplicationUserClaimConfiguration : IEntityTypeConfiguration<ApplicationUserClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
        {
            builder.ToTable(nameof(ApplicationUserClaim), SchemaConstant.UserManagement);
        }
    }
}
