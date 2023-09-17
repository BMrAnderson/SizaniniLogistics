using Microsoft.Extensions.DependencyInjection;
using SizananiLogistics.Infrastructure.Constants;
using SizananiLogistics.Infrastructure.Implementation;

namespace SizananiLogistics.Infrastructure.Extensions
{
    public static class DependencyRegistration
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            return services
                .AddTransient<IContractorRepository>(_ =>
                {
                    return new SqlContractorRepository(InfrastructureConstants.Database.ConnectionString);
                })
                .AddTransient<IVehicleRepository>(_ =>
                {
                    return new SqlVehicleRepository(InfrastructureConstants.Database.ConnectionString);
                })
                .AddTransient<IVehicleContractorSummaryRepository>(_ =>
                {
                    return new SqlVehicleContractorSummaryRepository(InfrastructureConstants.Database.ConnectionString);
                });
        }
    }
}
