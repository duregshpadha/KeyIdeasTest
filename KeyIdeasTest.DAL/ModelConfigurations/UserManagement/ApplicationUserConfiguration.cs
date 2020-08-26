using KeyIdeasTest.Constants.DALConstants;
using KeyIdeasTest.DAL.Models.UserManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyIdeasTest.DAL.ModelConfigurations.UserManagement
{
    class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable(nameof(ApplicationUser), SchemaConstant.UserManagement);

            builder.Property(e => e.Id).HasMaxLength(MaxLengthConstant.ID).IsRequired();
            builder.Property(e => e.FirstName).HasMaxLength(MaxLengthConstant.ShortStringLenght).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(MaxLengthConstant.ShortStringLenght);

            builder.Ignore(e => e.Name);
        }
    }
}
