using KeyIdeasTest.Constants.DALConstants;
using KeyIdeasTest.DAL.Models.UserManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace KeyIdeasTest.DAL.ModelConfigurations.UserManagement
{
    class ApplicationUserTokenConfiguration : IEntityTypeConfiguration<ApplicationUserToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
        {
            builder.ToTable(nameof(ApplicationUserToken), SchemaConstant.UserManagement);
        }
    }
}
