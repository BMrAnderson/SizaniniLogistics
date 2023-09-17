using Microsoft.Extensions.DependencyInjection;
using SizananiLogistics.Application.Implementation;

namespace SizananiLogistics.Application.Extensions
{
    public static class DependencyRegistration
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            return services
                .AddTransient<IContractorService, ContractorService>()
                .AddTransient<IVehicleService, VehicleService>()
                .AddTransient<IVehicleContractorSummaryService, VehicleContractorSummaryService>();
        }

    }
}
