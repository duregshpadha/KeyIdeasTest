using KeyIdeasTest.DAL.Models.UserManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace KeyIdeasTest.DAL.DataSead.UserManagementSeed
{
    class ApplicationRoleData
    {
        internal static EntityTypeBuilder<ApplicationRole> Seed(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(new ApplicationRole[]
            {
                new ApplicationRole()
                {
                    Id="01062020-122757000-cf779961-09c1-4fbe-8f8d",
                    Name="user",
                    NormalizedName="USER",
                    ConcurrencyStamp=Guid.NewGuid().ToString()
                }
            });

            return builder;
        }
    }
}
