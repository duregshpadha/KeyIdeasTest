using KeyIdeasTest.Constants.DALConstants;
using KeyIdeasTest.DAL.Models.UserManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyIdeasTest.DAL.ModelConfigurations.UserManagement
{
    class ApplicationUserLoginConfiguration : IEntityTypeConfiguration<ApplicationUserLogin>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
        {
            builder.ToTable(nameof(ApplicationUserLogin), SchemaConstant.UserManagement);
        }
    }
}
