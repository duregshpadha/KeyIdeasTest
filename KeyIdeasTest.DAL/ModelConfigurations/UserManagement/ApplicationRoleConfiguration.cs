using KeyIdeasTest.Constants.DALConstants;
using KeyIdeasTest.DAL.DataSead.UserManagementSeed;
using KeyIdeasTest.DAL.Models.UserManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace KeyIdeasTest.DAL.ModelConfigurations.UserManagement
{
    class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable(nameof(ApplicationRole), SchemaConstant.UserManagement);

            ApplicationRoleData.Seed(builder);
        }
    }
}
