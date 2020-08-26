using Microsoft.Extensions.DependencyInjection;

namespace KeyIdeasTest.Utilities.DI
{
    public static class DependenciesUtilities
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            services.AddScoped<IGenerateID, GenerateID>();
        }
    }
}
